using Xunit;

public class VectorFacts
{
  public class Vectors
  {
    [Fact]
    public void VectorWReturnsZero()
    {
      float expectedW = 0f;

      Vector vector = new();

      Assert.Equal(expectedW, vector.w);
    }

    [Fact]
    public void VectorsSumReturnsVector()
    {
      float expectedW = 0f;

      Vector expectedVector = new(2, 3, 5);
      Vector vectorA = new(3, 1, 2);
      Vector vectorB = new(-1, 2, 3);

      Vector resultVector = vectorA + vectorB;

      Assert.Equivalent(expectedVector, resultVector);
      Assert.Equal(expectedW, resultVector.w);
    }

    [Fact]
    public void VectorsSubReturnsVector()
    {
      float expectedW = 0f;

      Vector expectedVector = new(4, -1, -1);
      Vector vectorA = new(3, 1, 2);
      Vector vectorB = new(-1, 2, 3);

      Vector resultVector = vectorA - vectorB;

      Assert.Equivalent(expectedVector, resultVector);
      Assert.Equal(expectedW, resultVector.w);
    }

    [Fact]
    public void MultiplyVector()
    {
      float scale = 3.5f;
      Vector expectedVector = new(7, 10.5f, 3.5f);
      Vector vector = new(2, 3, 1);

      Vector multipliedVector = vector * scale;

      Assert.Equivalent(expectedVector, multipliedVector);
    }

    [Fact]
    public void DivideVector()
    {
      float scale = 2f;
      Vector expectedVector = new(1, 1.5f, .5f);
      Vector vector = new(2, 3, 1);

      Vector dividedVector = vector / scale;

      Assert.Equivalent(expectedVector, dividedVector);
    }

    [Fact]
    public void NegateVectors()
    {
      Vector expectedVector = new(3, -2, 5);

      Vector vector = new(-3, 2, -5);

      Assert.Equivalent(expectedVector, !vector);
    }

    [Fact]
    public void CalculateVectorMagnitude()
    {
      Vector expectedVector = new(1, 2, 3);

      double vectorMagnitude = expectedVector.Magnitude();

      Assert.Equal(vectorMagnitude, Math.Sqrt(14));
    }

    [Fact]
    public void CalculateVectorsDotProduct()
    {
      double expectedDotProduct = 13f;
      Vector vectorA = new(2, 2, 1);
      Vector vectorB = new(2, 4, 1);

      double dotProduct = vectorA.Dot(vectorB);

      Assert.Equivalent(expectedDotProduct, dotProduct);
    }

    [Fact]
    public void CalculateVectorCrossProduct()
    {
      Vector expectedVector = new(-2, 0, 4);
      Vector vectorA = new(2, 2, 1);
      Vector vectorB = new(2, 4, 1);

      Vector crossProduct = vectorA.Cross(vectorB);

      Assert.Equivalent(expectedVector, crossProduct);
    }

    [Fact]
    public void NormalizeVector()
    {
      Vector expectedVector = new(1, 0, 0);
      Vector vector = new(5, 0, 0);

      Vector normalizedVector = vector.Normalize();

      Assert.Equivalent(expectedVector, normalizedVector);
    }

    [Theory]
    [InlineData(
        1, -1, 0,
        0, 1, 0,
        1, 1, 0
        )]
    [InlineData(
        0, -1, 0,
        1.4142f, 1.4142f, 0,
        1, 0, 0
        )]
    public void ValidateReflectVector(
        float inX, float inY, float inZ,
        float nX, float nY, float nZ,
        float expectedX, float expectedY, float expectedZ
        )
    {
      Vector incoming = new(inX, inY, inZ);
      Vector normal = new(nX, nY, nZ);
      Vector expectedVector = new(
          expectedX, expectedY, expectedZ);

      Vector actualReflectedVector = new Vector()
        .Reflect(incoming, normal);

      Assert.Equal(expectedVector, actualReflectedVector);
    }
  }
}
