public class Tuple
{
  public double x;
  public double y;
  public double z;
  public double w;

  public Tuple() { }

  public Tuple(double x, double y, double z, double w)
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

  public double Dot(Tuple b)
  {
    return this.x * b.x +
    this.y * b.y +
    this.z * b.z +
    this.w * b.w;
  }

  public override bool Equals(object? obj)
  {
    var tuple = obj as Tuple;
    return tuple != null &&
           Utility.FE(x, tuple.x) &&
           Utility.FE(y, tuple.y) &&
           Utility.FE(z, tuple.z) &&
           Utility.FE(w, tuple.w);
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
