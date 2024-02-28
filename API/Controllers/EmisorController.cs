using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class EmisorController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmisorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Emisor>>> Get()
        {
            var entidades = await _unitOfWork.Emisors.GetAllAsync();
            return _mapper.Map<List<Emisor>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmisorDto>> Get(string id)
        {
            var entidad = await _unitOfWork.Emisors.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<EmisorDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Emisor>> Post(EmisorDto EmisorDto)
        {
            var entidad = _mapper.Map<Emisor>(EmisorDto);
            this._unitOfWork.Emisors.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            EmisorDto.Identificacion = entidad.Identificacion;
            return CreatedAtAction(nameof(Post), new {id = EmisorDto.Identificacion}, EmisorDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmisorDto>> Put(string id, [FromBody] EmisorDto EmisorDto)
        {
            if(EmisorDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Emisor>(EmisorDto);
            _unitOfWork.Emisors.Update(entidades);
            await _unitOfWork.SaveAsync();
            return EmisorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var entidad = await _unitOfWork.Emisors.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Emisors.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
