using System;
using System.Collections.Generic;
using System.Web;

namespace CRUD.Models {
	public class Produto {
		public int Id { get; set; }
		public string TipoMercadoria { get; set; }
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public decimal Preco { get; set; }
        public string PrecoStr
        {
            get
            {
                return $"R$ {Preco.ToString("N")}";
            }
        }
		public string TipoNegocio { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataExclusao { get; set; }
       
        //Método para Calcular a soma dos produtos.
        public decimal SomaProdutos
        {
            get
            {
                decimal soma = 0;
                soma = Quantidade * Preco;
                return soma;
            }
        }
        public string SomaProdutosStr
        {
            get
            {
                return $"R$ {SomaProdutos.ToString("N")}";
            }
        }

    }
}
