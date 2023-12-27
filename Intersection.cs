public class Intersection
{
  public double t;
  public IIntersectable intersectedObj;

  public Intersection(double t, IIntersectable intersectedObj)
  {
    this.t = t;
    this.intersectedObj = intersectedObj;
  }
}
