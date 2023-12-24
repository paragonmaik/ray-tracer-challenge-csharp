public class Tupl
{
  public float x;
  public float y;
  public float z;
  public float w;

  public Tupl()
  {
  }
  public Tupl(float x, float y, float z, float w)
  {
    this.x = x;
    this.y = y;
    this.z = z;
    this.w = w;
  }

  public double Magnitude()
  {
    double mag = Math.Sqrt(this.x * this.x +
        this.y * this.y + this.z * this.z);

    return (double)mag;
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
}

