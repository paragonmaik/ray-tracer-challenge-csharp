using Xunit;

public class TuplFacts
{
  public class CreateVector
  {
    [Fact]
    public void VectorWReturnsZero()
    {
      //Given
      float expectedW = 0f;

      //When
      Vector vector = new();

      //Then
      Assert.Equal(expectedW, vector.w);
    }
  }

  public class CreatePoint
  {
    [Fact]
    public void PointWReturnsOne()
    {
      //Given
      float expectedW = 1f;

      //When
      Point point = new();

      //Then
      Assert.Equal(expectedW, point.w);
    }
  }
}
