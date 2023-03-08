using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepostiory;
using MagicVilla_VillaAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace MagicVilla_VillaAPI.Services
{
    public class VillaNumberService: IVillaNumberService
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberService(IVillaNumberRepository dbVillaNumber, IMapper mapper,IVillaRepository dbVilla) 
        {
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            _response = new();
            _dbVilla = dbVilla;
        }
        public async Task<IEnumerable<VillaNumberDTO>> GetVillaNumbers()
        {
            IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync(includeProperties: "Villa");
            IEnumerable<VillaNumberDTO> villaNumberDTOList = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);

            return villaNumberDTOList;
        }
        public async Task<VillaNumber> GetVillaNumber(int id)
        {
            var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
            return villaNumber;
        }
        public async Task<VillaNumber> CreateVillaNumber(VillaNumberCreateDTO createDTO)
        {

            VillaNumber villaNumber = _mapper.Map<VillaNumber>(createDTO);

            await _dbVillaNumber.CreateAsync(villaNumber);
            return villaNumber;


        }
        public async Task<bool> CheckVillaExists(VillaNumberCreateDTO createDTO)
        {
            if (await _dbVillaNumber.GetAsync(u => u.VillaNo == createDTO.VillaNo) != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<bool> CheckVillaID(int villaID)
        {
            if (await _dbVilla.GetAsync(u => u.Id == villaID) == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public async Task<VillaNumber> GetVillaByNumber(int id)
        {
            return await _dbVillaNumber.GetAsync(u => u.VillaNo == id);

        }
        public Task RemoveVillaNumber(VillaNumber villaNumber)
        {
            return _dbVillaNumber.RemoveAsync(villaNumber);

        }
        public async Task UpdateVillaNumber(VillaNumberUpdateDTO updateDTO)
        {
            VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

            await _dbVillaNumber.UpdateAsync(model);
        }


    }
}
