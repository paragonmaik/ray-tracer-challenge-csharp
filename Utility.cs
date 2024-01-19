public static class Utility
{
  public static double epsilon = 0.001;
  public static double Infinity = 1e10;

  public static double DegToRad(double degrees)
  {
    return degrees * (Math.PI / 180.0);
  }

  public static bool FE(double a, double b)
  {
    double temp = Math.Abs(a - b);

    if (temp < epsilon)
    {
      return true;
    }
    return false;
  }
}
