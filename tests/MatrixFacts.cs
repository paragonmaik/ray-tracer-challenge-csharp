using Xunit;

public class MatrixFacts
{
  public class Matrices
  {
    [Fact]
    public void ValidateMatrixInstantiation()
    {
      int size = 4;
      double randomVal = 0.4f;
      Matrix mat4 = new(size);

      mat4[0, 3] = randomVal;

      Assert.Equal(mat4.GetSize(), size);
      Assert.Equal(mat4[0, 3], randomVal);
    }
  }
}
