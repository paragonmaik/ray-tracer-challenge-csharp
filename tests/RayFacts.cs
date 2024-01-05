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
      Matrix mat = new Matrix(4).Scale(3, 4, 5);
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
      Matrix expectedMatrix = new Matrix(4)
        .Translate(2, 3, 4);

      sphere.SetMatrix(expectedMatrix);

      Assert.Equal(expectedMatrix, sphere.GetMatrix());
    }

    [Fact]
    public void ValidateIntersectWithScaledSphere()
    {
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      sphere.SetMatrix(sphere.GetMatrix().Scale(2, 2, 2));

      List<Intersection> intersections = ray
              .Intersect(sphere);


      Assert.Equal(2, intersections.Count());
      Assert.Equal(3, intersections[0].t);
      Assert.Equal(7, intersections[1].t);
    }

    [Fact]
    public void ValidateIntersectWithTranslatedSphere()
    {
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      sphere.SetMatrix(sphere.GetMatrix().Scale(5, 0, 0));

      Action act = () => ray
              .Intersect(sphere);

      NonInvertibleMatrixException exception = Assert
        .Throws<NonInvertibleMatrixException>(act);

      Assert.Equal(
          "Determinant equals 0, Matrix cannot be inverted",
          exception.Message);
    }
  }
}
