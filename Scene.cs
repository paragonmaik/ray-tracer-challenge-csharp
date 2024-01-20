public class Scene
{
  public static Scene current = null;
  public IntersectableObjs objects;
  private List<Light> lights;
  private List<IntersectableObject> rayObjects;

  public Scene()
  {
    if (current == null)
    {
      current = this;
      new Random();
    }

    lights = new List<Light>();
    rayObjects = new List<IntersectableObject>();
    objects = new IntersectableObjs();
    Default();
  }

  public List<Light> GetLights()
  {
    return lights;
  }

  public List<IntersectableObject> GetRayObjects()
  {
    return rayObjects;
  }

  public void ClearRayObjects()
  {
    rayObjects = new List<IntersectableObject>();
    objects = new IntersectableObjs();
  }

  public void ClearLights()
  {
    lights = new List<Light>();
  }

  public void Clear()
  {
    ClearRayObjects();
    ClearLights();
  }

  public void AddLight(Light light)
  {
    lights.Add(light);
  }

  public void AddRayObject(IntersectableObject rayObject)
  {
    rayObjects.Add(rayObject);
  }

  public List<Intersection> Intersections(Ray ray)
  {
    List<Intersection> intersections = new List<Intersection>();

    intersections = objects.Intersect(ray);

    return Intersection.SortIntersections(intersections);
  }

  public Intersection Hit(List<Intersection> intersections)
  {
    intersections = Intersection.SortIntersections(
      intersections
    );
    if (intersections.Count == 0)
    {
      return null;
    }

    Intersection first = null;
    for (int i = 0; i < intersections.Count; i++)
    {
      if (intersections[i].t < 0.0)
      {
        continue;
      }
      else
      {
        first = intersections[i];
        break;
      }
    }

    return first;
  }

  public Color ShadeHit(Computations c)
  {
    return c.rayObject.Lighting(
      c.point,
      this.lights[0],
      c.eye,
      c.normal
    );
  }

  public Color ColorAt(Ray ray, int remaining = 1)
  {
    List<Intersection> intersections = this.Intersections(ray);
    if (intersections.Count() == 0)
    {
      return new();
    }

    Intersection hit = this.Hit(intersections);
    Computations c = Computations.Prepare(
      hit,
      ray,
      intersections
    );

    return Scene.current.ShadeHit(c);
  }

  public Ray RayForPixel(Camera cam, int px, int py)
  {
    double xOffset = (px + 0.5) * cam.PixelSize;
    double yOffset = (py + 0.5) * cam.PixelSize;

    double worldX = cam.HalfWidth - xOffset;
    double worldY = cam.HalfHeight - yOffset;

    Point pixel =
      cam.transform.Inverse() * new Point(worldX, worldY, -1);
    Point origin = cam.transform.Inverse() * new Point(0, 0, 0);
    Vector direction = (pixel - origin).Normalize();

    return new(origin, direction);
  }

  public Canvas Render(Camera cam)
  {
    Canvas image = new Canvas(cam.hSize, cam.vSize);

    for (int y = 0; y < cam.vSize; y++)
    {
      for (int x = 0; x < cam.hSize; x++)
      {
        Ray temp = this.RayForPixel(cam, x, y);
        Color pixelColor = this.ColorAt(temp);
        image.SetPixel(x, y, pixelColor);
      }
    }
    return image;
  }

  public void Default()
  {
    this.Clear();
    Light light = new Light(
      new Point(-10, 10, -10),
      new Color(1, 1, 1)
    );
    Sphere s1 = new Sphere();
    Sphere s2 = new Sphere();

    s1.material = new Material(new Color(0.8, 1.0, 0.6));
    s1.material.Diffuse = 0.7;
    s1.material.Specular = 0.2;
    s2.SetMatrix(new Matrix(4).Scale(0.5, 0.5, 0.5));
  }
}
