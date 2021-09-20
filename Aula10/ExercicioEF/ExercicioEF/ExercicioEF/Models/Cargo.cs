using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExercicioEF.Models
{
    [Table("TB_CARGO")]
    class Cargo
    {
        [Key]
        [Column("ID_CARGO")]
        public int Id { get; set; }

        [Column("DESC_CARGO", TypeName = "VARCHAR(50)")]
        public string DescricaoCargo { get; set; }

        public ICollection<User_Cargo> User_Cargo { get; set; }
    }
}
