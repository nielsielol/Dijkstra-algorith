using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_algorithm.classes
{
    class Point
    {
        private List<Linker> _linkers;
        public char Name;
        public bool IsEnd;
        public int Vortex { get; set; } // this distance traveled to this point!
        //public List<Point> Path { get; set; }
        public string path { get; set; }

        public Point(char name, bool isEnd = false) {
            Name = name;
            IsEnd = isEnd;
            //Path = new List<Point>();
            path = "";
        }

        public void setLinkers(List<Linker> linkers) {
            _linkers = linkers;
        }

        public List<Linker> getLinkers()
        {
            return _linkers;
        }

        /*public string getPath() {
            string path = "";
            foreach (Point pointer in Path) {
                path += pointer.Name;
            }
            return path;
        }*/


    }
}
