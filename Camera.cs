public class Camera
{
  public int hSize;
  public int vSize;
  public double fov;
  public Matrix transform;
  private double pixelSize;
  private double halfWidth;
  private double halfHeight;

  public Camera(
    int hSize = 160,
    int vSize = 120,
    double fieldOfView = Math.PI / 2
  )
  {
    this.hSize = hSize;
    this.vSize = vSize;
    fov = fieldOfView;
    transform = new Matrix(4);
    CalculatePixelSize();
  }

  public Matrix ViewTransform(Point from, Point to, Vector up)
  {
    up = up.Normalize();
    Vector forward = (to - from).Normalize();

    Vector left = forward.Cross(up);

    Vector trueUp = left.Cross(forward);

    Matrix orientation =
      new(
        new double[4, 4]
        {
          { left.x, left.y, left.z, 0 },
          { trueUp.x, trueUp.y, trueUp.z, 0 },
          { -forward.x, -forward.y, -forward.z, 0 },
          { 0, 0, 0, 1 },
        }
      );

    transform =
      orientation
      * new Matrix(4).Translate(-from.x, -from.y, -from.z);
    return transform;
  }

  public void CalculatePixelSize()
  {
    double halfView = Math.Tan(this.fov / 2);
    double aspect = this.hSize / this.vSize;

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

    this.pixelSize = (this.halfWidth * 2) / this.hSize;
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
