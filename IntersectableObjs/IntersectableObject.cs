public abstract class IntersectableObject
{
  public enum Axis
  {
    X,
    Y,
    Z
  }

  protected static int currentId = 0;
  protected int id;
  public Material material;
  public bool canReceiveShadows = true;
  public bool canCastShadows = true;

  protected Matrix matrix = new(4);
  protected IntersectableObject parent = null;
  protected List<IntersectableObject> children =
    new List<IntersectableObject>();

  public IntersectableObject GetParent()
  {
    return parent;
  }

  public bool Includes(IntersectableObject o)
  {
    if (this == o)
    {
      return true;
    }

    foreach (IntersectableObject i in GetChildren())
    {
      if (i.Includes(o))
        return true;
    }

    return false;
  }

  public List<IntersectableObject> GetChildren()
  {
    return children;
  }

  public void SetParent(IntersectableObject newParent)
  {
    if (parent != null)
    {
      parent.RemoveChild(this);
    }

    if (newParent != null)
    {
      newParent.AddChild(this);
    }
    else if (Scene.current.objects != null)
    {
      Scene.current.objects.AddChild(this);
    }
    else
    {
      Console.WriteLine(
        "Root group of scene successfully created."
      );
    }
  }

  protected void AddChild(IntersectableObject newChild)
  {
    if (newChild.parent != this)
    {
      children.Add(newChild);
    }
    newChild.parent = this;
  }

  protected void RemoveChild(IntersectableObject child)
  {
    if (child.parent == this)
    {
      children.Remove(child);
    }
    child.parent = null;
  }

  public void SetMatrix(Matrix matrix)
  {
    this.matrix = matrix;
  }

  public Matrix GetMatrix()
  {
    return this.matrix;
  }

  public void SetPosition(Point point)
  {
    this.matrix[0, 3] = point.x;
    this.matrix[1, 3] = point.y;
    this.matrix[2, 3] = point.z;
  }

  public Point GetPosition()
  {
    return new Point(
      this.matrix[0, 3],
      this.matrix[1, 3],
      this.matrix[2, 3]
    );
  }

  protected virtual Ray RayToObjectSpace(Ray ray)
  {
    return ray * GetMatrix().Inverse();
  }

  public int Id
  {
    get { return id; }
    private set { id = value; }
  }

  public IntersectableObject()
  {
    if (Scene.current != null)
    {
      this.SetParent(Scene.current.objects);
      Scene.current.AddRayObject(this);
    }

    id = currentId++;
    material = new Material();
  }

  public abstract Vector CalculateLocalNormal(
    Point localPoint,
    Intersection i = null
  );

  public Vector GetNormal(
    Point worldPoint,
    Intersection i = null
  )
  {
    Point localPoint = this.WorldToObject(worldPoint);
    Vector localNormal = CalculateLocalNormal(localPoint, i);
    Vector worldNormal = NormalToWorld(localNormal);
    return worldNormal;
  }

  public override string ToString()
  {
    return "RayObject: " + id.ToString();
  }

  public abstract List<Intersection> Intersect(Ray ray);

  public Color Lighting(
    Point position,
    Light light,
    Vector eye,
    Vector normal,
    bool inShadow = false
  )
  {
    Color temp = material.color;

    Color effectiveColor = temp * light.intensity;
    Vector lightVec = (light.position - position).Normalize();
    Color ambientColor = temp * material.Ambient;
    Color diffuseColor;
    Color specularColor;

    if (inShadow)
      return ambientColor;

    double lDotN = lightVec.Dot(normal);
    if (lDotN <= 0)
    {
      diffuseColor = new();
      specularColor = new();
    }
    else
    {
      diffuseColor = effectiveColor * material.Diffuse * lDotN;
      Vector reflect = Vector.Reflect(-lightVec, normal);
      double rDotE = reflect.Dot(eye);

      if (rDotE <= 0)
        specularColor = new();
      else
      {
        double factor = (double)
          Math.Pow((double)rDotE, (double)material.Shinniness);
        specularColor =
          light.intensity * material.Specular * factor;
      }
    }

    return ambientColor + diffuseColor + specularColor;
  }

  public Point WorldToObject(Point p)
  {
    if (this.GetParent() != null)
    {
      p = this.GetParent().WorldToObject(p);
    }

    return this.GetMatrix().Inverse() * p;
  }

  public Vector NormalToWorld(Vector n)
  {
    n = this.GetMatrix().Inverse().Transpose() * n;
    n.w = 0;
    n.Normalize();

    if (this.GetParent() != null)
    {
      n = this.GetParent().NormalToWorld(n);
    }

    return n;
  }
}
