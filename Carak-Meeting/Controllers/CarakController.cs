using AutoMapper;
using Carak_Meeting.DTOs;
using Carak_Meeting.Interfaces;
using Carak_Meeting.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carak_Meeting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarakController : ControllerBase
    {

        private readonly ICarak _Carak;
        private readonly IMapper _mapper;

        public CarakController(ICarak carak , IMapper mapper)
        {
            _Carak = carak;
            _mapper = mapper;
        }

        // GET: api/<CarakController>
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var result = await _Carak.GetAllCarak();
            return Ok(result);
        }



        // GET api/<CarakController>/5
        [HttpGet("GetCarakById")]
        public async Task<IActionResult> GetById(int id)
        {

            return Ok(await _Carak.GetCarakById(id));
        }



        // POST api/<CarakController>
        [HttpPost("CreateCarak")]
        public async Task<IActionResult> CreateCarak(CarakDto carakDto)
        {
            var map = _mapper.Map<UserCarak>(carakDto);
            _Carak.Add(map);
            await _Carak.SaveAll();
            return Ok(map);

        }



        // PUT api/<CarakController>/5
        //Omda
        [HttpPut("updateCarak")]
        public async Task<IActionResult> UpdateCarak(int id, CarakDto userCarak)
        {
            var Carak = await _Carak.GetCarakById(id);

            Carak.ProductName = userCarak.ProductName;
            Carak.Quantity = userCarak.Quantity;
          //  Carak.Price = userCarak.Price;
            Carak.PhoneNum = userCarak.PhoneNum;
            Carak.Date = userCarak.Date;

            await _Carak.SaveChanges();
            return Ok("Item Updated Successfully");
        }

        // DELETE api/<CarakController>/5
        [HttpDelete("deleteCarak/{id}")]
        public async Task<IActionResult> DeleteCarak(int id)
        {
            var cark = await _Carak.GetCarakById(id);

            //check if Exist : 
            if(cark != null)
            {
                _Carak.Remove(cark);
               await _Carak.SaveChanges();

                return Ok("Item Deleted Successfuly...");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
