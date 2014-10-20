using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseoCliente.Connection
{
     public interface IResourceObject<T>
    {
        void Create();

        void Save(string id);

        T Get(string id);

        List<T> GetAsCollection();
    }
}
