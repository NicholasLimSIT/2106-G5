using ParkWhere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkWhere.DAL
{
    interface ICarparkGateway
    {
        IEnumerable<Carpark> SelectAll();
        Carpark SelectById(int? id);
        void Insert(Carpark obj);
        void Update(Carpark obj);
        Carpark Delete(int? id);
        void Save();
    }
}
