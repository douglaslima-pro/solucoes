namespace Solucoes.Domain.Entities.Projetos
{
    public class ProjetoConvite
    {
        // Propriedades públicas
        public int Id { get; private set; }
        public int ProjetoId { get; private set; }
        public int UsuarioId { get; private set; }
        public int ProjetoPapelId { get; private set; }
        public byte[] TokenHash { get; private set; }
        public DateTime ExpiraEm { get; private set; }
        public bool? Aceito { get; private set; }
        public int CriadoPorProjetoMembroId { get; private set; }
        public DateTime CriadoEm { get; private set; }

        // Relacionamentos
        public Projeto? Projeto { get; private set; }
        public ProjetoPapel? ProjetoPapel { get; private set; }
        public ProjetoMembro? CriadoPorProjetoMembro { get; private set; }

        protected ProjetoConvite() { }

        public ProjetoConvite(int projetoId, int usuarioId, int projetoPapelId, byte[] tokenHash, int projetoMembroId)
        {
            ProjetoId = projetoId;
            UsuarioId = usuarioId;
            ProjetoPapelId = projetoPapelId;
            TokenHash = tokenHash;
            ExpiraEm = DateTime.UtcNow.AddDays(7);
            CriadoPorProjetoMembroId = projetoMembroId;
            CriadoEm = DateTime.UtcNow;
        }
    }
}
