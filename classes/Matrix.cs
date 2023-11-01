using busca_largura.extensions;

public class Matrix {
    public int?[][] Values;

    public Matrix(int? v1, int? v2, int? v3, int? v4, int? v5, int? v6, int? v7, int? v8, int? v9){
        var array1 = new int?[3] { v1, v2, v3};
        var array2 = new int?[3] { v4, v5, v6};
        var array3 = new int?[3] { v7, v8, v9};

        Values = new int?[][] {array1, array2, array3};
    }

    public Matrix()
    {
    }

    public Matrix(int?[][] values)
    {
        Values = values;
    }

    public override string ToString(){
        foreach(var array in Values){
            Console.WriteLine(string.Format($"{array[0].ToStringOrEmpty()} | {array[1].ToStringOrEmpty()} | {array[2].ToStringOrEmpty()}"));
        }

        return string.Empty;
    }

    public override bool Equals(object? obj)
    {
        if (Values == null) {
            return false;
        }

        var matrix2 = obj ==  null ? new Matrix() : (Matrix)obj;

        return CheckEquality(Values[0], matrix2.Values[0]) && CheckEquality(Values[1], matrix2.Values[1]) && CheckEquality(Values[2], matrix2.Values[2]);
    }

    private bool CheckEquality<T>(T[] first, T[] second)
    {
        return Enumerable.SequenceEqual(first, second);
    }
}