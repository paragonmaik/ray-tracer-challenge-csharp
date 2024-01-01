public class Sphere : IIntersectable
{
  private Point origin;
  private double radius;
  private Guid id;
  private Matrix mat;

  public Sphere()
  {
    this.origin = new();
    this.radius = 1f;
    this.id = Guid.NewGuid();
    this.mat = new Matrix(4).Identity();
  }

  public Point Origin() { return this.origin; }
  public Matrix GetMatrix() { return this.mat; }
  public void SetMatrix(Matrix mat) { this.mat = mat; }

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
