using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Cars
{
    class Utility
    {
        internal static Car ParseFromCsv(string row)
        {
            // split the row element
            var columns = row.Split(',');
            // then this column wil be a array of different value
            return new Car
            {

                Year = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Name = columns[2],
                Displacement = double.Parse(columns[3]),
                Cylinders = int.Parse(columns[4]),
                City = int.Parse(columns[5]),
                Highway = int.Parse(columns[6]),
                Combined = int.Parse(columns[7]),
            };
        }
    }
}
