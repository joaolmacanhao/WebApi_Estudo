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

        //ok
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

        //ok
        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFucionarioById(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);
                if (funcionario == null)
                {
                    serviceResponse.Message = "Funcionário não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionário deletado com sucesso!";
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //ok
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
        //ok
        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);
                if (funcionario == null)
                {
                    serviceResponse.Message = "Funcionário não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                serviceResponse.Data = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //ok
        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {

            
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
                if (funcionario == null)
                {
                    serviceResponse.Message = "Funcionário não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                funcionario.Ativo = false;
                funcionario.DateDeAlteracao = DateTime.Now;
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionário inativado com sucesso!";
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        //ok
        public async Task<ServiceResponse<List<FuncionarioModel>>> RetivaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionarios.FindAsync(id);
                if (funcionario == null)
                {
                    serviceResponse.Message = "Funcionário não encontrado";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                funcionario.Ativo = true;
                funcionario.DateDeAlteracao = DateTime.Now;
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Funcionarios.ToList();
                serviceResponse.Message = "Funcionário reativado com sucesso!";
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

    }
}
