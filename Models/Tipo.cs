namespace Zapateria.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<Zapato> zapatos { get; set; }
    }
}
