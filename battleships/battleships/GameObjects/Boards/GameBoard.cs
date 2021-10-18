using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using battleships.GameObjects.Ships;

namespace battleships.GameObjects.Boards
{
    public class GameBoard : Board
    {
        /// <summary>
        /// Method arranges ships on passed ships list.
        /// </summary>
        /// <param name="shipsList"></param>
        public void PlaceShipsOnBoard(List<Ship> shipsList)
        {
            var rn = new Random();

            foreach (var ship in shipsList)
            {
                var foundPlace = false;

                while (!foundPlace)
                {
                    var startX = rn.Next(10);
                    var startY = rn.Next(10);
                    var endX = startX;
                    var endY = startY;

                    // We can place our ship vertically or horizontally. 0 - vertically, 1 - horizontally.
                    var orientation = rn.Next(2);

                    if (orientation == 0)
                    {
                        endY += ship.Length;
                    }
                    else
                    {
                        endX += ship.Length;
                    }

                    // Check that we aren't exceeding the board limits and don't interfere with any other ship.
                    if ((endX < 10 && endY < 10) && !CheckIfOccupied(startX, endX, startY, endY))
                    {
                        // Place ship 
                        for (int i = 0; i < ship.Length; i++)
                        {
                            if (orientation == 0)
                            {
                                var fieldToChange = Fields.First(field => field.Coordinates.Y == startY + i && field.Coordinates.X == startX);
                                fieldToChange.FieldType = ship.ScreenSymbol;
                            }
                            else
                            {
                                var fieldToChange = Fields.First(field => field.Coordinates.X == startX + i && field.Coordinates.Y == startY);
                                fieldToChange.FieldType = ship.ScreenSymbol;
                            }
                        }
                        foundPlace = true;
                    }
                }
            }
        }

        /// <summary>
        /// Function checks if selected place for ship is occupied. 
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="endX"></param>
        /// <param name="startY"></param>
        /// <param name="endY"></param>
        /// <returns></returns>
        private bool CheckIfOccupied(int startX, int endX, int startY, int endY)
        {
            var occupiedList = Fields.Where(field =>
                field.Coordinates.X >= startX && field.Coordinates.X <= endX && field.Coordinates.Y >= startY &&
                field.Coordinates.Y <= endY && field.FieldType != (char)FieldTypes.Empty).ToList();

            return occupiedList.Any();
        }
    }
}
