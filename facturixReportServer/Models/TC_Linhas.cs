using System;

namespace facturixReportServer.Models
{
	public class TC_Linhas
	{
		public int ID { get; set; }
		public string mesa { get; set; } = "";
		public string tipo_doc { get; set; } = "";
		public string ano_serie { get; set; } = "";
		public int numero_doc { get; set; } = 0;
		public string mesa_uniao_principal { get; set; } = "";
		public int linha { get; set; }
		public string codigo_produto { get; set; } = "";
		public string descricao { get; set; } = "";
		public string medida { get; set; } = "";
		public decimal qtd { get; set; }
		public decimal qtd_ordem_servico { get; set; }
		public decimal taxa_desconto { get; set; }
		public decimal taxa_iva { get; set; }
		public decimal pr_unit_sem_iva { get; set; }
		public decimal pr_unit_com_iva { get; set; }
		public decimal pr_total_com_iva { get; set; }
		public string armazem { get; set; } = "";
		public string operador_numero { get; set; } = "";
		public string operador_nome { get; set; } = "";
		public DateTime data_criacao { get; set; }
		public DateTime data_alteracao { get; set; }
		public string vendedor_numero { get; set; } = "";
		public bool pago { get; set; } = false;
		public string nome_cliente { get; set; } = "";
		public string departamento_designacao { get; set; } = "";
		public int pedido { get; set; } = 0;
	}
}