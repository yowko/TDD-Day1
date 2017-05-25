using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Day1
{
    public interface IGroupSum
    {
        List<int> SumData(int n, string col);
    }

    public class GroupSum : IGroupSum
    {
        private List<Product> _products;

        public GroupSum(List<Product> products)
        {
            this._products = products;
        }

        public GroupSum()
        {
            _products = new List<Product>();
            #region - 塞假資料 -
            //for (int i = 1; i < 12; i++)
            //{
            //    this._products.Add(new Product() { Id = i, Cost = i, Revenue = 10 + i, SellPrice = 20 + i });
            //}
            #endregion
        }

        public List<int> SumData(int n, string col)
        {
            List<int> result = new List<int>();
            #region - 使用 queue 實作 -          

            //if (this._products == null)
            //{
            //    throw new NullReferenceException();
            //}
            //else
            //{
            //    var props = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(x => x.Name == col);
            //    var queue = new Queue<Product>(this._products);
            //    for (int i = 0; i < (this._products.Count / n) + 1; i++)
            //    {
            //        int tmpCount = 0;
            //        for (int j = 0; j < n; j++)
            //        {
            //            if (queue.Count != 0)
            //            {
            //                var tmp = queue.Dequeue();
            //                tmpCount += (int)props.GetValue(tmp);
            //            }

            //        }
            //        result.Add(tmpCount);
            //    }
            //}
            #endregion

            #region - linq 自訂分群 -

            var props = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault(x => x.Name == col);
            for (int i = 0; i < (this._products.Count / n) + 1; i++)
            {
                //result.Add(this._products.Skip(i * n).Take(n).Sum(a => a.Cost));

                result.Add(this._products.Skip(i * n).Take(n).Sum(a => (int)props.GetValue(a)));
            }

            #endregion

            return result;
        }
    }
}
