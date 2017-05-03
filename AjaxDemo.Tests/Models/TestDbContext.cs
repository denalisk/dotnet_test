using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjaxDemo.Models;
using AjaxDemo.Models.Repositories;

namespace AjaxDemo.Tests.Models
{
    public class TestDbContext : AjaxDemoDbContext
    {
        public override DbSet<Widget> Widgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AjaxDemoTest;integrated security = True");
        }
    }
}
