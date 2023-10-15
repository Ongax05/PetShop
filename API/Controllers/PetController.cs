using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Employee")]
    public class PetController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<PetDto>>> Get(
            [FromQuery] Params PetParams
        )
        {
            if (PetParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Pet.GetAllAsync(
                PetParams.PageIndex,
                PetParams.PageSize
            );
            var PetListDto = _mapper.Map<List<PetDto>>(registers);
            return new Pager<PetDto>(
                PetListDto,
                totalRegisters,
                PetParams.PageIndex,
                PetParams.PageSize
            );
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pet>> Post(PetDto PetDto)
        {
            var Pet = _mapper.Map<Pet>(PetDto);
            if (Pet == null)
            {
                return BadRequest(new ApiResponse(400, "Object cannot be null"));
            }
            _unitOfWork.Pet.Add(Pet);
            await _unitOfWork.SaveAsync();
            PetDto.Id = Pet.Id;
            return CreatedAtAction(nameof(Post), new { id = PetDto.Id }, PetDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<PetDto>> Put(
            int id,
            [FromBody] PetDto PetDto
        )
        {
            if (PetDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Pet = _mapper.Map<Pet>(PetDto);
            _unitOfWork.Pet.Update(Pet);
            await _unitOfWork.SaveAsync();
            return PetDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Pet = await _unitOfWork.Pet.GetByIdAsync(id);
            if (Pet == null)
            {
                return BadRequest(new ApiResponse(400));
            }
            _unitOfWork.Pet.Remove(Pet);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}