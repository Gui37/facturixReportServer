using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using facturixReportServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace facturixReportServer.Controllers
{
	[RoutePrefix("api/relatorio")]
	public class RelatorioController : ApiController
	{
		[HttpPost]
		[Route("gerar")]
		public IHttpActionResult GerarRelatorio(PedidoDto pedido)
		{
			try
			{
				ReportDocument rpt = new ReportDocument();
				string caminho = System.Web.Hosting.HostingEnvironment.MapPath("~/reports/TalaoDepartamento.rpt");

				rpt.Load(caminho);

				rpt.SetParameterValue("nome_departamento", pedido.nomeDepartamento);
				rpt.SetParameterValue("data", pedido.data);
				rpt.SetParameterValue("mesa", pedido.mesa);
				rpt.SetParameterValue("numero_pedido", pedido.numeroPedido);
				rpt.SetParameterValue("cancelado", pedido.cancelado);
				rpt.SetParameterValue("mensagem", pedido.cancelado == 0 ? pedido.mensagem : "");

				Stream pdf = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
				pdf.Seek(0, SeekOrigin.Begin);

				return new FileResult(pdf, "application/pdf", "Conta.pdf");
			}
			catch (System.Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		public class FileResult : IHttpActionResult
		{
			private readonly Stream _stream;
			private readonly string _contentType;
			private readonly string _fileName;

			public FileResult(Stream stream, string contentType, string fileName)
			{
				_stream = stream;
				_contentType = contentType;
				_fileName = fileName;
			}

			public async System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
			{
				var result = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
				{
					Content = new System.Net.Http.StreamContent(_stream)
				};
				result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(_contentType);
				result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
				{
					FileName = _fileName
				};
				return result;
			}
		}
	}
}