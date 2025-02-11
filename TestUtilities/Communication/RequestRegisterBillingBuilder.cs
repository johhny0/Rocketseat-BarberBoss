using Bogus;
using Communication.Request;
using Domain.Enums;

namespace TestUtilities.Builder
{
    public class RequestRegisterBillingBuilder
    {
        private readonly RequestBilling _registerBillingValidator;

        public RequestRegisterBillingBuilder()
        {
            _registerBillingValidator = new Faker<RequestBilling>()
                .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                .RuleFor(r => r.Description, faker => faker.Lorem.Text())
                .RuleFor(r => r.DueDate, faker => faker.Date.Recent().ToString())
                .RuleFor(r => r.PaymentMethod, faker => faker.PickRandom<PaymentMethod>())
                .RuleFor(r => r.Value, faker => faker.Random.Decimal(1, 1000));
        }

        public RequestRegisterBillingBuilder WithDescription(string description)
        {
            _registerBillingValidator.Description = description;

            return this;
        }

        public RequestRegisterBillingBuilder WithDueDate(string dueDate)
        {
            _registerBillingValidator.DueDate = dueDate;

            return this;
        }

        public RequestRegisterBillingBuilder WithPaymentMethod(int paymentMethod)
        {
            _registerBillingValidator.PaymentMethod = (PaymentMethod)paymentMethod;

            return this;
        }

        public RequestRegisterBillingBuilder WithPaymentMethod(PaymentMethod? paymentMethod)
        {
            _registerBillingValidator.PaymentMethod = paymentMethod;

            return this;
        }

        public RequestRegisterBillingBuilder WithTitle(string title)
        {
            _registerBillingValidator.Title = title;

            return this;
        }

        public RequestRegisterBillingBuilder WithValue(decimal? value)
        {
            _registerBillingValidator.Value = value;

            return this;
        }

        public RequestBilling Build()
        {
            return _registerBillingValidator;
        }
    }
}
