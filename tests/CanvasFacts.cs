using Xunit;

public class CanvasFacts
{
  public class Canvases
  {
    [Fact]
    public void ValidateCanvasInstantiation()
    {
      int width = 10;
      int height = 10;

      Canvas canvas = new(width, height);
      Color defaultCanvasColor = new();

      Assert.Equal(canvas.GetWidth(), width);
      Assert.Equal(canvas.GetWidth(), height);
      Assert.Equivalent(defaultCanvasColor, canvas.canvas[0, 0]);
    }
  }
}
