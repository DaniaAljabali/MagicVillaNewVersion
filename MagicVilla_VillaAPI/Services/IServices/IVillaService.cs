using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Services.IServices
{
    public interface IVillaService
    {

        public Task<IEnumerable<VillaDTO>> GetVillas(int? occupancy,string? search, int pageSize = 0, int pageNumber = 1);
        public Task<Villa> GetVillaByID(int id, bool tracked);
        public Task<VillaDTO> GetVillaByName(string name);
        public Task<Villa> CreateVilla(VillaCreateDTO createDTO);
        public Task RemoveVilla(Villa villa);
        public Task UpdateVilla(VillaUpdateDTO updateDTO);

    }
}
