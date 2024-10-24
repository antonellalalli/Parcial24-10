using ParcialPoo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace ParcialPoo.Modelos
{
    public static class SistemaPanaderia
    {
        public static List<Producto> Productos = new();
        static readonly string Archivo = "Panaderia.txt";

        public static void AgregarProducto(Producto prod)
        {
            Productos.Add(prod);
        }

        public static void MostrarProductos()
        {

            if (Productos.Count > 0) 
            {
                Console.WriteLine("------PRODUCTOS------");
                foreach (var prod in Productos)
                { 
                    Console.WriteLine(prod);

                }
            }
            else
            {
                Console.WriteLine("No hay productos que mostrar");
            }
        }

        public static void EliminarProducto(string nombre)
        {
            var producto = Productos.Find(p => p.Nombre == nombre);
            if (producto != null)
            {
                Productos.Remove(producto);
            }
            else
            {
                Console.WriteLine("El producto no se encontró");
            }
        }

        public static void ModificarProducto(string nombre, decimal precio, int stock)
        {
            var producto = Productos.Find(p => p.Nombre == nombre);
            if (producto != null )
            {
                producto.Precio = precio;
                producto.Stock = stock;
                Console.WriteLine("El producto se modifico");
            }
            else
            {
                Console.WriteLine("El producto no se encontro");
            }
        }
        public static decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var producto in Productos)
            {     
                total += producto.Precio;
            }
            return total;
        }

        public static void GuardarDatos()
        {
            using StreamWriter writer = new StreamWriter(Archivo);
            foreach (var producto in Productos)
            {
                writer.WriteLine(producto);
            }
        }

        public static void GuardarProducto(Producto producto)
        {
            using StreamWriter writer = new StreamWriter(Archivo, true);
            writer.WriteLine(producto);
        }


        public static void CargarDatos()
        {
            if (File.Exists(Archivo))
            {
                using StreamReader reader = new StreamReader(Archivo);

                foreach (var linea in File.ReadAllLines(Archivo))
                {
                    string[] datos = linea.Split(", ");
                    string nombre = datos[0];
                    decimal precio = decimal.Parse(datos[1]);
                    Categoria categoria = (Categoria)Enum.Parse(typeof(Categoria), datos[2]);
                    int stock = int.Parse(datos[3]);

                    Producto producto = new Producto(nombre, precio, categoria, stock);
                    Productos.Add(producto);

                }
            }
        }
    }
}
