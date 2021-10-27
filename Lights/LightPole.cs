using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestre1project
{
    class LightPole
    {
        int range;
        int xposition;
        int yposition;
        public int Range { get { return range; } set { range = value; } }
        public int Xposition { get { return xposition; } set { xposition = value; } }
        public int Ypostion { get { return yposition; } set { yposition = value; } }
        public LightPole(int range, int xposition, int ypostion)
        {
            Range = range;
            Xposition = xposition;
            Ypostion = ypostion;
        }

        public LightPole()
        {
        }
    }

}
