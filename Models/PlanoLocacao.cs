namespace LockAiAPI.Models
{
    public class PropostaLocacao
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int IdUsuario { get; set; }
        public int IdObjeto { get; set; }
        public int IdPlanoLocacao { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string DataValidade { get; set; }
        public float Valor { get; set; }
        public char Situacao { get; set; }
        public string DataSituacao { get; set; }
        public int IdUsuarioSituacao { get; set; }
    }
}
