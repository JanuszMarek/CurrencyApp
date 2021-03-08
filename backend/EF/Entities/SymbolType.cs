using System.ComponentModel.DataAnnotations;

namespace EF.Entities
{
    public class SymbolType
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
