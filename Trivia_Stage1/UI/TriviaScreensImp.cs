using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trivia_Stage1.Models;

namespace Trivia_Stage1.UI
{
    public class TriviaScreensImp:ITriviaScreens
    {

        //Place here any state you would like to keep during the app life time
        //For example, player login details...


        //Implememnt interface here
        public bool ShowLogin()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
            return true;
        }
        public bool ShowSignUp()
        {
            //Logout user if anyone is logged in!
            //A reference to the logged in user should be stored as a member variable
            //in this class! Example:
            //this.currentyPLayer == null

            //Loop through inputs until a user/player is created or 
            //user choose to go back to menu
            char c = ' ';
            while (c != 'B' && c != 'b' /*&& this.currentyPLayer == null*/)
            {
                //Clear screen
                ClearScreenAndSetTitle("Signup");

                Console.Write("Please Type your email: ");
                string email = Console.ReadLine();
                while (!IsEmailValid(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Bad Email Format! Please try again:");
                    Console.ResetColor();
                    email = Console.ReadLine();
                }

                Console.Write("Please Type your password: ");
                string password = Console.ReadLine();
                while (!IsPasswordValid(password))
                {
                    Console.ForegroundColor= ConsoleColor.Red;  
                    Console.Write("password must be at least 4 characters! Please try again: ");
                    Console.ResetColor();   
                    password = Console.ReadLine();
                }

                Console.Write("Please Type your Name: ");
                string name = Console.ReadLine();
                while (!IsNameValid(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("name must be at least 3 characters! Please try again: ");
                    Console.ResetColor();
                    name = Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Connecting to Server...");
                Console.ResetColor();
                /* Create instance of Business Logic and call the signup method
                 * For example:
                try
                {
                    TriviaDBContext db = new TriviaDBContext();
                    this.currentyPLayer = db.SignUp(email, password, name);
                }
                catch (Exception ex)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to signup! Email may already exist in DB!");
                Console.ResetColor();
                }
                
                */

                //Provide a proper message for example:
                Console.WriteLine("Press (B)ack to go back or any other key to signup again...");
                //Get another input from user
                c = Console.ReadKey(true).KeyChar;
            }
            //return true if signup suceeded!
            return (false);
        }

        public void ShowAddQuestion()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
        }

        public void ShowPendingQuestions()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
        }
        public void ShowGame()
        {
            ShowQuestionAndAnswers();
            Console.WriteLine("What is your final answer?");
            int pans = int.Parse(Console.ReadLine());
            if()//שמנו את התשובות במערך של מספרים ועכשיו אנחנו רוצים למצוא את התשובה הנכונה ולראוץ אפ המשתמש צדק





        }

        TriviaContext context = new TriviaContext();
        int[] ansArrNumbers = new int[4];
        public void ShowQuestionAndAnswers()
        {
            Random rnd = new Random();
            int questionId=rnd.Next(1, context.Qs.Count() + 1);
            
            Q question = context.GetQ(questionId);
            if (question!=null)
                Console.WriteLine($"THEEEEE QUESTION ISSSSSS: {question}");

            // מראה שאלה בץקווה

            string correctAnswer = context.GetAnsCorrect(questionId);
            string answer1 = context.GetAns1(questionId);
            string answer2 = context.GetAns2(questionId);
            string answer3 = context.GetAns3(questionId);
            int index = rnd.Next(0, 4);
            string[] ansArr = new string[4];
            
           
            int tempIndex = 0;
            ansArr[0] = correctAnswer;
            ansArr[1] = answer1;
            ansArr[2] = answer2;
            ansArr[3] = answer3;
            for (int i = 0; i < ansArr.Length; i++)
            {
                while (index == tempIndex)
                {
                    index = rnd.Next(0, 4);
                }
                Console.WriteLine(ansArr[index]);
                ansArrNumbers[i] = index;
                tempIndex = index;

            }
        }


       

        
        public void ShowProfile()
        {
            Console.WriteLine("Not implemented yet! Press any key to continue...");
            Console.ReadKey(true);
        }


        //Private helper methods down here...
        private void ClearScreenAndSetTitle(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title,65}");
            Console.WriteLine();
            Console.ResetColor();   
        }

        private bool IsEmailValid(string emailAddress)
        {
            //regex is string based pattern to validate a text that follows a certain rules
            // see https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference

            var pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            var regex = new Regex(pattern);
            return regex.IsMatch(emailAddress);

        //another option is using .net System.Net.Mail library which has an EmailAddress class that stores email
        //we can use it to validate the structure of the email:
       // https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress?view=net-7.0
            /*
             * try
             * {
             *     //try to create MailAddress objcect from the email address string
             *      var email=new MailAddress(emailAddress);
             *      //if success
             *      return true;
             * }
             *      //if it throws a formatExcpetion then the string is not email format.
             * catch (Exception ex)
             * {
             * return false;
             * }
             */

        }



        private bool IsPasswordValid(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 3;
        }

        private bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 3;
        }
    }
}
