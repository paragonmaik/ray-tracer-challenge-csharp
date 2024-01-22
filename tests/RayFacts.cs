using Xunit;

public class RayFacts
{
  public class Rays
  {
    [Theory]
    [InlineData(0, 2, 3, 4)]
    [InlineData(1, 3, 3, 4)]
    [InlineData(-1, 1, 3, 4)]
    [InlineData(2.5, 4.5, 3, 4)]
    public void ValidateRayPosition(
      double value,
      double px,
      double py,
      double pz
    )
    {
      Ray ray = new(new(2, 3, 4), new(1, 0, 0));
      Point expectedPosition = new(px, py, pz);

      Point actualPosition = ray.Position(value);

      Assert.Equal(expectedPosition, actualPosition);
    }

    [Fact]
    public void ValidateIntersectionReturnsCorrectData()
    {
      Sphere sphere = new();
      List<Intersection> intersections =
        new() { new(sphere, 1), new(sphere, 2) };

      Assert.Equal(1, intersections[0].t);
      Assert.Equal(sphere, intersections[0].intersectableObj);

      Assert.Equal(2, intersections[1].t);
      Assert.Equal(sphere, intersections[1].intersectableObj);
    }

    [Fact]
    public void ValidateTranslateRay()
    {
      Ray ray = new(new(1, 2, 3), new(0, 1, 0));
      Matrix mat = new Matrix(4).Translate(3, 4, 5);
      Point expectedOrigin = new(4, 6, 8);
      Vector expectedDirection = new(0, 1, 0);

      Ray ray2 = ray * mat;

      Assert.Equal(expectedOrigin, ray2.Origin());
      Assert.Equal(expectedDirection, ray2.Direction());
    }

    [Fact]
    public void ValidateScaleRay()
    {
      Ray ray = new(new(1, 2, 3), new(0, 1, 0));
      Matrix mat = new Matrix(4).Scale(2, 3, 4);
      Point expectedOrigin = new(2, 6, 12);
      Vector expectedDirection = new(0, 3, 0);

      Ray ray2 = ray * mat;

      Assert.Equal(expectedOrigin, ray2.Origin());
      Assert.Equal(expectedDirection, ray2.Direction());
    }

    [Fact]
    public void ValidateDefaultSphereMatrix()
    {
      Sphere sphere = new();
      Matrix expectedMatrix = new Matrix(4).Identity();

      Assert.Equal(expectedMatrix, sphere.GetMatrix());
    }

    [Fact]
    public void ValidateSetTranslateSphereMatrix()
    {
      Sphere sphere = new();
      Matrix expectedMatrix = new Matrix(4).Translate(2, 3, 4);

      sphere.SetMatrix(expectedMatrix);

      Assert.Equal(expectedMatrix, sphere.GetMatrix());
    }
  }
}
