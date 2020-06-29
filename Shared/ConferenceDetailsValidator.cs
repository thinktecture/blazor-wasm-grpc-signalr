using ConfTool.Shared.DTO;
using FluentValidation;

namespace ConfTool.Shared
{
    public class ConferenceDetailsValidator : AbstractValidator<ConferenceDetails>
    {
        public ConferenceDetailsValidator()
        {
            RuleFor(conference => conference.DateTo).GreaterThanOrEqualTo(conference => conference.DateFrom);
        }
    }
}
