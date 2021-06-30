using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesslibrary.Models;

namespace DataAccesslibrary.DataAccess
{
    public interface IDataConnection
    {
        USER CreaUSER(USER model);
        USER DeleteUSER(USER model);
        List<USER> GetUSER_All();

    }
}
