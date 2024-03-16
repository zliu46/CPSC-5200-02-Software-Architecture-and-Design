using GlobalAddressNavigatorServer.Data;
using GlobalAddressNavigatorServer.Models;
using Microsoft.EntityFrameworkCore;



namespace GlobalAddressNavigatorServer.Data
{
    public class ApiContext :DbContext
    {
        public DbSet<GANClass> Addresses { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {
        }
    }
}
