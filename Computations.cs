public class Computations
{
  public double t;
  public IntersectableObject intersectableObject;
  public Point point;
  public Vector eyeV;
  public Vector normalV;

  public Computations(IntersectableObject intersectableObject)
  {
    this.intersectableObject = intersectableObject;
    this.t = 0f;
    this.point = new();
    this.eyeV = new();
    this.normalV = new();
  }

  public Computations(
      double t, IntersectableObject intersectableObject,
      Point point, Vector eyeV, Vector normalV)
  {
    this.t = t;
    this.intersectableObject = intersectableObject;
    this.point = point;
    this.eyeV = eyeV;
    this.normalV = normalV;
  }
}
