using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebApp.Dtos.Validators;

namespace WebApp.Dtos
{
	public class EventFormDto : IValidatableObject
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public string Question { get; set; }
		public string Address { get; set; }
		public string Postcode { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public DateTime? VoteDeadline { get; set; }
		public DateTime? EnrollmentDeadline { get; set; }
		public DateTime? Date { get; set; }
		
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var validator = new EventFormDtoValidator();
			var result = validator.Validate(this);
			return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
		}
	}
}