using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var person = new Person(name: "Maor Rocky", age: 22, city: "Tel Aviv", phone: "0542322730", email: "maor@gmail.com",
                                    food: new List<string> { "Burger", "Pizza" });
            var person2 = new Person(name: "Maor Rocky", age: 22, city: "Tel Aviv", phone: "0542322730", email: "maor@gmail.com",
                                     food: new List<string> { "Pizza", "Burger" });
            Console.WriteLine(person.GetHashCode());
            Console.WriteLine(person2.GetHashCode());
            Console.WriteLine(person.Hash.Equals(person2.Hash));

            var lst = new List<string>()
            {
                "d", "a", "b", "c"
            };
            lst.Sort();
            Console.WriteLine(string.Join(",", lst));

            IEnumerable<string> test = new List<string>() { "c", "a", "b" };
            var x = test.OrderBy(x=>x).ToList();
            Console.WriteLine(string.Join(",", x));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<string> Food { get; set; }

        public string Hash { get; }

        public Person(string name, int age, string city, string phone, string email, List<string> food)
        {
            Name = name;
            Age = age;
            City = city;
            Phone = phone;
            Email = email;
            Food = food;
            Hash = CreateHash();
        }

        public override int GetHashCode()
        {
            Food.Sort();
            return HashCode.Combine(Name, Age, City, Phone, Email, Food);
        }

        string CreateHash()
        {
            using var mySha256 = SHA256.Create();
            Food.Sort();
            var hashValue =
                mySha256.ComputeHash(Encoding.UTF8.GetBytes(this.Name +
                                                            this.Age +
                                                            this.City +
                                                            this.Phone +
                                                            this.Email +
                                                            string.Join(",", this.Food)));

            return BitConverter.ToString(hashValue);
        }
    }
}