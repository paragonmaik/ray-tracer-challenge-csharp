public class Computations
{
  public bool inside;
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

    CalculateInsideOrOutsideHit();
  }

  // TODO: remove
  public void PrepareComputations(Intersection i, Ray ray)
  {
    this.t = i.t;
    this.intersectedObject = i.intersectedObj;
    this.point = ray.Position(this.t);
    this.eyeV = -ray.Direction();
    this.normalV = i.intersectedObj.NormalAt(this.point);
    CalculateInsideOrOutsideHit();
  }

  private void CalculateInsideOrOutsideHit()
  {
    if (this.normalV.Dot(this.eyeV) < 0)
    {
      this.inside = true;
      this.normalV = -this.normalV;
    }
    else
    {
      this.inside = false;
    }
  }
}
