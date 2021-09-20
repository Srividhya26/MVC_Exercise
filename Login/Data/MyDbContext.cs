using Login.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Data
{
    public class MyDbContext : IdentityDbContext<Application>
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
