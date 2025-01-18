using Application.UseCases.Billings.Reports;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetExcel(
            [FromServices] IGenerateBillingsReportExcelUseCase useCase,
            [FromHeader] DateOnly date
            )
        {
            byte[] fileResult = useCase.Execute(date);

            if (fileResult.Length == 0)
            {
                return NoContent();
            }

            return GenerateFile(date, fileResult, MediaTypeNames.Application.Octet);
        }

        [HttpGet("pdf")]
        public IActionResult GetPdf(
            [FromServices] IGenerateBillingsReportPdfUseCase useCase, 
            [FromHeader] DateOnly date)
        {
            byte[] fileResult = useCase.Execute(date);

            if (fileResult.Length == 0)
            {
                return NoContent();
            }

            return GenerateFile(date, fileResult, MediaTypeNames.Application.Pdf);
        }

        private FileContentResult GenerateFile(
            DateOnly date, 
            byte[] fileResult,
            string fileType)
        {
            var fileDate = date.ToString("yyyy-MM");

            var fileExtension = fileType == MediaTypeNames.Application.Pdf ? "pdf" : "xlsx";

            var fileName = $"Report.{fileDate}.{fileExtension}";

            return File(fileResult, fileType, fileName);
        }
    }
}
