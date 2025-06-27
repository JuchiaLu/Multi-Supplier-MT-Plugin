namespace MemoQ.PreviewInterfaces.Entities
{
    public class RequestStatus
    {
        /// <summary>
        /// Gets whether the request was accepted.
        /// </summary>
        public readonly bool RequestAccepted;

        /// <summary>
        /// The cause if the request has been refused.
        /// </summary>
        public readonly ErrorCodes? ErrorCode;

        /// <summary>
        /// The error message describing the problem.
        /// </summary>
        public readonly string ErrorMessage;

        private RequestStatus(bool requestAccepted, ErrorCodes? errorCode, string errorMessage)
        {
            RequestAccepted = requestAccepted;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public static RequestStatus Success()
        {
            return new RequestStatus(true, null, null);
        }

        public static RequestStatus Failed(ErrorCodes errorCode, string errorMessage)
        {
            return new RequestStatus(false, errorCode, errorMessage);
        }
    }
}
