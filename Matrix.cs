public class Matrix
{
  private double[,] values;
  private int size;

  public Matrix(int size)
  {
    this.size = size;
    this.values = new double[size, size];
  }

  public Matrix(double[,] values)
  {
    this.values = values;
    ValidateMatrixLength();
  }

  private void ValidateMatrixLength()
  {
    if (values.GetLength(0) != values.GetLength(1))
    {
      throw new ArgumentNullException("Height and width should have the same length.");
    }
    this.size = values.GetLength(0);
  }

  public int GetSize() { return size; }

  public double this[int i, int j]
  {
    get { return values[i, j]; }
    set { values[i, j] = value; }
  }

  public static Matrix operator *(Matrix a, Matrix b)
  {
    int size = a.GetSize();
    Matrix mat = new(size);

    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        for (int q = 0; q < size; q++)
        {
          mat[r, c] += a[r, q] * b[q, r];
        }
      }
    }


    return mat;
  }

  // TODO: add ToString method
}
