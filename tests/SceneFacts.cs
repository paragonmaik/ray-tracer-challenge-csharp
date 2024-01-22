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
      Intersection expectedIntersection = new(sphere, 1);
      List<Intersection> intersections =
        new() { new(sphere, 1), new(sphere, 2) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(
        expectedIntersection.intersectableObj,
        actualIntersection.intersectableObj
      );
    }

    [Fact]
    public void ValidateHitFewPositiveIntersections()
    {
      Scene scene = new();
      Sphere sphere = new();
      Intersection expectedIntersection = new(sphere, 1);
      List<Intersection> intersections =
        new() { new(sphere, -1), new(sphere, 1) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(
        expectedIntersection.intersectableObj,
        actualIntersection.intersectableObj
      );
    }

    [Fact]
    public void ValidateRayNegativeIntersections()
    {
      Scene scene = new();
      Sphere sphere = new();
      List<Intersection> intersections =
        new() { new(sphere, -1), new(sphere, -2) };

      Intersection actualIntersection = scene.Hit(intersections);

      Assert.Equal(null, actualIntersection);
    }

    [Fact]
    public void ValidateRayThroughCenterOfCanvas()
    {
      Camera cam = new(201, 101, Math.PI / 2);
      Scene scene = new();
      Ray ray = scene.RayForPixel(cam, 100, 50);

      Assert.Equal(new(0, 0, 0), ray.Origin());
      Assert.Equal(
        new(9.94E-17f, 0.4454f, -0.8953f),
        ray.Direction()
      );
    }

    [Fact]
    public void ValidateRayThroughCornerOfCanvas()
    {
      Camera cam = new(201, 101, Math.PI / 2);
      Scene scene = new();
      Ray ray = scene.RayForPixel(cam, 0, 0);

      Assert.Equal(new(0, 0, 0), ray.Origin());
      Assert.Equal(
        new(0.5763f, 0.5763f, -0.5792f),
        ray.Direction()
      );
    }
  }
}
