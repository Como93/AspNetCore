using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGetPostPutDelete.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGetPostPutDelete.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		List<User> users = new List<User>
		{
			new User() {Id=1,NameUser="Michele",SurnameUser="Comotti"},
			new User() {Id=2,NameUser="Martina",SurnameUser="Formichini"},
			new User() {Id=3,NameUser="Davide",SurnameUser="Pepoli"}
		};

		public UserController()
		{

		}

		// Get api/user
		public IEnumerable<User> GetUsers()
		{
			return users;
		}

		// Get api/user/2
		[HttpGet("{id}")]
		public IActionResult GetUser(int id)
		{
			//var us = users.FirstOrDefault(x => x.Id == id);
			var user = from u in users
					   where u.Id == id
					   select u;

			if(user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		// Post api/user
		[HttpPost]
		public IActionResult Post()
		{
			users.Add(new User() { Id = 4, NameUser = "Elisa", SurnameUser = "Cioffi" });

			return Ok(users);
		}

		// Put api/user/2
		[HttpPut("{id}")]
		public IActionResult Put(int id, User user)
		{
			user.Id = id;
			user.NameUser = "Valentina";
			user.SurnameUser = "Vignali";

			foreach(User u in users)
			{
				if(u.Id == id)
				{

					u.NameUser = user.NameUser;
					u.SurnameUser = user.SurnameUser;
				}
			}
			

			return Ok(users);
		}

		[HttpDelete("{id}")]
		// Delete api/user/2
		public IActionResult Delete(int id)
		{
			var itemRemove = users.SingleOrDefault(u => u.Id == id);
			users.Remove(itemRemove);

			return Ok(users);

		}
    }
}