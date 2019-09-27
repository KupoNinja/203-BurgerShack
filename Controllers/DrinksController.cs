using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly DrinksService _ds;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Drink>> Get()
        {
            try
            {
                return Ok(_ds.GetDrinks());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Drink> Get(string id)
        {
            try
            {
                return Ok(_ds.GetDrinkById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Drink> Post([FromBody] Drink drinkData)
        {
            try
            {
                Drink mydrink = _ds.AddDrink(drinkData);
                return Created(mydrink);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //code snippet
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Drink> Put(string id, [FromBody] Drink drinkData)
        {
            try
            {
                drinkData.Id = id;
                var drink = _ds.EditDrink(drinkData);
                return Accepted(drink);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Drink> Delete(string id)
        {
            try
            {
                var drink = _ds.DeleteDrink(id);
                return Accepted(drink);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public DrinksController(DrinksService ds)
        {
            _ds = ds;
        }
    }
}
