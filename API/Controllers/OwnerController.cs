using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = "Employee")]
    public class OwnerController : ApiBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<OwnerDto>>> Get(
            [FromQuery] Params OwnerParams
        )
        {
            if (OwnerParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Owner.GetAllAsync(
                OwnerParams.PageIndex,
                OwnerParams.PageSize
            );
            var OwnerListDto = _mapper.Map<List<OwnerDto>>(registers);
            return new Pager<OwnerDto>(
                OwnerListDto,
                totalRegisters,
                OwnerParams.PageIndex,
                OwnerParams.PageSize
            );
        }
        [HttpGet]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> Get1_1()
        {
            var registers = await _unitOfWork.Owner.GetAllAsync();
            var OwnerListDto = _mapper.Map<List<OwnerDto>>(registers);
            return OwnerListDto;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Owner>> Post(OwnerDto OwnerDto)
        {
            var Owner = _mapper.Map<Owner>(OwnerDto);
            if (Owner == null)
            {
                return BadRequest(new ApiResponse(400, "Object cannot be null"));
            }
            _unitOfWork.Owner.Add(Owner);
            await _unitOfWork.SaveAsync();
            OwnerDto.Id = Owner.Id;
            return CreatedAtAction(nameof(Post), new { id = OwnerDto.Id }, OwnerDto);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<OwnerDto>> Put(
            int id,
            [FromBody] OwnerDto OwnerDto
        )
        {
            if (OwnerDto == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var Owner = _mapper.Map<Owner>(OwnerDto);
            _unitOfWork.Owner.Update(Owner);
            await _unitOfWork.SaveAsync();
            return OwnerDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Delete(int id)
        {
            var Owner = await _unitOfWork.Owner.GetByIdAsync(id);
            if (Owner == null)
            {
                return BadRequest(new ApiResponse(400));
            }
            _unitOfWork.Owner.Remove(Owner);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("OwnerWithPets")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<Pager<OwnerWithPetsDto>>> GetWithPets(
            [FromQuery] Params OwnerParams
        )
        {
            if (OwnerParams == null)
            {
                return BadRequest(new ApiResponse(400, "Params cannot be null"));
            }
            var (totalRegisters, registers) = await _unitOfWork.Owner.OwnerWithPets(
                OwnerParams.PageIndex,
                OwnerParams.PageSize
            );
            var OwnerListDto = _mapper.Map<List<OwnerWithPetsDto>>(totalRegisters);
            return new Pager<OwnerWithPetsDto>(
                OwnerListDto,
                registers,
                OwnerParams.PageIndex,
                OwnerParams.PageSize
            );
        }
    }
}