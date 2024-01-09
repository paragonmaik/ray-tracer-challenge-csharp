using System.Text;

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
    // TODO: fix 2x2 multiplication bug
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
        temp[0],
        temp[1],
        temp[2],
        temp[3]
        );
  }

  public static Vector operator *(Matrix a, Vector b)
  {
    // TODO: fix 2x2 multiplication bug
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

    return new Vector(
        temp[0],
        temp[1],
        temp[2],
        temp[3]
        );
  }

  public static Point operator *(Matrix a, Point b)
  {
    // TODO: fix 2x2 multiplication bug
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

    return new Point(
        temp[0],
        temp[1],
        temp[2],
        temp[3]
        );
  }

  public Matrix Translate(double x, double y, double z)
  {
    Matrix mat = new Matrix(this).Identity();

    if (mat.GetSize() == 2)
    {
      mat[0, size - 1] = x;
      mat[1, size - 1] = y;
    }
    else
    {
      mat[0, size - 1] = x;
      mat[1, size - 1] = y;
      mat[2, size - 1] = z;
    }

    return mat;
  }

  public Matrix Translate(Point point)
  {
    Matrix mat = new Matrix(this).Identity();

    if (mat.GetSize() == 2)
    {
      mat[0, size - 1] = point.x;
      mat[1, size - 1] = point.y;
    }
    else
    {
      mat[0, size - 1] = point.x;
      mat[1, size - 1] = point.y;
      mat[2, size - 1] = point.z;
    }

    return mat;
  }

  public Matrix Translate(Vector vector)
  {
    Matrix mat = new Matrix(this).Identity();

    if (mat.GetSize() == 2)
    {
      mat[0, size - 1] = vector.x;
      mat[1, size - 1] = vector.y;
    }
    else
    {
      mat[0, size - 1] = vector.x;
      mat[1, size - 1] = vector.y;
      mat[2, size - 1] = vector.z;
    }

    return mat;
  }

  // TODO: overload method with point and vector signatures
  public Matrix Scale(double x, double y, double z)
  {
    Matrix mat = new Matrix(this).Identity();

    if (mat.GetSize() == 2)
    {
      mat[0, 0] = x;
      mat[1, 1] = y;
    }
    else
    {
      mat[0, 0] = x;
      mat[1, 1] = y;
      mat[2, 2] = z;
    }

    return mat;
  }

  public Matrix RotateXAxis(double x)
  {
    Matrix mat = new Matrix(this).Identity();

    mat[1, 1] = Math.Cos(x);
    mat[1, 2] = Math.Sin(x) * -1.0;
    mat[2, 1] = Math.Sin(x);
    mat[2, 2] = Math.Cos(x);

    return mat;
  }

  public Matrix RotateYAxis(double y)
  {
    Matrix mat = new Matrix(this).Identity();

    mat[0, 0] = Math.Cos(y);
    mat[2, 0] = Math.Sin(y) * -1.0;
    mat[0, 2] = Math.Sin(y);
    mat[2, 2] = Math.Cos(y);

    return mat;
  }

  public Matrix RotateZAxis(double z)
  {
    Matrix mat = new Matrix(this).Identity();

    mat[0, 0] = Math.Cos(z);
    mat[0, 1] = Math.Sin(z) * -1.0;
    mat[1, 0] = Math.Sin(z);
    mat[1, 1] = Math.Cos(z);

    return mat;
  }

  public Matrix Shear(
      double xy, double xz,
      double yx, double yz,
      double zx, double zy
      )
  {
    Matrix mat = new Matrix(this).Identity();

    mat[0, 1] = xy;
    mat[0, 2] = xz;
    mat[1, 0] = yx;
    mat[1, 2] = yz;
    mat[2, 0] = zx;
    mat[2, 1] = zy;

    return mat;
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
      return minor * -1f;
    }
  }

  public double Determinant()
  {
    double determinant = 0f;

    if (size == 2)
    {
      determinant = this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
    }
    else
    {
      for (var c = 0; c < size; c++)
      {
        determinant += this[0, c] * this.Cofactor(0, c);
      }
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

  public Matrix Inverse()
  {
    double determinant = this.Determinant();

    if (determinant == 0f)
    {
      throw new NonInvertibleMatrixException(
          "Determinant equals 0, Matrix cannot be inverted"
          );
    }
    Matrix retVal = new(size);
    Matrix a = new(this);

    for (int r = 0; r < this.size; r++)
    {
      for (int c = 0; c < this.size; c++)
      {
        retVal[r, c] = Cofactor(c, r) / determinant;
      }
    }

    return retVal;
  }

  // Private methods
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

    for (int r = 0; r < mat.size; r++)
    {
      for (int c = 0; c < mat.size; c++)
      {
        temp[r, c] = mat[r, c];
      }
    }
    return temp;
  }

  // Overridden methods
  public override string ToString()
  {
    StringBuilder matrixString = new StringBuilder();

    for (int r = 0; r < size; r++)
    {
      matrixString
          .Append("| ");
      for (int c = 0; c < size; c++)
      {
        if (c != 0)
        {
          matrixString
            .Append(" | ")
            .Append(Math.Round(this[r, c], 5));

          continue;
        }
        matrixString.Append(Math.Round(this[r, c], 5));
      }
      matrixString
        .Append(" |")
        .AppendLine();
    }

    return matrixString.ToString().Replace("-0 ", "0 ");
  }

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
        if ((Math.Abs(this[r, c])
              - Math.Abs(matB[r, c])) > 0.001f) return false;
      }
    }

    return true;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }
}
