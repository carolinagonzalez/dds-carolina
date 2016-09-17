using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TPDDSGrupo44.Models
{
    public class POIDbContext : DbContext
    {
        public DbSet<CuentaDeUsuario> cuentaDeUsuario { get; set; }
    }
}