﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_ScaffoldMVC.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Column("NM_USUARIO", TypeName = "VARCHAR(100)")]
        public string Nome { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}
