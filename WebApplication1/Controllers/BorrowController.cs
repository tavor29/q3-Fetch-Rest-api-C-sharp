using ClassLibrary1;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.UI.WebControls;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    public class BorrowController : ApiController
    {
        LibraryDbEntities db = new LibraryDbEntities();
        List<BorrowDto> borrows;
        // [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/borrow/table/{filter}")]
        public HttpResponseMessage GetByFilter(int filter)
        {
            
            if (filter < 2)
            {
                borrows = db.Borrows
                    .Where(x => x.returned == filter)
                    .Select(x => new BorrowDto()
                    {
                        StudentId = x.studentId,
                        StudentName = x.Student.name,
                        StudentSurname = x.Student.surname,
                        BookId = x.bookId,
                        BookName = x.Book.name,
                        Returned = x.returned
                    }).ToList();
            }
            else
            {
                borrows = db.Borrows
                    .Select(x => new BorrowDto()
                    {
                        StudentId = x.studentId,
                        StudentName = x.Student.name,
                        StudentSurname = x.Student.surname,
                        BookId = x.bookId,
                        BookName = x.Book.name,
                        Returned = x.returned
                    }).ToList();
            }
            return Request.CreateResponse(HttpStatusCode.OK, borrows);
        }


        [HttpPut]
        [Route("api/borrow/return")]  // must be the same variable name to work
        public HttpResponseMessage ReturnBook(BorrowDto dt)
        {
            int sid = dt.StudentId;
            int bid = dt.BookId;
            try
            {
               
                Borrow br = db.Borrows.Where(s => s.studentId == sid && s.bookId == bid).FirstOrDefault();
                if (br != null)
                {
                    br.broughtDate = DateTime.Now;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Retruned book Successfully");
                }

                
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to return book" + ex.Message );
                

            }
        }



    }

}



