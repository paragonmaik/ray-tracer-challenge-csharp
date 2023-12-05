public class Vector : Tupl
{
  public Vector() : base(0f, 0f, 0f, 0f)
  {
  }

  public Vector(float x = 0f, float y = 0f,
      float z = 0f, float w = 0f) : base(x, y, z, w)
  {
    this.w = 0f;
  }
}

