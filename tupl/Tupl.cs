public abstract class Tupl
{
  public float x;
  public float y;
  public float z;
  public float w;

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
}

