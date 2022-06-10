using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AnimalShelter.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnimalsController : ControllerBase
	{
		private readonly AnimalShelterContext _db;
		public AnimalsController(AnimalShelterContext db)
		{
			_db = db;
		}
		
		[HttpGet]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesDefaultResponseType]
		public async Task<List<Animal>> Get(string type, string name, int age)
		{
			IQueryable<Animal> query = _db.Animals.AsQueryable();
			if (name != null)
			{
				query = query.Where(entry => entry.Name == name);
			}
			if (type != null)
			{
				query = query.Where(entry => entry.Type == type);
			}
			if (age > 0)
			{
				query = query.Where(entry => entry.Age >= age);
			}
			
			return await query.ToListAsync();
		}
		
		[HttpPost]
		//[ProducesResponseType(StatusCodes.Status201Created)]
		//[ProducesDefaultResponseType]
		public async Task<ActionResult<Animal>> Post(Animal animal)
		{
			_db.Animals.Add(animal);
			await _db.SaveChangesAsync();
			return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
		}

		[HttpGet("{id}")]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesDefaultResponseType]
		public async Task<ActionResult<Animal>> GetAnimal(int id)
		{
			var animal = await _db.Animals.FindAsync(id);
			if (animal == null)
			{
				return NotFound();
			}
			return animal;
		}
		
		[HttpPut("{id}")]
		//[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesDefaultResponseType]
		public async Task<IActionResult> Put(int id, Animal animal)
		{
            if (id != animal.AnimalId)
			{
				return BadRequest();
			}
			_db.Entry(animal).State = EntityState.Modified;
			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AnimalExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}

		[HttpDelete("{id}")]
		//[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesDefaultResponseType]
		public async Task<IActionResult> DeleteAnimal(int id)
		{
			var animal = await _db.Animals.FindAsync(id);
			if (animal == null)
			{
				return NotFound();
			}
			_db.Animals.Remove(animal);
			await _db.SaveChangesAsync();
			return NoContent();
		}
		private bool AnimalExists(int id)
		{
			return _db.Animals.Any(e => e.AnimalId == id);
		}
	}
}