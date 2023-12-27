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
      List<Intersection> expectedIntersections = new() {
        new(4f, sphere), new(6f, sphere) };


      List<Intersection> actualIntersections = ray
        .Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
            expectedIntersections[i].t, actualIntersections[i].t);
        Assert.Equal(
            expectedIntersections[i].intersectedObj,
            actualIntersections[i].intersectedObj);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionAtTangent()
    {
      Ray ray = new(new(0, 1, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections = new() {
        new(5f, sphere), new(5f, sphere) };

      List<Intersection> actualIntersections = ray
        .Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
             expectedIntersections[i].t, actualIntersections[i].t);
        Assert.Equal(
            expectedIntersections[i].intersectedObj,
            actualIntersections[i].intersectedObj);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionMisses()
    {
      Ray ray = new(new(0, 2, -5), new(0, 0, 1));
      Sphere sphere = new();
      int expectedIntersectionsCount = 0;

      List<Intersection> actualIntersections = ray
        .Intersect(sphere);

      Assert.Equal(
          expectedIntersectionsCount, actualIntersections.Count);
    }

    [Fact]
    public void ValidateRaySphereIntersectionRayOriginatesInside()
    {
      Ray ray = new(new(0, 0, 0), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections = new() {
        new(-1f, sphere), new(1f, sphere) };

      List<Intersection> actualIntersections = ray
        .Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
             expectedIntersections[i].t, actualIntersections[i].t);
        Assert.Equal(
            expectedIntersections[i].intersectedObj,
            actualIntersections[i].intersectedObj);
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionSphereBehindRay()
    {
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections = new() {
        new(-6f, sphere), new(-4f, sphere) };

      List<Intersection> actualIntersections = ray
        .Intersect(sphere);

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
             expectedIntersections[i].t, actualIntersections[i].t);
        Assert.Equal(
            expectedIntersections[i].intersectedObj,
            actualIntersections[i].intersectedObj);
      }
    }

    [Fact]
    public void ValidateIntersectionInstantiation()
    {
      Sphere sphere = new();
      Intersection intersection = new(3.5f, sphere);

      Assert.Equal(3.5f, intersection.t);
      Assert.Equal(sphere, intersection.intersectedObj);
    }

    [Fact]
    public void ValidateIntersectionReturnsCorrectData()
    {
      Sphere sphere = new();
      List<Intersection> intersections = new() { new(1, sphere),
        new(2, sphere) };

      Assert.Equal(1, intersections[0].t);
      Assert.Equal(sphere, intersections[0].intersectedObj);

      Assert.Equal(2, intersections[1].t);
      Assert.Equal(sphere, intersections[1].intersectedObj);
    }

    [Fact]
    public void ValidateRayHitPositiveIntersections()
    {
      Sphere sphere = new();
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      Intersection expectedIntersection = new(1, sphere);
      List<Intersection> intersections = new() { new(1, sphere),
        new(2, sphere) };

      Intersection actualIntersection = ray.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(expectedIntersection
          .intersectedObj, actualIntersection.intersectedObj);
    }

    [Fact]
    public void ValidateRayHitFewPositiveIntersections()
    {
      Sphere sphere = new();
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      Intersection expectedIntersection = new(1, sphere);
      List<Intersection> intersections = new() { new(-1, sphere),
        new(1, sphere) };

      Intersection actualIntersection = ray.Hit(intersections);

      Assert.Equal(expectedIntersection.t, actualIntersection.t);
      Assert.Equal(expectedIntersection
          .intersectedObj, actualIntersection.intersectedObj);
    }

    [Fact]
    public void ValidateRayHitNegativeIntersections()
    {
      Sphere sphere = new();
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      List<Intersection> intersections = new() { new(-1, sphere),
        new(-2, sphere) };

      Intersection actualIntersection = ray.Hit(intersections);

      Assert.Equal(null, actualIntersection);
    }
  }
}
