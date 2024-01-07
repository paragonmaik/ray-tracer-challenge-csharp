public class Camera
{
  public Camera()
  {
  }

  public Matrix ViewTransform(
      Point from, Point to, Vector up)
  {
    Vector forward = (to - from).Normalize();
    Vector upN = up.Normalize();
    Vector left = forward.Cross(upN);
    Vector trueUp = left.Cross(forward);

    Matrix orientation = new(new double[4, 4]{
      { left.x, left.y, left.z, 0},
      { trueUp.x, trueUp.y, trueUp.z,0},
      { -forward.x, -forward.y, -forward.z, 0},
      { 0, 0, 0, 1},
    });

    return orientation *
      new Matrix(4)
      .Translate(-from.x, -from.y, -from.z);
  }
}
