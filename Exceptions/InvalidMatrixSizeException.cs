public class InvalidMatrixSizeException : Exception
{
  public InvalidMatrixSizeException() { }

  public InvalidMatrixSizeException(string Message)
    : base(Message) { }

  public InvalidMatrixSizeException(
    string Message,
    Exception inner
  )
    : base(Message, inner) { }
}
