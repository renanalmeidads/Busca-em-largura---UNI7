namespace busca_largura.classes
{
    public class BreadthFirst
    {
        public List<ConsoleKey> Operations { get; private set; }
        public Matrix Goal { get; private set; }
        public Matrix Initial { get; private set; }

        public BreadthFirst(Matrix initial, Matrix goal, List<ConsoleKey> operations)
        {
            Operations = operations;
            Goal = goal;
            Initial = initial;
        }

        public void Execute() {
            Console.WriteLine("Initial");
            Initial.ToString();

            Console.WriteLine("Goal");
            Goal.ToString();

            var openMatrixList = new List<Matrix>() { Initial };
            var closeMatrixList = new List<Matrix>();

            var iteration = 0;

            while (openMatrixList.FirstOrDefault() != null && !openMatrixList.First().Equals(Goal)) {
                Console.WriteLine($"================={++iteration}=================");

                var firstMatrix = openMatrixList.First();

                var currentMatrixList = new List<Matrix>();

                foreach (var operation in Operations) 
                {
                    var newMatrix = ApplyOperationToMatrix(firstMatrix, operation);

                    if (newMatrix != null && !openMatrixList.Contains(newMatrix))
                    {
                        currentMatrixList.Add(newMatrix);
                    }
                }

                closeMatrixList.Add(firstMatrix);
                openMatrixList.RemoveAt(0);

                openMatrixList.AddRange(currentMatrixList);
            }

            if (openMatrixList.FirstOrDefault() != null)
            {
                Console.WriteLine($"================={++iteration}=================");

                Console.WriteLine(openMatrixList.FirstOrDefault());
            }
        }

        private Matrix ApplyOperationToMatrix(Matrix matrix, ConsoleKey operation) 
        {
            var nullLocation = GetNullLocation(matrix);

            var newMatrix = new Matrix(matrix.Values[0][0],
                matrix.Values[0][1],
                matrix.Values[0][2],
                matrix.Values[1][0],
                matrix.Values[1][1],
                matrix.Values[1][2],
                matrix.Values[2][0],
                matrix.Values[2][1],
                matrix.Values[2][2]);

            switch (operation) {
                case ConsoleKey.UpArrow:
                    if (nullLocation.Key - 1 >= 0)
                    {
                        var newNullLocation = new KeyValuePair<int, int>(nullLocation.Key - 1, nullLocation.Value);
                        var valueAtNewLocation = matrix.Values[newNullLocation.Key][newNullLocation.Value];

                        newMatrix.Values[nullLocation.Key][nullLocation.Value] = valueAtNewLocation;
                        newMatrix.Values[newNullLocation.Key][newNullLocation.Value] = null;
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (nullLocation.Value - 1 >= 0)
                    {
                        var newNullLocation = new KeyValuePair<int, int>(nullLocation.Key, nullLocation.Value - 1);
                        var valueAtNewLocation = matrix.Values[newNullLocation.Key][newNullLocation.Value];

                        newMatrix.Values[nullLocation.Key][nullLocation.Value] = valueAtNewLocation;
                        newMatrix.Values[newNullLocation.Key][newNullLocation.Value] = null;
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (nullLocation.Value + 1 <= 2)
                    {
                        var newNullLocation = new KeyValuePair<int, int>(nullLocation.Key, nullLocation.Value + 1);
                        var valueAtNewLocation = matrix.Values[newNullLocation.Key][newNullLocation.Value];

                        newMatrix.Values[nullLocation.Key][nullLocation.Value] = valueAtNewLocation;
                        newMatrix.Values[newNullLocation.Key][newNullLocation.Value] = null;
                    }
                    else
                    {
                        return null;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (nullLocation.Key + 1 <= 2)
                    {
                        var newNullLocation = new KeyValuePair<int, int>(nullLocation.Key + 1, nullLocation.Value);
                        var valueAtNewLocation = matrix.Values[newNullLocation.Key][newNullLocation.Value];

                        newMatrix.Values[nullLocation.Key][nullLocation.Value] = valueAtNewLocation;
                        newMatrix.Values[newNullLocation.Key][newNullLocation.Value] = null;
                    }
                    else
                    {
                        return null;
                    }
                    break;
            }

            Console.WriteLine(newMatrix.ToString());

            return newMatrix;
        }

        private KeyValuePair<int, int> GetNullLocation(Matrix matrix) 
        {
            var arrayIndex = 0;

            foreach (var array in matrix.Values) 
            {
                var valueIndex = 0;

                foreach (var value in array) 
                {
                    if (!value.HasValue) {
                        return new KeyValuePair<int, int>(arrayIndex, valueIndex);
                    }

                    valueIndex++;
                }

                arrayIndex++;
                valueIndex = 0;
            }

            return new KeyValuePair<int, int>();
        }
    }
}
