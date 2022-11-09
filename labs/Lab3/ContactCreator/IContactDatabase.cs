using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCreator
{
    public interface IContactDatabase
    {
        Contact Add ( Contact contact, out string errorMessage );
        Contact Get ( int id );
        void Remove ( int id );
        bool Update ( int id, Contact contact, out string errorMessage );
    }
}
