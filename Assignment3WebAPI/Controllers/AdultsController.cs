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
        private IAdultService adultService;
        
        
        public AdultsController(IAdultService adultService) {
            this.adultService = adultService;
            Console.WriteLine("Hello");
        }

        
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults() {
            try {
                IList<Adult> adults = await adultService.GetAdultsAsync();
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
                Adult added = await adultService.AddAdultAsync(adult);
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
                await adultService.RemoveAdultAsync(id);
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
                Adult updatedAdult = await adultService.UpdateAdultAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        
        
        
    }
}