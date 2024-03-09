namespace QuantumNetLib
{
    public class Exception
    {
        public Exception(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public string Message { get; set; }
        public int ErrorCode { get; set; }

        public override string ToString()
        {
            return $"Error code: {ErrorCode}\nMessage: {Message}";
        }
    }
}