public class Scene
{
  // TODO: add list that concatenates all IntersectableObjects
  // iterate through all of them to invoke the Intersect
  // method passed to the IntersectWorld method
  public Light light;
  public Sphere innerSphere;
  public Sphere outerSphere;

  public Scene()
  {
    this.light = new(new(1, 1, 1), new(-10, 10, -10));
    this.innerSphere = new();
    this.outerSphere = new();
    DefaultScene();
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

  public Color ShadeHit(Computations c)
  {
    return c.intersectedObject.Lighting(
        c.point,
        this.light,
         c.eyeV, c.normalV
        );
  }

  public List<Intersection> IntersectWorld(Ray ray)
  {
    List<Intersection> intersections = new();
    List<Intersection> innerIntersections = innerSphere
      .Intersect(ray);
    List<Intersection> outerIntersections = outerSphere
      .Intersect(ray);

    intersections.Add(innerIntersections[0]);
    intersections.Add(innerIntersections[1]);
    intersections.Add(outerIntersections[0]);
    intersections.Add(outerIntersections[1]);

    List<Intersection> sortedIntersections = intersections
      .OrderBy(i => i.t).ToList();

    return sortedIntersections;
  }

  private void DefaultScene()
  {
    this.innerSphere = new();
    Material mat = new(new(0.8f, 1, 0.6f));

    mat.Diffuse = 0.7f;
    mat.Specular = 0.2f;
    innerSphere.material = mat;

    this.outerSphere
      .SetMatrix(this.outerSphere
      .GetMatrix()
      .Scale(0.5f, 0.5f, 0.5f));
  }
}
