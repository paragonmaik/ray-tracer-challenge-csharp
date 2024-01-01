public class Light
{
  public Color intensity;
  public Point position;

  public Light(Color intensity, Point position)
  {
    this.intensity = intensity;
    this.position = position;
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
