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
}

