﻿public class Light
{
  public Color intensity;
  public Point position;

  public Light()
  {
    if (Scene.current != null)
    {
      Scene.current.AddLight(this);
    }

    intensity = new Color(1, 1, 1);
    position = new Point(0, 0, 0);
  }

  public Light(Point position, Color intensity)
  {
    if (Scene.current != null)
    {
      Scene.current.AddLight(this);
    }

    this.intensity = intensity;
    this.position = position;
  }

  public override string ToString()
  {
    return $"Intensity: {this
      .intensity}, Position: {this.position}";
  }
}
