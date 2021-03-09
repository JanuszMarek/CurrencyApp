using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class SymbolType
    {
        public SymbolType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
