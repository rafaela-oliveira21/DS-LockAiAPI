namespace LockAiAPI.Models
{
    public class PlanoLocacao
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdUsuario { get; set; }
        public int IdObjeto { get; set; }
        public int IdPlanoLocacao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataValidade { get; set; }
        public DateTime? DataSituacao { get; set; }
        public int Valor { get; set; }
        public string? Situacao { get; set; }
        public int IdUsuarioSituacao { get; set; }
    }
}
