using Hubtel.Wallets.Api.Model;
using System.Collections.Generic;

namespace Hubtel.Wallets.Api.Data
{
    public interface IWalletRepo
    {
        //Develop a GET endpoint to retrieve a single wallet using an ID 
        WalletsModel GetWalletByID(int id);

        // Develop a GET endpoint to list all wallets
        IEnumerable<WalletsModel> GetWallets();

        //Develop a DELETE endpoint to remove a wallet


        // Develop a POST endpoint to add a wallet 
        void CreateWallet(WalletsModel walletsModel);

        //count for a single owner
        IEnumerable<WalletsModel> GetWalletsByOwner(string owner);

        // check for duplication based on account number
        IEnumerable<WalletsModel> GetWalletsByAccNum(string accNum);

        // SoftDelete
        void SoftDelete(int id);


        // save changes
        public bool SaveChanges();
    }
}
