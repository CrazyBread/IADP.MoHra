using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IADP.MoHra.Model.Classification
{
    public static class GeneticAlgorithm
    {
        private static readonly Random _rnd = new Random();
        private static readonly int _iterationsCount = 10000;
        private static readonly int _objCount = 20;
        private static readonly decimal _epsilon = 0.001M;

        public static decimal[] StartAlgorithm(CSpace space, CClass class1, CClass class2)
        {
            var currentGenertaion = _GetFirstGeneration(space);
            var class1Objects = space.Objects.Where(d => d.Class == class1).ToList();
            var class2Objects = space.Objects.Where(d => d.Class == class2).ToList();
            List<KeyValuePair<decimal[], decimal>> fitnessValues = _GetFitnessValues(class1Objects, class2Objects, currentGenertaion);

            decimal oldFitnessValue = -100;
            for (int i = 0; i < _iterationsCount; i++)
            {
                currentGenertaion = _GetNextGeneration(fitnessValues);
                fitnessValues = _GetFitnessValues(class1Objects, class2Objects, currentGenertaion);
                decimal currentFittnesValues = fitnessValues.OrderByDescending(d => d.Value).Select(d => d.Value).Average();
                
                if (Math.Abs(currentFittnesValues - oldFitnessValue) <= _epsilon)
                    break;
                else
                    oldFitnessValue = currentFittnesValues;
            }

            return fitnessValues.OrderByDescending(d => d.Value).Select(d => d.Key).FirstOrDefault();
        }

        private static decimal [][] _GetFirstGeneration(CSpace space)
        {
            var attrCount = space.Objects.First().AttributeValues.Count;
            var result = new decimal[_objCount][];
            for (int i = 0; i< _objCount; i++)
            {
                result[i] = new decimal[attrCount + 1];
                for (int j = 0; j < attrCount + 1; j++)
                    result[i][j] = (decimal)_rnd.NextDouble() * 2 - 1;
            }
            return result;
        }

        private static List<KeyValuePair<decimal[], decimal>> _GetFitnessValues(List<CObject> c1, List<CObject> c2, decimal[][] currentGeneration)
        {
            return currentGeneration.Select(d => new KeyValuePair<decimal[], decimal>(d, Helpers.FitnessValueHelper.GetValue(c1, c2, d))).ToList();
        }

        private static decimal[][] _GetNextGeneration(List<KeyValuePair<decimal[], decimal>> fitnessValues)
        {
            var selection = _GetSelection(fitnessValues);
            var attrCount = fitnessValues.First().Key.Length;
            var result = new decimal[_objCount][];
            for (int i = 0; i < _objCount; i++)
            {
                result[i] = new decimal[attrCount];

                decimal[] parent1 = null;
                decimal[] parent2 = null;

                if (i % 10 == 0)
                {
                    for (int j = 0; j < attrCount; j++)
                        result[i][j] = (decimal)_rnd.NextDouble() * 2 - 1;
                }
                else
                {
                    double rnd = _rnd.NextDouble();

                    if (i < selection.Count())
                    {
                        parent1 = selection[i];

                        if (i + 1 < selection.Count())
                            parent2 = selection[i + 1];
                        else
                            parent2 = selection[i - 2];
                    }
                    else
                    {
                        var index = _rnd.Next(0, selection.Count());
                        parent1 = selection[index];
                        if (index + 3 < selection.Count())
                            parent2 = selection[index + 3];
                        else
                            parent2 = selection[index - 4];
                    }

                    for (int j = 0; j < attrCount; j++)
                        result[i][j] = rnd > 0.5 ? parent1[j] : parent2[j];
                }
            }

            return result;
        }

        private static decimal[][] _GetSelection(List<KeyValuePair<decimal[], decimal>> fitnessValues)
        {
            var selection = fitnessValues.OrderBy(d => d.Value).Select(d => d.Key).Take(2);
            selection = selection.Concat(fitnessValues.OrderByDescending(d => d.Value).Select(d => d.Key).Take(10));
            return selection.ToArray();
        }
    }
}
