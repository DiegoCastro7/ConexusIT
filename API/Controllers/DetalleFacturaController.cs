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
public class DetalleFacturaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetalleFacturaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleFactura>>> Get()
        {
            var entidades = await _unitOfWork.DetalleFacturas.GetAllAsync();
            return _mapper.Map<List<DetalleFactura>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleFacturaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.DetalleFacturas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<DetalleFacturaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleFactura>> Post(DetalleFacturaDto DetalleFacturaDto)
        {
            var entidad = _mapper.Map<DetalleFactura>(DetalleFacturaDto);
            this._unitOfWork.DetalleFacturas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            DetalleFacturaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = DetalleFacturaDto.Id}, DetalleFacturaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleFacturaDto>> Put(int id, [FromBody] DetalleFacturaDto DetalleFacturaDto)
        {
            if(DetalleFacturaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<DetalleFactura>(DetalleFacturaDto);
            _unitOfWork.DetalleFacturas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return DetalleFacturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.DetalleFacturas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.DetalleFacturas.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
