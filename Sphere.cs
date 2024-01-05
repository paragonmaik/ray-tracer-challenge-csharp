public class Sphere : IntersectableObject
{
  public Material material;
  private Point origin;
  private double radius;
  private Guid id;
  private Matrix mat;

  public Sphere()
  {
    this.material = new(new(1, 1, 1));
    this.origin = new();
    this.radius = 1f;
    this.id = Guid.NewGuid();
    this.mat = new Matrix(4).Identity();
  }

  public Point Origin() { return this.origin; }
  public Matrix GetMatrix() { return this.mat; }
  public void SetMatrix(Matrix mat) { this.mat = mat; }

  public List<Intersection> Intersect(Ray ray)
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

  public Vector NormalAt(Point point)
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
