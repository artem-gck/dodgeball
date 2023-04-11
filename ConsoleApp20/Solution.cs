namespace ConsoleApp20
{
    public static class Solution
    {
        public static int Resolve(bool[][] array, int x, int y, Direction direction)
        {
            var counter = 0;

            while (true)
            {
                (int x, int y)? position = null;

                for (var i = ((int)direction + 1) % 8; i != (int)direction; i = (i + 1) % 8)
                {
                    //Select resolve from 2 methods

                    position = CheckDirectionSwitch(array, x, y, (Direction)i);
                    //position = CheckDirectionDictionary(array, x, y, (Direction)i);

                    if (position is not null)
                    {
                        x = position.Value.x;
                        y = position.Value.y;
                        direction = (Direction)((i + 4) % 8);

                        counter++;

                        break;
                    }
                }

                if (position is null)
                {
                    break;
                }
            }

            return counter;
        }

        private static (int x, int y)? CheckDirectionSwitch(bool[][] array, int x, int y, Direction direction)
        {
            var length = array.Length;
            var result = (x, y);

            for (var i = 0; i < length; i++)
            {
                switch (direction)
                {
                    case Direction.N:
                        result.y--;
                        break;

                    case Direction.NE:
                        result.x++;
                        result.y--;
                        break;

                    case Direction.E:
                        result.x++;
                        break;

                    case Direction.SE:
                        result.x++;
                        result.y++;
                        break;

                    case Direction.S:
                        result.y++;
                        break;

                    case Direction.SW:
                        result.x--;
                        result.y++;
                        break;

                    case Direction.W:
                        result.x--;
                        break;

                    case Direction.NW:
                        result.x--;
                        result.y--;
                        break;
                }

                if (result.x < 0 || result.x >= length || result.y < 0 || result.y >= length)
                    return null;

                if (array[result.x][result.y])
                {
                    array[result.x][result.y] = false;
                    return result;
                }
            }

            return null;
        }

        private static (int x, int y)? CheckDirectionDictionary(bool[][] array, int x, int y, Direction direction)
        {
            var length = array.Length;
            var result = (x, y);
            var methods = new Dictionary<Direction, Func<(int x, int y), (int x, int y)>>()
            {
                { Direction.N, tuple =>
                {
                    tuple.y--;

                    return tuple;
                } },
                { Direction.NE, tuple =>
                {
                    tuple.x++;
                    tuple.y--;

                    return tuple;
                } },
                { Direction.E, tuple =>
                {
                    tuple.x++;

                    return tuple;
                } },
                { Direction.SE, tuple =>
                {
                    tuple.x++;
                    tuple.y++;

                    return tuple;
                } },
                { Direction.S, tuple =>
                {
                    tuple.y++;

                    return tuple;
                } },
                { Direction.SW, tuple =>
                {
                    tuple.x--;
                    tuple.y++;

                    return tuple;
                } },
                { Direction.W, tuple =>
                {
                    tuple.x--;

                    return tuple;
                } },
                { Direction.NW, tuple =>
                {
                    tuple.y--;
                    tuple.x--;

                    return tuple;
                } }
            };

            for (var i = 0; i < length; i++)
            {
                result = methods[direction](result);

                if (result.x < 0 || result.x >= length || result.y < 0 || result.y >= length)
                    return null;

                if (array[result.x][result.y])
                {
                    array[result.x][result.y] = false;
                    return result;
                }
            }

            return null;
        }
    }
}
