public class Canvas
{
  private int width;
  private int height;
  public Color[,] canvas;

  public Canvas(int width, int height)
  {
    this.width = width;
    this.height = height;
    canvas = new Color[width, height];
    FillCanvas(new());
  }

  public int GetWidth() { return width; }
  public int GetHeight() { return height; }

  public void FillCanvas(Color color)
  {
    for (int i = 0; i < width; i++)
    {
      for (int j = 0; j < width; j++)
      {
        canvas[i, j] = color;
      }
    }
  }
}
