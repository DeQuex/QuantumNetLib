namespace QuantumNetLib
{
    public class Exception
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }

        public Exception(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public override string ToString()
        {
            return $"Error code: {ErrorCode}\nMessage: {Message}";
        }

    }
}