using AutoMapper;
using ClosedXML.Excel;
using Domain;
using Domain.Repositories.Billings;
using Domain.Resources;

namespace Application.UseCases.Billings.Reports
{
    public class GenerateBillingsReportExcelUseCase(
        IBillingsReadOnlyRepository repository,
        IMapper mapper) : IGenerateBillingsReportExcelUseCase
    {
        public byte[] Execute(DateOnly date)
        {
            var billings = repository.GetBillingsByMonth(date);

            if (billings.Count == 0)
            {
                return [];
            }

            using var workbook = new XLWorkbook
            {
                Author = "BarberBoss",
            };

            workbook.Style.Font.FontName = "Times New Roman";
            workbook.Style.Font.FontSize = 12;


            var worksheet = workbook.AddWorksheet(date.ToString("Y"));

            InsertHeader(worksheet);

            InsertBody(worksheet, billings);

            var file = new MemoryStream();
            workbook.SaveAs(file);
            return file.ToArray();
        }

        private void InsertBody(IXLWorksheet worksheet, List<Billing> billings)
        {
            var xlsBillings = mapper.Map<BillingXls[]>(billings);

            worksheet.Cell("A2").InsertData(xlsBillings);

            worksheet.Columns().AdjustToContents();
        }

        private void InsertHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = BillingsResource.TITLE;
            worksheet.Cell("B1").Value = BillingsResource.DUE_DATE;
            worksheet.Cell("C1").Value = BillingsResource.PAYMENT_METHOD;
            worksheet.Cell("D1").Value = BillingsResource.VALUE;
            worksheet.Cell("E1").Value = BillingsResource.DESCRIPTION;

            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

            worksheet.Cells("A1:E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }
    }
}
