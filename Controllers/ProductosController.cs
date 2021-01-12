using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly List<ProductosViewModel> _products = new List<ProductosViewModel>()
        {
            new ProductosViewModel {Id = 1, Descripcion = "Samsung Galaxy"},
            new ProductosViewModel {Id = 2, Descripcion = "Xiaomi"},
            new ProductosViewModel {Id = 3, Descripcion = "Xbox series x"}
        };
        

        //"Samsung Galaxy", "Xiaomi", "Iphone", "Xiaomi MI 10", "Huawei mate 10", "Sony xperia", "Samsung 10", "Xbox series x", "PS4", "Cargador Universal"
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_products);
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var p = _products;
            return p.SingleOrDefault(x => x.Id==id)?.Descripcion ;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

            _products.Add(new ProductosViewModel
            {
                Id = _products.Last().Id + 1,
                Descripcion = value

            });

        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
