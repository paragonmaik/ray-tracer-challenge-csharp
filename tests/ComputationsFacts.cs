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

      Computations c = Computations.Prepare(
        firstHit,
        ray,
        intersections
      );

      Assert.Equal(firstHit.t, c.t);
      Assert.Equal(
        firstHit.intersectableObj,
        c.intersectableObj
      );
      Assert.Equal(new(0, 0, -1), c.point);
      Assert.Equal(new(0, 0, -1), c.eye);
      Assert.Equal(new(0, 0, -1), c.normal);
    }

    [Fact]
    public void ValidateOutsideHit()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> intersections = sphere.Intersect(ray);
      Intersection firstHit = scene.Hit(intersections);

      Computations c = Computations.Prepare(
        firstHit,
        ray,
        intersections
      );

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

      Computations c = Computations.Prepare(
        firstHit,
        ray,
        intersections
      );

      Assert.Equal(true, c.inside);
    }

    [Fact]
    public void ValidateColorAtRayMiss()
    {
      Scene scene = new();
      Ray ray = new(new(0, 0, -5), new(0, 1, 0));

      Color actualColor = scene.ColorAt(ray);

      Assert.Equal(new(0, 0, 0), actualColor);
    }
  }
}
