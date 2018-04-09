using System;
using System.Collections.Generic;

namespace GeneticSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            throw new NotImplementedException();
        }

        static SortedList<int, Algorithm> Train(List<Algorithm> algorithms)
        {
            List<int> trainingData = GenerateTrainingData();
            //Somewhat self-defeatingly using a sorting algorithm to create sorting algorithms
            SortedList<int, Algorithm> mutations = new SortedList<int, Algorithm>();
            foreach (Algorithm a in algorithms)
            {
                for (int i = 0; i < 5; i++)
                {
                    Algorithm mutation = a.mutate();
                    mutations.Add(mutation.Run(trainingData), mutation);
                }
            }
            if (mutations.Count < algorithms.Count)
            {
                return mutations;
            }
            //Kill underperforming algorithms.
            //TODO- after x iterations kill algorithms that are out performed by a bogo sort
            SortedList<int, Algorithm> survivors = new SortedList<int, Algorithm>();
            for (int i = mutations.Count - 1; i > mutations.Count - algorithms.Count; i--)
            {
                survivors.Add(mutations.Keys[i], mutations.Values[i]);
            }
            return survivors;
        }

        static List<int> GenerateTrainingData()
        {
            throw new NotImplementedException();
        }
    }
}
