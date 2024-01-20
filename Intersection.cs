public class Intersection
{
  public IntersectableObject intersectableObj;
  public double t;
  public double u;
  public double v;

  public Intersection(
    IntersectableObject obj,
    double t,
    double u = 0.0,
    double v = 0.0
  )
  {
    intersectableObj = obj;
    this.t = t;
    this.u = u;
    this.v = v;
  }

  public static List<Intersection> SortIntersections(
    List<Intersection> intersections
  )
  {
    if (intersections.Count == 0)
      return intersections;

    List<Intersection> sortedIntersections =
      new List<Intersection>();

    sortedIntersections.Add(intersections[0]);

    int currentIntersection = 1;
    bool valueInserted = false;

    while (currentIntersection < intersections.Count)
    {
      valueInserted = false;
      for (int i = 0; i < sortedIntersections.Count; i++)
      {
        if (
          intersections[currentIntersection].t
          < sortedIntersections[i].t
        )
        {
          sortedIntersections.Insert(
            i,
            intersections[currentIntersection]
          );
          currentIntersection++;
          valueInserted = true;
          break;
        }
      }
      if (!valueInserted)
      {
        sortedIntersections.Add(
          intersections[currentIntersection]
        );
        currentIntersection++;
        valueInserted = false;
      }
    }
    return sortedIntersections;
  }
}
