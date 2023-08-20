using System;

namespace CSE144Lab4 {

    class DriverClass {
        public static void Main () {
            Console.WriteLine("Welcome to Shapes' Warehouse!");

            for (int i = 0; i < 70; i++) {
                Console.WriteLine("=");
            }

            Console.Write("\n");
            Console.WriteLine("[1] Add a Circle.");
            Console.WriteLine("[2] Add a Rectangle.");
        }
    }
}