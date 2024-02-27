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
public class FacturaController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacturaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Factura>>> Get()
        {
            var entidades = await _unitOfWork.Facturas.GetAllAsync();
            return _mapper.Map<List<Factura>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FacturaDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Facturas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<FacturaDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Factura>> Post(FacturaDto FacturaDto)
        {
            var entidad = _mapper.Map<Factura>(FacturaDto);
            this._unitOfWork.Facturas.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            FacturaDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = FacturaDto.Id}, FacturaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FacturaDto>> Put(int id, [FromBody] FacturaDto FacturaDto)
        {
            if(FacturaDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Factura>(FacturaDto);
            _unitOfWork.Facturas.Update(entidades);
            await _unitOfWork.SaveAsync();
            return FacturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Facturas.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Facturas.Delete(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
