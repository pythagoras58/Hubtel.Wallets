using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubtel.Wallets.Api.Model
{
    public class WalletsModel
    {

        public WalletsModel() 
        {
            CreatedAt= DateTime.UtcNow;
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public CardType Type { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public AccScheme AccountScheme { get; set; }

        
       // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Phone]
        public string Owner { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool status { get; set; }


       

    }

    public enum CardType
    {
        Momo, Card
    }

    public enum AccScheme
    {
        visa, mastercard, mtn, vodafone, airteltigo
    }


}
