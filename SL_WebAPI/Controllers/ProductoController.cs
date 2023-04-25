using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SL_WebAPI.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        [HttpGet]
        [Route("api/Producto")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

      
        [HttpGet]
        [Route("api/Producto/{IdProducto}")]
        public IHttpActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdEF(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Producto
        [HttpPost]
        [Route("api/Producto")]
        public IHttpActionResult Post([FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Producto/5
        [HttpPut]
        [Route("api/Producto/{IdProducto}")]
        public IHttpActionResult Put(int IdProducto, [FromBody] ML.Producto producto)
        {
            ML.Result result = BL.Producto.UpdateEF(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Producto/5
        [HttpDelete]
        [Route("api/Producto/{IdProducto}")]
        public IHttpActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


    }
}

