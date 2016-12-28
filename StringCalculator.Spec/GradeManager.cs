using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Spec
{
    public class GradeManager
    {
        private IGradeRepository _gradeRepository;

        public GradeManager(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public double CalculateAverage(string accountNumber)
        {
            var grades = _gradeRepository.GetGrades(accountNumber);
            var UVs = 0;
            var average = 0;

            foreach (var grade in grades)
            {
                UVs += grade.UV;
                average += grade.GradeValue * grade.UV;
            }

            return System.Math.Round((double)average/(double)UVs,2);
        }
    }
}