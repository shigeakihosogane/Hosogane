using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Hinode.Models
{
    public class HndContext : DbContext
    {
        // b. コンス トラクター 
        public HndContext( DbContextOptions <HndContext> options) : base( options) { }

        // c. モデル クラス への アクセサー 
        public DbSet <Customer> Customer { get; set; }


        
    }
}
