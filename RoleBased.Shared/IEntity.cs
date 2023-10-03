using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Shared;

public interface IEntity<T> where T : IEquatable<T>
{
    T RegNo { get; set; }

}

public interface IEntity : IEntity<string> { }