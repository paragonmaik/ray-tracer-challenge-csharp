public class Computations
{
  public double t;
  public IntersectableObject intersectedObject;
  public Point point;
  public Vector eyeV;
  public Vector normalV;

  public Computations(Intersection i, Ray ray)
  {
    this.t = i.t;
    this.intersectedObject = i.intersectedObj;
    this.point = ray.Position(this.t);
    this.eyeV = -ray.Direction();
    this.normalV = i.intersectedObj.NormalAt(this.point);
  }

  // TODO: remove
  public void PrepareComputations(Intersection i, Ray ray)
  {
    this.t = i.t;
    this.intersectedObject = i.intersectedObj;
    this.point = ray.Position(this.t);
    this.eyeV = -ray.Direction();
    this.normalV = i.intersectedObj.NormalAt(this.point);
  }
}
