using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string imie, bool WagaOceny) : base(imie, WagaOceny)
        { 
            Type = GradeBookType.Ranked; 
        }


        public override char GetLetterGrade(double averageGrade)
        {


            if (Students.Count < 5)
                throw new InvalidOperationException("Oceny Pięciu Studentów");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var SortowanieOcen = Students
                .Select(ocena => ocena.AverageGrade)
                .OrderByDescending(g => g)
                .ToList();

            if (SortowanieOcen.IndexOf(averageGrade) < threshold)
                return 'a';
            if (SortowanieOcen.IndexOf(averageGrade) < threshold * 2)
                return 'b';
            if (SortowanieOcen.IndexOf(averageGrade) < threshold * 3)
                return 'c';
            if (SortowanieOcen.IndexOf(averageGrade) < threshold * 4)
                return 'd';
            return'f' ;
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) { Console.WriteLine("Lista Ocenionych Studentów");
                return;
            }

            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string imie)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Lista Ocenionych Studentów");
                return;
            }

            base.CalculateStudentStatistics(imie);
        }
    }
}
