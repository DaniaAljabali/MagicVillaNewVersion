using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Services.IServices
{
    public interface IVillaNumberService
    {
        public Task<IEnumerable<VillaNumberDTO>> GetVillaNumbers();
        public Task<VillaNumber> GetVillaNumber(int id);
        public Task<VillaNumber> CreateVillaNumber(VillaNumberCreateDTO createDTO);
        public Task<bool> CheckVillaExists(VillaNumberCreateDTO createDTO);
        public Task<bool> CheckVillaID(int villaID);
        public Task<VillaNumber> GetVillaByNumber(int id);
        public Task RemoveVillaNumber(VillaNumber villaNumber);
        public Task UpdateVillaNumber(VillaNumberUpdateDTO updateDTO);

    }
}
