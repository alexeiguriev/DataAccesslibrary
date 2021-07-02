using DataAccesslibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslibrary.DataAccess
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> Get();
        Task<UserModel> Get(int id);
        Task<UserModel> Create(UserModel user);
        Task Update(UserModel user);
        Task Delete(int id);
    }
}
