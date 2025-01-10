using Application.UseCases.Billings.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.VisualBasic.FileIO;
using System.Net.Mime;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("pdf/{date}")]
        public IActionResult GetPdf(
            [FromServices] IGenerateBillingsReportExcelUseCase useCase, 
            DateOnly date)
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

            var fileName = $"Report.{fileDate}.xlsx";

            return File(fileResult, fileType, fileName);
        }
    }
}
