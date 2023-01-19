using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbEntities db = new LibraryDbEntities();

            // this is to 
            var studs = db.Students.Select(x => new
            {
                Name = x.name,
              

            }).ToList();

            studs.ForEach(x => Console.WriteLine($"name: {x.Name}"));

            //var purchases1 = db.Purchases.Select(p => new
            //{
            //    sn = p.SerialNumber,
            //    numOfP = p.SerialNumber.Count()
            //}).ToList();

            //purchases1.ForEach(x => Console.WriteLine(x.sn + "" + x.numOfP));
            //var purchases1 = db.Purchases.GroupBy(x => x.SerialNumber).ToList();

            //purchases1.ForEach(x => Console.WriteLine($"{x.Key} {x.Sum(a => a.Amount)}"));

            //List<Student> students = db.Students.ToList();
            //List<Student> stud = students.Where(s => s.Purchases.Where(p => p.SerialNumber == ('14602'))).Count.ToList();


        }
    }
}
