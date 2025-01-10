
namespace Application.UseCases.Billings.Reports
{
    public interface IGenerateBillingsReportPdfUseCase
    {
        byte[] Execute(DateOnly date);
    }
}