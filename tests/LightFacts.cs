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
  }
}
