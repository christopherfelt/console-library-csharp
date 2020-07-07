namespace library.Models 
{
    
    public class Book
    {
        public Book(string title, string author, bool available)
        {
            Title = title;
            Author = author;
            Available = available;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }
    }
}