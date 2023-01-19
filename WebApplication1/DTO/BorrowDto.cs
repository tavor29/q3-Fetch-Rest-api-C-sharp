using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class BorrowDto
    {
        
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Returned { get; set; }

        public System.DateTime BroughtDate { get; set; }

        

        //public BorrowDto(string Studentname, int StudentId, int BookId, string BookName, int BorrowId, int Returned) 
        //{
        //    studentName = Studentname;

        //    studentId = StudentId;

        //    bookName = BookName;

        //    returned = Returned;

        //    bookId = BookId;

        //    borrowId= BorrowId;

        //    broughtDate = DateTime.Now;

        //}

    }
}