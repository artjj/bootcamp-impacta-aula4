using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExercicioEF.Models
{
    [Table("TB_USER")]
    class User
    {
        [Key]
        [Column("ID_USER")]
        public int Id { get; set; }

        [Column("NM_USER", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Column("DT_NASC", TypeName = "DATE")]
        public DateTime DataNascimento { get; set; }

        [Column("DS_CPF", TypeName = "VARCHAR(11)")]
        public string Cpf { get; set; }

        [Column("ID_CARGO_USER")]
        public int IdCargo { get; set; }

        [ForeignKey("IdCargo")]
        public virtual Cargo Cargo { get; set; }
    }
}
