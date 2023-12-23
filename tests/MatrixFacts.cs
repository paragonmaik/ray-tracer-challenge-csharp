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
      { 0, 0, 0, 0 }
      };
      Matrix mat = new(arr);

      Action act = () => mat.Inverse();
      NonInvertibleMatrixException exception = Assert
        .Throws<NonInvertibleMatrixException>(act);

      Assert.Equal(
          "Determinant equals 0, Matrix cannot be inverted",
          exception.Message);
    }

    [Fact]
    public void ValidateInverseMatrix1()
    {
      double[,] matValues = {
       { 8, -5, 9, 2 },
       { 7, 5, 6, 1 },
       { -6, 0, 9, 6 },
       { -3, 0, -9, -4 }
      };
      double[,] inverseMatValues = {
       { -0.15385, -0.15385, -0.28205, -0.53846 },
       { -0.07692, 0.12308, 0.02564, 0.03077 },
       { 0.35897, 0.35897, 0.43590, 0.92308 },
       { -0.69231, -0.69231, -0.76923, -1.92308 }
      };
      Matrix mat = new(matValues);
      Matrix expectedInverseMat = new(inverseMatValues);

      Matrix actualMat = mat.Inverse();

      Assert.Equal(expectedInverseMat, actualMat);
    }

    [Fact]
    public void ValidateInverseMatrix2()
    {
      double[,] matValues = {
      { 9 , 3 , 0 , 9 },
      { -5 , -2 , -6 , -3 },
      { -4 , 9 , 6 , 4 },
      { -7 , 6 , 6 , 2 }
      };
      double[,] inverseMatValues = {
        { -0.04074 , -0.07778 , 0.14444 , -0.22222 },
        { -0.07778 , 0.03333 , 0.36667 , -0.33333 },
        { -0.02901 , -0.14630 , -0.10926 , 0.12963 },
        { 0.17778 , 0.06667 , -0.26667 , 0.33333 }
      };
      Matrix mat = new(matValues);
      Matrix expectedInverseMat = new(inverseMatValues);

      Matrix actualMat = mat.Inverse();

      Assert.Equal(expectedInverseMat, actualMat);
    }

    [Fact]
    public void ValidateInverseMatrixMultiplication()
    {
      double[,] a = {
        { 3 , -9 , 7 , 3 },
        { 3 , -8 , 2 , -9 },
        { -4 , 4 , 4 , 1 },
        { -6 , 5 , -1 , 1 }
      };
      double[,] b = {
        { 8 , 2 , 2 , 2 },
        { 3 , -1 , 7 , 0 },
        { 7 , 0 , 5 , 4 },
        { 6 , -2 , 0 , 5 }
      };

      Matrix matrixA = new(a);
      Matrix matrixB = new(b);

      Matrix matrixC = matrixA * matrixB;
      Matrix expectedMatrix = matrixC * matrixB.Inverse();

      Assert.Equal(expectedMatrix, matrixA);
    }
  }

  [Fact]
  public void ValidateMultiplyTranslationMatrixByPoint()
  {
    Matrix mat = new(4);
    Point expectedPoint = new(2, 1, 7, 1);

    Matrix mat2 = mat.Translate(5f, -3f, 2f);
    Point point = new(-3, 4, 5);
    Point actualPoint = mat2 * point;

    Assert.Equivalent(expectedPoint, actualPoint);
  }

  [Fact]
  public void ValidateMultiplyTranslationMatrixInverseByPoint()
  {
    Matrix mat = new(4);
    Point expectedPoint = new(-8, 7, 3, 1);

    Matrix mat2 = mat.Translate(5f, -3f, 2f).Inverse();
    Point point = new(-3, 4, 5);
    Point actualPoint = mat2 * point;

    Assert.Equivalent(expectedPoint, actualPoint);
  }

  [Fact]
  public void ValidateMultiplyTranslationMatrixByVector()
  {
    Matrix mat = new(4);
    Vector expectedVector = new(-3, 4, 5, 0);

    Matrix mat2 = mat.Translate(5f, -3f, 2f);
    Vector vector = new(-3, 4, 5);
    Vector actualVector = mat2 * vector;

    Assert.Equivalent(expectedVector, actualVector);
  }
}
