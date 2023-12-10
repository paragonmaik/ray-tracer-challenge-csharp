using Xunit;

public class ColorFacts
{
  public class Colors
  {
    [Fact]
    public void ValidateColorInstantiation()
    {
      float red = 0.2f;
      float green = 1f;
      float blue = 0.7f;

      Color color = new(0.2f, 1, 0.7f);

      Assert.Equal(red, color.red);
      Assert.Equal(green, color.green);
      Assert.Equal(blue, color.blue);
    }

    [Fact]
    public void AddColors()
    {
      Color expectedColor = new(0.5f, 1, 0.2f);
      Color colorA = new(0.1f, 1, 0.1f);
      Color colorB = new(0.4f, 0, 0.1f);

      Color resultColor = colorA + colorB;

      Assert.Equal(expectedColor.red, resultColor.red, 4);
      Assert.Equal(expectedColor.green, resultColor.green, 4);
      Assert.Equal(expectedColor.blue, resultColor.blue, 4);
    }

    [Fact]
    public void SubtractColors()
    {
      Color expectedColor = new(-0.3f, 1, 0);
      Color colorA = new(0.1f, 1, 0.2f);
      Color colorB = new(0.4f, 0, 0.2f);

      Color resultColor = colorA - colorB;

      Assert.Equal(expectedColor.red, resultColor.red, 4);
      Assert.Equal(expectedColor.green, resultColor.green, 4);
      Assert.Equal(expectedColor.blue, resultColor.blue, 4);
    }

    [Fact]
    public void MultiplyColors()
    {
      Color expectedColor = new(0.04f, 0, 0.04f);
      Color colorA = new(0.1f, 1, 0.2f);
      Color colorB = new(0.4f, 0, 0.2f);

      Color resultColor = colorA * colorB;

      Assert.Equal(expectedColor.red, resultColor.red, 4);
      Assert.Equal(expectedColor.green, resultColor.green, 4);
      Assert.Equal(expectedColor.blue, resultColor.blue, 4);
    }

    [Fact]
    public void MultiplyColorByScalar()
    {

      Color expectedColor = new(0.2f, 2, 0.6f);
      Color colorA = new(0.1f, 1, 0.3f);
      float scalar = 2f;

      Color resultColor = colorA * scalar;

      Assert.Equal(expectedColor.red, resultColor.red, 4);
      Assert.Equal(expectedColor.green, resultColor.green, 4);
      Assert.Equal(expectedColor.blue, resultColor.blue, 4);
    }
  }
}

