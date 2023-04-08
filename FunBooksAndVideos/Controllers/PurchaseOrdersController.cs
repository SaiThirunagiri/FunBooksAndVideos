using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrdersController : Controller
    {
        private readonly IPurchaseOrderProcessorService _purchaseOrderProcessor;
        private readonly ILogger<PurchaseOrdersController> _logger;

        public PurchaseOrdersController(IPurchaseOrderProcessorService purchaseOrderProcessor, ILogger<PurchaseOrdersController> logger)
        {
            _purchaseOrderProcessor = purchaseOrderProcessor;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            try
            {
                _purchaseOrderProcessor.ProcessPurchaseOrderAsync(purchaseOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing purchase order");
                return StatusCode(500);
            }
        }
    }
}
