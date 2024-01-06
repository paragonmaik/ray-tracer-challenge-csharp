using Xunit;

public class ComputationsFacts
{
  public class Computation
  {
    [Fact]
    public void ValidatePrepareComputations()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);

      Computations c = new(firstHit, ray);

      Assert.Equal(firstHit.t, c.t);
      Assert.Equal(firstHit.intersectedObj, c.intersectedObject);
      Assert.Equal(new(0, 0, -1), c.point);
      Assert.Equal(new(0, 0, -1), c.eyeV);
      Assert.Equal(new(0, 0, -1), c.normalV);
    }

    [Fact]
    public void ValidateOutsideHit()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);

      Computations c = new(firstHit, ray);

      Assert.Equal(false, c.inside);
    }

    [Fact]
    public void ValidateInsideHit()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, 0), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);

      Computations c = new(firstHit, ray);

      Assert.Equal(true, c.inside);
    }

    [Fact]
    public void ValidateShadingOutsideHit()
    {
      // TODO: use scene methods
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = scene.innerSphere;

      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);
      Computations c = new(firstHit, ray);

      Color color = scene.ShadeHit(c);

      Assert.Equal(new(0.38066f, 0.47583f, 0.2855f), color);
    }

    [Fact]
    public void ValidateShadingInsideHit()
    {
      Scene scene = new();
      scene.light = new(new(1, 1, 1), new(0, 0.25f, 0));
      Ray ray = new(new(0, 0, 0), new(0, 0, 1));
      Sphere sphere = scene.outerSphere;

      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);
      Computations c = new(firstHit, ray);

      Color color = scene.ShadeHit(c);

      Assert.Equal(new(0.90498f, 0.90498f, 0.90498f), color);
    }

    [Fact]
    public void ValidateColorAtRayMiss()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 1, 0));

      Color actualColor = scene.ColorAt(ray);

      Assert.Equal(new(0, 0, 0), actualColor);
    }

    [Fact]
    public void ValidateColorRayHits()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));

      Color actualColor = scene.ColorAt(ray);

      Assert.Equal(new(
            0.38066125f, 0.4758265f, 0.28549594f), actualColor);
    }

    [Fact]
    public void ValidateColorAtRayHitBehindRay()
    {
      Scene scene = new();
      scene.innerSphere.material.Ambient = 1f;
      scene.outerSphere.material.Ambient = 1f;
      Ray ray = new(new(0, 0, 0.75f), new(0, 0, -1));

      Color actualColor = scene.ColorAt(ray);

      Assert
        .Equal(scene.outerSphere.material.color, actualColor);
    }
  }
}
