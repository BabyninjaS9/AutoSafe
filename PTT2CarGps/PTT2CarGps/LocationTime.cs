using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PTT2CarGps
{
    public class LocationTime
    {
        public Point Location { get; private set; }
        public DateTime Time { get; private set; }

        public LocationTime(Point location, DateTime time)
        {
            Location = location;
            Time = time;
        }
    }
}
