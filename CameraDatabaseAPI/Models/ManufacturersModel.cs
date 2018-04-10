using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CameraDatabaseAPI.Models
{
    public class ManufacturersModel : DbContext
    {

        public ManufacturersModel(DbContextOptions<ManufacturersModel> options) : base(options)
        {
        }

        public DbSet<Manufacturers> Manufacturers { get; set; }
    }
}