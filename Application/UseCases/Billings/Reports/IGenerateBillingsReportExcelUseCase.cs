
namespace Application.UseCases.Billings.Reports
{
    public interface IGenerateBillingsReportExcelUseCase
    {
        byte[] Execute(DateOnly date);
    }
}