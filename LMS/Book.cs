using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class Book: IBorrowable
    {
        public int BookId { get;set; }
        public string Title { get;set; }
        public string Author { get;set; }
        public BookStatus Status { get;set; }

        public void Borrow()
        {
            if(Status == BookStatus.Available)
            {
                Status= BookStatus.Borrowed;
            }
        }

        public void Return()
        {
            if(Status == BookStatus.Borrowed)
            {
                Status= BookStatus.Available;
            }
        }
    }
}
