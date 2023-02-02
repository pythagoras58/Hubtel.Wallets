using Hubtel.Wallets.Api.Model;
using System.ComponentModel.DataAnnotations;

namespace Hubtel.Wallets.Api.DTOs
{
    public class WalletReadDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public CardType Type { get; set; }

        public string AccountNumber { get; set; }

        public AccScheme AccountScheme { get; set; }

        public string CreatedAt { get; set; }

        public string Owner { get; set; }
    }
}
