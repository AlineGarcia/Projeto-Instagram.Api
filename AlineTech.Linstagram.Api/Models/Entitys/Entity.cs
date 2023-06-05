namespace AlineTech.Linstagram.Api.Models.Entitys
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Entity() 
        { 
            Id = Guid.NewGuid();
        }
    }
}
