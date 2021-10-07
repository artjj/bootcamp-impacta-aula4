using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Mercado.Models
{
    [Table("TB_USER")]
    public class User
    {
        [Key]
        [Column("ID_USER")]
        public int Id { get; set; }

        [Column("NM_USER", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("CD_EMAIL", TypeName = "varchar(60)")]
        public string Email { get; set; }

        [Column("CD_PASSWORD", TypeName = "varchar(60)")]
        [JsonIgnore]
        public string Password { get; set; }

        [Column("CD_PROFILE", TypeName = "varchar(20)")]
        public string Profile { get; set; }

        [JsonIgnore]
        public virtual ICollection<Venda> Vendas { get; set; }

    }
}
