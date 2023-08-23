namespace JosephGamboaEF_API_P62023.ModelsDTOs
{
    public class UserRoleDTO
    {
        public int IDRolUsuario { get; set; }
        public string DescripcionRol { get; set; } = null!;
        public bool UsuarioEsElegible { get; set; }
    }
}
