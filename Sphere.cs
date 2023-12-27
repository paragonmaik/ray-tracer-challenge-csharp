public class Sphere : IIntersectable
{
  private Point origin;
  private double radius;
  private Guid id;

  public Sphere()
  {
    this.origin = new();
    this.radius = 1f;
    this.id = Guid.NewGuid();
  }

  public Point Origin() { return this.origin; }

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
