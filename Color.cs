public class Color
{
  public float red;
  public float green;
  public float blue;

  public Color()
  { }

  public Color(float red = 0f, float green = 0f,
      float blue = 0f)
  {
    this.red = red;
    this.green = green;
    this.blue = blue;
  }

  public static Color operator +(Color a, Color b)
  {
    return new(
        a.red + b.red,
        a.green + b.green,
        a.blue + b.blue
        );
  }

  public static Color operator -(Color a, Color b)
  {
    return new(
        a.red - b.red,
        a.green - b.green,
        a.blue - b.blue
        );
  }

  public static Color operator *(Color a, Color b)
  {
    return new(
        a.red * b.red,
        a.green * b.green,
        a.blue * b.blue
        );
  }

  public static Color operator *(Color a, float b)
  {
    return new(
        a.red * b,
        a.green * b,
        a.blue * b
        );
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    Color color = (Color)obj;

    if (this.red != color.red)
    {
      return false;
    }

    if (this.green != color.green)
    {
      return false;
    }

    if (this.blue != color.blue)
    {
      return false;
    }

    return true;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }

  public override string ToString()
  {
    return $"Red: {this.red}, Green: {this.green}, Blue: {this.blue}";
  }
}
