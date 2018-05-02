using System;
using System.Collections.Generic;
using System.Linq;

namespace lab9_enhancedstudentinfo
{
    class Program
    {
        /*Program will recognize valid inputs when the user requests information
         * about students in class.
         * 
         * uses lists instead of arrays.
         * provides hometown, favorite food and favorite number information about students in a class.
         * prompt the user to retrieve, add or quit.
         * gives proper responses according to user submitted information.
         * ask user if they would like to learn or add info about another student at the correct steps.
         * added support for more than 20 students.
         * using LINQ for input validation to reject numbers when appropriate to do so.
         * 
         * TODO: EX Challenge: when a user adds another student, sort, 
         * locate student name in list and then add the student info at the correct index.
         * TODO: make a StudentInfo class with name and other info as data members. */

        // delcare lists
        public static List<string> Students = new List<string>{ "Angela","Bruce", "Chris",
                        "Dorian","Edward","Frank","Greg","Henry","Illya","Jim","Kendall","Lou","Mary",
                "Nancy","Othello","Paul", "Qurin", "Richard", "Stephen", "Tim",  };
        public static List<string> Hometowns = new List<string>{ "Akron, Ohio","Belleville, MI", "Chicago, IL", "Denver, CO",
                        "Edmonton, Canada", "Frankenmuth, MI", "Gary, IN", "Hamburg, Germany",
                        "Indianapolis, IN", "Jerusalem, Israel", "Kano, Nigeria", "La Trinidad, Nigeria",
                "Madison Heights, MI", "Nunapitchuk, Alaska", "Oakland, CA", "Pa Ju, South Korea",
                "Quebec City, Canada", "Richmond, VA", "San Diego, CA", "Tama, Japan", };

        public static List<string> FavFoods = new List<string>{"Lasagna","Soup", "Pizza","Chicken Schwarma","Pad Thai",
                "Hot Dogs","Apples","Potatoes","Drunken Noodle","Chips","Salad", "Sandwiches","Bibimbap","Chicken Vindaloo",
                "Lamb Korma","Jinga Masala", "Passion Fruit", "Hamburgers", "Tacos", "Pizza", };

        public static List<string> FavNumbers = new List<string> {"1","2", "3","4","5","6","7","8","9","10","11", "12","13","14",
                "15","16", "17", "18", "19", "20", };
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class!");

            // RunProgram is set to true, GoAgainAsker() and AnotherStudent() will set it to false.
            bool RunProgram = true;
            while (RunProgram == true)
            {
                //asks to retrieve or add
                Console.WriteLine("Type \"retrieve\" to retrieve information about a student.");
                Console.WriteLine("Type \"add\" to add a student and their information.");
                Console.WriteLine("Type \"quit\" to quit the program.");

                string RetrAddOrQuit = Console.ReadLine().ToLower();

                if (RetrAddOrQuit != "retrieve" && RetrAddOrQuit != "add" && RetrAddOrQuit != "quit")
                {
                    continue;
                }

                // if user wants to retrieve student info
                else if (RetrAddOrQuit == "retrieve")
                {
                    StudentRetriever();
                }
                // if user wants to add a student and their information.
                else if (RetrAddOrQuit == "add")
                {
                    StudentAdder();
                }
                // if user wants to quit
                else if (RetrAddOrQuit == "quit")
                {
                    Console.WriteLine("Bye!");
                    RunProgram = false;
                }
            }

        }

        // method to request user Y or N for more student info retrieval.
        static bool MoreInfoAsker()
        {
            Console.WriteLine("Would you like to know more about this student?  Type y for yes or anything else for no.");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // method to request user Y or N for more student info retrieval.
        static bool AddAnotherStudentAsker()
        {
            Console.WriteLine("Would you like to add information about another student?  Type y for yes or anything else for no.");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // method for adding students.
        static void StudentAdder()
        {
            bool AddingInfo = true;
            while (AddingInfo)
            {
                // adding name
                bool AskingName = true;
                while (AskingName)
                {
                    Console.WriteLine("What is the student's name?");
                    string NewStudent = Console.ReadLine();


                    bool numbersuccess = NewStudent.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewStudent) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid name.");
                        continue;
                    }
                    Students.Add(NewStudent);
                    AskingName = false;

                }

                bool AskingHomeTown = true;
                while (AskingHomeTown)
                {
                    // addding hometown
                    Console.WriteLine("What is the student's hometown?");
                    String NewHometown = Console.ReadLine();

                    bool numbersuccess = NewHometown.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewHometown) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid hometown.");
                        continue;
                    }
                    Hometowns.Add(NewHometown);
                    AskingHomeTown = false;
                }

                bool AskingFavFood = true;
                while (AskingFavFood)
                {
                    // adding favorite food
                    Console.WriteLine("What is the student's favorite food?");
                    String NewFavFood = Console.ReadLine();

                    bool numbersuccess = NewFavFood.Any(char.IsDigit);

                    if (String.IsNullOrEmpty(NewFavFood) || numbersuccess == true)
                    {
                        Console.WriteLine("Please enter a valid favorite food.");
                        continue;
                    }
                    FavFoods.Add(NewFavFood);
                    AskingFavFood = false;
                }

                bool AskingFavNum = true;
                while (AskingFavNum)
                {
                    // adding favorite number
                    Console.WriteLine("What is the student's favorite number?");
                    String NewFavNumber = Console.ReadLine();

                    bool numbersuccess = NewFavNumber.All(char.IsDigit);

                    if (String.IsNullOrEmpty(NewFavNumber) || numbersuccess == false)
                    {
                        Console.WriteLine("Please enter a valid favorite number.");
                        continue;
                    }
                    FavNumbers.Add(NewFavNumber);
                    AskingFavNum = false;

                }
                // ask to add another student
                AddingInfo = AddAnotherStudentAsker();
            }
        }

        //method for retrieving student info
        static void StudentRetriever()
        {
            bool RetrievingInfo = true;
            while (RetrievingInfo == true)
            {
                Console.WriteLine($"Enter a student number 1-{Students.Count}");
                string userchoice;
                userchoice = Console.ReadLine();
                int studentnum;
                int.TryParse(userchoice, out studentnum);
                studentnum = studentnum - 1;

                //input validation for student number.
                if (studentnum < 0 || studentnum >= Students.Count)
                {
                    Console.WriteLine("That student does not exist.  Please try again.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Student {studentnum + 1} is {Students[studentnum]}. What would you like to know about {Students[studentnum]}?");
                    while (RetrievingInfo == true)
                    {
                        Console.WriteLine("Enter 'hometown', 'favorite food' or 'favorite number'.");
                        string infochoice = Console.ReadLine().ToLower();

                        // input validation for student's info selection.
                        if (infochoice != "hometown" && infochoice != "favorite food" && infochoice != "favorite number")
                        {
                            Console.WriteLine("That data does not exist.  Please try again.");
                            continue;
                        }

                        else if (infochoice == "hometown")
                        {
                            Console.WriteLine($"{Students[studentnum]} is from {Hometowns[studentnum]}.");
                            RetrievingInfo = MoreInfoAsker();
                        }
                        else if (infochoice == "favorite food")

                        {
                            Console.WriteLine($"{Students[studentnum]}'s favorite food is {FavFoods[studentnum]}.");
                            RetrievingInfo = MoreInfoAsker();

                        }
                        else if (infochoice == "favorite number")
                        {
                            Console.WriteLine($"{Students[studentnum]}'s favorite number is {FavNumbers[studentnum]}.");
                            RetrievingInfo = MoreInfoAsker();
                        }
                    }
                }
            }
        }
    }
}
