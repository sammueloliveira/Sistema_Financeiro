﻿using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Despesa")]
    public class Despesa : Base
    {
        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public TipoDespesa Tipo { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }

        public bool Pago { get; set; }
        public bool DespesaAtrasada { get; set; }
        
        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
       //public Categoria Categoria { get; set; }

    }
} 