namespace WolfEmails.Classess
{
    public enum FlashMessageType
    {
        Info,
        Success,
        Warning,
        Error
    }
    
    
    public class FlashMessage
    {
        public string Message { get; set; }
        public FlashMessageType MessageType { get; set; }

        public FlashMessage(string message, FlashMessageType type) 
        {
            Message = message;
            MessageType = type;
        }
    }
}
