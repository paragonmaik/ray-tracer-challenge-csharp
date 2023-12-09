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
    Vector velocity = new(1, 1, 0);

    Environment env = new(gravity, wind);
    Projectile proj = new(position, velocity);


    while (proj.position.y > 0f)
    {
      Tick(env, proj);
      Console.WriteLine(
                    $"{proj.position.x},{proj.position.y},{proj.position.z}");

    }
  }

  static void Main(string[] args)
  {
    Run();
  }
}

