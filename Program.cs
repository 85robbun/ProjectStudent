using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ProjectStudent
{
    internal class Student
    {
        //Attributes
        private string fullName;

        private int age;
        private string martialStatus;
        private string birthMonth;
        private string housing;
        private string hobby;
        private string favoritCandy;
        private string education;
        private string favoritSeason;
        private string foodPreference;
        private string favoritAnimal;
        private string codingPassion;

        public Student()
        {
        }

        //Adding constructors
        public Student(string fullName, int age, string martialStatus, string birthMonth, string housing, string hobby,
            string favoritCandy,
            string education, string favoritSeason, string foodPreference, string favoritAnimal, string codingPassion)
        {
            this.fullName = fullName;
            this.age = age;
            this.martialStatus = martialStatus;
            this.birthMonth = birthMonth;
            this.housing = housing;
            this.hobby = hobby;
            this.favoritCandy = favoritCandy;
            this.education = education;
            this.favoritSeason = favoritSeason;
            this.foodPreference = foodPreference;
            this.favoritAnimal = favoritAnimal;
            this.codingPassion = codingPassion;
        }

        //Adding properties no need for set values here for application purpose.

        public string FullName
        {
            get => fullName;
        }

        public int Age
        {
            get => age;
        }

        public string MartialStatus
        {
            get => martialStatus;
        }

        public string Housing
        {
            get => housing;
        }

        public string Hobby
        {
            get => hobby;
        }

        public string FavoritCandy
        {
            get => favoritCandy;
        }

        public string Education
        {
            get => education;
        }

        public string FavoritSeason
        {
            get => favoritSeason;
        }

        public string FoodPreference
        {
            get => foodPreference;
        }

        public string FavoritAnimal
        {
            get => favoritAnimal;
        }

        public string CodingPassion
        {
            get => codingPassion;
        }

        //ToString medthod used a Micrsoft example that i really liked
        public override string ToString()
        {
            return ToString("A");
        }

        //Extending toString method in order to use more options in Main and make code "cleaner"
        //Example showing separate string  as "passion for C#" or "Just showing student names"
        public string ToString(string fmt)
        {
            if (string.IsNullOrEmpty(fmt))
                fmt = "A";

            switch (fmt.ToUpperInvariant())
            {
                //Show All Student Deatails testing adding rows
                //Would have worked much better if we used letters limits instead of adding long sentences that wont align.
                case "A":
                    return String.Format("{0,-15}", fullName);

                //Show Stundents names only
                case "B":

                    return string.Format(
                        "|-------------------------------------*C#Student*------------------------------------------------|\n" +
                        "|>Name: {0,-15}|Age: {1,-10}|Housing: {2,-10}|Favorite Hobby: {3,-10} \n" +
                        "|>Favorite Candy:{4,-10}|Education:{5,-10} |Favorite Season:{6,-10}\n" +
                        "|>Food Preference:{7,-10}|Favorite Animal>:{8,-10}\n" +
                        "|>Pation for code: \n*{9,-10}\n" +
                        "|----------------------------------------*end*---------------------------------------------------|\n"
                        , fullName, age, housing, hobby, favoritAnimal, education, favoritSeason, foodPreference, favoritAnimal, codingPassion);

                case "C":
                    return String.Format(
                           "|--------------------------------------------------------------------------------------------------|\n" +
                           "|Name: {0,-15}\n|Text: {1,-10}\n" +
                           "|-----------------------------------------*C#harksRock*--------------------------------------------|\n"
                           , fullName, codingPassion);
                //Using this case to export list inro the text file
                case "D":
                    return string.Format(
                           $"|>Name: {fullName}\n" +
                           $"|>Age: {Age}\n" +
                           $"|>Martial Status: {martialStatus}\n" +
                           $"|>Accommodation: {housing}\n" +
                           $"|>Favorite hobby: {hobby}\n" +
                           $"|>Favorite candy: {FavoritCandy}\n" +
                           $"|>Education: {Education}\n" +
                           $"|>Favorite season: {favoritSeason}\n" +
                           $"|>Food preferences: {foodPreference}\n" +
                           $"|>Favorite animal: {favoritAnimal}\n" +
                           $"|>Drive in programming: {codingPassion}\n");
                //In case error throws a message Preventing the error message
                //I could have used toString method for the whole aplication without creating additinal methods live listNames(),listAllDetails() and so on.
                //Default string msg would not couse any error as the values are entered by developer and passed to another method.
                //Therefore users will never have a option to choose/pick  the "wrong"/not exsisting value.
                default:
                    string msg = string.Format("'{0}' Is invalid string",
                        fmt);
                    throw new ArgumentException(msg);
            }
        }
    }

    internal class Program
    {
        //Making studentList accessible from this scope
        private static List<Student> studentList = new List<Student>();

        private static void Main(string[] args)
        {
            ListOFStudents();
            //Making keyboard press available
            ConsoleKeyInfo cki;

            //Creating simple switch menu with deiffrent options
            //All the options are added methods
            //used bool and while , i could have also used keystocks for esc button for exit  and do and while loop for the menu.
            PassToEnter();
            bool isON = true;
            while (isON)
            {
                //Method for displaying the menu
                Thread.Sleep(2000);
                OptMenu();

                cki = Console.ReadKey(true); // hide key when user input
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        //Print student Names only
                        ListNames();
                        break;

                    case "2":
                        ListAllDeatils();
                        break;

                    case "3":
                        ListNamesPassion();
                        break;

                    case "4":
                        DeleteStudent();
                        break;

                    case "5":
                        SaveToTxt();
                        break;

                    case "6":
                        Console.WriteLine("Exiting");
                        isON = false;
                        break;
                    // etc..
                    default:
                        Console.WriteLine("Invalid input. only numbers in menu!");
                        break;
                }
            }
        }

        //Adding a method for menu
        private static void OptMenu()
        {
            Console.WriteLine("\n" +
                               "|--------------------Menu-----------------------|\n\n" +
                               "|>[1]Show C#sharsk student names                |\n" +
                               "|>[2]Show C#sharsk students detailed info       |\n" +
                               "|>[3]Show C#sharsk students passion for Coding  |\n" +
                               "|>[4]Remove C#sharsk student                    |\n" +
                               "|>[5]Save studentlist to Mydocuments            |\n" +
                               "|>[6]Quit Aplication                            |\n" +
                               "|------------------C#sharks---------------------|");
        }

        //Creating and Adding students with their properties to list
        private static void ListOFStudents()
        {
            ///Creating List with C# memebrs

            studentList.Add(new Student("Tina Seger", 28, "Gift", "December", "Villa", "Löpning", "Saltlakrits",
                "Biomedicin-inriktning:fysisk träning", "Sommar", "Vegetariskt", "Hund",
                "Viljan att skapa en kreativ och intellektuell tillvaro, oberoende av fasta klockslag"));

            studentList.Add(new Student("Robert Bunjaku", 35, "Gift", "Novermber", "Lägenhet", "Fiska", "Choklad",
                "IT-säkerhet", "Sommar",
                "Pasta",
                "Hund",
                "Kombinera tidigare utbildning med nya kunskaper \n för att släppa los den kreativa kraften och styra/forma egna framtiden"));
            studentList.Add(new Student("Christofer Brizet", 35, "Sambo", "September", "Villa", "Gitarr,spel,läsa", "Sötlakrits",
                "Installationstekniker", "Höst",
                "Stinky French cheeses",
                "", "Planera, skapa och ett enormt svängrum för kreativitet ,plus fantasin om att erövra världen"));
            studentList.Add(new Student("Johan Rodin", 27, "Sambo", "Mars", "Lägenhet",
                "Poker och footboll", "Blandgodis",
                "Nätverksdrift", "Vinter",
                "Pasta",
                "Hund", "Egna arbetstider, roligt och intressant"));
            studentList.Add(new Student("Victor Salmberg", 30, "Singel", "Januari", "Lägenhet", "Gitarr", "Choklad",
                "Arabiska", "Höst",
                "Vegetarisk,och bacon",
                "Katt", "Kicken att förstå nya koncept och möjligheten till ett utvecklande arbetsliv."));
            studentList.Add(new Student("Oskar Kling", 30, "Sambo", "November", "Lägenhet", "Datorspel", "Kexchoklad",
                "Ett år Ekonmomi.Ett år Software Engineer", "Höst",
                "Kött,helst biff",
                "Hund och katt", "Kreativt, roligt, kontroll och problemlösning"));
            studentList.Add(new Student("Elias Hjalm", 22, "Sambo", "", "Lägenhet", "Datorspel", "Choklad",
                "Halvår Intgeraktionsdesigner", "Sommar", "Vegansk", "Hund",
                "Att få arbeta med något som är kreativt och som jag alltid kan utvecklas inom"));
            studentList.Add(new Student("Fisnik Balija", 32, "Flickvän", "", "Villa", "Fotboll", "Choklad",
                "Masterexamen i Geologi", "Sommar", "Allätare,föredrar kätt", "Hund",
                "Fascineras av hur något så enkelt men samtidigt komplicerat kan skapa något kraftfullt och användbart.\n Vidare så är programmering oerhört utmanande, spännande och framförallt roligt!"));
        }

        //Method for removing student from list
        //i chose to use full name case sensitive in order to remove
        //After all it shouldnt be that easy to delete C#sharks student
        private static void DeleteStudent()
        {
            ListNames();

            Console.WriteLine("\n\nEnter students full name ,case sensitive ,example: Robert Bunjaku");
            string removedStudent = Console.ReadLine();
            // studentList.RemoveAll(s => s.Name == removedStudent);
            /* foreach (Student student in studentList)
             {
                 Console.WriteLine(student);
                 }*/
            if (studentList.Any(student => removedStudent.Contains(student.FullName)))
            {
                studentList.RemoveAll(s => s.FullName == removedStudent);
                Console.WriteLine("You removed");
                ListNames();
            }
            else
            {
                Console.WriteLine("Wrong input!:TryAgain");
                DeleteStudent();
            }
        }

        // Console.WriteLine("You have removed: " + removedStudent);

        //Creating and Adding students with their properties to list

        //method for printing student names with comma
        private static void ListNames()
        {
            foreach (var student in studentList)
            {
                Console.Write($"{{0}},", student.FullName);
            }
        }

        //method for prtinting student names with all details and using toString method
        private static void ListAllDeatils()
        {
            foreach (Student s in studentList)
            {
                Console.WriteLine(s.ToString("B"));
            }
        }

        //method for prtinting student names with all details and using toString method
        private static void ListNamesPassion()
        {
            foreach (Student s in studentList)
            {
                Console.WriteLine(s.ToString("C"));
            }
        }

        //Password required to enter the aplication without exit or counting max tries.
        //I want you to login , no secrets here
        //Added little delay logging in info so the user can get time to realize he guessed right :)
        private static void PassToEnter()
        {
            var password = "";

            while (password != "csharks")
            {
                Console.WriteLine("What is the pass code?");
                password = Console.ReadLine();

                if (password == "csharks")
                {
                    Console.WriteLine("Password authentication successful!");
                    Console.Write("Logging in");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(500);
                    Console.Clear();
                }
                else if (password != "csharks")
                {
                    Console.WriteLine("Wrong password!");
                    Console.Write("Please try again: ");
                }
            }
        }

        //Adding a method to save the file do MyCoduments/Mina dokument
        private static void SaveToTxt()
        {
            Console.WriteLine("Saving a file...");
            Thread.Sleep(2000);
            Console.WriteLine("All done check your Mydocuments/Mina dokumment for StudentList.txt");
            Thread.Sleep(2000);
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (TextWriter tw = new StreamWriter(Path.Combine(docPath, "StudentList.txt")))

                foreach (Student s in studentList)
                {
                    tw.WriteLine(s.ToString("D"));
                }
        }
    }
}