
//Importo mis librerias

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiRestAPI.Data;
using MiRestAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MiRestAPI.Controllers{

//defino mi ruta principal
[Route("api/[controller]")]
[ApiController]

public class ProductosController: ControllerBase {

private readonly ProductoContext _context;

//defino mi constructor
public ProductosController(ProductoContext context){
_context = context;

}//fin del constructor

//valido si existe un producto
private bool ProductoExists(int id)
{
    return _context.Productos.Any(p => p.Id == id);
}


//Get: api/Productos
[HttpGet]
public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(){
return await _context.Productos.ToListAsync();
}//fin del metodo

//Get: api/Productos/5

[HttpGet("{Id}")]

public async Task<ActionResult<Producto>> GetProducto(int Id){

var producto = await _context.Productos.FindAsync(Id);

//Si no encuentra el producto retorname un error 404
if(producto == null){
return NotFound();
}

return producto;

}//fin del metodo 


//post : api/Productos

[HttpPost]

public async Task<ActionResult<Producto>> PostProducto(Producto producto){

_context.Productos.Add(producto);
await _context.SaveChangesAsync();

return CreatedAtAction("GetProducto", new { Id = producto.Id }, producto);

}//fin del metodo

//PUT: api/productos/5

[HttpPut("{Id}")]

public async Task<IActionResult> PutProducto(int Id, Producto producto){

if(Id!= producto.Id){
return BadRequest();
}

try{
await _context.SaveChangesAsync();


}catch(DbUpdateConcurrencyException){

    if(!ProductoExists(Id)){

        return NotFound();
    }else{

        throw;
    }

}

return NoContent();

}//fin del metodo


//DELETE: api/productos/5
[HttpDelete("{Id}")]

public async Task<ActionResult> DeleteProducto(int Id){

var producto = await _context.Productos.FindAsync(Id);
if(producto == null){

return NotFound();


}//fin del if

_context.Productos.Remove(producto);
await _context.SaveChangesAsync();

return NoContent();


}//fin del metodo


}//fin de la clase productos controller





}//fin del namespace