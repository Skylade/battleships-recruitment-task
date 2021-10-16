using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleships.GameObjects.Boards
{
    public class Board
    {
        public List<Field> Fields { get; set; }

        public Board()
        {
            Fields = new List<Field>();
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Fields.Add(new Field(i, j));
                }
            }
        }

        public char FieldTypeAt(int x, int y)
        {
            return Fields.First(field => field.Coordinates.X == x || field.Coordinates.Y == y).FieldType;
        }
    }
}
