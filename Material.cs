public class Material
{
  public Color color;
  double ambient;
  double diffuse;
  double specular;
  double shinniness;

  public Material()
  {
    color = new Color(1, 1, 1);
    ambient = 0.1;
    diffuse = 0.9;
    specular = 0.9;
    shinniness = 200;
  }

  public Material(
    Color color,
    double ambient = 0.1,
    double diffuse = 0.9,
    double specular = 0.9,
    double shinniness = 200.0
  )
  {
    this.color = color;
    Ambient = ambient;
    Diffuse = diffuse;
    Specular = specular;
    Shinniness = shinniness;
  }

  public double Ambient
  {
    get { return ambient; }
    set
    {
      if (value < 0.0)
      {
        value = 0.0;
      }
      ambient = value;
    }
  }

  public double Diffuse
  {
    get { return diffuse; }
    set
    {
      if (value < 0.0)
      {
        value = 0.0;
      }
      diffuse = value;
    }
  }

  public double Specular
  {
    get { return specular; }
    set
    {
      if (value < 0.0)
      {
        value = 0.0;
      }
      specular = value;
    }
  }

  public double Shinniness
  {
    get { return shinniness; }
    set
    {
      if (value <= 10.0)
      {
        value = 10.0;
      }
      if (value > 200.0)
      {
        value = 200.0;
      }
      shinniness = value;
    }
  }

  public override string ToString()
  {
    return "Material-> Color: "
      + color.ToString()
      + " Ambient: "
      + ambient.ToString()
      + " Diffuse: "
      + diffuse.ToString()
      + " Specular: "
      + specular.ToString()
      + " Shinniness: "
      + shinniness.ToString();
  }

  public override bool Equals(object? obj)
  {
    var material = obj as Material;

    if (obj == null)
    {
      return false;
    }

    return material != null
      && EqualityComparer<Color>.Default.Equals(
        color,
        material.color
      )
      && ambient == material.ambient
      && diffuse == material.diffuse
      && specular == material.specular
      && shinniness == material.shinniness
      && Ambient == material.Ambient
      && Diffuse == material.Diffuse
      && Specular == material.Specular
      && Shinniness == material.Shinniness;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
