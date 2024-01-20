class Program
{
  public static void Tick(Projectile proj, Environment env)
  {
    proj.position = proj.position + proj.velocity;
    Console.WriteLine(proj.position);
    proj.velocity = proj.velocity + env.gravity + env.wind;
  }

  public static void RunSimulation() { }

  static void Main(string[] args)
  {
    Scene scene = new Scene();
    scene.Default();
    scene.ClearRayObjects();

    IntersectableObject floor = new Sphere();
    floor.SetMatrix(new Matrix(4).Scale(10, 0.01, 10));
    floor.material = new Material();
    floor.material.color = new Color(1, 0.9, 0.9);
    floor.material.Specular = 0;

    IntersectableObject leftWall = new Sphere();
    leftWall.SetMatrix(
      new Matrix(4).Translate(0, 0, 5)
        * new Matrix(4).RotateYAxis(Math.PI / -4.0)
        * new Matrix(4).RotateXAxis(Math.PI / 2.0)
        * new Matrix(4).Scale(10, 0.01f, 10)
    );

    leftWall.material = floor.material;

    IntersectableObject rightWall = new Sphere();
    rightWall.SetMatrix(
      new Matrix(4).Translate(0, 0, 5)
        * new Matrix(4).RotateYAxis(Math.PI / 4.0)
        * new Matrix(4).RotateXAxis(Math.PI / 2.0)
        * new Matrix(4).Scale(10, 0.01, 10)
    );
    IntersectableObject middle = new Sphere();
    middle.SetMatrix(new Matrix(4).Translate(-0.5, 1.0, 0.5));
    middle.material.color = new Color(0.1, 1.0, 0.5);
    middle.material.Diffuse = 0.7;
    middle.material.Specular = 0.3;

    IntersectableObject right = new Sphere();
    right.SetMatrix(
      new Matrix(4).Translate(1.5, 0.5, -0.5)
        * new Matrix(4).Scale(0.5, 0.5, 0.5)
    );
    right.material.color = new Color(0.5, 1.0, 0.1);
    right.material.Diffuse = 0.7;
    right.material.Specular = 0.3;

    IntersectableObject left = new Sphere();
    left.SetMatrix(
      new Matrix(4).Translate(-1.5, 0.33, -0.75)
        * new Matrix(4).Scale(0.33, 0.33, 0.33)
    );
    left.material.color = new Color(1, 0.8, 0.1);
    left.material.Diffuse = 0.7;
    left.material.Specular = 0.3;

    Light light = Scene.current.GetLights()[0];
    light.position = new Point(-10.0, 10.0, -10.0);
    light.intensity = new(1, 1, 1);

    Camera camera = new Camera(320, 260, Math.PI / 3.0);

    camera.ViewTransform(
      new Point(0, 1.5, -5.0),
      new Point(0, 1, 0),
      new Vector(0, 1, 0)
    );

    Canvas canvas = Scene.current.Render(camera);
    canvas.Save("file");

    Console.WriteLine(
      new Matrix(4).Translate(0, 0, 5)
        * new Matrix(4).RotateYAxis(Math.PI / -4.0)
        * new Matrix(4).RotateXAxis(Math.PI / 2.0)
        * new Matrix(4).Scale(10, 0.01f, 10)
    );
  }
}
