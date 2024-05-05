using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTW_17.Utils
{
    public interface ICheckValid<T> where T : new()
    {
        string CheckValid(T input);
    }
}
