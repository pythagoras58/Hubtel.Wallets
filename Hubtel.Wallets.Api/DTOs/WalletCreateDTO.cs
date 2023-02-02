using Hubtel.Wallets.Api.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubtel.Wallets.Api.DTOs
{
    public class WalletCreateDTO
    {
        public WalletCreateDTO()
        {
            CreatedAt = DateTime.UtcNow;
        }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public AccScheme AccountScheme { get; set; }

        
       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Phone]
        public string Owner { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool status { get; set; } = true;


       
    }
}
