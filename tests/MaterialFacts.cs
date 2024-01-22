using Xunit;

public class MaterialFacts
{
  public class Materials
  {
    [Fact]
    public void ValidateMaterialinstantiation()
    {
      Material material =
        new(new(1, 1, 1), 0.1f, 0.9f, 0.9f, 200f);

      Assert.Equal(new(1, 1, 1), material.color);
      Assert.Equal(0.1f, material.Ambient);
      Assert.Equal(0.9f, material.Diffuse);
      Assert.Equal(0.9f, material.Specular);
      Assert.Equal(200f, material.Shinniness);
    }
  }
}
