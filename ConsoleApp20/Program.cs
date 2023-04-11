using ConsoleApp20;

var array = new bool[][] {
    new bool[] { false, false, false, false, true, false, false, false, false, false },
    new bool[] { false, false, false, false, true, false, false, false, false, false },
    new bool[] { false, true, false, false, false, false, false, false, false, false },
    new bool[] { false, false, false, false, false, true, false, false, false, false },
    new bool[] { false, false, false, false, false, true, false, false, false, true },
    new bool[] { false, true, false, false, true, true, false, false, false, false },
    new bool[] { false, false, false, false, false, false, false, false, true, false },
    new bool[] { false, false, false, false, false, false, false, false, false, false },
    new bool[] { false, false, false, false, false, true, false, false, false, false },
    new bool[] { false, false, false, false, false, false, false, false, false, false },
};

var x = 1;
var y = 4;
var direction = Direction.W;

var result = Solution.Resolve(array, x, y, direction);

Console.WriteLine(result);