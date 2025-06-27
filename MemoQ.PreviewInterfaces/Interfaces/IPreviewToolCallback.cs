using MemoQ.PreviewInterfaces.Entities;

namespace MemoQ.PreviewInterfaces.Interfaces
{
    public interface IPreviewToolCallback
    {
        void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest);
        void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest);
        void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest);
        void HandleDisconnect();
    }
}
