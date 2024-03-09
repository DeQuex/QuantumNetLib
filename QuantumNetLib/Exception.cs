using System;

namespace QuantumNetLib
{
    public class Exception : System.Exception
    {
        public Exception(string message)
        {
            Message = message;
        }

        public Exception(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public Exception(string message, Exception innerException)
        {
            Message = message;
            InnerException = innerException;
        }

        public Exception(string message, int errorCode, Exception innerException)
        {
            Message = message;
            ErrorCode = errorCode;
            InnerException = innerException;
        }

        public string Message { get; }
        public int ErrorCode { get; }
        public Exception InnerException { get; }

        public virtual string StackTrace => Environment.StackTrace;

        public override string ToString()
        {
            var message = Message;
            if (ErrorCode != 0)
                message += $"\nError Code: {ErrorCode}";
            if (InnerException != null)
                message += $"\nInner Exception: {InnerException}";
            return message;
        }
    }

    public class ArgumentException : Exception
    {
        public ArgumentException(string message) : base(message) { }
        public ArgumentException(string message, string innerException) : base(message, innerException) { }
    }

    public class ArgumentNullException : ArgumentException
    {
        public ArgumentNullException(string paramName) : base($"Argument '{paramName}' cannot be null.") { }
    }

    public class ArgumentOutOfRangeException : ArgumentException
    {
        public ArgumentOutOfRangeException(string paramName) : base($"Argument '{paramName}' is out of range.") { }
    }

    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string message) : base(message) { }
        public InvalidOperationException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class IndexOutOfRangeException : Exception
    {
        public IndexOutOfRangeException(string message = "Index is out of range.") : base(message) { }
    }
}