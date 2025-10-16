﻿using System.ComponentModel.DataAnnotations;
using WebApi_Estudo.Enums;

namespace WebApi_Estudo.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public DepartamentoEnum Departamento { get; set; } 
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DateDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
