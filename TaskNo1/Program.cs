using System;

namespace TaskNo1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Task 1 test:");
            IIntegerList arrayList = new IntegerList();
            ListExample(arrayList);
            
            Console.WriteLine("Task 2 test:");
            IGenericList<string> stringArrayList = new GenericList<string>();
            ListExampleGenerics(stringArrayList);

            foreach (string value in stringArrayList)
            {
                Console.WriteLine(value);
            }
            
        }
        
        public static void ListExample(IIntegerList listOfIntegers) {
            listOfIntegers.Add(1); // [1] 
            listOfIntegers.Add(2); // [1,2] 
            listOfIntegers.Add(3); // [1,2,3] 
            listOfIntegers.Add(4); // [1,2,3,4] 
            listOfIntegers.Add(5); // [1,2,3,4,5]
            listOfIntegers.RemoveAt(0); // [2,3,4,5] 
            listOfIntegers.Remove(5); //[2,3,4] 
            Console.WriteLine(listOfIntegers.Count); // 3 
            Console.WriteLine(listOfIntegers.Remove(100)); // false 
            Console.WriteLine(listOfIntegers.RemoveAt(5)); // false 
            listOfIntegers.Clear(); // [] 
            Console.WriteLine(listOfIntegers.Count); // 0
        }
        
        public static void ListExampleGenerics(IGenericList<string> listOfGenerics) {
            listOfGenerics.Add("a"); // [a] 
            listOfGenerics.Add("b"); // [a,b] 
            listOfGenerics.Add("car"); // [a,b,car] 
            listOfGenerics.Add("house"); // [a,b,car,house] 
            listOfGenerics.Add("roof"); // [a,b,car,house,roof]
            listOfGenerics.RemoveAt(0); // [b,car,house,roof] 
            listOfGenerics.Remove("house"); //[b,car,house] 
            Console.WriteLine(listOfGenerics.Count); // 3 
            Console.WriteLine(listOfGenerics.Remove("nonExistingWord")); // false 
            Console.WriteLine(listOfGenerics.RemoveAt(5)); // false 
            listOfGenerics.Clear(); // [] 
            Console.WriteLine(listOfGenerics.Count); // 0
        }
    }
}