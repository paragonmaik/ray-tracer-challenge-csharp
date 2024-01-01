using Xunit;

public class MaterialFacts
{
  public class Materials
  {
    [Fact]
    public void ValidateMaterialinstantiation()
    {
      Material material = new(
          new(1, 1, 1), 0.1f, 0.9f, 0.9f, 200f);

      Assert.Equal(material.color, new(1, 1, 1));
      Assert.Equal(material.Ambient, 0.1f);
      Assert.Equal(material.Diffuse, 0.9f);
      Assert.Equal(material.Specular, 0.9f);
      Assert.Equal(material.Shininess, 200f);
    }
  }
}
