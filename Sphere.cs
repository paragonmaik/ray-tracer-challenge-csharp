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
}
