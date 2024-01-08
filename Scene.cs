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

  public Color ColorAt(Ray ray)
  {
    List<Intersection> intersections = IntersectWorld(ray);
    if (intersections.Count() == 0)
    {
      return new(0, 0, 0);
    }

    Intersection hit = Hit(intersections);
    Computations c = new(hit, ray);

    return ShadeHit(c);
  }

  // TODO: rework after adding list that concatenates
  // all of the IntersectableObjects
  public List<Intersection> IntersectWorld(Ray ray)
  {
    List<Intersection> intersections = new();
    List<Intersection> innerIntersections = innerSphere
      .Intersect(ray);
    List<Intersection> outerIntersections = outerSphere
      .Intersect(ray);

    if (innerIntersections.Count() > 0)
    {
      intersections.Add(innerIntersections[0]);
      intersections.Add(innerIntersections[1]);
    }

    if (outerIntersections.Count() > 0)
    {
      intersections.Add(outerIntersections[0]);
      intersections.Add(outerIntersections[1]);
    }

    List<Intersection> sortedIntersections = intersections
    .OrderBy(i => i.t).ToList();

    return sortedIntersections;
  }

  public Ray RayForPixel(Camera cam, int px, int py)
  {
    double xOffset = (px + 0.5) * cam.PixelSize;
    double yOffset = (py + 0.5) * cam.PixelSize;

    float worldX = (float)(cam.HalfWidth - xOffset);
    float worldY = (float)(cam.HalfHeight - yOffset);

    Point pixel = cam.transform
      .Inverse() * new Point(worldX, worldY, -1);
    Point origin = cam.transform.Inverse() * new Point(0, 0, 0);
    Vector direction = (pixel - origin).Normalize();

    return new(origin, direction);
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
