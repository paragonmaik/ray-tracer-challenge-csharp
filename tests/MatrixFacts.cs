using Xunit;

public class MatrixFacts
{
  public class Matrices
  {
    [Fact]
    public void ValidateMatrix4x4Instantiation()
    {
      int size = 4;
      double randomVal = 0.4f;
      Matrix mat4 = new(size);

      mat4[0, 3] = randomVal;

      Assert.Equal(mat4.GetSize(), size);
      Assert.Equal(mat4[0, 3], randomVal);
    }

    [Fact]
    public void ValidateMatrix3x3Instantiation()
    {
      int size = 3;
      double randomVal = 0.9f;
      Matrix mat3 = new(size);

      mat3[0, 2] = randomVal;

      Assert.Equal(mat3.GetSize(), size);
      Assert.Equal(mat3[0, 2], randomVal);
    }

    [Fact]
    public void ValidateMatrix2x2Instantiation()
    {
      int size = 2;
      double randomVal = 0.1f;
      Matrix mat2 = new(size);

      mat2[0, 1] = randomVal;

      Assert.Equal(mat2.GetSize(), size);
      Assert.Equal(mat2[0, 1], randomVal);
    }

    [Fact]
    public void Validate4x4MatrixMultiplication()
    {
      double[,] arr1 = {
        { 1, 1, 1, 1 },
        { 1, 1, 1, 1 },
        { 1, 1, 1, 1 },
        { 1, 1, 1, 1 }
      };

      double[,] arr2 = {
        { 3, 3, 3, 3 },
        { 3, 3, 3, 3 },
        { 3, 3, 3, 3 },
        { 3, 3, 3, 3 }
      };

      double[,] arr3 = {
        { 12, 12, 12, 12 },
        { 12, 12, 12, 12 },
        { 12, 12, 12, 12 },
        { 12, 12, 12, 12 }
      };

      Matrix matA = new(arr1);
      Matrix matB = new(arr2);
      Matrix expectedMatrix = new(arr3);

      Matrix multipliedMat = matA * matB;

      Assert.Equivalent(expectedMatrix[0, 0], multipliedMat[0, 0]);
    }

    [Fact]
    public void Validate3x3MatrixMultiplication()
    {
      double[,] arr1 = {
        { 1, 1, 1 },
        { 1, 1, 1 },
        { 1, 1, 1 }
      };

      double[,] arr2 = {
        { 3, 3, 3 },
        { 3, 3, 3 },
        { 3, 3, 3 }
      };

      double[,] arr3 = {
        { 9, 9, 9 },
        { 9, 9, 9 },
        { 9, 9, 9 }
      };

      Matrix matA = new(arr1);
      Matrix matB = new(arr2);
      Matrix expectedMatrix = new(arr3);

      Matrix multipliedMat = matA * matB;

      Assert.Equivalent(expectedMatrix[0, 0], multipliedMat[0, 0]);
    }

    [Fact]
    public void Validate2x2MatrixMultiplication()
    {
      double[,] arr1 = {
        { 1, 1 },
        { 1, 1 }
      };

      double[,] arr2 = {
        { 3, 3 },
        { 3, 3 }
      };

      double[,] arr3 = {
        { 6, 6 },
        { 6, 6 }
      };

      Matrix matA = new(arr1);
      Matrix matB = new(arr2);
      Matrix expectedMatrix = new(arr3);

      Matrix multipliedMat = matA * matB;

      Assert.Equivalent(expectedMatrix[0, 0], multipliedMat[0, 0]);
    }

    [Fact]
    public void ValidateMatrixMultipliedByTupl()
    {
      double[,] arr = {
      { -1, 4, 3, 5 },
      { 2, 6, 8, 6 },
      { 4, 8, 9, 6 },
      { 9, 5, 8, 7 }
      };
      Matrix mat = new(arr);
      Tupl tupl = new(2, 4, 1, 6);
      Tupl expected = new(47, 72, 85, 88);

      Tupl res = mat * tupl;

      Assert.Equivalent(expected, res);
    }
  }
}
