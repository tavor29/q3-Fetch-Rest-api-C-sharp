using ClassLibrary1;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{

    public class StudentController : ApiController
    {
        DataTable table = new DataTable();
        LibraryDbEntities db = new LibraryDbEntities();


        //https://localhost:44309/api/student
        //public dynamic Get()
        //{
        //    return db.Students.Where(x => x.StudentId == 156).Select(s => new { id = s.StudentId, name = s.Name, avg = s.AvgGrade, countOfPurchase = s.Purchases.Count() }).FirstOrDefault();
        //}

        [HttpGet]
        [Route("api/Student/all")]
        public List<StudentDto> GetStudentDtos()
        {

            var students = db.Students.Select(x => new StudentDto()
            {
                StudentId = x.studentId,  //dto attr = x.(students attr) exact names from each one
                Name = x.name,

            }).ToList();
            //table.Columns.Add("Name");
           // students.ForEach(x => table.Rows.Add(x.Name));
            return students; // student becomes an array of dto's

        }



        [HttpPost]
        [Route("api/Student/newstu")] //adding student with dto entirely from the body
        public string CreatStudent([FromBody] StudentDto student) // data in postman was sent like this: {"StudentId":534, "Name":"hieevte"}
        {
            try
            {
                if (student != null)
                {
                    Student s = new Student();
                    s.studentId = student.StudentId;
                    s.name = student.Name;

                    db.Students.Add(s);
                    db.SaveChanges();
                    return "Student Added Sucessfully";


                }

                else return "Problem adding student";
            }

            catch (Exception ex)
            {
                return "Internal Server Error: " + ex.Message;
            }

        }



        [HttpPost]
        [Route("api/Student/new/{id}")] // adding student with name from the body, id from the url
        public string CreatStudentfromBody([FromBody] string name, int id) // make sure to send name as json!!!
        {

            if (id >= 0 && !string.IsNullOrEmpty(name))
            {
                var student = new Student
                {
                    studentId = id,
                    name = name
                };

                db.Students.Add(student);
                db.SaveChanges();
                return "Student Added Sucessfully";
            }
            else
            {
                return "Invalid student ID or name";
            }
        }

        [HttpPost]
        [Route("api/Student/{id}/{name}")] // adding student with params from the url
        public string CreatStudent(int id, string name)
        {

            if (id > 0 && !string.IsNullOrEmpty(name))
            {
                var student = new Student
                {
                    studentId = id,
                    name = name
                };

                db.Students.Add(student);
                db.SaveChanges();
                return "Student Added Sucessfully";
            }
            else
            {
                return "Invalid student ID or name";
            }
        }



        [HttpPut]
        [Route("api/Student/update")]
        public string Put([FromBody] StudentDto student) // update student name and grade from database using params entirely from the body
        {
            int id = student.StudentId;
            try
            {
                Student existingStudent = db.Students.Where(s => s.studentId == id).FirstOrDefault();
                if (existingStudent != null)
                {
                    existingStudent.name = student.Name;

                    db.SaveChanges();

                    return "Student updated Sucessfully";
                }
                else
                    return "Problem updating Student / No existing student";

            }

            catch (Exception ex)
            {
                return "Internal Server Error: " + ex.Message;
            }
        }



        [HttpDelete]
        [Route("api/Student/delete/{id}")] 
        public string Delete(int id) // deleting student
        {
            try
            {
                Student student = db.Students.Where(s => s.studentId == id).FirstOrDefault();
                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                    return "Student deleted from database";
                }
                else return "Failed to delete student";
            }
            catch (Exception ex)
            {
                return "Internal Server Error: " + ex.Message;
            }

        }



    }
}
