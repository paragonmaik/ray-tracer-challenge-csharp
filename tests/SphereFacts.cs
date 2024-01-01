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

      Vector actualNormalizedVector = sphere.NormalAt(new(x, y, z));

      Assert.Equal(expectedVector, actualNormalizedVector);
    }
  }
}
