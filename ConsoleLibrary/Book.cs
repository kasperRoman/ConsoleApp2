using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public abstract class Book
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Author { get; private set; }

        public bool IsBorrowed { get; private set; }

        public Book(string title, string author)
        {
            Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title cannot be null or empty.") : title;
            Author = string.IsNullOrWhiteSpace(author) ? throw new ArgumentException("Author cannot be null or empty.") : author;
        }
        public virtual BorrowResult Borrow()
        { 
           if (IsBorrowed)
            {
                return BorrowResult.AlreadyBorrowed;
            }
            IsBorrowed = true;
            return BorrowResult.Success;
        }

    }
   
}
