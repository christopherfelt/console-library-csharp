using System;
using System.Collections.Generic;
using library.Models;

namespace library 
{
    public class App
    {
        public Library Library { get; set; } = new Library();
        public bool Running { get; set; }
        public void Run()
        {
            Console.Clear();
            System.Console.WriteLine("Hello! Welcome to the Library");
            System.Console.WriteLine("Here are the available books:");
            System.Console.WriteLine();
            Running = true;
            while(Running){
                System.Console.WriteLine("What would you like to see?");
                System.Console.WriteLine("Checked In or Checked Out or enter \"quit\" to exit");
                string choice = Console.ReadLine().ToLower();
                if(choice == "checked in"){
                    GetCheckedIn();
                    System.Console.WriteLine("Would you like to check out a book?");
                    System.Console.WriteLine("Yes or No?");
                    string checkOutChoice = Console.ReadLine().ToLower();
                    if(checkOutChoice == "yes")
                    {
                        System.Console.WriteLine("Which book would you like to checkout? Return the Number.");
                        string checkOutBookChoice = Console.ReadLine().ToLower();
                        bool validBookChoice = ValidateCheckoutBookChoice(checkOutBookChoice);
                        if(validBookChoice){
                            int num = Int32.Parse(checkOutBookChoice);
                            Book checkedOutBook = Library.Books[num-1];
                            
                            checkedOutBook.Available = false;
                            
                            System.Console.WriteLine("Booked successfully checked out");
                            System.Console.WriteLine($"{checkedOutBook.Title} by {checkedOutBook.Author}.");
                        } else {
                            System.Console.WriteLine("Sorry that is not a valid book selection.  You die.");
                        }
                    }

                } else if (choice == "checked out") {
                    GetCheckedOut();
                    System.Console.WriteLine("Would you like to check in a book?");
                    System.Console.WriteLine("Yes or No?");
                    string checkInChoice = Console.ReadLine().ToLower();
                    if(checkInChoice == "yes")
                    {
                        System.Console.WriteLine("Which book would you like to checkout? Return the Number.");
                        string checkInBookChoice = Console.ReadLine().ToLower();
                        bool validBookChoice = ValidateCheckInBookChoice(checkInBookChoice);
                        if(validBookChoice){
                            int num = Int32.Parse(checkInBookChoice);
                            Book checkedInBook = Library.Books[num-1];
                            
                            checkedInBook.Available = true;
                            
                            System.Console.WriteLine("Booked successfully checked In");
                            System.Console.WriteLine($"{checkedInBook.Title} by {checkedInBook.Author}.");
                        } else {
                            System.Console.WriteLine("Sorry that is not a valid book selection.  You die.");
                        }
                    }

                } else if (choice == "quit")
                {
                    Running = false;
                    System.Console.WriteLine("You die");
                } 
                else {
                    System.Console.WriteLine("I'm sorry that is not an option");
                    System.Console.WriteLine("You die");
                }
            }



        }

        public void GetCheckedIn()
        {
            for (int i = 0; i < Library.Books.Count; i++)
            {
                Book book = Library.Books[i];
                if(book.Available)
                {
                    System.Console.WriteLine($"{i+1}.");
                    System.Console.WriteLine($"Title: {book.Title}");
                    System.Console.WriteLine($"Author: {book.Author}");
                    System.Console.WriteLine($"Checked in: {book.Available}");
                    System.Console.WriteLine();
                }

            }
        }
        public void GetCheckedOut()
        {
            for (int i = 0; i < Library.Books.Count; i++)
            {
                Book book = Library.Books[i];
                if(!book.Available)
                {
                    System.Console.WriteLine($"{i+1}.");
                    System.Console.WriteLine($"Title: {book.Title}");
                    System.Console.WriteLine($"Author: {book.Author}");
                    System.Console.WriteLine($"Checked in: {book.Available}");
                    System.Console.WriteLine();
                }

            }
        }

        public bool ValidateCheckoutBookChoice(string bookChoice){
            int validBookChoice = ValidateBookChoice(bookChoice);
            List<Book> Books = Library.Books;
            System.Console.WriteLine("validBookChoice: "+ validBookChoice.ToString());
            if(validBookChoice == -1){
                return false;
            }
            if(Books[validBookChoice].Available){
                return true;
            }
            return false;
        }

        public bool ValidateCheckInBookChoice(string bookChoice){
            int validBookChoice = ValidateBookChoice(bookChoice);
            List<Book> Books = Library.Books;
            System.Console.WriteLine("validBookChoice: "+ validBookChoice.ToString());
            if(validBookChoice == -1){
                return false;
            }
            if(!Books[validBookChoice].Available){
                return true;
            }
            return false;
        }

        public int ValidateBookChoice(string bookChoice){
            int num;
            List<Book> Books = Library.Books;
            if(Int32.TryParse(bookChoice, out num)){
                if(num <=  Library.Books.Count){
                    return num-1;
                }
            };
            return -1;
        }
    }
}