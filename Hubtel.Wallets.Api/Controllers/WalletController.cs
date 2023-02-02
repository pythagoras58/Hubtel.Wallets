using AutoMapper;
using Hubtel.Wallets.Api.Data;
using Hubtel.Wallets.Api.DTOs;
using Hubtel.Wallets.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hubtel.Wallets.Api.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepo _repository;
        private readonly IMapper _mapper;

        // inject the repository and the author mapper interfaces
        public WalletController(IWalletRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetWalletById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<WalletReadDTO>  GetWalletById(int id)
        {
            var wallet = _repository.GetWalletByID(id);
            if(wallet == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WalletReadDTO>(wallet));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WalletReadDTO>> GetAllWallets()
        {
            var wallets = _repository.GetWallets(); // get the available data through repo
            // check for nullability 
            if(wallets == null)
            {
                return NoContent();  
            }
           

            return Ok(_mapper.Map<IEnumerable<WalletReadDTO>>(wallets));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<WalletCreateDTO> CreateWallet(WalletCreateDTO walletCreateDTO)
        {
            // take the first 6 digits of the account number
            if(walletCreateDTO.AccountNumber.Length > 6)
            {
                walletCreateDTO.AccountNumber.Substring(0, 5);
            }

            var walletModel = _mapper.Map<WalletsModel>(walletCreateDTO);

            // ensure owners have maximum of 5 wallets
            var owner = walletModel.Owner.ToString();
            var walletOwned = _repository.GetWalletsByOwner(owner);
            var _ownerCount = 0;

            foreach(var c in walletOwned)
            {
                _ownerCount++;
            }

            if(_ownerCount > 5)
            {
                return BadRequest("Account Limit Exceeded");
            }

            // check for duplication
            var accNum = walletModel.AccountNumber.ToString();
            var numberOfAccOwned = _repository.GetWalletsByAccNum(accNum);
            var numOfAcc = 0;
           
            // prevent wallet duplications
            foreach (var c in numberOfAccOwned)
            {
                numOfAcc++;
            }

            if(numOfAcc >= 1)
            {
                return BadRequest("Account Number Already Exist");
            }
            

            _repository.CreateWallet(walletModel); // create new wallet through the repo
            _repository.SaveChanges(); // persist the changes

            // for REST best practice, return the location of the transaction created using CreatedAtRoute
            var walletReadDTO = _mapper.Map<WalletReadDTO>(walletModel);

            return CreatedAtRoute(nameof(GetWalletById), new {ID = walletModel.ID}, walletReadDTO);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult SoftDeleteWallet(int id)
        {
            // check if id was specified
            if(id == null)
            {
                return BadRequest("ID is required");
            }

            
            _repository.SoftDelete(id); // pass the id to the softdelete function in the repo
            _repository.SaveChanges(); // persist the changes

            return NoContent();
        }
    }
}
