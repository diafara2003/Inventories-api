using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DominioServicesLayer.Models
{
    public partial class inventoriesContext : DbContext
    {
        public inventoriesContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CUOUMN7\\SQLEXPRESS;Initial Catalog=inventories;Integrated Security=true");
            }
        }


    }
}
