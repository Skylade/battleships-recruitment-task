﻿using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Boards
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
