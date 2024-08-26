using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            var numbers = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(numbers);

            //TODO: Print the first number of the array
            Console.WriteLine(numbers[0]);
            //TODO: Print the last number of the array            
            Console.WriteLine(numbers[49]);

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(numbers.Reverse());
            Console.WriteLine("---------REVERSE CUSTOM------------");
            NumberPrinter(ReverseArray(numbers));
            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(numbers);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> ints = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"Capacity: {ints.Count}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(ints);

            //TODO: Print the new capacity
            Console.WriteLine($"Capacity: {ints.Count}");
            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            var userInput  = Console.ReadLine();
            bool result = int.TryParse(userInput, out int number);
            if (result)
            {
                NumberChecker(ints, number);
            }
            else
            {
                Console.WriteLine("Value provided is not a number, please try again.");
            }

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(ints);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(ints);
            NumberPrinter(ints);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            ints.Sort();
            NumberPrinter(ints);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] intArray = ints.ToArray();

            //TODO: Clear the list
            ints.Clear();
            Console.WriteLine("Final List:");
            NumberPrinter(ints);
            Console.WriteLine($"Capacity: {ints.Count}");
            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = numbers[i] % 3;
                if(remainder == 0)
                {
                    numbers[i] = 0;
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                var number = numberList[i];
                double remainder = number % 2;

                if (remainder != 0)
                {
                    numberList.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber)) {
                Console.WriteLine($"The number {searchNumber} is present in the list");
            } else
            {
                Console.WriteLine($"The number {searchNumber} is not present in the list");
            }

        }

        private static void Populater(List<int> numberList)
        {
            while (numberList.Count < 50)
            {
                Random rng = new Random();
                int number = rng.Next(1, 50);
                numberList.Add(number);
            }
        }

        private static void Populater(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Random randomNum = new Random();
                numbers[i] = randomNum.Next(1, 50);
            }

        }        

        private static int[] ReverseArray(int[] array)
        {
            var reversedArray = new int[50];
            for (int i = 0; i < array.Length; i++)
            {
                reversedArray[i] = array[array.Length - 1 - i];
            }
            return reversedArray;
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
