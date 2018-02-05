using System;
using System.Collections.Generic;
using System.Text;

namespace MegaSena.Domain.Interface
{
    public interface InterfaceGeneric<T> where T : class
    {
        void Add(T Entitie);
        void Update(T Entitie);
        void Remove(T Entitie);
        IEnumerable<T> List();
    }
}
