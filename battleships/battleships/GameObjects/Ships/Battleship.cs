using System;
using System.Collections.Generic;
using System.Text;


namespace battleships.GameObjects.Ships
{
    public class Battleship: Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Length = 4;
            ScreenSymbol = (Char)FieldTypes.Battleship;
        }
    }
}
