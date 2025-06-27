using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces
{
    internal class CallbackHandler
    {
        private readonly IPreviewToolCallback previewToolCallback;
        private readonly Queue<Action> callbackActions;
        private readonly AutoResetEvent callbackEnqueued;
        private readonly AutoResetEvent stopExecution;

        private volatile bool executionThreadRunning;
        private Thread workerThread;

        public CallbackHandler(IPreviewToolCallback previewToolCallback)
        {
            this.previewToolCallback = previewToolCallback;

            callbackActions = new Queue<Action>();
            callbackEnqueued = new AutoResetEvent(false);
            stopExecution = new AutoResetEvent(false);
            Task.Factory.StartNew(performCallbacks);
        }

        public void QueueContentUpdateRequest(ContentUpdateRequestFromMQ request)
        {
            lock (this)
            {
                callbackActions.Enqueue(() => previewToolCallback.HandleContentUpdateRequest(request));
                callbackEnqueued.Set();
            }
        }

        public void QueueChangeHighlightRequest(ChangeHighlightRequestFromMQ request)
        {
            lock (this)
            {
                callbackActions.Enqueue(() => previewToolCallback.HandleChangeHighlightRequest(request));
                callbackEnqueued.Set();
            }
        }

        public void QueuePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ request)
        {
            lock (this)
            {
                callbackActions.Enqueue(() => previewToolCallback.HandlePreviewPartIdUpdateRequest(request));
                callbackEnqueued.Set();
            }
        }

        public void QueueDisconnectRequest()
        {
            lock (this)
            {
                callbackActions.Clear();
                callbackActions.Enqueue(() => previewToolCallback.HandleDisconnect());
                callbackEnqueued.Set();
            }
        }

        public void Stop()
        {
            stopExecution.Set();

            if (executionThreadRunning)
            {
                // wait 3x200 ms for the completion
                int i = 0;
                while (i++ < 3)
                {
                    // return if there is no operation in progress
                    if (!executionThreadRunning)
                        return;

                    // sleep 200 ms if there is an operation in progress
                    Thread.Sleep(200);
                }

                // abort the worker thread if there is a running operation
                if (i > 3)
                {
                    try
                    {
                        if (workerThread != null)
                            workerThread.Abort();
                    }
                    catch { /* swallow the exception */ }
                }
            }
        }

        private void performCallbacks()
        {
            try
            {
                executionThreadRunning = true;
                workerThread = Thread.CurrentThread;

                EventWaitHandle[] waitHandles = { stopExecution, callbackEnqueued };

                while (true)
                {
                    var currentWaitHandle = waitHandles[WaitHandle.WaitAny(waitHandles)];

                    // stop the execution is a stop signal arrived
                    if (currentWaitHandle == stopExecution)
                        return;

                    while (true)
                    {
                        Action callbackAction = null;
                        lock (this)
                        {
                            if (callbackActions.Any())
                                callbackAction = callbackActions.Dequeue();
                            else
                                break;
                        }

                        callbackAction?.Invoke();
                    }
                }
            }
            finally
            {
                executionThreadRunning = false;
            }
        }
    }
}
