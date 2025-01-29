namespace CrudDapperVideo.Dto
{
    public class UsuarioDtoListar
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }       
        public bool Situacao { get; set; }        
    }
}
