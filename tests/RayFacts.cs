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

    [Fact]
    public void ValidateRaySphereIntersection()
    {
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<double> expectedIntersections = new() { 4f, 6f };

      List<double> actualIntersections = ray.Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(expectedIntersections, actualIntersections);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionAtTangent()
    {
      Ray ray = new(new(0, 1, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<double> expectedIntersections = new() { 5f, 5f };

      List<double> actualIntersections = ray.Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(expectedIntersections, actualIntersections);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionMisses()
    {
      Ray ray = new(new(0, 2, -5), new(0, 0, 1));
      Sphere sphere = new();
      int expectdIntersectionsCount = 0;

      List<double> actualIntersections = ray.Intersect(sphere);

      Assert.Equal(
          expectdIntersectionsCount, actualIntersections.Count);
    }

    [Fact]
    public void ValidateRaySphereIntersectionRayOriginatesInside()
    {
      Ray ray = new(new(0, 0, 0), new(0, 0, 1));
      Sphere sphere = new();
      List<double> expectedIntersections = new() { -1f, 1f };

      List<double> actualIntersections = ray.Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(expectedIntersections, actualIntersections);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionSphereBehindRay()
    {
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      Sphere sphere = new();
      List<double> expectedIntersections = new() { -6f, -4f };

      List<double> actualIntersections = ray.Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(expectedIntersections, actualIntersections);
      }
    }
  }
}
