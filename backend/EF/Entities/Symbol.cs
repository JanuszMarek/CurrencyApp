using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        public string SymbolName { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [ForeignKey(nameof(SymbolType))]
        public int SymbolTypeId { get; set; }

        public SymbolType SymbolType { get; set; }
    }
}
