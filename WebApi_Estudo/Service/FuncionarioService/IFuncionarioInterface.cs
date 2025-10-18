using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {

        Task<ServiceResponse<List<FuncionarioModel>>> GetFucionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> CreatFucionarios(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>>UpdateFuncionarioById(FuncionarioModel editandoFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>>DeleteFucionarioById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
    }
}
