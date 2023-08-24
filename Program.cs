using System;
using System.Data.Common;
using System.Dynamic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace CSE144Lab4 {
    class Shape {
        public int identifier;
    }

    class Cube : Shape {
        private double m_side;
        public double Side {
            get {return m_side;}
            set {
                m_side = value;
            }
        }

        public Cube (double s) {
            identifier = 3;
            Side = s;
        }
    }

    class Rectangle : Shape {
        private double m_length;
        private double m_width;
        public double Length {
            get {return m_length;}
            set {
                m_length = value;
            } 
        }
        public double Width {
            get {return m_width;}
            set {
               m_width = value;
            }
        }
        public Rectangle (double l, double w) {
            identifier = 2;
            Length = l;
            Width = w;
        }
    }

    class Circle : Shape {
        private double m_diameter;
        public double Diameter {
            get {return m_diameter;}
            set {
                m_diameter = value;
            }
        }
        public Circle (double dm) {
            identifier = 1;
            Diameter = dm;
        }
    }
    class DriverClass {

        private static int lastBlankPos = 0;
        static void Main() {
            Console.WriteLine("\t\tWelcome to Shapes' Warehouse!");

            for (int i = 0; i < 70; i++) {
                Console.Write("-");
            }

            Shape[] warehouse = new Shape[100];

            while (true) {
                Console.Write("\n");
                Console.WriteLine("[1] Add a Circle.");
                Console.WriteLine("[2] Add a Rectangle.");
                Console.WriteLine("[3] Add a Cube.");
                Console.WriteLine("[4] List Items.");
                Console.WriteLine("[5] Get Statistics.");
                Console.WriteLine("[6] Exit.");
                Console.WriteLine("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        if (lastBlankPos < 100) {
                            while (true) {
                                Console.Write("Enter the diameter of the circle: ");
                                double diameter = Convert.ToDouble(Console.ReadLine());

                                if (diameter >= 0) {
                                    warehouse[lastBlankPos] = new Circle(diameter);
                                    break;
                                } else {
                                    Console.WriteLine("Diameter cannot be negative!");
                                }
                            }

                            Console.WriteLine("Successfully added a Circle!");
                            lastBlankPos++;
                        } else {
                            Console.WriteLine("\nOops, warehouse full!");
                        }

                        continue;
                    case 2:
                        if (lastBlankPos < 100) {
                            double length, width;
                        
                            while (true) {
                                Console.Write("Enter length of the rectangle: ");
                                length = Convert.ToDouble(Console.ReadLine());

                                if (length < 0) {
                                    Console.WriteLine("Length cannot be negative");
                                } else {
                                    break;
                                }
                            }

                            while (true) {
                                Console.Write("Enter width of the rectangle: ");
                                width = Convert.ToDouble(Console.ReadLine());

                                if (width < 0) {
                                    Console.WriteLine("Width cannot be negative");
                                } else {
                                    break;
                                }
                            }

                            warehouse[lastBlankPos] = new Rectangle(length, width);
                            Console.WriteLine("Successfully added a Rectangle!");
                            lastBlankPos++;
                        } else {
                            Console.WriteLine("\nOops, warehouse full!");
                        }

                        continue;
                    case 3:
                        if (lastBlankPos < 100) {
                            double side;
                            while (true) {
                                Console.Write("Enter the side of the cube: ");
                                side = Convert.ToDouble(Console.ReadLine());

                                if (side < 0) {
                                    Console.WriteLine("Side cannot be negative.");
                                } else {
                                    break;
                                }
                            }

                            warehouse[lastBlankPos] = new Cube(side);
                            Console.WriteLine("Successfully added a Cube.");
                            lastBlankPos++;
                        } else {
                            Console.WriteLine("\nOops, warehouse full!");
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

            void ListItems() {
                
                Console.Write("\n");
                Console.WriteLine("ID\t\tType\t\t\tDimension");
                
                for (int i = 0; i < 70; i++) {
                    Console.Write("-");
                }

                Console.Write("\n");

                for (int i = 0; i < lastBlankPos; i++) {
                    if (warehouse[i].identifier == 1) {
                        Console.WriteLine((i+1) + "\t\tCirle\t\t\t" + ((Circle)warehouse[i]).Diameter);
                    } else if (warehouse[i].identifier == 2) {
                        Console.WriteLine((i+1) + "\t\tRectangle\t\t" + ((Rectangle)warehouse[i]).Length + " x " + ((Rectangle)warehouse[i]).Width);
                    } else if (warehouse[i].identifier == 3) {
                        Console.WriteLine((i+1) + "\t\tCube\t\t\t" + ((Cube)warehouse[i]).Side + " x " + ((Cube)warehouse[i]).Side + " x " + ((Cube)warehouse[i]).Side);
                    }
                }

            }

            void GetStats() {
                Console.WriteLine("\n\t\tSummary of the Warehouse:");
                
                for (int i = 0; i < 70; i++) {
                    Console.Write("-");
                }

                Console.Write("\n");

                Console.WriteLine("Total no. of Shapes in the Warehouse: " + lastBlankPos);
                
                int circles = 0, rects = 0, cubes = 0, total = 0;
                double circArea = 0, rectArea = 0, cubeArea = 0;
                decimal totalArea = 0;

                for (int i = 0; i < lastBlankPos; i++) {
                    if (warehouse[i].identifier == 1) {
                        circles++;

                        circArea += (0.25 * (Math.PI) * (((Circle)warehouse[i]).Diameter) * (((Circle)warehouse[i]).Diameter));

                        totalArea += Convert.ToDecimal(circArea);
                    } else if (warehouse[i].identifier == 2) {
                        rects++;

                        rectArea += ((((Rectangle)warehouse[i]).Length) * (((Rectangle)warehouse[i]).Width));

                        totalArea += Convert.ToDecimal(rectArea);
                    } else if (warehouse[i].identifier == 3) {
                        cubes++;

                        cubeArea += (6 * (((Cube)warehouse[i]).Side) * (((Cube)warehouse[i]).Side));

                        totalArea += Convert.ToDecimal(cubeArea);
                    }
                }

                total = circles + rects + cubes;

                decimal percent1 = (Convert.ToDecimal(circArea)/totalArea) * 100, percent2 = (Convert.ToDecimal(rectArea)/totalArea) * 100, percent3 = (Convert.ToDecimal(cubeArea)/totalArea) * 100;

                string totalAreaString = String.Format("{0:0.00}", totalArea);
                string circString = String.Format("{0:0.00}",circArea);
                string rectString = String.Format("{0:0.00}", rectArea);
                string cubeString = String.Format("{0:0.00}", cubeArea);
                string percent1String = String.Format("{0:0.00}", percent1);
                string percent2String = String.Format("{0:0.00}", percent2);
                string percent3String = String.Format("{0:0.00}", percent3); 

                Console.WriteLine("Shapes in the warehouse: " + total);
                Console.WriteLine("Circles: " + circles);
                Console.WriteLine("Rectangles: " + rects);
                Console.WriteLine("Cubes: " + cubes);
                Console.WriteLine("Total Area: " + totalAreaString);
                Console.WriteLine("Circular Area: " + circString + " (" + percent1String + "%)");
                Console.WriteLine("Rectangular Area: " + rectString + " (" + percent2String + "%)");
                Console.WriteLine("Cubic Area: " + cubeString + " (" + percent3String + "%)"); 
            }
        }
    }
}