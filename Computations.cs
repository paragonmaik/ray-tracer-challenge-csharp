public class Computations
{
  public bool inside;
  public double t;
  public IntersectableObject intersectableObj;
  public Point point;
  public Point overPoint;
  public Vector eye;
  public Vector normal;

  public Computations(
    IntersectableObject intersectableObj,
    double t,
    Point point,
    Vector eye,
    Vector normal
  )
  {
    this.t = t;
    this.intersectableObj = intersectableObj;
    this.point = point;
    this.eye = eye;
    this.normal = normal;
    this.overPoint = new();
  }

  public static Computations Prepare(
    Intersection i,
    Ray ray,
    List<Intersection> xs
  )
  {
    Point temp = ray.Position(i.t);

    Computations c = new Computations(
      i.intersectableObj,
      i.t,
      temp,
      -ray.Direction().Normalize(),
      i.intersectableObj.GetNormal(temp, i).Normalize()
    );

    if (c.normal.Dot(c.eye) < 0)
    {
      c.inside = true;
      c.normal = -c.normal;
    }
    else
    {
      c.inside = false;
    }

    c.overPoint = c.point + (c.normal * Utility.epsilon);

    return c;
  }
}
