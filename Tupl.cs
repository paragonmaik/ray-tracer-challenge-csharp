public class Tupl
{
  public double x;
  public double y;
  public double z;
  public double w;

  public Tupl()
  {
  }

  public Tupl(double x, double y, double z, double w)
  {
    this.x = x;
    this.y = y;
    this.z = z;
    this.w = w;
  }

  public double Magnitude()
  {
    return Math.Sqrt(this.x * this.x +
        this.y * this.y + this.z * this.z +
        this.w * this.w);
  }

  public double Dot(Tupl b)
  {
    return this.x * b.x +
      this.y * b.y +
      this.z * b.z +
      this.w * b.w;
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }
    Tupl tupl = (Tupl)obj;

    if ((Math.Abs(this.x) - Math.Abs(tupl.x)) > 0.001f)
    {
      return false;
    }

    if ((Math.Abs(this.y) - Math.Abs(tupl.y)) > 0.001f)
    {
      return false;
    }
    if ((Math.Abs(this.z) - Math.Abs(tupl.z)) > 0.001f)
    {
      return false;
    }

    if ((Math.Abs(this.w) - Math.Abs(tupl.w)) > 0.001f)
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
    return $"x: {this.x}, y: {this.y}, z: {this.z}, w: {this.w}";
  }
}

