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

    [Fact]
    public void ValidateIdentityMatrix()
    {
      double[,] arr = {
      { -1, 4, 3, 5 },
      { 2, 6, 8, 6 },
      { 4, 8, 9, 6 },
      { 9, 5, 8, 7 }
      };
      double[,] identity = {
      { 1, 0, 0, 0 },
      { 0, 1, 0, 0 },
      { 0, 0, 1, 0 },
      { 0, 0, 0, 1 }
      };
      Matrix mat = new(arr);
      Matrix expectedIdentity = new(identity);

      mat.Identity();

      Assert.Equal(mat[0, 0], expectedIdentity[0, 0]);
      Assert.Equal(mat[1, 1], expectedIdentity[1, 1]);
      Assert.Equal(mat[2, 2], expectedIdentity[2, 2]);
      Assert.Equal(mat[3, 3], expectedIdentity[3, 3]);
    }

    [Fact]
    public void ValidateTransposeMatrix()
    {
      double[,] arr = {
      { 0, 9, 3, 0 },
      { 9, 8, 0, 8 },
      { 1, 8, 5, 3 },
      { 0, 0, 5, 8 }
    };
      double[,] transpose = {
      { 0, 9, 1, 0 },
      { 9, 8, 8, 0 },
      { 3, 0, 5, 4 },
      { 0, 8, 3, 8 }
      };
      Matrix mat = new(arr);
      Matrix expectedTransposedMatrix = new(transpose);

      mat.Transpose();

      Assert.Equal(mat[0, 0], expectedTransposedMatrix[0, 0]);
      Assert.Equal(mat[0, 1], expectedTransposedMatrix[0, 1]);
      Assert.Equal(mat[0, 2], expectedTransposedMatrix[0, 2]);
      Assert.Equal(mat[0, 3], expectedTransposedMatrix[0, 3]);
    }
  }
}