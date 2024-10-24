using ParcialPoo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPoo.Modelos
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get;  set; }
        public Categoria Categoria { get; private set; }
        public int Stock {  get; set; }

        public Producto(string nombre, decimal precio, Categoria categoria, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Categoria}, {Precio}, {Stock}";      
        }
    }
}
