public class Camera
{
  public int hsize;
  public int vsize;
  public double fov;
  public Matrix transform;
  private double pixelSize;
  private double halfWidth;
  private double halfHeight;

  public Camera()
  {
    this.hsize = 160;
    this.vsize = 120;
    this.fov = Math.PI / 2;
    this.transform = new Matrix(4).Identity();
    CalculatePixelSize();
  }

  public Camera(int hsize, int vsize,
      double fov)
  {
    this.hsize = hsize;
    this.vsize = vsize;
    this.fov = fov;
    this.transform = new Matrix(4).Identity();
    CalculatePixelSize();
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

  private void CalculatePixelSize()
  {
    double halfView = Math.Tan(this.fov / 2);
    double aspect = this.hsize / this.vsize;

    if (aspect >= 1)
    {
      this.halfWidth = halfView;
      this.halfHeight = halfView / aspect;
    }
    else
    {
      this.halfWidth = halfView * aspect;
      this.halfHeight = halfView;
    }
    this.pixelSize = (this.halfWidth * 2) / this.hsize;
  }

  public double PixelSize
  {
    get { return pixelSize; }
  }

  public double HalfWidth
  {
    get { return halfWidth; }
  }

  public double HalfHeight
  {
    get { return halfHeight; }
  }
}