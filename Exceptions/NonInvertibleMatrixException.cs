public class NonInvertibleMatrixException : Exception
{
  public NonInvertibleMatrixException() { }

  public NonInvertibleMatrixException(string Message)
    : base(Message) { }

  public NonInvertibleMatrixException(
    string Message,
    Exception inner
  )
    : base(Message, inner) { }
}
