using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dijkstra_algorithm.classes;

namespace Dijkstra_algorithm
{
    class Program
    {
        private List<Point> _pointers = new List<Point>();
        private List<Point> _visited = new List<Point>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.initialyzeGraph();

            Point theChosenOne = null;
            bool foundAnswer = false;
            while (!foundAnswer) {
                if (theChosenOne == null && program._visited.Count == 1)
                { // this is the first time
                    theChosenOne = program._visited[0];
                    Console.WriteLine("we added the first!: " + theChosenOne.Name);
                    theChosenOne.path += theChosenOne.Name;
                }

                //check and set the vortex if it isn't set or if it is lower!
                foreach (Linker linker in theChosenOne.getLinkers()) {
                    Console.WriteLine(theChosenOne.Name + " --> " + linker.PointerTo.Name + " linker vortex: " + linker.PointerTo.Vortex +
                        " distance: " + (theChosenOne.Vortex + linker.Distance));
                    if (linker.PointerTo.Vortex == -1 || linker.PointerTo.Vortex > (theChosenOne.Vortex + linker.Distance)) {
                        foreach (Point point in program._pointers) {
                            if (point.Equals(linker.PointerTo)) {
                                Console.Write("we are setting a new pointerVortex: " + point.Name + "the old Vortex = " + point.Vortex);

                                point.Vortex = theChosenOne.Vortex + linker.Distance; // set the new vortex!
                                Console.WriteLine(" the new vortex = " + point.Vortex + " ( " + theChosenOne.Vortex + " + " + linker.Distance + " ) ");
                                //set a new path witch belongs to the selected path
                                point.path = theChosenOne.path; // set the new shorter path                                
                                point.path += point.Name; // add itself to the end :)
                                Console.WriteLine("point.pathh: " + point.path);
                                if (point.IsEnd) {
                                    Console.WriteLine("we found the end!");
                                    foundAnswer = true;
                                }
                            }
                        }
                    }
                }

                if (!foundAnswer)
                {
                    //select the new chosen one ^^
                    theChosenOne = null;
                    foreach (Point pointer in program._pointers)
                    {
                        if (!program._visited.Contains(pointer))
                        {
                            if (theChosenOne == null)
                            {
                                Console.WriteLine("the chosen one is null so the first occurrence is: " + pointer.Name + " " + pointer.Vortex);
                                theChosenOne = pointer;
                            }
                            else if (pointer.Vortex < theChosenOne.Vortex && pointer.Vortex != -1)
                            {
                                Console.WriteLine("we found a lower vortex: " + pointer.Name + " " + pointer.Vortex);
                                theChosenOne = pointer;
                            }

                        }
                    }
                    Console.WriteLine("the new chosen one: " + theChosenOne.Name);
                    Console.WriteLine();
                    program._visited.Add(theChosenOne);
                }
            }

            foreach (Point pointer in program._pointers) {
                if(pointer.IsEnd)
                    Console.WriteLine(pointer.path);
            }
            
            Console.ReadLine();
        }

        public void initialyzeGraph() {
            _pointers.Add(new Point('A'));//0
            _pointers.Add(new Point('B'));//1
            _pointers.Add(new Point('C'));//2
            _pointers.Add(new Point('D'));//3
            _pointers.Add(new Point('E'));//4
            _pointers.Add(new Point('F', true));//5
            _pointers.Add(new Point('G'));//6
            
            //set all the linkers!
            //A
            List<Linker> linker = new List<Linker>();
            linker.Add(new Linker(_pointers[1], 4));
            linker.Add(new Linker(_pointers[2], 3));
            linker.Add(new Linker(_pointers[4], 7));
            _pointers[0].setLinkers(linker);

            //B
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[0], 4));
            linker.Add(new Linker(_pointers[2], 6));
            linker.Add(new Linker(_pointers[3], 5));
            _pointers[1].setLinkers(linker);

            //C
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[0], 3));
            linker.Add(new Linker(_pointers[1], 6));
            linker.Add(new Linker(_pointers[3], 11));
            linker.Add(new Linker(_pointers[4], 8));
            _pointers[2].setLinkers(linker);

            //D
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[1], 5));
            linker.Add(new Linker(_pointers[2], 11));
            linker.Add(new Linker(_pointers[4], 7));
            linker.Add(new Linker(_pointers[6], 10));
            linker.Add(new Linker(_pointers[5], 2));
            _pointers[3].setLinkers(linker);

            //E
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[0], 7));
            linker.Add(new Linker(_pointers[2], 8));
            linker.Add(new Linker(_pointers[3], 2));
            linker.Add(new Linker(_pointers[6], 5));
            _pointers[4].setLinkers(linker);

            //F
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[3], 2));
            linker.Add(new Linker(_pointers[6], 3));
            _pointers[5].setLinkers(linker);

            //G
            linker = new List<Linker>();
            linker.Add(new Linker(_pointers[4], 5));
            linker.Add(new Linker(_pointers[3], 10));
            linker.Add(new Linker(_pointers[5], 3));
            _pointers[6].setLinkers(linker);

            foreach (Point pointer in _pointers) {
                pointer.Vortex = -1;
            }

            //initialize the starting Pointer
            _pointers[0].Vortex = 0;
            _visited.Add(_pointers[0]);
        }
    }
}
