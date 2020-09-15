namespace admAPIWebHurtado.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public enum Places
	{
		SantaCruz = 1,
		Beni = 2,
		Pando = 3,
		LaPaz = 4,
		Sucre = 5
	}
	public class Hurtado
	{
		[Key]
		public int HurtadoID { get; set; }

		[Required]
		[Display(Name = "Nombre Completo")]
		[StringLength(24, MinimumLength = 2)]
		public string FriendofHurtado { get; set; }

		[Required]
		public Places Place { get; set; }

		[EmailAddress]
		[DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
		public string Email { get; set; }

		[Display(Name = "Cumpleaños")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime Birthdate { get; set; }
	}
}