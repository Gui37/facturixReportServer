using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace facturixReportServer.Models
{
	public class PedidoDto
	{
		public int ID { get; set; }
		public string mesa { get; set; } = "";
		public string nomeDepartamento { get; set; } = "";
		public string numeroPedido { get; set; } = "";
		public int cancelado { get; set; } = 0;
		public string mensagem { get; set; } = "";
		public DateTime data { get; set; } = DateTime.Now;
		public List<TC_Linhas> Linhas { get; set; } = new List<TC_Linhas>();
	}
}