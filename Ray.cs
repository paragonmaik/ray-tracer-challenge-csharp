public class Ray
{
  private Point origin;
  private Vector direction;

  public Ray(Point origin, Vector direction)
  {
    this.origin = origin;
    this.direction = direction;
  }

  public static Ray Transform(Ray ray, Matrix mat)
  {
    Ray temp;
    temp = ray * mat;
    return temp;
  }

  public Point Position(double t)
  {
    return this.origin + (this.direction * t);
  }

  public static Ray operator *(Ray r, Matrix mat)
  {
    Ray tempRay = new Ray(r.origin, r.direction);

    tempRay.origin = mat * r.origin;
    tempRay.direction = mat * r.direction;

    return tempRay;
  }

  public Point Origin() { return this.origin; }
  public Vector Direction() { return this.direction; }

  public override string ToString()
  {
    return $"Ray's origin: {this
      .origin}, Ray's direction: {this.direction}";
  }
}
