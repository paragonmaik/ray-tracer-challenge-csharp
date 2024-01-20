public class IntersectableObjs : IntersectableObject
{
  public bool performAABBIntersectionTest = true;

  public IntersectableObjs()
    : base() { }

  public override Vector CalculateLocalNormal(
    Point localPoint,
    Intersection i = null
  )
  {
    Console.WriteLine(
      "Exception - Attempted to get a normal from a group object."
    );
    throw new NotImplementedException();
  }

  public override List<Intersection> Intersect(Ray ray)
  {
    List<Intersection> xs = new List<Intersection>();

    Ray transRay = ray * GetMatrix().Inverse();

    foreach (IntersectableObject obj in GetChildren())
    {
      xs.AddRange(obj.Intersect(transRay));
    }

    return Intersection.SortIntersections(xs);
  }
}
