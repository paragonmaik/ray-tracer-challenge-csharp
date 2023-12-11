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

  public void SetPixel(int xAxis, int yAxis, Color color)
  {
    int x = xAxis - 1;
    int y = yAxis - 1;

    if (x < 0 && y < 0 && x >= width && y >= height)
    {
      return;
    }
    canvas[x, y] = color;
  }

  public void Save(string filename)
  {
    WritePPM(filename);
  }

  private void WritePPM(string filename)
  {
    string header = BuildHeader();
    string EOF = "\n";

    using (
        System.IO.StreamWriter sw = System.IO.File
        .CreateText(filename + ".ppm"))
    {
      sw.WriteLine(header);

      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < height; x++)
        {
          Color currentPixel = canvas[x, y];
          // string red = currentPixel.red
          sw.Write($" {currentPixel.red} {currentPixel.green} {currentPixel.blue} ");
        }
        sw.Write("\n");
      }

      sw.Write(EOF);
    }
  }

  private string BuildHeader()
  {
    int maxColorValue = 255;
    string header = "P3\n" +
      this.width + " " + this.height + "\n" + maxColorValue;

    return header;
  }

  private int NormalizeColor(float colorVal, int max, int min = 0)
  {
    int normalizedValue = (int)colorVal * max;

    if (normalizedValue > max) return max;
    if (normalizedValue < min) return min;

    return normalizedValue;
  }
}
