using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly List<ProductosViewModel> _products = new List<ProductosViewModel>()
        {
            new ProductosViewModel {Id = 1, Descripcion = "Samsung Galaxy",Precio = 23000},
            new ProductosViewModel {Id = 2, Descripcion = "Xiaomi mi 10",Precio = 13499},
            new ProductosViewModel {Id = 3, Descripcion = "Xbox series x",Precio = 8499},
            new ProductosViewModel {Id = 4, Descripcion = "Samsung Galaxy 20 pro",Precio = 23000},
            new ProductosViewModel {Id = 5, Descripcion = "PS4",Precio = 13499},
            new ProductosViewModel {Id = 6, Descripcion = "Xbox series s",Precio = 8499},
            new ProductosViewModel {Id = 7, Descripcion = "Disco Duro 1T HDD",Precio = 23000},
            new ProductosViewModel {Id = 8, Descripcion = "Disco duro 128 gb SSD",Precio = 13499},
            new ProductosViewModel {Id = 9, Descripcion = "Iphone 10",Precio = 8499},
            new ProductosViewModel {Id = 10, Descripcion = "NIntendo Switch",Precio = 8499}
        };


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_products);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            var p = _products;
            return p.SingleOrDefault(x => x.Id == id)?.Descripcion;
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProductosViewModel vM)
        {
            //if (string.IsNullOrWhiteSpace(value))
            //{
            //    return BadRequest("Ha ocurrido un error durante la inserción.");
            //}
            _products.Add(new ProductosViewModel
            {
                Id = _products.Last().Id + 1,
                Descripcion = vM.Descripcion,
                Precio = vM.Precio
            });
            return Ok(_products);
        }


        [HttpPut]
        public IActionResult Put([FromBody] ProductosViewModel vM)
        {
            //if (string.IsNullOrWhiteSpace(value))
            //{
            //    return BadRequest("Ha ocurrido un error durante la inserción.");
            //}
            //var vM = new ProductosViewModel();
            var prod = _products.First(x => x.Id == vM.Id);
            //JsonConvert.PopulateObject(value, vM);
            prod.Precio = vM.Precio;
            prod.Descripcion = vM.Descripcion;
            return Ok(_products);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prod = _products.FirstOrDefault(x => x.Id == id);
            if (prod == null)
            {
                return Ok(_products);
            }
            _products.Remove(prod);
            return Ok(_products);
        }

    }
}
