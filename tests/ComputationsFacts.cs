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
  }
}
