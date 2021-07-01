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
        UserModel PostUser(UserModel model);
        List<UserModel> GetUser_All();
        UserModel PutUser(UserModel oldVal, UserModel newVal);
        UserModel DeleteUser(UserModel model);

    }
}
