using Xunit;

public class LightFacts
{
  public class Lights
  {
    [Fact]
    public void ValidateLightInstantiation()
    {
      Light light = new(new(1, 1, 1), new(0, 0, 0));

      Assert.Equal(light.intensity, new(1, 1, 1));
      Assert.Equal(light.position, new(0, 0, 0));
    }

    [Theory]
    [InlineData(
        0, 0, -1,
        0, 0, -10, 1, 1, 1,
        1.9f, 1.9f, 1.9f
        )]
    [InlineData(
        0, 1.4142 / 2, -1.4142 / 2,
        0, 0, -10, 1, 1, 1,
        1, 1, 1
        )]
    [InlineData(
        0, 0, -1,
        0, 10, -10, 1, 1, 1,
        0.7364f, 0.7364f, 0.7364f
        )]
    [InlineData(
        0, -1.4142 / 2, -1.4142 / 2,
        0, 10, -10, 1, 1, 1,
        1.6346f, 1.6346f, 1.6346f
        )]
    [InlineData(
        0, 0, -1,
        0, 0, 10, 1, 1, 1,
        0.1f, 0.1f, 0.1f
        )]
    public void ValidateSurfaceLighting(
        float eyeX, float eyeY, float eyeZ,
        float pX, float pY, float pZ, float cX, float cY, float cZ,
        float expectedX, float expectedY, float expectedZ
        )
    {
      Vector eyeV = new(eyeX, eyeY, eyeZ);
      Vector normalV = new(0, 0, -1);
      Sphere sphere = new();
      Light light = new(new(cX, cY, cZ), new(pX, pY, pZ));
      Color expectedColor = new(expectedX, expectedY, expectedZ);
      Material material = new(new(cX, cY, cZ));

      Color actualColor = sphere.Lighting(
                new Point(), light, eyeV, normalV
                );

      Assert.Equal(expectedColor, actualColor);
    }
  }
}
