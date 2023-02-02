using AutoMapper;
using Hubtel.Wallets.Api.DTOs;
using Hubtel.Wallets.Api.Model;

namespace Hubtel.Wallets.Api.Profiles
{
    public class WalletProfile : Profile
    {
        /*
         This class maps a source and a destination Data Transfer Objects
         */
        public WalletProfile() 
        {
            // Map WalletsModel to Read DTO of Wallet
            CreateMap<WalletsModel, WalletReadDTO>();

            // Map wallets model to Create DTO of wallet
            CreateMap<WalletCreateDTO, WalletsModel>();
        }  
    }
}
