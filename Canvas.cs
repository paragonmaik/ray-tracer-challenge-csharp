public class Canvas
{
  private int width;
  private int height;
  public Color[,] canvas;

  public Canvas(int width, int height)
  {
    this.width = width;
    this.height = height;
    this.canvas = new Color[width, height];
    FillCanvas(new());
  }

  public int GetWidth()
  {
    return width;
  }

  public int GetHeight()
  {
    return height;
  }

  public void FillCanvas(Color color)
  {
    for (int x = 0; x < width; x++)
    {
      for (int y = 0; y < height; y++)
      {
        canvas[x, y] = new Color(color);
      }
    }
  }

  public void SetPixel(int x, int y, Color color)
  {
    if (x >= 0 && y >= 0 && x < width && y < height)
    {
      canvas[x, y] = color;
    }
  }

  public Color GetPixel(int x, int y)
  {
    Color temp = new Color();

    if (x >= 0 && y >= 0 && x < width && y < height)
    {
      temp = canvas[x, y];
    }
    return temp;
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
      System.IO.StreamWriter sw = System.IO.File.CreateText(
        filename + ".ppm"
      )
    )
    {
      sw.WriteLine(header);
      WriteBody(sw);
      sw.Write(EOF);
      sw.Close();
    }
  }

  private void WriteBody(System.IO.StreamWriter sw)
  {
    string currentLine = "";

    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        Color color = GetPixel(x, y);

        string red = NormalizeColor(color.r * 255).ToString();
        string green = NormalizeColor(color.g * 255).ToString();
        string blue = NormalizeColor(color.b * 255).ToString();

        currentLine = $" {red} {green} {blue} ";

        sw.WriteLine(currentLine);
      }
    }
  }

  private string BuildHeader()
  {
    int maxColorValue = 255;
    string header =
      "P3\n"
      + this.width
      + " "
      + this.height
      + "\n"
      + maxColorValue;

    return header;
  }

  private int NormalizeColor(
    double colorVal,
    int max = 255,
    int min = 0
  )
  {
    int normalizedValue = (int)colorVal;
    if (normalizedValue > max)
    {
      normalizedValue = max;
      return normalizedValue;
    }
    if (normalizedValue < min)
    {
      normalizedValue = min;
    }
    return normalizedValue;
  }
}
