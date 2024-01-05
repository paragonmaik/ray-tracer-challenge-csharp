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

    [Fact]
    public void ValidateWorldIntersectsRay()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));

      List<double> expectedTIntersections = new(){
        4, 4.5f, 5.5f, 6
      };

      List<Intersection> actualIntersections = scene
        .IntersectWorld(ray);

      Assert.Equal(expectedTIntersections
          .Count(), actualIntersections.Count());
      Assert.Equal(expectedTIntersections[0],
          actualIntersections[0].t);
      Assert.Equal(expectedTIntersections[1],
               actualIntersections[1].t);
      Assert.Equal(expectedTIntersections[2],
               actualIntersections[2].t);
      Assert.Equal(expectedTIntersections[3],
               actualIntersections[3].t);
    }
  }
}
