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
    }

    class Rectangle : Shape {
        public int identifier = 2;
    }

    class Circle : Shape {
        public int identifier = 1;
        public double diameter {get; set;}
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
                Console.WriteLine("\nEnter the diameter:");
                warehouse[lastBlankPos] = new Circle();
            }

            void AddRect() {

            }

            void AddCube() {

            }

            void ListItems() {

            }

            void GetStats() {
                
            }
        }
    }
}