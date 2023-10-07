using System.Net;

namespace CSE_Lab_2104076_GeoShapes
{
    class Shape
    {
        public virtual double Area()
        {
            return 0;
        }

        public virtual bool IsValid () {
            return true;
        }
    }

    class Circle : Shape
    {
        public double diameter;
        public override double Area()
        {
            return ((1 / 4) * (22/7) * diameter * diameter);
        }

        public override bool IsValid()
        {
            if (diameter > 0) {
                return true;
            } else {
                return false;
            }
            
        }
        public Circle ()
        {
            bool validInput = false;
            
            while (!validInput) {
                try {
                    Console.Write("\nEnter the diameter of the circle: ");
                    diameter = Convert.ToDouble(Console.ReadLine());
                    validInput = true;

                    Console.WriteLine("\nAdded a circle");
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                } catch (OverflowException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    class Rectangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }
        public double angle1, angle2, angle3, angle4;

        public override double Area ()
        {
            return length * width;
        }

        public Rectangle ()
        {

            bool validInput = false;

            while (!validInput) {
                try {
                    Console.Write("\nEnter length: ");
                    length = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter width: ");
                    width = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter angle-1: ");
                    angle1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter angle-2: ");
                    angle2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter angle-3: ");
                    angle3 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter angle-4: ");
                    angle4 = Convert.ToDouble(Console.ReadLine());

                    validInput = true;
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                } catch (OverflowException ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("\nAdded a rectangle.");
        }

        public override bool IsValid()
        {
            if ((length > 0) && (width > 0) && (angle1 + angle2 + angle3 + angle4 == 360)) {
                return true;
            } else {
                return false;
            }
        }
    }

    class Cube : Shape
    {
        public double side { get; set; }
        public override double Area()
        {
            return 6 * side * side;
        }

        public Cube ()
        {
            bool validInput = false;
            
            while (!validInput) {
                try {
                    Console.Write("Enter side of the cube: ");
                    side = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nAdded a cube");

                    validInput = true;

                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                } catch (OverflowException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override bool IsValid()
        {
            if (side > 0) {
                return true;
            } else {
                return false;
            }
        }

    }

    class Triangle : Shape
    {
        public double side1 { get; set; }
        public double side2 { get; set; }
        public double side3 { get; set; }

        public override double Area()
        {
            double HalfPeri = 0.5 * (side1 + side2 + side3);
            return Math.Sqrt(HalfPeri * (HalfPeri - side1) * (HalfPeri - side2) * (HalfPeri - side3));
        }

        public Triangle ()
        {
            bool validInput = false;

            while (!validInput) {
                try {
                    Console.WriteLine("Enter side-1: ");
                    side1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter side-2: ");
                    side2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter side-3: ");
                    side3 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Added a Triangle!");

                    validInput = true;
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                } catch (OverflowException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    class WHManager {
        private Dictionary<string, List<Shape>> warehouse =  new ();
        public void AddShapeObject(string str, Shape s)
        {
            if (!warehouse.ContainsKey(str))
            {
                warehouse[str] = new ();
            }

            try
            {
                if (s.IsValid())
                {
                    warehouse[str].Add(s);
                    Console.WriteLine("\nShape added successfully.");
                }
                else
                {
                    throw new ArgumentException("Invalid shape. Not added to the warehouse.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListItems()
        {
            Console.WriteLine("\n\t\tItems in the warehouse:");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            Console.Write("Circles: ");

            foreach (var c in warehouse["circle"]) {
                Console.Write(((Circle)c).diameter + " ");
            }

            Console.WriteLine();

            Console.Write("Rectangles: ");
            foreach (var r in warehouse["rectangle"]) {
                Console.Write(((Rectangle)r).length + "x" + ((Rectangle)r).width + " ");    
            }

            Console.WriteLine();

            Console.Write("Cubes: ");
            foreach (var c in warehouse["cube"]) {
                Console.Write(((Cube)c).side + "x" + ((Cube)c).side + "x" + ((Cube)c).side + " ");    
            }

            Console.WriteLine();

            Console.Write("Triangles: ");
            foreach (var t in warehouse["triangle"]) {
                Console.Write(((Triangle)t).Area() + " ");
            }

            Console.WriteLine();

        }

        public void GetStats()
        {
            Console.WriteLine("Total no. of Shapes: " + (warehouse["circle"].Count + warehouse["rectangle"].Count + warehouse["cube"].Count + warehouse["triangle"].Count));

            Console.WriteLine("Circles: " + warehouse["circle"].Count);
            Console.WriteLine("Rectangles: " + warehouse["rectangle"].Count);
            Console.WriteLine("Cubes: " + warehouse["cube"].Count);
            Console.WriteLine("Triangles: " + warehouse["triangle"].Count);
        }
    }

    class Driver
    {
        public static void Main()
        {
            Console.WriteLine("\t\tWelcome to Shapes' Warehouse!");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            int choice;

            WHManager mg = new();

            while (true)
            {
                Console.WriteLine("\n[1] Add a Circle");
                Console.WriteLine("[2] Add a Rectangle");
                Console.WriteLine("[3] Add a Cube");
                Console.WriteLine("[4] Add a Triangle");
                Console.WriteLine("[5] List Items");
                Console.WriteLine("[6] Get Statistics");
                Console.WriteLine("[7] Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt16(Console.ReadLine());

                try {
                    switch (choice)
                    {
                        case 1:
                            Circle circle = new ();
                            mg.AddShapeObject("circle", circle);
                            continue;
                        case 2:
                            Rectangle rectangle = new ();
                            mg.AddShapeObject("rectangle", rectangle);
                            continue;
                        case 3:
                            Cube cube = new ();
                            mg.AddShapeObject("cube", cube);
                            continue;
                        case 4:
                            Triangle triangle = new ();
                            mg.AddShapeObject("triangle", triangle);
                            continue;
                        case 5:
                            mg.ListItems();
                            continue;
                        case 6:
                            mg.GetStats();
                            continue;
                        case 7:
                            Console.WriteLine("\nSuccessfully exited the program.");
                            break;
                    }
                } catch (KeyNotFoundException) {
                    Console.WriteLine("Desired shapes don't yet exist in the warehouse!\n");
                    continue;
                }

                break;
            }
        }
    }
}
