public class Computations
{
  public double t;
  public IntersectableObject intersectableObject;
  public Vector eyeV;
  public Vector normalV;

  public Computations(IntersectableObject intersectableObject)
  {
    this.intersectableObject = intersectableObject;
    this.t = 0f;
    this.eyeV = new();
    this.normalV = new();
  }

  public Computations(
      double t, IntersectableObject intersectableObject,
      Vector eyeV, Vector normalV)
  {
    this.t = t;
    this.intersectableObject = intersectableObject;
    this.eyeV = eyeV;
    this.normalV = normalV;
  }
}
