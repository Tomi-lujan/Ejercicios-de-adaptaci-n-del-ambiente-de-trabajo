using System;
using CarritoCompras; 


namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Carrito carrito = new Carrito();
            Tienda tienda = new Tienda();

            string opcion;

            do
            {

                Console.WriteLine("===== Bienvenidos al 39-Market =====");
                Console.WriteLine("1. Categorías disponibles");
                Console.WriteLine("2. Productos disponibles");
                Console.WriteLine("3. Ver productos por categoría");
                Console.WriteLine("4. Agregar un producto al carrito");
                Console.WriteLine("5. Eliminar producto del carrito");
                Console.WriteLine("6. Ver carrito");
                Console.WriteLine("7. Ver importe");
                Console.WriteLine("8. Finalizar compra");
                Console.WriteLine("0. Salir del sistema");
                Console.WriteLine("==========================");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();


                switch (opcion)
                {
                    case "1":
                        VerCategorias();
                        break;

                    case "2":
                        VerTodosProductos();
                        break;

                    case "3":
                        VerProductosPorCategoria();
                        break;

                    case "4":
                        AgregarAlCarrito();
                        break;

                    case "5":
                        EliminarDelCarrito();
                        break;

                    case "6":
                        VerCarrito();
                        break;

                    case "7":
                        VerTotalAGastar();
                        break;

                    case "8":
                        FinalizarCompra();
                        break;

                    case "0":
                        Console.WriteLine("¡Gracias por usar el sistema de compras!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida");
                        break;

                }

                void VerCategorias(){
                    for (int i = 0; i < tienda.Categorias.Count; i++){
                        Console.WriteLine($"{i + 1}. {tienda.Categorias[i].nombre} - {tienda.Categorias[i].descripcion}");
                    }
                }

                void VerTodosProductos(){
                    foreach (var producto in tienda.Productos)
                    {
                        Console.WriteLine($"Código: {producto.codigo} | {producto.nombre} - ${producto.precio} | Stock: {producto.stock} | Categoría: {producto.categoria.nombre}");
                    }
                }

                void VerProductosPorCategoria(){
                    
                }

                void AgregarAlCarrito(){
                    Console.Write("Ingrese el código del producto: ");
                    int codigo = int.Parse(Console.ReadLine());

                }

                void EliminarDelCarrito()
                {
                    Console.Write("Ingrese el código del producto a eliminar: ");
                    int codigo = int.Parse(Console.ReadLine());

                }

                void VerCarrito()
                {
                    carrito.Ver();
                }

                void VerTotalAGastar()
                {
                    double total = carrito.Total();
                    Console.WriteLine($"Total a pagar: ${total}");
                }

                void FinalizarCompra()
                {
                    if (carrito.EstaVacio())
                    {
                        Console.WriteLine("No hay productos en el carrito.");
                        return;
                    }


                    VerTotalAGastar();
                    carrito.listaItems.Clear();
                    Console.WriteLine("¡Compra finalizada con éxito!");
                }



                if (opcion != "0")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear(); // Limpia la pantalla para mejor visualización
                }

            } while (opcion != "0");

            Console.WriteLine("¡Gracias por visitar 39-Market!");

        }
    }
}
