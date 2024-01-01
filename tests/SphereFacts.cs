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

    [Fact]
    public void ValidateTranslatedSphereNormal()
    {
      Sphere sphere = new();
      Vector expectedVector = new(0, 0.70711f, -0.70711f);
      sphere.SetMatrix(sphere.GetMatrix().Translate(0, 1, 0));

      Vector actualNormalizedVector = sphere
        .NormalAt(new(0, 1.70711f, -0.70711f));

      Assert.Equal(expectedVector, actualNormalizedVector);
    }

    [Fact]
    public void ValidateScaledSphereNormal()
    {
      Sphere sphere = new();
      Vector expectedVector = new(0, 0.97014f, -0.24254f);
      sphere.SetMatrix(
          sphere.GetMatrix().Scale(1, 0.5f, 1) *
          sphere.GetMatrix().RotateZAxis(Math.PI / 5)
          );

      Vector actualNormalizedVector = sphere
        .NormalAt(new(0, (float)Math.Sqrt(2) / 2, -(float)Math.Sqrt(2) / 2));

      Assert.Equal(expectedVector, actualNormalizedVector);
    }
  }
}
