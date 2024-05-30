using backendP.DTOs;
using backendP.Models;
using backendP.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace backendP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //inyectamos el validador ItemInsertDto
        private IValidator<ItemInsertDto> _itemInsertValidator;
        //inyectamos el validador ItemInsertUpdate
        private IValidator<ItemUpdateDto> _itemUpdateValidator;
        //inyeccion del servicio la logica del negocio 
        private ICommonService<ItemDto,ItemInsertDto,ItemUpdateDto> _itemService;


        public ItemController(IValidator<ItemInsertDto>
            itemInsertDto, IValidator<ItemUpdateDto> itemUpdateValidator,
            [FromKeyedServices("itemService")] ICommonService<ItemDto,ItemInsertDto,ItemUpdateDto> itemService)
        {
            _itemInsertValidator = itemInsertDto;
            _itemUpdateValidator = itemUpdateValidator;
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> Get() => await _itemService.Get();

        [HttpGet("{ItemID}")]
        public async Task<ActionResult<ItemDto>> GetById(int ItemID)
        {
            var itemDto= await _itemService.GetById(ItemID);
            return itemDto == null ? NotFound() : Ok(itemDto);   
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Add(ItemInsertDto itemInsertDto)
        {
            var item= await _itemService.Add(itemInsertDto);
            var validationResult = await _itemInsertValidator.ValidateAsync(itemInsertDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            if (!_itemService.Validate(itemInsertDto))
            {
                return BadRequest(_itemService.Errors);
            }
            //retorna en encabezado se requieren tres parametros
            //primero necesita la url de donde esta el recurso
            //parametro que mandaras a la ruta
            //lo que se va a retornar el objeto final
            //Console.Write(nameof(GetById));
            return CreatedAtAction(nameof(GetById), new { ItemID =item.ItemID }, item);
        }
        [HttpPut("{ItemID}")]
        public async Task<ActionResult<ItemDto>> Update(int ItemID, ItemUpdateDto itemUpdateDto)
        {
            var ItemUpdateService = await _itemService.Update(ItemID,itemUpdateDto);
            //var validationUpdate = await _itemUpdateValidator.ValidateAsync(itemUpdateDto);

            //if (!validationUpdate.IsValid)
            //{
            //    return BadRequest(validationUpdate.Errors);
            //}

            return ItemUpdateService==null ? NotFound():Ok();
        }

        [HttpDelete("{ItemID}")]
        public async Task<ActionResult<ItemDto>> Delete(int ItemID)
        {
            var itemDeleteService= await _itemService.Delete(ItemID);
            return Ok(itemDeleteService);
        }
    }
}
