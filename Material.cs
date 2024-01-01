public class Material
{
  public Color color;
  private double ambient;
  private double diffuse;
  private double specular;
  private double shininess;

  public Material(
      Color color, double ambient, double diffuse,
      double specular, double shininess
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
}
