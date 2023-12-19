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

  public double Minor(int row, int column)
  {
    Matrix submatrix = this.SubMatrix(row, column);
    return submatrix.Determinant();
  }

  public double Cofactor(int row, int column)
  {
    double minor = this.Minor(row, column);

    if (((row + column) % 2) == 0)
    {
      return minor;
    }
    else
    {
      return -minor;
    }
  }

  public double Determinant()
  {
    double determinant = 0f;

    if (size == 2)
    {
      determinant = Calculate2x2Det();
    }
    if (size == 3)
    {
      determinant = Calculate3x3Det();
    }
    if (size == 4)
    {
    }

    return determinant;
  }

  public Matrix SubMatrix(int row, int column)
  {
    if (size < 3)
    {
      throw new ArgumentNullException();
    }

    if (row >= size || column >= size)
    {
      throw new ArgumentNullException();
    }

    Matrix submatrix = new(size - 1);
    int i = 0;

    for (var r = 0; r < size; r++)
    {
      int j = 0;

      if (r == row) continue;

      for (var c = 0; c < size; c++)
      {
        if (c == column) continue;

        submatrix[i, j] = this[r, c];
        j++;
      }
      i++;
    }

    return submatrix;
  }

  // Private methods

  private double Calculate2x2Det()
  {
    return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
  }

  private double Calculate3x3Det()
  {
    return this[0, 0] * this.Cofactor(0, 0) +
            this[0, 1] * this.Cofactor(0, 1) +
            this[0, 2] * this.Cofactor(0, 2);
  }

  private void ValidateMatrixLength()
  {
    if (values.GetLength(0) != values.GetLength(1))
    {
      throw new ArgumentNullException("Height and width should have the same length.");
    }
    this.size = values.GetLength(0);
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

  // Overridden methods

  public override bool Equals(object? obj)
  {
    if (obj == null)
    {
      return false;
    }

    Matrix matB = (Matrix)obj;


    for (int r = 0; r < size; r++)
    {
      for (int c = 0; c < size; c++)
      {
        if (this[r, c] != matB[r, c]) return false;
      }
    }

    return true;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
