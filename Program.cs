using System;
using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CSE144Lab4 {
    class Shape {
        public int identifier;
        
    }

    class Rectangle : Shape {
 
    }

    class Cube : Shape {

    }

    class Circle : Shape {

    }
    class DriverClass {
        private Shape[] warehouse = new Shape[100];
        void Main() {
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
            int lastBlankPos = 0;

            while (true) {
                switch (choice) {
                    case 1:
                        if (lastBlankPos < 100) {
                            AddCirc(warehouse, lastBlankPos);
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

                        continue;
                    case 6:

                        break;
                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        continue;
                }

                break;
            }

            void AddCirc(Shape[] warehouse, int lastBlankPos) {

            }

            void AddRect(Shape[] warehouse, int lastBlankPos) {

            }

            void AddCube(Shape[] warehouse, int lastBlankPos) {

            }

            void ListItems() {

            }
        }
    }
}