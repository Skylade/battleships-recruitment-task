using System;
using System.Collections.Generic;
using System.Text;


namespace battleships.GameObjects.Ships
{
    public class Submarine: Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Length = 3;
            ScreenSymbol = (Char)FieldTypes.Submarine;
        }
    }
}
