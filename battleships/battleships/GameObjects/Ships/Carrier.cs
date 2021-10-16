using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Ships
{
    public class Carrier: Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Length = 5;
            ScreenSymbol = (Char)FieldTypes.Carrier;
        }
    }
}
