using Application.Fonts;
using Application.UseCases.Billings.Resources;
using Domain;
using Domain.Enums;
using Domain.Repositories.Billings;
using Domain.Resources;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;

namespace Application.UseCases.Billings.Reports
{
    public class GenerateBillingsReportPdfUseCase : IGenerateBillingsReportPdfUseCase
    {
        private readonly IBillingsReadOnlyRepository _repository;

        private const string ROW_HEIGHT = "25";

        public GenerateBillingsReportPdfUseCase(IBillingsReadOnlyRepository repository)
        {
            GlobalFontSettings.FontResolver = new FontReportResolver();

            _repository = repository;
        }

        public byte[] Execute(DateOnly date)
        {
            var billings = _repository.GetBillingsByMonth(date);

            if (billings.Count == 0)
            {
                return [];
            }

            var document = CreateDocument();

            var page = CreatePage(document);

            AddSumHeader(page, date, billings);

            foreach (var billing in billings)
            {
                var table = page.AddTable();
                AddColumns(table);

                var rowTitle = table.AddRow();
                rowTitle.Height = ROW_HEIGHT;
                AddCellTitle(rowTitle.Cells[0], billing);
                AddCellHeaderValue(rowTitle.Cells[3]);

                var rowInfo = table.AddRow();
                rowInfo.Height = ROW_HEIGHT;
                AddCellDate(rowInfo.Cells[0], billing);
                AddCellHour(rowInfo.Cells[1], billing);
                AddCellPaymentType(rowInfo.Cells[2], billing);
                AddCellValue(rowInfo.Cells[3], billing);


                if (!string.IsNullOrEmpty(billing.Description))
                {
                    var rowDescription = table.AddRow();
                    rowDescription.Height = ROW_HEIGHT;
                    
                    AddCellDescription(rowDescription.Cells[0], billing.Description);
                    rowInfo.Cells[3].MergeDown = 1;
                }

                var row2 = table.AddRow();
                row2.Height = "30";
                row2.Borders.Visible = false;
            }

            return RenderDocument(document);
        }

        private static void AddSumHeader(Section page, DateOnly date, List<Billing> billings)
        {
            var title = string.Format(BillingReportResource.TOTAL_SPENT_INT, date.ToString("Y"));
            page
                .AddParagraph()
                .AddFormattedText(title, new Font { Name = FontNames.RALEWAY_REGULAR, Size = 15 })
                .AddLineBreak();


            var value = billings.Sum(b => b.Value);
            page
                .AddParagraph()
                .AddFormattedText(value.ToString("C"), new Font { Name = FontNames.WORKSANS_BLACK, Size = 50 })
                .AddLineBreak();
        }

        private static void AddCellDescription(Cell cell, string description)
        {
            cell.AddParagraph(description);
            cell.Format.Font = new Font { Name = FontNames.WORKSANS_REGULAR, Size = 10, Color = ColorsConstant.BLACK };
            cell.Shading.Color = ColorsConstant.GREEN_LIGHT;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
            cell.Format.LeftIndent = 20;
        }

        private static void AddCellValue(Cell cell, Billing billing)
        {
            cell.AddParagraph(string.Concat("-", billing.Value.ToString("C")));
            cell.Format.Font = new Font() { Color = ColorsConstant.BLACK, Name = FontNames.WORKSANS_REGULAR, Size = 14 };
            cell.Format.LeftIndent = 20;
            cell.Shading.Color = ColorsConstant.WHITE;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }

        private static void AddCellPaymentType(Cell cell, Billing billing)
        {
            cell.AddParagraph(billing.PaymentMethod.GetDescription());
            SetStyleBaseForExpenseInformation(cell);
        }

        private static void AddCellHour(Cell cell, Billing billing)
        {
            cell.AddParagraph(billing.DueDate.ToString("t"));
            SetStyleBaseForExpenseInformation(cell);
        }

        private static void AddCellDate(Cell cell, Billing billing)
        {
            cell.AddParagraph(billing.DueDate.ToString("D"));
            cell.Format.LeftIndent = 20;
            SetStyleBaseForExpenseInformation(cell);

        }

        private static void AddCellHeaderValue(Cell cell)
        {
            cell.AddParagraph(BillingsResource.VALUE);
            cell.Format.Font = new Font() { Color = ColorsConstant.WHITE, Name = FontNames.RALEWAY_BLACK, Size = 14 };
            cell.Shading.Color = ColorsConstant.RED_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }
       
        private static void AddCellTitle(Cell cell, Billing billing)
        {
            cell.AddParagraph(billing.Title);
            cell.Format.Font = new Font() { Color = ColorsConstant.BLACK, Name = FontNames.RALEWAY_BLACK, Size = 14 };
            cell.Format.LeftIndent = 20;
            cell.Shading.Color = ColorsConstant.RED_LIGHT;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
        }

        private static void AddColumns(Table table)
        {
            table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
        }

        private static Document CreateDocument()
        {
            var document = new Document();
            document.Info.Title = "Billing Report";

            document.Styles["Normal"]!.Font.Name = FontNames.DEFAULT;

            return document;
        }

        private static Section CreatePage(Document document)
        {
            var section = document.AddSection();

            section.PageSetup = document.DefaultPageSetup.Clone();

            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }

        private static void SetStyleBaseForExpenseInformation(Cell cell)
        {
            cell.Format.Font = new Font { Name = FontNames.WORKSANS_REGULAR, Size = 10, Color = ColorsConstant.BLACK };
            cell.Shading.Color = ColorsConstant.GREEN_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }

        private static byte[] RenderDocument(Document document)
        {
            var renderer = new PdfDocumentRenderer()
            {
                Document = document
            };

            renderer.RenderDocument();

            using var stream = new MemoryStream();
            renderer.PdfDocument.Save(stream, false);
            return stream.ToArray();
        }
    }
}
