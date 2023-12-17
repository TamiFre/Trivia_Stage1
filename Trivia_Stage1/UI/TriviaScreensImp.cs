using Microsoft.EntityFrameworkCore.Storage.Internal;
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
        private Player player =new Player();
        TriviaContext context = new TriviaContext();
        int[] ansArrNumbers = new int[4];
       



        //לשמור את המשתמש שהתחבר


        private Player Login(string name, string pass, string mail)
        {
            return context.Login(name, pass, mail);
        }

        //Implememnt interface here
        public bool ShowLogin()
        {
            string name = "";
            string pass = "";
            string mail = "";
            Console.WriteLine("Please enter Username");
            try
            {
                name = Console.ReadLine();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Please enter Password");
            try
            {
                pass = Console.ReadLine();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine("Please enter Email");
            try
            {
                mail = Console.ReadLine();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //if (Login(name, pass, mail) )
            //{
            //    context.SetPlayerMail(mail, player.PlayerId);
            //    context.SetPlayerName(name, player.PlayerId);
            //    context.SetPlayerPass(pass, player.PlayerId);
            //    Console.WriteLine("You've successfully logged in");
            //    return true;
            //}
            //Console.WriteLine("Wrong email/password/username");
            //return false;
            Player player2 = context.Login(name, pass, mail);
            if (player2 != null)
            {
                Console.WriteLine("Success");
                Thread.Sleep(3000);
                this.player = player2;
                return true;
            }


            Console.WriteLine("fail");
            Thread.Sleep(3000);
            return false;




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






        //לשאול האם התנאים קורים לפלייר ואם כן להראות את כל השאלות ולתת לו להוסיף שאלה
        //להוסיף את השאלה בשורה נפרדת שבה הוא יכתוב את כל מה שצריך לשאלה
        public void ShowAddQuestion()
        {
            if (player.Points >= 100 || player.DargaId == 2 || player.DargaId == 3)
            {
                Q newQ = new Q();
                string? newTitle = "";
                string? newSub = "";
                string? newCorrect = "";
                string? newWrong1 = "";
                string? newWrong2 = "";
                string? newWrong3 = "";




                Console.WriteLine("Enter new question please");
                try
                {
                    newTitle = Console.ReadLine();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                context.SetTitle(newTitle, newQ.Qid);

                Console.WriteLine("Enter subject");
                    try
                    {
                        newSub = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetSubject(newSub, newQ.Qid);

                    Console.WriteLine("Enter the correct answer");
                    try
                    {
                        newCorrect = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetCorrectAns(newCorrect, newQ.Qid);

                    Console.WriteLine("Enter wrong answer #1");
                    try
                    {
                        newWrong1 = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetA1(newWrong1, newQ.Qid);

                    Console.WriteLine("Enter wrong answer #2");
                    try
                    {
                        newWrong2 = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetA2(newWrong2, newQ.Qid);

                    Console.WriteLine("Enter wrong answer #3");
                    try
                    {
                        newWrong3 = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetA1(newWrong3, newQ.Qid);
               
                
            }
            else

            { 
            Console.WriteLine("You are not allowed to add a question. get tf out of here");
            Thread.Sleep(3000);
            }

        }





        
        //לשאול האם התנאים קורים לפלייר ואם כן להראות לו בלולאה את השאלות ולשאול אם לאשר או לא
        //לשנות את הסטטוס של השאלה לאפרובד או דיקליינד
        public void ShowPendingQuestions()
        {
            if (player.DargaId == 3)
            {
                int i = 0;
                string continueStatus = "No";
                while (continueStatus != "No" || i>context.GetPendingQs().Count)
                {
                    try  // תופס אם יש שגיאה לדוגמה אם מישהו מכניס מספר במקום סטרינג
                    {
                        Console.WriteLine(context.GetPendingQs()[i]);
                        Console.WriteLine("Would you like to approve the question? If yes press Y");
                        string wannaAprrove = Console.ReadLine();
                        if (wannaAprrove == "Y")
                        {
                            context.SetQStatusToApprove(context.GetPendingQs()[i].Qid);
                        }
                        else
                        {
                            context.SetQStatusToDeclined(context.GetPendingQs()[i].Qid);
                        }
                        i++;
                        Console.WriteLine("Would you like to continue approving questions? If not write No");
                        continueStatus = Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            else 
            { 
                Console.WriteLine("You are not allowed here. Get tf out");
                Thread.Sleep(3000);
            }
        }





        public void ShowGame()
        {
            ShowQuestionAndAnswers();
            Console.WriteLine("What is your final answer?");
            int pans = int.Parse(Console.ReadLine());
            if (ansArrNumbers[pans] == 0)
            {
                Console.WriteLine("Congrats! You were right! +10 points.");
                context.SetPoints(player.PlayerId, context.GetPoints(player.PlayerId) + 10);
                Thread.Sleep(3000);

            }//שמנו את התשובות במערך של מספרים ועכשיו אנחנו רוצים למצוא את התשובה הנכונה ולראוץ אפ המשתמש צדק
            else
            {
                Console.WriteLine("Nice try! But you were wrong, you should kill yourself.");
                Console.WriteLine("But because this game does not have the authority to kill you, -5 points");
                context.SetPoints(player.PlayerId, context.GetPoints(player.PlayerId) -5);
                Thread.Sleep(3000);
            }

        }



       
        
        
        public void ShowQuestionAndAnswers()
        {
            Random rnd = new Random();
            int questionId=rnd.Next(1, context.Qs.Count() + 1);
            
            Q question = context.GetQ(questionId);
            if (question!=null)
                Console.WriteLine($"THEEEEE QUESTION ISSSSSS: {context.GetTitle(question.Qid)}");

            // מראה שאלה בץקווה

            string correctAnswer = context.GetAnsCorrect(questionId);
            string answer1 = context.GetAns1(questionId);
            string answer2 = context.GetAns2(questionId);
            string answer3 = context.GetAns3(questionId);
            int index = rnd.Next(0, 4);
            string[] ansArr = new string[4];
            
           
            
            ansArr[0] = correctAnswer;
            ansArr[1] = answer1;
            ansArr[2] = answer2;
            ansArr[3] = answer3;
            for (int i = 0; i < ansArr.Length; i++)
            {
                while ( ansArr[index] == null)
                {
                    index = rnd.Next(0, 4);
                }
                Console.WriteLine(ansArr[index]);
                ansArrNumbers[i] = index;
                ansArr[index] = null;
            }
        }


       

        
        public void ShowProfile()
        {
            Console.WriteLine($"Hello {context.GetPlayerName(player.PlayerId)}, welcome back!");
            Console.WriteLine("Your private details are:");
            Console.WriteLine($"Your Email is: {context.GetPlayerMail(player.PlayerId)}");
            Console.WriteLine($"The amount of points you have: {context.GetPoints(player.PlayerId)}");
            Console.WriteLine($"Your Rank is: {context.GetDargaName(player.PlayerId)}");
            Console.WriteLine("Do you want to want to change any of your private details?");
            string answer = "start";
            string name = "";
            string mail = "";
            string pass = "";

            try 
            { 
            answer = Console.ReadLine();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }



            if (answer == "yes")
            {
                
                Console.WriteLine("Do you want to change your name?");
                try 
                { 
                answer = Console.ReadLine();
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message); 
                }
                if (answer == "yes")
                {
                    Console.WriteLine("Enter you new name");
                    try
                    {
                        name = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetPlayerName(name, player.PlayerId);
                }
                Console.WriteLine("Do you want to change your mail?");
                answer = Console.ReadLine();
                if (answer == "yes")
                {
                    
                    Console.WriteLine("Enter you new mail");
                    try
                    {
                        mail = Console.ReadLine();
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetPlayerMail(mail, player.PlayerId);
                }
                Console.WriteLine("Do you want to change your password?");
                answer = Console.ReadLine();
                if (answer == "yes")
                {
                    Console.WriteLine("Enter you new password");
                    try 
                    { 
                    pass = (Console.ReadLine());
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    context.SetPlayerPass(pass, player.PlayerId);
                }

            }
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
