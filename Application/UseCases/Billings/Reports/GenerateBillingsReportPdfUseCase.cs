using Domain.Exceptions;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Reports
{
    public class GenerateBillingsReportPdfUseCase(IBillingsReadOnlyRepository repository) : IGenerateBillingsReportPdfUseCase
    {
        public byte[] Execute(DateOnly date)
        {
            var billings = repository.GetBillingsByMonth(date);

            if (billings.Count == 0)
            {
                return [];
            }

            return [];

        }
    }
}
