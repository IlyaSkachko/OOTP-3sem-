using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    internal interface ISet<T>
    {
        void Add(T item);
        void Remove(T item);
        void Show();
    }
}
