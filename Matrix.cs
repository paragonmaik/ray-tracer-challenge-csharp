public class Matrix
{
  private double[,] values;
  private int size;

  public Matrix(Matrix mat)
  {
    this.values = CastMatrixToValArray(mat);
    this.size = mat.size;
  }

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
          mat[r, c] += a[r, q] * b[q, c];
        }
      }
    }

    return mat;
  }

  public static Tupl operator *(Matrix a, Tupl b)
  {
    int size = a.GetSize();
    double[] temp = new double[size];
    double[] temp2 = { b.x, b.y, b.z, b.w };

    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        temp[r] += a[r, c] * temp2[c];
      }
    }

    return new Tupl(
        (float)temp[0],
        (float)temp[1],
        (float)temp[2],
        (float)temp[3]
        );
  }

  public Matrix Identity()
  {
    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        if (r == c)
        {
          this[r, c] = 1;
        }
        else
        {
          this[r, c] = 0;
        }
      }
    }

    return this;
  }

  public Matrix Transpose()
  {
    Matrix transposedMatrix = new(4);

    for (int c = 0; c < size; c++)
    {
      for (int r = 0; r < size; r++)
      {
        transposedMatrix[r, c] = this[c, r];
      }
    }

    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        this[r, c] = transposedMatrix[r, c];
      }
    }

    return this;
  }

  public double Determinant()
  {
    if (this.size == 2)
    {
      return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
    }
    return 0;
  }

  private void ValidateMatrixLength()
  {
    if (values.GetLength(0) != values.GetLength(1))
    {
      throw new ArgumentNullException("Height and width should have the same length.");
    }
    this.size = values.GetLength(0);
  }

  private double Calculate2x2Det()
  {
    return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
  }

  private double[,] CastMatrixToValArray(Matrix mat)
  {
    double[,] temp = new double[mat.size, mat.size];

    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        temp[r, c] = mat[r, c];
      }
    }

    return temp;
  }
}
