using busca_largura.classes;

var initial = new Matrix(1, 2, 3, 4, null, 5, 6, 7, 8);
var goal = new Matrix(1, 2, 3, 4, 5, null, 6, 7, 8);

var operations = new List<ConsoleKey>();
var validKeys = new List<ConsoleKey>() { ConsoleKey.DownArrow, ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow };

var pressedKey = Console.ReadKey(true).Key;

while (pressedKey != ConsoleKey.Enter && !Console.KeyAvailable)
{
    if (validKeys.Contains(pressedKey)) 
    { 
        operations.Add(pressedKey); 
    }

    pressedKey = Console.ReadKey(true).Key;
}

new BreadthFirst(initial, goal, operations).Execute();