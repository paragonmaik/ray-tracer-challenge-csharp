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

    [Fact]
    public void ValidateRayThroughCenterOfCanvas()
    {
      Camera cam = new(201, 101, Math.PI / 2);
      Scene scene = new();
      Ray ray = scene.RayForPixel(cam, 100, 50);

      Assert.Equal(new(0, 0, 0), ray.Origin());
      Assert.Equal(new(9.94E-17f, 0.4454f, -0.8953f), ray.Direction());
    }

    [Fact]
    public void ValidateRayThroughCornerOfCanvas()
    {
      Camera cam = new(201, 101, Math.PI / 2);
      Scene scene = new();
      Ray ray = scene.RayForPixel(cam, 0, 0);

      Assert.Equal(new(0, 0, 0), ray.Origin());
      Assert.Equal(new(0.5763f, 0.5763f, -0.5792f),
          ray.Direction());
    }

    [Fact]
    public void ValidateRayThroughCanvasWhenTransformedCamera()
    {
      Camera cam = new(201, 101, Math.PI / 2);
      cam.transform = cam.transform
        .RotateYAxis(Math.PI / 4) * cam.transform
        .Translate(0, -2, 5);
      Scene scene = new();
      Ray ray = scene.RayForPixel(cam, 100, 50);

      Assert.Equal(new(0, 2, -5), ray.Origin());
      Assert.Equal(new(0.7071f / 2, 0, -0.7071f / 2),
          ray.Direction());
    }

    [Fact]
    public void ValidateSceneRender()
    {
      Scene scene = new();
      Camera cam = new(11, 11, Math.PI / 2);
      Point from = new(0, 0, -5);
      Point to = new(0, 0, 0);
      Vector up = new(0, 1, 0);
      cam.transform = cam.ViewTransform(from, to, up);

      Canvas image = scene.Render(cam);

      Assert.Equal(new(0.38066f, 0.47583f, 0.2855f),
          image.GetPixel(5, 5));
    }
  }
}
