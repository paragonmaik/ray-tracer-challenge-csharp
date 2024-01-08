using Xunit;

public class CameraFacts
{
  public class Cameras
  {
    [Fact]
    public void ValidateCameraInstantiation()
    {
      Camera cam = new();

      Assert.Equal(160, cam.hsize);
      Assert.Equal(120, cam.vsize);
      Assert.Equal(Math.PI / 2, cam.fov);
    }

    [Theory]
    [InlineData(200, 125, Math.PI / 2)]
    [InlineData(125, 200, Math.PI / 2)]
    public void ValidateCanvasPixelSize(
        int hsize, int vsize, double fov
        )
    {
      Camera cam = new(hsize, vsize, fov);

      Assert.True(
          Math.Abs(0.01f - cam.PixelSize) < 0.01);
    }

    [Fact]
    public void ValidateDefaultMatrixOrientation()
    {
      Camera cam = new();
      Point from = new(0, 0, 0);
      Point to = new(0, 0, -1);
      Vector up = new(0, 1, 0);
      Matrix expectedViewTransform = new Matrix(4)
        .Identity();

      Matrix actualViewTransform = cam
        .ViewTransform(from, to, up);

      Assert.Equal(expectedViewTransform, actualViewTransform);
    }

    [Fact]
    public void ValidateViewTransformZDirection()
    {
      Camera cam = new();
      Point from = new(0, 0, 0);
      Point to = new(0, 0, 1);
      Vector up = new(0, 1, 0);
      Matrix expectedViewTransform = new Matrix(4)
        .Scale(-1, -1, -1);

      Matrix actualViewTransform = cam
        .ViewTransform(from, to, up);

      Assert.Equal(expectedViewTransform, actualViewTransform);
    }

    [Fact]
    public void ValidateViewTransformsMoveScene()
    {
      Camera cam = new();
      Point from = new(0, 0, 0);
      Point to = new(0, 0, 0);
      Vector up = new(0, 1, 0);
      Matrix expectedViewTransform = new Matrix(4)
        .Translate(0, 0, -8);
      Matrix actualViewTransform = cam
        .ViewTransform(from, to, up);
      Assert.Equal(expectedViewTransform, actualViewTransform);
    }

    [Fact]
    public void ValidateArbitraryViewTransformation()
    {
      Camera cam = new(); Point from = new(1, 3, 2); Point to = new(4, -2, 8); Vector up = new(1, 1, 0);
      Matrix expectedViewTransform = new(new double[4, 4]{
       { -0.50709 , 0.50709 , 0.67612 , -2.36643 },
       { 0.76772 , 0.60609 , 0.12122 , -2.82843 },
       { -0.35857 , 0.59761 , -0.71714 , 0.00000 },
       { 0.00000 , 0.00000 , 0.00000 , 1.00000 }
      });

      Matrix actualViewTransform = cam
        .ViewTransform(from, to, up);

      Assert.Equal(expectedViewTransform, actualViewTransform);
    }
  }
}
