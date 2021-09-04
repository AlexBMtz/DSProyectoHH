using DSProyectoHH.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSProyectoHH.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
