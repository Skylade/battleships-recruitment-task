using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Ships
{
    public class Cruiser: Ship
    {
        public Cruiser()
        { 
            Name = "Cruiser";
            Length = 3;
            ScreenSymbol = (Char)FieldTypes.Cruiser;
        }
    }
}
