using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var p1 = new Employee(1, "John", "Doe");
            var p2 = new Employee(1, "John", "Doe");
            Console.WriteLine(p1 == p2 ? "same" : "different");
        }
    }

    public record Employee(int EmployeeId, string FirstName, string LastName);
}