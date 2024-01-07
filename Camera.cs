public class Camera
{
  public int hsize;
  public int vsize;
  public double fov;
  public Matrix tranform;

  public Camera()
  {
    this.hsize = 160;
    this.vsize = 120;
    this.fov = Math.PI / 2;
    this.tranform = new Matrix(4).Identity();
  }

  public Camera(int hsize, int vsize,
      double fov)
  {
    this.hsize = hsize;
    this.vsize = vsize;
    this.fov = fov;
    this.tranform = new Matrix(4).Identity();
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
