using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment3WebAPI.Data;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultService adultsService;
        
        
        public AdultsController(IAdultService adultService) {
            this.adultsService = adultService;
            Console.WriteLine("Hello");
        }

        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int? id) {
            try {
                IList<Adult> adults = await adultsService.GetAdultsAsync();
                return Ok(adults);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                Adult added = await adultsService.AddAdultAsync(adult);
                return Created($"/{added.Id}", added); 
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id) {
            try {
                await adultsService.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult) {
            try {
                Adult updatedAdult = await adultsService.UpdateAdultAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        
        
        
    }
}