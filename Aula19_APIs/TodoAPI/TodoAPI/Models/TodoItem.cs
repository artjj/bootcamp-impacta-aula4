﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    [Table("TB_TODO_ITEM")]
    public class TodoItem
    {
        [Key]
        [Column("ID_TODO_ITEM")]
        public int Id { get; set; }

        [Column("NM_TODO_ITEM", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("IS_COMPLETED")]
        public bool IsCompleted { get; set; }

    }
}
