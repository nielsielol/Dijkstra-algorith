using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_algorithm.classes
{
    class Linker
    {
        public Point PointerTo;
        public int Distance;

        public Linker(Point pointerTo, int distance) {
            PointerTo = pointerTo;
            Distance = distance;
        }
    }
}
