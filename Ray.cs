public class Ray
{
  private Point origin;
  private Vector direction;

  public Ray(Point origin, Vector direction)
  {
    this.origin = origin;
    this.direction = direction;
  }

  public Point Position(double t)
  {
    return this.origin + this.direction * (float)t;
  }

  public static Ray operator *(Ray r, Matrix mat)
  {
    Ray tempRay = new(r.origin, r.direction);

    tempRay.origin = mat * r.origin;
    tempRay.direction = mat * r.direction;

    return tempRay;
  }

  public List<Intersection> Intersect(Sphere s)
  {
    List<Intersection> intersections = new();

    Ray transRay = this * s.GetMatrix().Inverse();

    Vector sphereToRay = transRay.origin - s.Origin();
    double a = transRay.direction.Dot(transRay.direction);
    double b = 2.0f * transRay.direction.Dot(sphereToRay);
    double c = sphereToRay.Dot(sphereToRay) - 1.0f;

    double discriminant = b * b - 4.0f * a * c;

    if (discriminant < 0)
    {
      return intersections;
    }

    double t1 = (-b - (double)Math.Sqrt(discriminant)) / (2.0f * a);
    double t2 = (-b + (double)Math.Sqrt(discriminant)) / (2.0f * a);

    intersections.Add(new(t1, s));
    intersections.Add(new(t2, s));

    return intersections;
  }

  public Point Origin() { return this.origin; }
  public Vector Direction() { return this.direction; }

  public override string ToString()
  {
    return $"Ray's origin: {this.origin}, Ray's direction: {this.direction}";
  }
}
