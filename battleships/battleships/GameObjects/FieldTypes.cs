using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects
{
    public enum FieldTypes
    {
        Carrier = 'C',
        Battleship = 'B',
        Cruiser = 'P',
        Submarine = 'S',
        Destroyer = 'D',
        Hit = 'H',
        Miss = 'M',
        Empty = 'o'
    }
}
