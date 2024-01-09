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
      for (int j = 0; j < height; j++)
      {
        canvas[i, j] = color;
      }
    }
  }

  public void SetPixel(int x, int y, Color color)
  {
    if (x > 0 && y > 0 && x < width && y < height)
    {
      canvas[x, y] = color;
    }
  }

  public Color GetPixel(int x, int y)
  {
    return canvas[x, y];
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
          string red = NormalizeColor(currentPixel.red, 255).ToString();
          string green = NormalizeColor(currentPixel.green, 255).ToString();
          string blue = NormalizeColor(currentPixel.blue, 255).ToString();

          sw.Write($" {red} {green} {blue} ");
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

  private int NormalizeColor(double colorVal, int max, int min = 0)
  {
    int normalizedValue = (int)colorVal * max;

    if (normalizedValue > max) return max;
    if (normalizedValue < min) return min;

    return normalizedValue;
  }
}
