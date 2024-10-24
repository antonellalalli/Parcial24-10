using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialPoo.Enums;
namespace ParcialPoo.Modelos
{
    public static class Menu
    {
        public static List<Action> Acciones = new()
         {
             AgregarProducto,
             MostrarProductos,
             ModificarProducto,
             EliminarProducto,
             ConocerTotal
         };

        public static void MostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("1.Agregar producto");
                Console.WriteLine("2.Mostrar productos");
                Console.WriteLine("3.Modificar producto");
                Console.WriteLine("4.Eliminar producto");
                Console.WriteLine("5.Conocer total de dinero");

                Console.WriteLine("Seleccione una opcion:  ");
                string opcion = Console.ReadLine();

                if(int.TryParse(opcion, out int indice) && indice >=  1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }


            }
        }

        static void MostrarProductos() => SistemaPanaderia.MostrarProductos();
        static void AgregarProducto()
        {
           
            Console.WriteLine("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la categoria del producto 1.Pan / 2. Bizcocho / 3. Pastel");
            int categoria = int.Parse(Console.ReadLine());
            Categoria cat = (Categoria)categoria;

            Producto producto = new Producto(nombre, precio, cat, stock);

            SistemaPanaderia.AgregarProducto(producto);
            SistemaPanaderia.GuardarProducto(producto);
        }

        static void EliminarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto que desea eliminar: ");
            string nombre = Console.ReadLine();
            SistemaPanaderia.EliminarProducto(nombre);
            SistemaPanaderia.GuardarDatos();
        }

        static void ModificarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto que desea modificar: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo stock del producto: ");
            int stock = int.Parse(Console.ReadLine());

            SistemaPanaderia.ModificarProducto(nombre, precio, stock);
            SistemaPanaderia.GuardarDatos();
        }

        static void ConocerTotal()
        {
            decimal total = SistemaPanaderia.CalcularTotal();
            Console.WriteLine($"El total de dinero utilizado en productos es de ${total}");
        }
    }
}
