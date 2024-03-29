﻿public class Point : Tuple
{
  public Point()
    : base(0, 0, 0, 1) { }

  public Point(Point p)
    : base(p.x, p.y, p.z, p.w) { }

  public Point(
    double x = 0,
    double y = 0,
    double z = 0,
    double w = 1
  )
    : base(x, y, z, w)
  {
    this.w = 1f;
  }

  public static Point operator +(Point a, Vector b)
  {
    Point pointSum =
      new(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);

    return pointSum;
  }

  public static Vector operator -(Point a, Point b)
  {
    Vector vectorSubtraction =
      new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

    return vectorSubtraction;
  }

  public static Point operator -(Point a, Vector b)
  {
    Point pointSub =
      new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

    return pointSub;
  }

  public static Point operator -(Vector a, Point b)
  {
    Point pointSub =
      new(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);

    return pointSub;
  }

  public static Point operator *(Point a, float b)
  {
    return new Point(a.x * b, a.y * b, a.z * b, a.w * b);
  }

  public static Point operator /(Point a, float b)
  {
    return new Point(a.x / b, a.y / b, a.z / b, a.w / b);
  }

  public static Point operator !(Point a)
  {
    return new Point(a.x * -1, a.y * -1, a.z * -1, a.w * -1);
  }
}
