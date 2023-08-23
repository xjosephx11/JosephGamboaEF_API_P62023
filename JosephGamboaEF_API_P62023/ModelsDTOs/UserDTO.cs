namespace JosephGamboaEF_API_P62023.ModelsDTOs
{
    public class UserDTO
    {
        public int idusuariodto { get; set; }
        public string correodto { get; set; } = null!;
        public string nombre { get; set; } = null!;
        public string apellidos { get; set; } = null!;
        public string? numero { get; set; }
        public string contrasenia { get; set; } = null!;
        public int cuentastrike { get; set; }
        public string respaldoemail { get; set; } = null!;
        public string? trabajodescripcion { get; set; }
        public int idusuariostatus { get; set; }
        public int idpais { get; set; }
        public int idusuariorol { get; set; }
    }
}
