using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExercicioEF.Models
{
    [Table("TB_USER_CARGO")]
    class User_Cargo
    {
        [Key]
        [Column("ID_USER_CARGO")]
        public int Id_User_Cargo { get; set; }

        [Column("ID_CARGO")]
        public int Id_Cargo { get; set; }

        [Column("ID_USER")]
        public int Id_User { get; set; }

        [ForeignKey("Id_Cargo")]
        public virtual Cargo Cargo { get; set; }

        [ForeignKey("Id_User")]
        public virtual User User { get; set; }
    }
}
