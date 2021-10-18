using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battleships.GameObjects.Boards
{
    public class FireBoard : Board
    {
        /// <summary>
        /// Method returns the list of empty fields.
        /// </summary>
        /// <returns></returns>
        public List<Field> GetAvailableFieldsList()
        {
            return Fields.Where(field => field.FieldType == (char)FieldTypes.Empty).ToList();
        }
    }
}
