class Program
{
  public static void Tick(Environment env, Projectile proj)
  {
    proj.position = proj.position + proj.velocity;
    proj.velocity = proj.velocity + env.gravity + env.wind;
  }

  public static void Run()
  {
    Vector gravity = new(0, -0.1f, 0);
    Vector wind = new(-0.01f, 0, 0);

    Point position = new(0, 1, 0);
    Vector velocity = new(6, 6, 0);

    Environment env = new(gravity, wind);
    Projectile proj = new(position, velocity);

    Canvas canvas = new(500, 500);
    canvas.FillCanvas(new(1, 1, 1));
    Color redColor = new(1, 0.5f, 0.5f);

    while (proj.position.y > 0f)
    {
      Tick(env, proj);
      Console.WriteLine(
                    $"{proj.position.x},{proj.position.y},{proj.position.z}");

      canvas.SetPixel(
          (int)proj.position.x, (int)proj.position.y, redColor);
    }
    canvas.Save("file");
  }

  static void Main(string[] args)
  {
    Run();
  }
}

