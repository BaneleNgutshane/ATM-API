using FluentValidation;
using FluentValidation.Results;
using vpos.messages;

namespace vpos.seb.business.Payments
{
    /// <summary>
    /// Deposit operation validator.
    /// </summary>
    public class DepositOperationValidator : AbstractValidator<DepositOperation>
    {
        public void SetupRules()
        {
            RuleFor(x => x.PinCode).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.AccountNumber).NotEmpty().WithMessage(ResponseCodes.A1003.ToString());

            });
            RuleFor(x => x.DepositAmount).NotEmpty().WithMessage(ResponseCodes.D1001.ToString());
            RuleFor(x => x.DepositAmount).GreaterThan(0).WithMessage(ResponseCodes.D1002.ToString());
        }

        public override ValidationResult Validate(ValidationContext<DepositOperation> context)
        {
            return context == null
                            ? new ValidationResult(new[] { new ValidationFailure("DepositOperation", ResponseCodes.D1001.ToString()) })
                            : base.Validate(context);
        }
    }
}
