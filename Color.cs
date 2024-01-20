public class Color
{
  public double r;
  public double g;
  public double b;

  public Color(Color color)
  {
    this.r = color.r;
    this.g = color.g;
    this.b = color.b;
  }

  public Color(double r = 0.0, double g = 0.0, double b = 0.0)
  {
    this.r = r;
    this.g = g;
    this.b = b;
  }

  public static Color operator -(Color a, Color b)
  {
    Color temp = new Color();
    temp.r = a.r - b.r;
    temp.g = a.g - b.g;
    temp.b = a.b - b.b;
    return temp;
  }

  public static Color operator *(Color a, double b)
  {
    Color temp = new Color();
    temp.r = a.r * b;
    temp.g = a.g * b;
    temp.b = a.b * b;
    return temp;
  }

  public static Color operator *(double a, Color b)
  {
    Color temp = new Color();
    temp.r = b.r * a;
    temp.g = b.g * a;
    temp.b = b.b * a;
    return temp;
  }

  public static Color operator *(Color a, Color b)
  {
    Color temp = new Color();
    temp.r = a.r * b.r;
    temp.g = a.g * b.g;
    temp.b = a.b * b.b;
    return temp;
  }

  public static Color operator +(Color a, Color b)
  {
    Color temp = new Color();
    temp.r = a.r + b.r;
    temp.g = a.g + b.g;
    temp.b = a.b + b.b;
    return temp;
  }

  public override bool Equals(object? obj)
  {
    var color = obj as Color;

    return color != null
      && Utility.FE(r, color.r)
      && Utility.FE(g, color.g)
      && Utility.FE(b, color.b);
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }

  public override string ToString()
  {
    return $"Red: {this.r}, Green: {this.g}, Blue: {this.b}";
  }
}
