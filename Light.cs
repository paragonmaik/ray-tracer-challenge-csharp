public class Light
{
  public Color intensity;
  public Point position;

  public Light(Color intensity, Point position)
  {
    this.intensity = intensity;
    this.position = position;
  }

  public Color Lighting(
      Material ma, Point p, Vector eyeV, Vector normalV)
  {
    Material m = new(new(1, 1, 1));
    Color diffuseColor = new();
    Color specularColor = new();

    Color effectiveColor = m.color * this.intensity;
    Vector lightV = (this.position - p).Normalize();
    Color ambientColor = effectiveColor * (float)m.Ambient;
    double lightDotNormal = lightV.Dot(normalV);

    if (lightDotNormal < 0)
    {
      diffuseColor = new(0, 0, 0);
      specularColor = new(0, 0, 0);
    }
    else
    {
      diffuseColor = effectiveColor *
        (float)m.Diffuse * (float)lightDotNormal;
      Vector reflectV = new Vector()
        .Reflect(-lightV, normalV);
      double reflectDotEye = reflectV.Dot(eyeV);

      if (reflectDotEye <= 0)
      {
        specularColor = new(0, 0, 0);
      }
      else
      {
        double factor = (double)Math
          .Pow(reflectDotEye, m.Shininess);
        specularColor = this.intensity *
          (float)m.Specular * (float)factor;
      }
    }

    return ambientColor + diffuseColor + specularColor;
  }

  public override string ToString()
  {
    return $"Intensity: {this.intensity}, Position: {this.position}";
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    Light light = (Light)obj;

    if (this.intensity != light.intensity)
    {
      return false;
    }

    if (this.position != light.position)
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
