using AutoMapper;
using backendP.DTOs;
using backendP.Models;
using backendP.Repository;
using Microsoft.EntityFrameworkCore;

namespace backendP.Services
{
    public class ItemService : ICommonService<ItemDto, ItemInsertDto, ItemUpdateDto>
    {        
        public List<string> Errors { get; }
        //inyeccion del respositorio 
        private IRepository<Item> _Itemrepository;
        //inyeccion m apper
        private IMapper _mapper;
    public ItemService(IRepository<Item> itemRepository,IMapper mapper)
        {
            _Itemrepository = itemRepository;
            _mapper = mapper;
            Errors = new List<string>();
        }

        public async Task<IEnumerable<ItemDto>> Get() {
            var items = await _Itemrepository.Get();

            return items.Select(x =>_mapper.Map<ItemDto>(x));
        }

        public async Task<ItemDto> GetById(int ItemID)
        {
            var item=await _Itemrepository.GetById(ItemID);

            if (item!=null)
            {
                var itemDto = _mapper.Map<ItemDto>(item);

                return itemDto;
            }
            return null;          
        }


        public async Task<ItemDto> Add(ItemInsertDto itemInsertDto)
        {
            //objeto que se relaciona directamente a la base de datos
            var item = _mapper.Map<Item>(itemInsertDto);
            //indica que hara un insert 
            await _Itemrepository.Add(item);
            //se insertan los cambios en la base de datos
            await _Itemrepository.Save();

            //respuesta 
            var itemDto=_mapper.Map<ItemDto>(item);
            //var itemDto = new ItemDto
            //{
            //    ItemID = item.ItemID,
            //    Name = item.Name,
            //    Description = item.Description,
            //    DepartmentID = item.DepartmentID
            //};
            return itemDto;
        }

        public async Task<ItemDto> Update(int ItemID, ItemUpdateDto itemUpdatetDto)
        {
            var item = await _Itemrepository.GetById(ItemID);

            if (item!=null)
            {
                //item.Name= itemUpdatetDto.Name;
                //item.Description= itemUpdatetDto.Description;
                //item.DepartmentID= itemUpdatetDto.DepartmentID;
               item=_mapper.Map<ItemUpdateDto,Item>(itemUpdatetDto,item);

                _Itemrepository.Update(item);
                await _Itemrepository.Save();
                var itemDto =_mapper.Map<ItemDto>(item);
                //var itemDto = new ItemDto
                //{
                //    ItemID = itemUpdateDto.ItemID,
                //    Name = itemUpdatetDto.Name,
                //    Description = itemUpdatetDto.Description,
                //    DepartmentID = itemUpdatetDto.DepartmentID
                //};

                return itemDto;
            }
            return null;
        }
        public async Task<ItemDto> Delete(int ItemID)
        {
            var item=await _Itemrepository.GetById(ItemID);

            if (item!=null)
            {
                var itemDto = _mapper.Map<ItemDto>(item);
                //var itemDto = new ItemDto
                //{
                //    ItemID = item.ItemID,
                //    Name = item.Name,
                //    Description = item.Description,
                //    DepartmentID = item.DepartmentID
                //};

                _Itemrepository.Delete(item);
                await _Itemrepository.Save();

                return itemDto;
            }

            return null;
        }

        //public bool Validate(ItemInsertDto itemInsertDto)
        //{
        //    if (_Itemrepository.Search(i=>i.Name==itemInsertDto.Name).Count()>0)
        //    {
        //        Errors.Add("No puede existir un articulo con un nombre ya existente");
        //        return false;
        //    }
        //    return true;

        //}

        public bool Validate(ItemUpdateDto itemUpdateDto)
        {
            if (_Itemrepository.Search(i=>i.Name==itemUpdateDto.Name && itemUpdateDto.ItemID!=i.ItemID).Count()>0)
            {
                Errors.Add("No puede existir un item con un nombre ya existente");
                return false;
            }
            return true;
        }
    }
}
