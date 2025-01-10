using Domain.Resources;

namespace Domain.Enums
{
    public static class PaymentMethodDescription
    {
        public static string GetDescription(this PaymentMethod paymentMethod)
        {
            return paymentMethod switch
            {
                PaymentMethod.CreditCard => PaymentMethodResource.CREDIT_CARD,
                PaymentMethod.DebitCard => PaymentMethodResource.DEBIT_CARD,
                PaymentMethod.BankSlip => PaymentMethodResource.BANK_SLIP,
                PaymentMethod.FedNow => PaymentMethodResource.FEDNOW,
                PaymentMethod.OnCredit => PaymentMethodResource.ON_CREDIT,
                PaymentMethod.Money => PaymentMethodResource.MONEY,
                _ => string.Empty
            };
        }
    }
}
