using System;
using Model.Utils;

namespace Model.Entities
{
	public class Event : IEntityBase
	{
		private string _title;

		public string Title
		{
			get => _title;
			set
			{
				_title = value;
				Slug = value.GenerateSlug();
			}
		}
		
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string Slug { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public float? Price { get; set; }
		public string Question { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Postcode { get; set; }
		public string Country { get; set; }
		public DateTime? VoteDeadline { get; set; }
		public DateTime? EnrollmentDeadline { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? ValidatedAt { get; set; }

		public User Author { get; set; }
	}
}