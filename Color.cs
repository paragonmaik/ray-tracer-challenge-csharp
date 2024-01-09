public class Color
{
  public double red;
  public double green;
  public double blue;

  public Color()
  { }

  public Color(double red = 0f, double green = 0f,
      double blue = 0f)
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

    if (Math.Abs(this.red - color.red) > 0.0001f)
    {
      return false;
    }

    if (Math.Abs(this.green - color.green) > 0.0001f)
    {
      return false;
    }

    if (Math.Abs(this.blue - color.blue) > 0.0001f)
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
