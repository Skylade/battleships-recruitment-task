using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Boards
{
    public class Field
    {
        public Coordinates Coordinates { get; set; }
        public char FieldType { get; set; }

        public Field(int x, int y)
        {
            Coordinates = new Coordinates(x, y);
            FieldType = (char)FieldTypes.Empty;
        }
    }
}
