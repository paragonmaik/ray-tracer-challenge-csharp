public class Point : Tupl
{
  public Point() : base(0f, 0f, 0f, 1f)
  {
  }

  public Point(float x = 0f, float y = 0f,
      float z = 0f, float w = 1f) : base(x, y, z, w)
  {
    this.w = 1f;
  }

  public static Point operator +(Point a, Vector b)
  {
    Point pointSum = new(
        a.x + b.x,
        a.y + b.y,
        a.z + b.z,
        a.w + b.w);

    return pointSum;
  }
}

