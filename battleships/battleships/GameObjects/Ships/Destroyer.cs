using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Ships
{
    public class Destroyer: Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Length = 2;
            ScreenSymbol = (Char)FieldTypes.Destroyer;
        }
    }
}
