using Hubtel.Wallets.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.Wallets.Api.Data
{
    /*
     * This class serves as the Db Context class for the wallet model.
     */
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options) {}

        
        public DbSet<WalletsModel> walletModel { get; set; }

        
    }
}
