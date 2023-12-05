using Xunit;

public class TuplFacts
{
  public class CreateVector
  {
    [Fact]
    public void VectorWReturnsZero()
    {
      float expectedW = 0f;

      Vector vector = new();

      Assert.Equal(expectedW, vector.w);
    }
  }

  public class CreatePoint
  {
    [Fact]
    public void PointWReturnsOne()
    {
      float expectedW = 1f;

      Point point = new();

      Assert.Equal(expectedW, point.w);
    }
  }
}
