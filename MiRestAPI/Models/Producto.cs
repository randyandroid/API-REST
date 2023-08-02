//Clase modelo de la API

using System.ComponentModel.DataAnnotations;

namespace MiRestAPI.Models{

//Modelo de la Tabla Producto
public class Producto{

[Key]
public int Id { get; set; }

[Required]
public string Nombre { get; set; }

[Required]
public string Descripcion { get; set; }

[Required]
public decimal Precio { get; set; }

[Required]
public int Cantidad {   get; set; }




}//fin de la clase Producto



}// fin del namespace

