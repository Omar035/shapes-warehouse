namespace CSE_Lab_2104076_GeoShapes
{
    class Shape
    {
        public virtual double Area()
        {
            return 0;
        }
    }

    class Circle : Shape
    {
        public double diameter;
        public override double Area()
        {
            return ((1 / 4) * (22/7) * diameter * diameter);
        }

        public Circle ()
        {
            while (true)
            {
                Console.Write("\nEnter the diameter of the circle: ");
                diameter = Convert.ToDouble(Console.ReadLine());

                if (diameter < 0)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                break;
            }

            Console.WriteLine("\nSuccessfully added a circle");
        }
    }

    class Rectangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }

        public override double Area ()
        {
            return length * width;
        }

        public Rectangle ()
        {
            while (true)
            {
                Console.Write("\nEnter length: ");
                length = Convert.ToDouble(Console.ReadLine());

                if (length < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Enter width: ");
                width = Convert.ToDouble(Console.ReadLine());

                if (width < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                break;
            }

            Console.WriteLine("\nSuccessfully added a rectangle.");
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
            while (true)
            {
                Console.Write("Enter side of the cube: ");
                side = Convert.ToDouble(Console.ReadLine());

                if (side < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                break;
            }
            Console.WriteLine("\nSucccessfully added a cube");
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
            while (true)
            {
                while (true)
                {
                    Console.Write("Enter side 1: ");
                    side1 = Convert.ToDouble(Console.ReadLine());

                    if (side1 < 0)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    break;
                }

                while (true)
                {
                    Console.Write("Enter side 2: ");
                    side2 = Convert.ToDouble(Console.ReadLine());

                    if (side2 < 0)
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    break;
                }

                while (true)
                {
                    Console.Write("Enter side 3: ");
                    side3 = Convert.ToDouble(Console.ReadLine());

                    if (side3 < 0)
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }

                    break;
                }

                if (side1 + side2 > side3 && side2 + side3 > side1 && side1 + side3 > side2) {
                    Console.WriteLine("\nSucccessfully added a triangle");
                    break;
                } else
                {
                    Console.WriteLine("Side inputs cannot construct a triangle! Enter side again!");
                }
            }
        }
    }

    class Driver
    {
        public static List <Shape> Warehouse = new List <Shape> ();
        public static void Main()
        {
            Console.WriteLine("\t\tWelcome to Shapes' Warehouse!");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            int choice;

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

                switch (choice)
                {
                    case 1:
                        Circle circle = new Circle();
                        Warehouse.Add(circle);
                        continue;
                    case 2:
                        Rectangle rectangle = new Rectangle();
                        Warehouse.Add(rectangle);
                        continue;
                    case 3:
                        Cube cube = new Cube();
                        Warehouse.Add(cube);
                        continue;
                    case 4:
                        Triangle triangle = new Triangle();
                        Warehouse.Add(triangle);
                        continue;
                    case 5:
                        ListItems();
                        continue;
                    case 6:
                        GetStats();
                        continue;
                    case 7:
                        Console.WriteLine("\nSuccessfully exited the program.");
                        break;
                }

                break;
            }
        }

        public int TotalShapes = Warehouse.Count();
        

        private static void ListItems()
        {
            Console.WriteLine("\n\t\tItems in the warehouse");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.Write("\n");

            Console.WriteLine("\tID\t\t\tType\t\t\tDimension\n");

            for (int i = 0; i < 70; i++)
            {
                Console.Write("-");
            }

            Console.Write('\n');

            int index = 1;

            foreach (var item in Warehouse)
            {
                if (item is Circle)
                {
                    Console.WriteLine("\t" + index + "\t\t\tCircle\t\t\t" + ((Circle)item).diameter);
                } else if (item is Rectangle)
                {
                    Console.WriteLine("\t" + index + "\t\t\tRectangle\t\t\t" + ((Rectangle)item).length + " x " + ((Rectangle)item).width);
                } else if (item is Cube) {
                    Console.WriteLine("\t" + index + "\t\t\tCube\t\t\t" + ((Cube)item).side + " x " + ((Cube)item).side + " x " + (((Cube)item).side));
                } else {
                    
                }

                index++;
            }

        }

        private static void GetStats()
        {
            throw new NotImplementedException ();
        }
    }
}