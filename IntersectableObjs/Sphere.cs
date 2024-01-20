public class Sphere : IntersectableObject
{
  double radius;

  public Sphere(double radius = 1.0)
    : base()
  {
    this.radius = radius;
  }

  public override string ToString()
  {
    return "Sphere: " + id.ToString();
  }

  public override Vector CalculateLocalNormal(
    Point localPoint,
    Intersection i = null
  )
  {
    Vector normal = localPoint - new Point(0, 0, 0);

    normal.w = 0;
    normal.Normalize();
    return normal;
  }

  public override List<Intersection> Intersect(Ray ray)
  {
    List<Intersection> intersectionPoints =
      new List<Intersection>();

    Ray transRay = RayToObjectSpace(ray);

    Vector sphereToRay = transRay.Origin() - new Point(0, 0, 0);
    double a = transRay.Direction().Dot(transRay.Direction());
    double b = 2.0 * transRay.Direction().Dot(sphereToRay);
    double c = sphereToRay.Dot(sphereToRay) - 1.0;
    double discriminant = b * b - 4.0 * a * c;
    if (discriminant < 0)
      return intersectionPoints;

    double t1 =
      (-b - (double)Math.Sqrt(discriminant)) / (2.0 * a);
    double t2 =
      (-b + (double)Math.Sqrt(discriminant)) / (2.0 * a);
    intersectionPoints.Add(new Intersection(this, t1));
    intersectionPoints.Add(new Intersection(this, t2));

    return intersectionPoints;
  }

  // public override Bounds GetLocalBounds()
  // {
  //   Bounds b = new Bounds();

  //   b.min.y = -1;
  //   b.max.y = 1;

  //   b.min.x = -1;
  //   b.max.x = 1;

  //   b.min.z = -1;
  //   b.max.z = 1;

  //   return b;
  // }
}
