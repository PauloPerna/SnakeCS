using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jogo;

namespace Snake
{
    public static class SnakeActions
    {

        public static Direction Actions(ConsoleKey key)
        {
            if (_actions.ContainsKey(key))
                return _actions[key];

            return Direction.Stay;
        }

        private static Dictionary<ConsoleKey, Direction> _actions = new()
        {
            { ConsoleKey.UpArrow, Direction.Top },
            { ConsoleKey.RightArrow, Direction.Right },
            { ConsoleKey.DownArrow, Direction.Down },
            { ConsoleKey.LeftArrow, Direction.Left }
        };
    }
}
