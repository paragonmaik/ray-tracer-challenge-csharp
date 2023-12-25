using Xunit;

public class RayFacts
{
  public class Rays
  {
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(2.5)]
    public void ValidateRayPosition(
        double value
        )
    {
      Ray ray = new(new(2, 3, 4), new(1, 0, 0));
      Point expectedPosition = new();

      Point actualPosition = ray.Position(value);

      Assert.Equal(expectedPosition, actualPosition);
    }
  }
}
