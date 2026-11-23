using System.Text.Json;

namespace Front_Celulares
{
    // Una linea del carrito (un celular + cuantas unidades)
    public class ItemCarrito
    {
        public int CelularId { get; set; }
        public string? Modelo { get; set; }
        public string? Color { get; set; }
        public string? Almacenamiento { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        // Se calculan, no se guardan en la sesion
        public decimal Subtotal => Precio * Cantidad;
        public decimal Iva => Math.Round(Subtotal * CarritoSesion.TasaIva, 2);
        public decimal Total => Subtotal + Iva;
    }

    // El carrito vive en la sesion (ya configurada en Program.cs), no en la BD.
    // La BD solo se toca al finalizar la compra (Facturas + DetallesFacturas).
    public static class CarritoSesion
    {
        public const decimal TasaIva = 0.19m;
        private const string Clave = "Carrito";

        public static List<ItemCarrito> Leer(ISession sesion)
        {
            var json = sesion.GetString(Clave);
            if (string.IsNullOrEmpty(json))
                return new List<ItemCarrito>();
            return JsonSerializer.Deserialize<List<ItemCarrito>>(json) ?? new List<ItemCarrito>();
        }

        public static void Guardar(ISession sesion, List<ItemCarrito> items)
            => sesion.SetString(Clave, JsonSerializer.Serialize(items));

        public static void Vaciar(ISession sesion)
            => sesion.Remove(Clave);
    }
}
