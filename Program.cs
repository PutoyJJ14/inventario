using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, double precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}

class Program
{
    static void Main()
    {

        List<Producto> inventario = new List<Producto>();


        int opcion;
        do
        {
            Console.WriteLine("\nMenú de Inventario:");
            Console.WriteLine("1. Añadir producto");
            Console.WriteLine("2. Actualizar cantidad de producto");
            Console.WriteLine("3. Calcular valor total del inventario");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:

                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    double precio = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese la cantidad en stock: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());

                    AgregarProducto(inventario, nombre, precio, cantidad);
                    break;

                case 2:

                    Console.Write("Ingrese el nombre del producto a actualizar: ");
                    string nombreProducto = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad en stock: ");
                    int nuevaCantidad = Convert.ToInt32(Console.ReadLine());

                    ActualizarStock(inventario, nombreProducto, nuevaCantidad);
                    break;

                case 3:

                    double valorTotal = CalcularValorTotal(inventario);
                    Console.WriteLine($"El valor total del inventario es: {valorTotal:C}");
                    break;

                case 4:
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción del 1 al 4.");
                    break;
            }

        } while (opcion != 4);
    }


    static void AgregarProducto(List<Producto> inventario, string nombre, double precio, int cantidad)
    {
        Producto nuevoProducto = new Producto(nombre, precio, cantidad);
        inventario.Add(nuevoProducto);
        Console.WriteLine($"Producto '{nombre}' añadido al inventario.");
    }


    static void ActualizarStock(List<Producto> inventario, string nombre, int nuevaCantidad)
    {
        bool productoEncontrado = false;

        foreach (var producto in inventario)
        {
            if (producto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                producto.Cantidad = nuevaCantidad;
                Console.WriteLine($"Cantidad actualizada para el producto '{nombre}'. Nueva cantidad: {nuevaCantidad}");
                productoEncontrado = true;
                break;
            }
        }

        if (!productoEncontrado)
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado en el inventario.");
        }
    }


    static double CalcularValorTotal(List<Producto> inventario)
    {
        double valorTotal = 0;
        foreach (var producto in inventario)
        {
            valorTotal += producto.Precio * producto.Cantidad;
        }
        return valorTotal;
    }
}