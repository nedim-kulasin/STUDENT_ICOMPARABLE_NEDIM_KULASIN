using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        // Main program, test case
        static void Main(string[] args)
        {
            //it will list all students
            List<Student> list = new List<Student>();
            list.Add(new Student("Adis", "Jugo", "adis.jugo@hotmail.com", "Sarajevo"));
            list.Add(new Student("Nedim", "Kulasin", "nedim.kulasin@hotmail.com", "Hrasno"));
            list.Add(new Student("Hamo", "Hamic", "hamo.hamic@hotmail.com", "Tuzla"));
            list.Sort();
            foreach (Student s in list)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }

    class Person
    {
        //all strings 
        protected string name;
        private string LastName;
        public static int count = 0;
        public string lastName
        {
            get { return LastName; }
            set
            {
                //Check if last name has more than 2 characters
                if (value.Length < 2) throw new Exception("Last name must have more then two characters");
                foreach (Char c in value)
                {
                    //It will check if last name has only letters, nothing else
                    if (!Char.IsLetter(c))
                    {
                        //throws this exception
                        throw new Exception("Last name cannot contain anything else then letters");
                    }
                }
                LastName = value;
            }
        }
        
        protected Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            count++; // Create count of number persons
        }

        public Person()
        {
            count++; // Create count of number persons
        }

        public string getPersonInfo() { return name + ", " + lastName; }

    };


    class Student : Person, IComparable
    {
        ~Student() //It is empty destructor
        {

        }

        public string email { get; set; } // Property of email

        private string _location; // Variable for another automatic property

        // Automatic property Location
        public string Location
        {
            set
            {
                if (value == "SA" || value == "Sarajevo" || value == "SARAJEVO") this._location = "SA";
                else
                    if (value.ToLower() == "tuzla") this._location = "TZ";
                    else
                        this._location = "NA";
            }
            get
            {
                if (this._location == "SA") return "Sarajevo";
                if (this._location == "TZ") return "Tuzla";
                return "Other";
            }
        }

        //Constructor for another 3 parameters
        public Student(string name, string lastName, string email)
            : base(name, lastName) //Student constructor will take 3 strings arguments lastname, name and email by calling the Parent class constructor
        {
            this.email = email;
        }
        
        //Constructor for 4 parameters
        public Student(string name, string lastName, string email, string location)
            : base(name,lastName)
        {
            this.Location = location;
            this.email = email;
        }
        public bool setName(string input)
        {
            //It will check if name has more than 2 characters
            if (input.Length < 2)
            {
                Console.WriteLine("Name must have more then two characters");
                return false;
            }
            //It will check if Name has only letters
            if (input.All(Char.IsLetter))
            {
                Console.WriteLine("Last name cannot contain anything else then letters");
                return false;
            }
            //Check if Name starts with uppercase letter
            if (Char.IsLower(input[0]))
            {
                Console.WriteLine("Name cannot start with lowercase letter");
                return false;
            }
            //Everything's okay, return true and set name to input.
            this.name = input;
            return true;
        }

        public Student() : base()
        {

        }

        public string getStudentInfo()
        {
            return getPersonInfo()+", "+email+", "+Location;
        }

        public int CompareTo(object other)
        {
            return name.CompareTo(((Student)other).name);
        }

        public string ToString()
        {
            return getStudentInfo();
        }
    }
}
