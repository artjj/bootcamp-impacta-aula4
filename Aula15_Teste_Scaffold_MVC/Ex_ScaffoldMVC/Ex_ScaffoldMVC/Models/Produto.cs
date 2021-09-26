using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Models
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("ID_PRODUTO")]
        public int Id { get; set; }

        [Column("NM_PRODUTO", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        [Column("VLR_PRODUTO", TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Column("DT_VALIDADE")]
        public DateTime Validade { get; set; }

        public virtual ICollection<VendaItem> ItensDoProdutoVendido { get; set; }
    }
}
