using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD_Day1
{
    public class GroupSum<T>
    {
        private IEnumerable<T> _products;

        public GroupSum(IEnumerable<T> products)
        {
            this._products = products;
        }

        public GroupSum()
        {
            _products = new List<T>();
        }

        public IEnumerable<int> Sum(int groupsize, Func<T, int> SumCol)
        {
            if (_products == null)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < (this._products.Count() / groupsize) + 1; i++)
            {
                yield return this._products.Skip(i * groupsize).Take(groupsize).Sum(SumCol);
            }
        }
    }
}
