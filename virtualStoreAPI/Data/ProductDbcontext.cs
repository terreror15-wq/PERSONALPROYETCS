using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using VirtualStore.Models;

namespace VirtualStore.Data
{
    public class ProductDbcontext : DbContext
    {
        public  ProductDbcontext(DbContextOptions options) : base(options)
            {
             
            }


        public DbSet<Product> products { get; set; }
    }

}
