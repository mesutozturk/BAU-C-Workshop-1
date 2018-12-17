using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketKayit
{
    public class MyContext : DbContext
    {
        public virtual DbSet<Urun> Urunler { get; set; }
    }
}
