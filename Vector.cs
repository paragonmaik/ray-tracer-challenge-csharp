public class Vector : Tuple
{
  public Vector() : base(0, 0, 0, 0)
  { }

  public Vector(double x = 0, double y = 0,
      double z = 0, double w = 0) : base(x, y, z, 0.0)
  { }

  public static Vector operator +(Vector a, Vector b)
  {
    return new(
      a.x + b.x,
      a.y + b.y,
      a.z + b.z,
      a.w + b.w);
  }

  public static Vector operator -(Vector a, Vector b)
  {
    return new(
     a.x - b.x,
     a.y - b.y,
     a.z - b.z,
     a.w - b.w);
  }

  public static Vector operator -(Vector a)
  {
    return new(
      -a.x,
      -a.y,
      -a.z,
      -a.w
      );
  }

  public static Vector operator *(Vector a, double b)
  {
    return new(
    a.x * b,
    a.y * b,
    a.z * b,
    a.w * b);
  }

  public static Vector operator /(Vector a, float b)
  {
    return new(
    a.x / b,
    a.y / b,
    a.z / b,
    a.w / b);
  }

  public static Vector operator !(Vector a)
  {
    return new(
        a.x * -1,
        a.y * -1,
        a.z * -1,
        a.w * -1);
  }

  public Vector Normalize()
  {
    double mag = this.Magnitude();

    if (Utility.FE(0, mag))
    {
      return new();
    }

    this.x = this.x / mag;
    this.y = this.y / mag;
    this.z = this.z / mag;
    this.w = this.w / mag;

    return this;
  }

  public Vector Cross(Vector b)
  {
    return new(
      this.y * b.z - this.z * b.y,
      this.z * b.x - this.x * b.z,
      this.x * b.y - this.y * b.x
      );
  }

  public static Vector Reflect(Vector incoming, Vector normal)
  {
    return incoming - normal * 2 * incoming.Dot(normal);
  }
}
