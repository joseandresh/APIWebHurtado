using System;
using System.Net;
using System.Web.Http.Results;
using APIWebHurtado.Controllers;
using APIWebHurtado.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAPIWebHurtado
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestGet()
		{
			//Arrange
			HurtadoesController controller = new HurtadoesController();

			//Act
			var hurtadoesList = controller.GetHurtadoes();

			//Assert
			Assert.IsNotNull(hurtadoesList);
		}

		[TestMethod]
		public void TestPost()
		{
			//Arrange
			HurtadoesController controller = new HurtadoesController();
			Hurtado hurtado = new Hurtado()
			{
				HurtadoID = 1,
				FriendofHurtado = "Migi Tapia",
				Place = Places.SantaCruz,
				Email = "migi@gmail.com",
				Birthdate = DateTime.Now
			};

			//Act
			var actionResult = controller.PostHurtado(hurtado);
			var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Hurtado>;

			//Assert
			Assert.IsNotNull(createdResult);
			Assert.AreEqual("DefaultApi", createdResult.RouteName);
			Assert.IsNotNull(createdResult.RouteValues["id"]);
		}

		[TestMethod]
		public void TestPut()
		{
			//Arrange
			HurtadoesController controller = new HurtadoesController();
			Hurtado hurtado = new Hurtado()
			{
				HurtadoID = 1,
				FriendofHurtado = "Migi Tapia",
				Place = Places.Beni,
				Email = "migitapia@gmail.com",
				Birthdate = DateTime.Now
			};

			//Act
			var actionResult = controller.PostHurtado(hurtado);
			var createdResult = controller.PutHurtado(hurtado.HurtadoID, hurtado) as StatusCodeResult;

			//Assert
			Assert.IsNotNull(createdResult);
			Assert.IsInstanceOfType(createdResult, typeof(StatusCodeResult));
			Assert.AreEqual(HttpStatusCode.NoContent, createdResult.StatusCode);
		}

		[TestMethod]
		public void TestDelete()
		{
			//Arrange
			HurtadoesController controller = new HurtadoesController();
			Hurtado hurtado = new Hurtado()
			{
				HurtadoID = 2,
				FriendofHurtado = "Migi Ferrufino",
				Place = Places.LaPaz,
				Email = "migiferrufino@gmail.com",
				Birthdate = DateTime.Now
			};

			//Act
			var actionResultPost = controller.PostHurtado(hurtado);
			var actionResultDelete = controller.DeleteHurtado(hurtado.HurtadoID);

			//Assert
			Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Hurtado>));
		}
	}
}
