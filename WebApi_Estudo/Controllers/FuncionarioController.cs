using Microsoft.AspNetCore.Mvc;
using WebApi_Estudo.Models;
using WebApi_Estudo.Service.FuncionarioService;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;   

namespace WebApi_Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionario()
        {
            return Ok(await _funcionarioInterface.GetFucionarios());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreatFucionarios(novoFuncionario));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            return Ok(await _funcionarioInterface.GetFuncionarioById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionarioById(int id)
        {
            return Ok(await _funcionarioInterface.DeleteFucionarioById(id));
        }

        [HttpPut("inativa/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.InativaFuncionario(id));
        }

        [HttpPut("reativa/{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> ReativaFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.RetivaFuncionario(id));
        }

        // ✅ Gera e força download do PDF
        [HttpGet("relatorio")]
          public async Task<IActionResult> GerarRelatorio()
        {
            // Defina o caminho do relatório FastReport (.frx)
            var caminhoDiretorio = @"C:\Users\joaom\Desktop\FastReport\Relatorios";
            // Combine o caminho do diretório com o nome do arquivo do relatório
            var caminhoRelatorio = Path.Combine(caminhoDiretorio, "ListagemFuncionarios.frx");
           
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            var webReport = new WebReport();
            webReport.Report.Load(caminhoRelatorio);
            await webReport.Report.PrepareAsync();

            using (MemoryStream ms = new MemoryStream())
            {
                var pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();

                var pdfBytes  = ms.ToArray();
                var result =  File(pdfBytes, "application/pdf", "RelatorioFuncionarios.pdf");
                return result;
            }

        }
    }
}
