using System;
using System.Collections.Generic;

namespace lab9_enhancedstudentinfo
{
    class Program
    {
        /*Program will recognize valid inputs when the user requests information
         * about students in class.
         * 
         * uses lists instead of arrays;
         * provides information about students in a class.
         * prompt the user to ask about a particular student.
         * give proper responses according to user submitted information.
         * ask user if they would like to learn about another student.
         * 
         * TODO: use lists instead of arrays.
         * List<string>
         * ArrayList
         * 
         * TODO: add another list to contain student's favorite number.
         * TODO: maybe use an array to contain choices for student info???
         * TODO: update validation to include favorite number. (no blanks!)
         * TODO: ask to add another student.
         * TODO: when a user adds another student, sort, locate student name in
         * list and then add the student info at the correct index.
         * TODO: make a StudentInfo class with name and other info as data members.
         * 
         * ** EX CHALLENGE, CONVERT TO A 2D ARRAY OR LIST!
         * 
         * use a list of StudentInfo instance to store the information.
         * 
         * input validation.*/

        static void Main(string[] args)
        {
            // declares lists
            List<string> Students = new List<string>{ "Angela","Bruce", "Chris",
                        "Dorian","Edward","Frank","Greg","Henry","Illya","Jim","Kendall","Lou","Mary",
                "Nancy","Othello","Paul", "Qurin", "Richard", "Stephen", "Tim",  };

            List<string>Hometowns = new List<string>{ "Akron, Ohio","Belleville, MI", "Chicago, IL", "Denver, CO",
                        "Edmonton, Canada", "Frankenmuth, MI", "Gary, IN", "Hamburg, Germany",
                        "Indianapolis, IN", "Jerusalem, Israel", "Kano, Nigeria", "La Trinidad, Nigeria",
                "Madison Heights, MI", "Nunapitchuk, Alaska", "Oakland, CA", "Pa Ju, South Korea",
                "Quebec City, Canada", "Richmond, VA", "San Diego, CA", "Tama, Japan", };

            List<string> FavFoods = new List<string>{"Lasagna","Soup", "Pizza","Chicken Schwarma","Pad Thai",
                "Hot Dogs","Apples","Potatoes","Drunken Noodle","Chips","Salad", "Sandwiches","Bibimbap","Chicken Vindaloo",
                "Lamb Korma","Jinga Masala", "Passion Fruit", "Hamburgers", "Tacos", "Pizza", };

            List<string> FavNumbers = new List<string> {"1","2", "3","4","5","6","7","8","9","10","11", "12","13","14",
                "15","16", "17", "18", "19", "20", };

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
                    bool RetrievingInfo = true;
                    while (RetrievingInfo == true)
                    {
                        Console.WriteLine("Enter a student number 1-20");
                        string userchoice;
                        userchoice = Console.ReadLine();
                        int studentnum;
                        int.TryParse(userchoice, out studentnum);
                        studentnum = studentnum - 1;

                        //input validation for student number.
                        if (studentnum < 0 || studentnum >= 20)
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

                // if user wants to add a student and their information.
                else if (RetrAddOrQuit == "add")
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

                            if (String.IsNullOrEmpty(NewStudent))
                            {
                                Console.WriteLine("Please enter a valid name.");
                                continue;
                            }
                            Students.Add(NewStudent);
                            Console.WriteLine(Students[Students.Count - 1]);
                            AskingName = false;

                        }

                        bool AskingHomeTown = true;
                        while (AskingHomeTown)
                        {
                            // addding hometown
                            Console.WriteLine("What is the student's hometown?");
                            String NewHometown = Console.ReadLine();

                            if (String.IsNullOrEmpty(NewHometown))
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

                            if (String.IsNullOrEmpty(NewFavFood))
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

                            int i;
                            bool success = int.TryParse(NewFavNumber, out i);

                            if (String.IsNullOrEmpty(NewFavNumber) || success == false)
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
                else if (RetrAddOrQuit == "quit")
                {
                    Console.WriteLine("Bye!");
                    RunProgram = false;
                }
                else
                {
                    RunProgram = AnotherStudent();
                }
            }

        }

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

        static bool AnotherStudent()
        {
            Console.WriteLine("Would you like to know more about another student?  Type y for yes or anything else for no.");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Bye!");
                return false;
            }
        }

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

        static void StudentAdder()
        {
        }
    }
}
