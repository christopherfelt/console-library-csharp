using System.Collections.Generic;

namespace library.Models 
{
    
    public class Library
    {
        public Library()
        {
                        
            Books.Add(new Book("The Dispossessed", "Ursula K. Le Gein", true));
            Books.Add(new Book("Post-Scarcity Anarchism", "Murray Bookchin", true));
            Books.Add(new Book("Fields, Factories, and Workshops", "Peter Kropotkin", false));
            

        }
        

        public List<Book> Books { get; private set; } = new List<Book>();

    }
}