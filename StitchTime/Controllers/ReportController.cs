using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]
    
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService service)
        {
            _reportService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReportDto>> GetReports()
        {
            try
            {
                var result = _reportService.GetAll();
                return new OkObjectResult(result);
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetReport(int id)
        {
            var result = await _reportService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<ReportDto> PutReport(int id, ReportDto report)
        {        
            try
            {

                var result = _reportService.Update(report);
                return Ok(result);
            }
            catch (Exception)
            {
                if (!ReportExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto>> PostReport(ReportDto report)
        {
            await _reportService.Insert(report);

            return Ok(report);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReport(int id)
        {
            try
            {
                await _reportService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                if (!ReportExists(id))
                {
                    return NotFound();
                }
            }

            return Problem();
        }

        private bool ReportExists(int id)
        {
            if (_reportService.GetById(id) != null)
                return true;
            else
                return false;
        }
    }
}