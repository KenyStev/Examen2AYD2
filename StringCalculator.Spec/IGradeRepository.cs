using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace StringCalculator.Spec
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrades(string accountNumber);
    }
}