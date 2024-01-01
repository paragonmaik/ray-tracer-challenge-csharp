public class Vector : Tupl
{
  public Vector() : base(0f, 0f, 0f, 0f)
  {
  }

  public Vector(float x = 0f, float y = 0f,
      float z = 0f, float w = 0f) : base(x, y, z, w)
  {
    this.w = 0f;
  }

  public static Vector operator +(Vector a, Vector b)
  {
    Vector vectorSum = new(
        a.x + b.x,
        a.y + b.y,
        a.z + b.z,
        a.w + b.w);

    return vectorSum;
  }

  public static Vector operator -(Vector a, Vector b)
  {
    Vector vectorSub = new(
        a.x - b.x,
        a.y - b.y,
        a.z - b.z,
        a.w - b.w);

    return vectorSub;
  }

  // TODO: retype float to double
  public static Vector operator *(Vector a, float b)
  {
    return new Vector(
    a.x * b,
    a.y * b,
    a.z * b,
    a.w * b);
  }

  public static Vector operator /(Vector a, float b)
  {
    return new Vector(
    a.x / b,
    a.y / b,
    a.z / b,
    a.w / b);
  }

  public static Vector operator !(Vector a)
  {
    return new Vector(
        a.x * -1,
        a.y * -1,
        a.z * -1,
        a.w * -1);
  }

  public Vector Normalize()
  {
    this.x = this.x / (float)Magnitude();
    this.y = this.y / (float)Magnitude();
    this.z = this.z / (float)Magnitude();
    this.w = this.w / (float)Magnitude();

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

  public Vector Reflect(Vector incoming, Vector normal)
  {
    return incoming - normal * 2 * (float)incoming.Dot(normal);

  }
}

