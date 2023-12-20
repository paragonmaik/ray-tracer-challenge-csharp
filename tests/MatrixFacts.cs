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

      Assert.Equal(expectedMatrix, multipliedMat);
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

      Assert.Equal(expectedMatrix, multipliedMat);
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

      Assert.Equal(expectedMatrix, multipliedMat);
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

      Assert.Equal(mat, expectedIdentity);
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

    [Fact]
    public void Validate2x2MatrixDeterminant()
    {
      double[,] arr5 = {
      {1, 5},
      {-3, 2}
      };
      double expectedDeterminant = 17;

      Matrix matD = new(arr5);
      double matDDeterminant = matD.Determinant();

      Assert.Equal(expectedDeterminant, matDDeterminant);
    }

    [Fact]
    public void Validate3x3MatrixDeterminant()
    {
      double[,] arr = {
      { 1, 2, 6 },
      { -5, 8, -4 },
      { 2, 6, 4 },
      };

      double expectedDeterminant = -196;

      Matrix mat = new(arr);
      double matDeterminant = mat.Determinant();

      Assert.Equal(expectedDeterminant, matDeterminant);
    }

    [Fact]
    public void Validate4x4MatrixDeterminant()
    {
      double[,] arr = {
      { -2, -8, 3, 5 },
      { -3, 1, 7, 3 },
      { 1, 2, -9, 6 },
      { -6, 7, 7, -9 }
      };
      double expectedDeterminant = -4071;

      Matrix mat = new(arr);
      double matDeterminant = mat.Determinant();

      Assert.Equal(expectedDeterminant, matDeterminant);
    }

    [Fact]
    public void Validate3x3Submatrix()
    {
      double[,] arr1 = {
      { 1, 5, 0 },
      { -3, 2, 7 },
      { 0, 6, -3 }
      };

      double[,] arr2 = {
        { -3, 2 },
        { 0 , 6 }
      };
      Matrix expectedSubmatrix = new(arr2);

      Matrix mat = new(arr1);
      Matrix submatrix = mat.SubMatrix(0, 2);

      Assert.Equal(expectedSubmatrix, submatrix);
    }

    [Fact]
    public void Validate4x4Submatrix()
    {
      double[,] arr1 = {
      { -6, 1, 1, 6 },
      { -8, 5, 8, 6 },
      { -1, 0, 8, 2 },
      { -7, 1, -1, 1 }
      };

      double[,] arr2 = {
      { -6, 1, 6 },
      { -8, 8, 6 },
      { -7, -1, 1 }
      };

      Matrix expectedSubmatrix = new(arr2);

      Matrix mat = new(arr1);
      Matrix submatrix = mat.SubMatrix(2, 1);

      Assert.Equal(expectedSubmatrix, submatrix);
    }

    [Fact]
    public void Validate3x3MatrixMinor()
    {
      double[,] arr = {
      {0, 0, 0},
      {1, 5, 0},
      {-3, 2, 0}
      };
      double expectedMinor = 17;

      Matrix mat = new(arr);
      double matMinor = mat.Minor(0, 2);

      Assert.Equal(expectedMinor, matMinor);
    }

    [Fact]
    public void Validate3x3MatrixCofactor()
    {
      double[,] arr10 = {
      { 3, 5, 0 },
      { 2, -1, -7 },
      { 6, -1, 5 }
      };

      double expectedCofactor = -25;
      Matrix mat = new(arr10);

      double matCofactor = mat.Cofactor(1, 0);

      Assert.Equal(expectedCofactor, matCofactor);
    }

    [Fact]
    public void ValidateWhetherMatrixIsInvertible()
    {
      double[,] arr = {
      { -4, 2, -2, -3 },
      { 9, 6, 2, 6 },
      { 0, -5, 1, -5 },
      { 0, 0, 0, 1 }
      };
      Matrix mat = new(arr);

      Action act = () => mat.Inverse();
      NonInvertibleMatrixException exception = Assert
        .Throws<NonInvertibleMatrixException>(act);

      Assert.Equal(
          "Determinant equals 0, Matrix cannot be inverted",
          exception.Message);
    }
  }
}
