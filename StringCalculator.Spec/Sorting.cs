using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Spec
{
    internal class Sorting
    {
        public static void QuickSort(Employe[] employes)
        {
            QuickSort(employes, 0, employes.Length - 1);
        }

        static void QuickSort(Employe[] employes, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            Employe pivot = employes[start];

            int i = start, j = end;

            while (i < j)
            {
                while (i < j && employes[j].Name.CompareTo(pivot.Name) > 0)
                {
                    j--;
                }

                employes[i] = employes[j];

                while (i < j && employes[i].Name.CompareTo(pivot.Name) < 0)
                {
                    i++;
                }

                employes[j] = employes[i];
            }

            employes[i] = pivot;
            QuickSort(employes, start, i - 1);
            QuickSort(employes, i + 1, end);
        }
    }
}