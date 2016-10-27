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
            //Print it out
            Console.WriteLine(person1.text, person1.name);
            Console.WriteLine(person1.name);
            Console.ReadKey();


        }
                         
    }
}
