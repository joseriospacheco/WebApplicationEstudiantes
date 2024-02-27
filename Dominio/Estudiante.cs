namespace Dominio
{
    public class Estudiante
    {
        public required int Id { get; set; }
        public required string Documento { get; set; }
        public required string  Nombres { get; set; }
        public required string Programa { get; set; }
        public required int Semestre { get; set; }
        public bool Activo { get; set; } = true;

    }
}
