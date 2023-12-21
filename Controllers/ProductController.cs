using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PatikaAkbank.NETCohorts_Homework1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<ProductModel> _ProductModels = new List<ProductModel>
        {
            new ProductModel { Id = 1, Name = "ProductModel 1", Price = 19.99m },
            new ProductModel { Id = 2, Name = "ProductModel 2", Price = 29.99m }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ProductModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ProductModel = _ProductModels.Find(p => p.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }

            return Ok(ProductModel);
        }



        [HttpPost]
        public IActionResult Create([FromBody] ProductModel ProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductModel.Id = _ProductModels.Count + 1;
            _ProductModels.Add(ProductModel);

            return CreatedAtAction(nameof(GetById), new { id = ProductModel.Id }, ProductModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductModel updatedProductModel)
        {
            var existingProductModel = _ProductModels.Find(p => p.Id == id);

            if (existingProductModel == null)
            {
                return NotFound();
            }

            existingProductModel.Name = updatedProductModel.Name;
            existingProductModel.Price = updatedProductModel.Price;

            return Ok(existingProductModel);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductModel> patchDocument, [FromQuery] string additionalInfo)
        {
            var existingProduct = _ProductModels.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            patchDocument.ApplyTo(existingProduct, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ProductModel = _ProductModels.Find(p => p.Id == id);

            if (ProductModel == null)
            {
                return NotFound();
            }

            _ProductModels.Remove(ProductModel);

            return NoContent();
        }

        [HttpGet("list")]
        public IActionResult GetList([FromQuery] string name)
        {
            var filteredProducts = _ProductModels.Where(p => p.Name.Contains(name ?? "", StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(filteredProducts);
        }

        [HttpGet("list/sorted")]
        public IActionResult GetSortedList()
        {
            var sortedProducts = _ProductModels.OrderBy(p => p.Name).ToList();
            return Ok(sortedProducts);
        }

    }
}
