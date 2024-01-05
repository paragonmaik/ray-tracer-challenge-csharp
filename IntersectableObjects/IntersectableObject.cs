public abstract class IntersectableObject
{
  public Material material;
  protected Point origin;
  protected Guid id;
  protected Matrix mat;

  public IntersectableObject()
  {
    this.material = new(new(1, 1, 1));
    this.origin = new();
    this.id = Guid.NewGuid();
    this.mat = new Matrix(4).Identity();
  }

  public Point Origin() { return this.origin; }
  public Matrix GetMatrix() { return this.mat; }
  public void SetMatrix(Matrix mat) { this.mat = mat; }

  public abstract List<Intersection> Intersect(Ray ray);
  public abstract Vector NormalAt(Point point);

  public Color Lighting(Point position, Light light, Vector eye, Vector normal, bool inShadow = false)
  {
    Material material = new(new(1, 1, 1));
    Color temp = material.color;
    Color effectiveColor = temp * light.intensity;
    Vector lightVec = (light.position - position).Normalize();
    Color ambientColor = temp * (float)material.Ambient;
    Color diffuseColor;
    Color specularColor;

    double lDotN = lightVec.Dot(normal);

    if (lDotN <= 0)
    {
      diffuseColor = new(0, 0, 0);
      specularColor = new(0, 0, 0);
    }
    else
    {
      diffuseColor = effectiveColor * (float)material.Diffuse * (float)lDotN;
      Vector reflect = new Vector().Reflect(-lightVec, normal);
      double rDotE = reflect.Dot(eye);

      // Console.WriteLine(rDotE);
      if (rDotE <= 0)
        specularColor = new(0, 0, 0);
      else
      {
        double factor = (double)Math.Pow((double)rDotE, (double)material.Shininess);
        specularColor = light.intensity * (float)material.Specular * (float)factor;
      }
    }

    return ambientColor + diffuseColor + specularColor;
  }
}
