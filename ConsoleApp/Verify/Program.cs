using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verify
{
    class Person
    {
        //Definition of Fields
        public string text;
        public string name;

        //Create Constructor
        public Person()
        {
            text = "Hellobuild";
            name = "Peter Johansson";
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create objekt
            Person person1 = new Person();

            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Hello," + name);

            Console.WriteLine("How many hours did you sleep lanst night");
            int hours = int.Parse(Console.ReadLine());

            //Console.WriteLine(person1.text + person1.name + test);
            if (hours < 8)
            {
                Console.WriteLine("You seems to be tired");
            }
            else
            {
                Console.WriteLine("you must be happy");
            }
            Console.WriteLine("Goodby," + name);
            Console.ReadKey();


        }
                         
    }
    class Account
    {

    }
}
