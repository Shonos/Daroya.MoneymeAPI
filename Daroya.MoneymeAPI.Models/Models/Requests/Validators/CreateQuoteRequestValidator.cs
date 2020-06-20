using Daroya.MoneymeAPI.Models.Requests;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Daroya.MoneymeAPI.Models.Models.Requests.Validators
{
    public class CreateQuoteRequestValidator : AbstractValidator<CreateQuoteRequest>
    {
        public CreateQuoteRequestValidator()
        {
            RuleFor(x => x.Quote)
                .NotNull()
                .WithMessage("Quote request is not valid");

            RuleFor(x => x.Quote.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is required.")
                .MaximumLength(50)
                .WithMessage("First name is over 50 characters");

            RuleFor(x => x.Quote.LastName)
                .NotEmpty()
                .WithMessage("LastName is required.")
                .MaximumLength(50)
                .WithMessage("Last name is over 50 characters"); ;

            RuleFor(x => x.Quote.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address")
                .MaximumLength(50)
                .WithMessage("Email is over 50 characters");

            RuleFor(x => x.Quote.Amount)
                .NotEmpty().WithMessage("Amount is required");

            RuleFor(x => x.Quote.Mobile)
                .NotEmpty().WithMessage("Mobile is required")
                .MaximumLength(50)
                .Must((o, list, context) =>
                {
                    context.MessageFormatter.AppendArgument("Mobile", o.Quote.Mobile);
                    return ValidatorUtils.IsValidMobileNumber(o.Quote.Mobile);
                }).WithMessage("Invalid Mobile Number");

        }
    }
}
