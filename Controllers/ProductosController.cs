using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<ProductosViewModel> GetProductos()
        {
            var list = new List<ProductosViewModel>
            {
                new ProductosViewModel {Id = 1, Descripcion = "Samsung Galaxy"},
                new ProductosViewModel {Id = 2, Descripcion = "Xiaomi"},
                new ProductosViewModel{Id=3,Descripcion = "Xbox series x"}
            };
            return list;
        }

        //"Samsung Galaxy", "Xiaomi", "Iphone", "Xiaomi MI 10", "Huawei mate 10", "Sony xperia", "Samsung 10", "Xbox series x", "PS4", "Cargador Universal"
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetProductos());
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var p = GetProductos();
            return p.SingleOrDefault(x => x.Id==id)?.Descripcion ;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

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
