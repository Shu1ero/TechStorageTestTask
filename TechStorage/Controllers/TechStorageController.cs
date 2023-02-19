using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System.Net;
using System.Web;
using Services;
using Microsoft.AspNetCore.Authorization;

namespace TechStorage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechStorageController : ControllerBase
    {
        private readonly ILogger<TechStorageController> _logger;
        private IStorageService _storageService;

        public TechStorageController(ILogger<TechStorageController> logger, IStorageService storageService)
        {
            _logger = logger;
            _storageService = storageService;
        }


        [Authorize]
        [HttpGet("Get")]
        public List<Contract> Get()
        {
            return _storageService.GetContracts();
        }

        [HttpPost("Add")]
        public ActionResult Post(int facilityId, int equipmentId, int quantity) 
        {
            try 
            {
                _storageService.CreateContract(facilityId, equipmentId, quantity);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
            
            return Ok();
        }

        [HttpPost("Update")]
        public ActionResult Update(Contract contract)
        {
            try
            {
                _storageService.UpdateContract(contract);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int contractId) 
        {
            try
            {
                _storageService.DeleteContract(contractId);
            }
            catch(Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}