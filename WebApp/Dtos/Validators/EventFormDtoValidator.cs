using FluentValidation;

namespace WebApp.Dtos.Validators
{
	public class EventFormDtoValidator : AbstractValidator<EventFormDto>
	{
		public EventFormDtoValidator()
		{
			RuleFor(evt => evt.Title).NotEmpty().MaximumLength(50);
			RuleFor(evt => evt.Description).NotEmpty();
			RuleFor(evt => evt.Address).NotEmpty();
			RuleFor(evt => evt.Postcode).NotEmpty();
			RuleFor(evt => evt.City).NotEmpty();
			RuleFor(evt => evt.Country).NotEmpty();
			RuleFor(evt => evt.VoteDeadline).NotEmpty();
			RuleFor(evt => evt.EnrollmentDeadline).NotEmpty();
		}	
	}
}