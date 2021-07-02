using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccesslibrary.Models;

namespace DataAccesslibrary.DataAccess
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options){ }
        public DbSet<UserModel> User { get; set; }

    }
}
