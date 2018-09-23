using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Model.Entities
{
	public class User : IEntityBase
	{
		private string _password;

		public string Password
		{
			get { return _password; }
			set
			{
				using (var sha256 = SHA256.Create())
				{
					var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
					var hash = BitConverter.ToString(hashedBytes).Replace("-", "");
					_password = hash;
				}
			}
		}

		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string SchoolGroup { get; set; }
		public string Avatar { get; set; }
		public bool EmailAlert { get; set; }

		public ICollection<Event> EventsCreated { get; set; }
	}
}