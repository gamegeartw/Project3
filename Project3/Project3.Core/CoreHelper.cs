using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Project3.Core
{
    public static class CoreHelper
    {
        /// <summary>
        /// 字串雜湊(SHA256)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToSHA256(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            return BitConverter.ToString(SHA256.Create().ComputeHash(bytes)).Replace("-", string.Empty);
        }

        /// <summary>
        /// 字串雜湊(MD5)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMd5(this string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            return BitConverter.ToString(MD5.Create().ComputeHash(bytes)).Replace("-", string.Empty);
        }

        /// <summary>
        /// 如果集合中不包含該項，則添加
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddIfNotContains<T>(this ICollection<T> collection, T item)
        {
            if (!collection.Contains(item))
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// 如果集合中不包含集合內的任一項目,就加入到集合,有的話就忽略
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddRangeIfNotContains<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.AddIfNotContains(item);
            }
        }
    }
}