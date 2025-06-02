namespace facturixReportServer.Models
{
	public class TC
	{
		public int ID { get; set; }
		public string mesa { get; set; } = "";
		public string tipo_doc { get; set; } = "";
		public string ano_serie { get; set; } = "";
		public int numero_doc { get; set; } = 0;
		public string cliente_numero { get; set; } = "";
		public string mensagem_mesa { get; set; } = "";
		public string mensagem_cozinha { get; set; } = "";
		public bool pago { get; set; } = false;
	}
}