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

  public List<Intersection> Intersect(Sphere s)
  {
    List<Intersection> intersections = new();

    Vector sphereToRay = this.origin - s.Origin();
    double a = this.direction.Dot(this.direction);
    double b = 2.0f * direction.Dot(sphereToRay);
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
}
