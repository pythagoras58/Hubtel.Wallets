using Hubtel.Wallets.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hubtel.Wallets.Api.Data
{
    public class WalletRepo : IWalletRepo
    {
        private readonly WalletContext _context;

        //Inject the Wallet context through a contructor
        public WalletRepo(WalletContext context)
        {
            _context = context;
        }

        /*
         This method allows for the creation of new wallets
         */
        public void CreateWallet(WalletsModel walletsModel)
        {
            // ensure a body was passed 
            if(walletsModel== null)
            {
                throw new System.ArgumentNullException(nameof(walletsModel));
            }

            // Set default values to status and createdAt fields
            walletsModel.status = true;
            walletsModel.CreatedAt = DateTime.UtcNow;

            if(walletsModel.AccountNumber.Length > 6)
            {
                walletsModel.AccountNumber.Substring(0, 5);
            }
           
            _context.walletModel.Add(walletsModel); // add to the model

        }

        /*
         * Repository method to get wallet by id.
         */
        public WalletsModel GetWalletByID(int id)
        {
            return _context.walletModel.FirstOrDefault(c=>c.ID== id && c.status==true);
        }

        /*
         * Repository method to get all active wallets .
         */
        public IEnumerable<WalletsModel> GetWallets()
        {
            return _context.walletModel.Where(c=>c.status == true).ToList();
        }

        /*
         * Repository method to get all active wallets to validate the Account number to prevent duplication.
         */
        public IEnumerable<WalletsModel> GetWalletsByAccNum(string accNum)
        {
            return _context.walletModel.Where(u=>u.AccountNumber== accNum && u.status==true).ToList();
        }

        /*
         Count active wallets belonging to an individual
         */
        public IEnumerable<WalletsModel> GetWalletsByOwner(string owner)
        {
            return _context.walletModel.Where(u=>u.Owner==owner && u.status==true).ToList();
        }



        // affect the database with changes
        public bool SaveChanges()
        {
          
            return _context.SaveChanges() >= 0;
        }

        /*
         Deactivate the wallet transactions
         */
        public void SoftDelete(int id)
        {
            if(id == null)
            {
                throw new System.ArgumentNullException(nameof(id));
            }

            WalletsModel walletsModel= _context.walletModel.FirstOrDefault(c=>c.ID== id);
            walletsModel.status= false;

            _context.walletModel.Update(walletsModel);
        }
    }
}
