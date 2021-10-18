using System;
using System.Collections.Generic;
using System.Text;

namespace battleships.GameObjects.Ships
{
    public class Ship
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public char ScreenSymbol { get; set; }
        public int Hits { get; set; }

        /// <summary>
        /// Method returns if a ship has sunk, based on its length and number of hits.
        /// </summary>
        /// <returns></returns>
        public bool HasSunk()
        {
            return Hits >= Length;
        }
    }
}
