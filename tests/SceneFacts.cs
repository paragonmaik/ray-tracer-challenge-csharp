using Xunit;

public class SceneFacts
{
  public class Scenes
  {
    [Fact]
    public void ValidateHitPositiveIntersections()
    {
      Scene scene = new();
      Sphere sphere = new();
      Intersection expectedIntersection = new(1, sphere);
      List<Intersection> intersections = new() { new(1, sphere),
        new(2, sphere) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(expectedIntersection
          .intersectedObj, actualIntersection.intersectedObj);
    }

    [Fact]
    public void ValidateHitFewPositiveIntersections()
    {
      Scene scene = new();
      Sphere sphere = new();
      Intersection expectedIntersection = new(1, sphere);
      List<Intersection> intersections = new() { new(-1, sphere),
        new(1, sphere) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(expectedIntersection
          .intersectedObj, actualIntersection.intersectedObj);
    }

    [Fact]
    public void ValidateRayNegativeIntersections()
    {
      Scene scene = new();
      Sphere sphere = new();
      List<Intersection> intersections = new() { new(-1, sphere),
        new(-2, sphere) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(null, actualIntersection);
    }
  }
}
