using AutoMapper;
using Hubtel.Wallets.Api.DTOs;
using Hubtel.Wallets.Api.Model;

namespace Hubtel.Wallets.Api.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile() 
        {
            // Map WalletsModel to Read DTO of Wallet
            CreateMap<WalletsModel, WalletReadDTO>();

            // Map wallets model to Create DTO of wallet
            CreateMap<WalletCreateDTO, WalletsModel>();
        }  
    }
}
