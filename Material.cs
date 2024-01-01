public class Material
{
  public Color color;
  private double ambient;
  private double diffuse;
  private double specular;
  private double shininess;

  public Material(
      Color color, double ambient = 0.1f, double diffuse = 0.9f,
      double specular = 0.9f, double shininess = 200f
      )
  {
    this.color = color;
    this.ambient = ambient;
    this.diffuse = diffuse;
    this.specular = specular;
    this.shininess = shininess;
  }

  public double Ambient
  {
    get { return ambient; }
    set
    {
      if (value < 0.0)
      { value = 0.0; }
      ambient = value;
    }
  }

  public double Diffuse
  {
    get { return diffuse; }
    set
    {
      if (value < 0.0)
      { value = 0.0; }
      diffuse = value;
    }
  }

  public double Specular
  {
    get { return specular; }
    set
    {
      if (value < 0.0)
      { value = 0.0; }
      specular = value;
    }
  }

  public double Shininess
  {
    get { return shininess; }
    set
    {
      if (value <= 10.0)
      { value = 10.0; }
      if (value > 200.0)
      {
        value = 200.0;
      }
      shininess = value;
    }
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    Material material = (Material)obj;

    if (this.color != material.color)
    {
      return false;
    }

    if (Math.Abs(this.ambient) -
        Math.Abs(material.Ambient) < 0001f)
    {
      return false;
    }

    if (Math.Abs(this.diffuse) -
            Math.Abs(material.Diffuse) < 0001f)
    {
      return false;
    }

    if (Math.Abs(this.specular) -
            Math.Abs(material.Specular) < 0001f)
    {
      return false;
    }

    if (Math.Abs(this.shininess) -
               Math.Abs(material.Shininess) < 0001f)
    {
      return false;
    }

    return true;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
