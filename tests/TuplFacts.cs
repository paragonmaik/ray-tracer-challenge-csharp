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
  }
}
