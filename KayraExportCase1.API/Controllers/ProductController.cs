using KayraExportCase1.Business.Abstract;
using KayraExportCase1.Business.Result;
using KayraExportCase1.Domain.Dtos;
using KayraExportCase1.Domain.ListDtos;
using Microsoft.AspNetCore.Mvc;

namespace KayraExportCase1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        /// <summary>
        /// Yeni bir ürünü oluşturur.
        /// </summary>
        /// <remarks>
        /// Gövdeye <c>ProductDto</c> gönderin. Başarılı olursa oluşturulan kaydın temel bilgileri döner.
        /// </remarks>
        /// <param name="dto">Oluşturulacak ürün verisi.</param>
        /// <response code="201">Ürün başarıyla oluşturuldu.</response>
        /// <response code="400">Geçersiz istek veya doğrulama hatası.</response>
        /// <response code="500">Sunucu hatası.</response>
        [HttpPost]
        [ProducesResponseType(typeof(SystemResult<ProductListDto>), 201)]
        [ProducesResponseType(typeof(SystemResult<ProductListDto>), 400)]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _service.Save(dto);
            if (result == null) return StatusCode(500);
            if (!result.IsSuccess) return BadRequest(result);
            var id = result.Data?.Id ?? 0;
            return CreatedAtAction(nameof(GetById), new { id }, result);
        }
        /// <summary>
        /// Ürünleri sayfalı liste olarak döner.
        /// </summary>
        /// <remarks>
        /// Varsayılan: <c>page=1</c>, <c>count=10</c>. Değerler 1 veya daha büyük olmalıdır.
        /// </remarks>
        /// <param name="page">Sayfa numarası (1..N).</param>
        /// <param name="count">Sayfa başına kayıt adedi (1..N).</param>
        /// <response code="200">Sayfalı ürün listesi döner.</response>
        /// <response code="400">Geçersiz sayfalama parametreleri.</response>
        /// <response code="500">Sunucu hatası.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PaggingResult<ProductListDto>), 200)]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            if (page < 1 || count < 1) return BadRequest("page ve count 1 veya daha büyük olmalıdır.");
            var result = await _service.GetAll(page, count);
            if (result == null) return StatusCode(500);
            return Ok(result);
        }
        /// <summary>
        /// Belirtilen kimliğe sahip ürünün detayını döner.
        /// </summary>
        /// <param name="id">Ürün kimliği.</param>
        /// <response code="200">Ürün bulundu ve döndü.</response>
        /// <response code="404">Ürün bulunamadı.</response>
        /// <response code="500">Sunucu hatası.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(SystemResult<ProductListDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.Get(id);
            if (result == null) return StatusCode(500);
            if (!result.IsSuccess || result.Data == null) return NotFound(result);
            return Ok(result);
        }
        /// <summary>
        /// Belirtilen kimliğe sahip ürünü siler.
        /// </summary>
        /// <param name="id">Silinecek ürün kimliği.</param>
        /// <response code="200">Ürün silindi, işlem sonucu döndü.</response>
        /// <response code="404">Ürün bulunamadı veya silinemedi.</response>
        /// <response code="500">Sunucu hatası.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(SystemResult<ProductListDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result == null) return StatusCode(500);
            if (!result.IsSuccess) return NotFound(result);
            return Ok(result);
        }
    }
}
