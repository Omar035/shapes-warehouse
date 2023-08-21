using System;
using System.Data.Common;
using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CSE144Lab4 {
    class Shape {

    }

    class Cube : Shape {
        public int identifier = 3;
        private double _side;

        public double Side {
            get {return _side;}
            set {
                if (value < 0) {
                    Console.WriteLine("\nSide cannot be negative!");
                } else {
                    _side = value;
                }
            }
        }
    }

    class Rectangle : Shape {
        public int identifier = 2;
        private double _length;
        private double _width;

        public double Length {
            get {return _length;}
            set {
                if (value < 0) {
                    Console.WriteLine("\nLength cannot be negative!");
                } else {
                    _length = value;
                }
            } 
        }

        public double Width {
            get {return _width;}
            set {
                if (value < 0) {
                    Console.WriteLine("\nWidth cannot be negative!");
                } else {
                    _width = value;
                }
            }
        }
    }

    class Circle : Shape {
        public int identifier = 1;
        private double _diameter;

        public double Diameter {
            get {return _diameter;}
            set {
                if (value < 0) {
                    Console.WriteLine("\nDiameter cannot be negative!");
                } else {
                    _diameter = value;
                }
            }
        }
    }
    class DriverClass {

        private static int lastBlankPos = 0;
        static void Main() {
            Console.WriteLine("\t\tWelcome to Shapes' Warehouse!");

            for (int i = 0; i < 70; i++) {
                Console.Write("=");
            }

            Console.Write("\n");
            Console.WriteLine("[1] Add a Circle.");
            Console.WriteLine("[2] Add a Rectangle.");
            Console.WriteLine("[3] Add a Cube.");
            Console.WriteLine("[4] List Items.");
            Console.WriteLine("[5] Get Statistics.");
            Console.WriteLine("[6] Exit.");
            Console.WriteLine("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            Shape[] warehouse = new Shape[100];

            while (true) {
                switch (choice) {
                    case 1:
                        if (lastBlankPos < 100) {
                            AddCirc();
                        } else {
                            Console.WriteLine("\nOops, warehouse fulL!");
                        }

                        continue;
                    case 2:
                        if (lastBlankPos < 100) {
                            AddRect();
                        } else {
                            Console.WriteLine("\nOops, warehouse fulL!");
                        }

                        continue;
                    case 3:
                        if (lastBlankPos < 100) {
                            AddCube();
                        } else {
                            Console.WriteLine("\nOops, warehouse fulL!");
                        }

                        continue;
                    case 4:
                        ListItems();
                        continue;
                    case 5:
                        GetStats();
                        continue;
                    case 6:

                        break;
                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        continue;
                }

                break;
            }

            void AddCirc() {
                warehouse[lastBlankPos] = new Circle();

                Console.WriteLine("\nEnter the diameter:");
                ((Circle)warehouse[lastBlankPos]).Diameter = Convert.ToDouble(Console.ReadLine());

                lastBlankPos++;
                Console.WriteLine("\nSuccessfully added a Circle!");
            }

            void AddRect() {
                warehouse[lastBlankPos] = new Rectangle();

                Console.WriteLine("\nEnter the length:");
                ((Rectangle)warehouse[lastBlankPos]).Length = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the width:");
                ((Rectangle)warehouse[lastBlankPos]).Width = Convert.ToDouble(Console.ReadLine());

                lastBlankPos++;
                Console.WriteLine("\nSuccessfully added a Rectangle!");
            }

            void AddCube() {
                warehouse[lastBlankPos] = new Cube();

                Console.WriteLine("Enter the side:");
                ((Cube)warehouse[lastBlankPos]).Side = Convert.ToDouble(Console.ReadLine());

                lastBlankPos++;
                Console.WriteLine("\nSuccessfully added a Cube!");
            }

            void ListItems() {

            }

            void GetStats() {
                
            }
        }
    }
}