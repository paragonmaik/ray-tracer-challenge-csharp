public class Scene
{
  public Scene()
  {
  }

  public Intersection Hit(List<Intersection> intersections)
  {
    if (intersections.Count == 0)
    {
      return null;
    }

    Intersection firstHit = null;

    foreach (var inter in intersections)
    {
      if (inter.t < 0.0f) continue;

      firstHit = inter;
      break;
    }

    return firstHit;
  }

}
