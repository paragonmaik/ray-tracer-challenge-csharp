using Xunit;

public class TuplFacts
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
  }

  public class Points
  {
    [Fact]
    public void PointWReturnsOne()
    {
      float expectedW = 1f;

      Point point = new();

      Assert.Equal(expectedW, point.w);
    }

    [Fact]
    public void PointAndVectorSumReturnsPoint()
    {
      float expectedW = 1f;

      Point expectedPoint = new(0, 6, 7);
      Point point = new(1, 4, 4);
      Vector vector = new(-1, 2, 3);

      Point resultPoint = point + vector;

      Assert.Equivalent(expectedPoint, resultPoint);
      Assert.Equal(expectedW, resultPoint.w);
    }

    [Fact]
    public void PointAndVectorSubReturnsPoint()
    {
      float expectedW = 1f;

      Point expectedPoint = new(2, 2, 1);
      Point point = new(1, 4, 4);
      Vector vector = new(-1, 2, 3);

      Point resultPoint = point - vector;

      Assert.Equivalent(expectedPoint, resultPoint);
      Assert.Equal(expectedW, resultPoint.w);
    }

    [Fact]
    public void PointsSubReturnsVector()
    {
      float expectedW = 0f;

      Vector expectedVector = new(1, 0, 5);
      Point pointA = new(0, 2, 8);
      Point pointB = new(-1, 2, 3);

      Vector resultVector = pointA - pointB;

      Assert.Equivalent(expectedVector, resultVector);
      Assert.Equal(expectedW, resultVector.w);
    }

    [Fact]
    public void MultiplyPoint()
    {
      float scale = 3.5f;
      Point expectedPoint = new(7, 10.5f, 3.5f);
      Point point = new(2, 3, 1);

      Point multipliedPoint = point * scale;

      Assert.Equivalent(expectedPoint, multipliedPoint);
    }

    [Fact]
    public void DividePoint()
    {
      float scale = 2f;
      Point expectedPoint = new(1, 1.5f, .5f);
      Point point = new(2, 3, 1);

      Point dividedPoint = point / scale;

      Assert.Equivalent(expectedPoint, dividedPoint);
    }

    [Fact]
    public void NegatePoints()
    {
      Point expectedPoint = new(5, -1, 2);

      Point point = new(-5, 1, -2);

      Assert.Equivalent(expectedPoint, !point);
    }
  }

  public class Colors
  {
    [Fact]
    public void ValidateColorInstantiation()
    {
      float red = 0.2f;
      float green = 1f;
      float blue = 0.7f;

      Color color = new(0.2f, 1, 0.7f);

      Assert.Equal(red, color.red);
      Assert.Equal(green, color.green);
      Assert.Equal(blue, color.blue);
    }

    [Fact]
    public void AddColors()
    {
      Color expectedColor = new(2, 3, 5);
      Color colorA = new(0.1f, 1, 0.3f);
      Color colorB = new(0.4f, 0, 0.4f);

      Color resultColor = colorA + colorB;

      Assert.Equivalent(expectedColor, resultColor);
    }

    [Fact]
    public void SubtractColors()
    {
      Color expectedColor = new(2, 3, 5);
      Color colorA = new(0.1f, 1, 0.3f);
      Color colorB = new(0.4f, 0, 0.4f);

      Color resultColor = colorA - colorB;

      Assert.Equivalent(expectedColor, resultColor);
    }

    [Fact]
    public void MultiplyColorByScalar()
    {

      Color expectedColor = new(2, 3, 5);
      Color colorA = new(0.1f, 1, 0.3f);
      Color colorB = new(0.4f, 0, 0.4f);

      Color resultColor = colorA * colorB;

      Assert.Equivalent(expectedColor, resultColor);
    }
  }
}
