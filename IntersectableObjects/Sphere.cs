public class Sphere : IntersectableObject
{
  private double radius;

  public Sphere()
  {
    this.radius = 1f;
  }

  public override List<Intersection> Intersect(Ray ray)
  {
    List<Intersection> intersections = new();

    Ray transRay = ray * this.GetMatrix().Inverse();

    Vector sphereToRay = transRay.Origin() - this.Origin();
    double a = transRay.Direction().Dot(transRay.Direction());
    double b = 2.0f * transRay.Direction().Dot(sphereToRay);
    double c = sphereToRay.Dot(sphereToRay) - 1.0f;

    double discriminant = b * b - 4.0f * a * c;

    if (discriminant < 0)
    {
      return intersections;
    }

    double t1 = (-b - (double)Math.Sqrt(discriminant)) / (2.0f * a);
    double t2 = (-b + (double)Math.Sqrt(discriminant)) / (2.0f * a);

    intersections.Add(new(t1, this));
    intersections.Add(new(t2, this));

    return intersections;
  }

  public override Vector NormalAt(Point point)
  {
    Point objectPoint = this.mat.Inverse() * point;
    Vector objectNormal = objectPoint - new Point(0, 0, 0);
    Vector worldNormal = this.mat.Inverse().Transpose() * objectNormal;
    worldNormal.w = 0;

    return worldNormal.Normalize();
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    Sphere sphereB = (Sphere)obj;

    if (this.id != sphereB.id)
    {
      return false;
    }

    return true;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
