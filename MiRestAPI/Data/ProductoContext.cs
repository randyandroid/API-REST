//Importo mis librerias

using Microsoft.EntityFrameworkCore;
using MiRestAPI.Models;


namespace MiRestAPI.Data{

public class ProductoContext: DbContext{

//declaro el constructor

public ProductoContext(DbContextOptions<ProductoContext> options) : base(options){
 

}//fin del constructor

public DbSet<Producto> Productos{ get; set; }


}//fin de la clase 



}//fin del namespace

