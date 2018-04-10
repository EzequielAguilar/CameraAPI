using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CameraDatabaseAPI.Models;

namespace CameraDatabaseAPI.Models
{
    public class CameraModel : DbContext
    {

        public CameraModel(DbContextOptions<CameraModel> options) : base(options)
        {
        }

        public DbSet<Cameras> Cameras { get; set; }

        public DbSet<CameraDatabaseAPI.Models.Manufacturers> Manufacturers { get; set; }
    }
}
