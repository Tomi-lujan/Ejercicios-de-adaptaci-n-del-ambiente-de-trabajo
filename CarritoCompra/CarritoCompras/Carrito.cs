using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    public class Carrito
    {
       public List<ItemCarrito> listaItems;

        public Carrito()
        {
            listaItems = new List<ItemCarrito>();
        }

        public void Agregar(Producto producto, int cantidad)
        {
            var existente = listaItems.FirstOrDefault(i => i.producto.codigo == producto.codigo);
            if (existente != null)
            {
                existente.cantidad += cantidad;
            }
            else
            {
                listaItems.Add(new ItemCarrito(producto, cantidad));
            }
            producto.stock -= cantidad;
        }

        public void Eliminar(int codigo)
        {
            var items = listaItems.FirstOrDefault(i => i.producto.codigo == codigo);
            if (items != null)
            {
                items.producto.stock += items.cantidad;
                listaItems.Remove(items);
            }
        }

        public void Ver()
        {
            if (!listaItems.Any())
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            foreach (var item in listaItems)
            {
                Console.WriteLine($"{item.producto.nombre} - Cantidad: {item.cantidad} - Total: ${item.producto.precio * item.cantidad}");
            }
        }

        public double Total()
        {
            return listaItems.Sum(i => i.producto.precio * i.cantidad);
        }

        public void Vaciar()
        {
            listaItems.Clear();
        }

        public bool EstaVacio()
        {
            return !listaItems.Any();
        }
    }
}