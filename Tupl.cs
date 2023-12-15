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
}

