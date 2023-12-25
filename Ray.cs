public class Ray
{
  Point origin;
  Vector direction;

  public Ray(Point origin, Vector direction)
  {
    this.origin = origin;
    this.direction = direction;
  }

  public Point Position(double t)
  {
    return this.origin + this.direction * (float)t;
  }
}
