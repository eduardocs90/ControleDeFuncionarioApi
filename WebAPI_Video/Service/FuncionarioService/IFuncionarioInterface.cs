using WebAPI_Video.Models;

namespace WebAPI_Video.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        //Task porque estaremos usando métodos assincronos 
        //Dentro do diamante do Task Está o ServiceRespose criado na Models que trás os Dados, Mensagem e o status de Sucesso da requisição 
        //Dentro do ServiceResponse vai ter uma List(porque retorna uma lista) e Dentro da List vai ter a lista de FuncionarioModel: Task<ServiceResponse<List<FuncionarioModel>>> e o nome do método();
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        //Afunção Create vai receber como parametro FuncionarioModel porque essa função cria um funcionario novo e FuncionarioModel representa todos os atributos de um funcionario 
        // e por fim FucionarioModel passa a ser novoFuncionario
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);
        //No GetFuncionarioByID como o nome do metodo ja diz, vai retonar o id de um funcionario ou seja vai buscar apenas um funcionnario, por tanto passamos como parametr o int id
        Task<ServiceResponse<FuncionarioModel>>GetFuncionarioByID(int id);
        //UpdateFunconario retorna uma lista de funcionarios por tanto recebe por parametro FuncionarioModel porque editaremos os atributos do funcionario, porfim torna se editadoFuncionario
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFunconario(FuncionarioModel editadoFunconario);
        //O DeleteFuncionario retorna uma List porque vai retornar a lista de funcionarios sem o funcionario deletado, e rece como paramero o id porque será deletado pelo id
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        //O InativaFuncionario Retorna uma List de Funcionario com o status de ativo false e recebe como parametro id porque inativaremos o funcionario pelo id
        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);


    }
}
