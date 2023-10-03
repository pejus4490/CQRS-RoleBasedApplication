using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Shared;
    public interface IVM<T> where T : IEquatable<T>

    {
        T RegNo { get; set; }
    }
public interface IVM : IVM<string> { }
