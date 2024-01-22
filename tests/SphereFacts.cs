using Xunit;

public class SphereFacts
{
  public class Spheres
  {
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(0, 1, 0)]
    [InlineData(0, 0, 1)]
    [InlineData(1.7320f / 3f, 1.7320f / 3f, 1.7320f / 3f)]
    public void ValidateSphereNormal(float x, float y, float z)
    {
      Sphere sphere = new();
      Vector expectedVector = new(x, y, z);

      Vector actualNormalizedVector = sphere.GetNormal(
        new(x, y, z)
      );

      Assert.Equal(expectedVector, actualNormalizedVector);
    }

    [Fact]
    public void ValidateTranslatedSphereNormal()
    {
      Sphere sphere = new();
      Vector expectedVector = new(0, 0.70711f, -0.70711f);
      sphere.SetMatrix(sphere.GetMatrix().Translate(0, 1, 0));

      Vector actualNormalizedVector = sphere.GetNormal(
        new(0, 1.70711f, -0.70711f)
      );

      Assert.Equal(expectedVector, actualNormalizedVector);
    }

    [Fact]
    public void ValidateScaledSphereNormal()
    {
      Sphere sphere = new();
      Vector expectedVector = new(0, 0.97014f, -0.24254f);
      sphere.SetMatrix(
        sphere.GetMatrix().Scale(1, 0.5f, 1)
          * sphere.GetMatrix().RotateZAxis(Math.PI / 5)
      );

      Vector actualNormalizedVector = sphere.GetNormal(
        new(0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2)
      );

      Assert.Equal(expectedVector, actualNormalizedVector);
    }

    [Fact]
    public void ValidateSphereHasMaterial()
    {
      Sphere sphere = new();
      Material material = new(new(1, 1, 1));
      material.Ambient = 1f;

      sphere.material = material;

      Assert.Equal(sphere.material, material);
    }

    [Fact]
    public void ValidateRaySphereIntersection()
    {
      Ray ray = new(new(0, 0, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections =
        new() { new(sphere, 4f), new(sphere, 6f) };

      List<Intersection> actualIntersections = sphere.Intersect(
        ray
      );

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
          expectedIntersections[i].t,
          actualIntersections[i].t
        );
        Assert.Equal(
          expectedIntersections[i].intersectableObj,
          actualIntersections[i].intersectableObj
        );
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionAtTangent()
    {
      Ray ray = new(new(0, 1, -5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections =
        new() { new(sphere, 5f), new(sphere, 5f) };

      List<Intersection> actualIntersections = sphere.Intersect(
        ray
      );

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
          expectedIntersections[i].t,
          actualIntersections[i].t
        );
        Assert.Equal(
          expectedIntersections[i].intersectableObj,
          actualIntersections[i].intersectableObj
        );
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionMisses()
    {
      Ray ray = new(new(0, 2, -5), new(0, 0, 1));
      Sphere sphere = new();
      int expectedIntersectionsCount = 0;

      List<Intersection> actualIntersections = sphere.Intersect(
        ray
      );

      Assert.Equal(
        expectedIntersectionsCount,
        actualIntersections.Count
      );
    }

    [Fact]
    public void ValidateRaySphereIntersectionRayOriginatesInside()
    {
      Ray ray = new(new(0, 0, 0), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections =
        new() { new(sphere, -1f), new(sphere, 1f) };

      List<Intersection> actualIntersections = sphere.Intersect(
        ray
      );

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
          expectedIntersections[i].t,
          actualIntersections[i].t
        );
        Assert.Equal(
          expectedIntersections[i].intersectableObj,
          actualIntersections[i].intersectableObj
        );
      }
    }

    [Fact]
    public void ValidateRaySphereIntersectionSphereBehindRay()
    {
      Ray ray = new(new(0, 0, 5), new(0, 0, 1));
      Sphere sphere = new();
      List<Intersection> expectedIntersections =
        new() { new(sphere, -6f), new(sphere, -4f) };

      List<Intersection> actualIntersections = sphere.Intersect(
        ray
      );

      for (int i = 0; i < 2; i++)
      {
        Assert.Equal(
          expectedIntersections[i].t,
          actualIntersections[i].t
        );
        Assert.Equal(
          expectedIntersections[i].intersectableObj,
          actualIntersections[i].intersectableObj
        );
      }
    }
  }
}
