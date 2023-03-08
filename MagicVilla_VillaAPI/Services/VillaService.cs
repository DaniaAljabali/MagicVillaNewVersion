using AutoMapper;
using Azure;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepostiory;
using MagicVilla_VillaAPI.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Services
{
    
    public class VillaService : IVillaService
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaService(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
         
        }
        public async Task<IEnumerable<VillaDTO>> GetVillas(int? occupancy,string? search, int pageSize = 0, int pageNumber = 1)
        {
            IEnumerable<Villa> villaList;

            if (occupancy > 0)
            {
                villaList = await _dbVilla.GetAllAsync(u => u.Occupancy == occupancy, pageSize: pageSize,pageNumber: pageNumber);
            }
            else
            {
                villaList = await _dbVilla.GetAllAsync(pageSize: pageSize,
                    pageNumber: pageNumber);
            }
            if (!string.IsNullOrEmpty(search))
            {
                villaList = villaList.Where(u => u.Name.ToLower().Contains(search));
            }
            return _mapper.Map<List<VillaDTO>>(villaList);

        }
        public async Task<Villa> GetVillaByID(int id,bool tracked)
        {
           var villa = await _dbVilla.GetAsync(u => u.Id == id,tracked);
            return villa;
        }
        public async Task<VillaDTO> GetVillaByName(string name)
        {
            var villa = await _dbVilla.GetAsync(u => u.Name.ToLower() == name.ToLower());
            return _mapper.Map<VillaDTO>(villa);
        }
        public async Task<Villa> CreateVilla(VillaCreateDTO createDTO)
        {
            Villa villa = _mapper.Map<Villa>(createDTO);
            await _dbVilla.CreateAsync(villa);
            return villa;

        }
        public async Task RemoveVilla(Villa villa)
        {
            await _dbVilla.RemoveAsync(villa);
        }
        public async Task UpdateVilla(VillaUpdateDTO updateDTO)
        {
            Villa model = _mapper.Map<Villa>(updateDTO);
            await _dbVilla.UpdateAsync(model);
        }

    }
}
