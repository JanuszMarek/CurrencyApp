using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        public string Code { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [ForeignKey(nameof(SymbolType))]
        public int SymbolTypeId { get; set; }

        public SymbolType SymbolType { get; set; }
    }
}
