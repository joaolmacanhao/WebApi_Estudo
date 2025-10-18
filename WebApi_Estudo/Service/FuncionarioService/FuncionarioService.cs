using WebApi_Estudo.DataContext;
using WebApi_Estudo.Models;

namespace WebApi_Estudo.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreatFucionarios(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novoFuncionario == null) { 
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informe os dados do funcionario";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFucionarioById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFucionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
            serviceResponse.Data = _context.Funcionarios.ToList();

                if(serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado...";
                }
            
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            } 
            return serviceResponse;
        }

        public Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarioById(FuncionarioModel editandoFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}
