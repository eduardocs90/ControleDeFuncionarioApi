using Microsoft.EntityFrameworkCore;
using WebAPI_Video.DataContext;
using WebAPI_Video.Models;

namespace WebAPI_Video.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AplicationDbContext _context; // Também é necessário criar esse elemento privado para leitura
        public FuncionarioService(AplicationDbContext context) // é necessario criar esse construtor para poder se comunicar com o banco de dados
        {
            _context = context;  // quando usarmos o context no nosso codigo estaremos usando o AplicationDbContext ou seja acessando o banco de dados
        }

        //FUNÇÃO GET
        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios() //O metodo NaIfuncionarioInterface é Task, por esse motivo tem que colocar async(Porque é uma função assincrona)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>(); // Cria uma nova instância de ServiceResponse para armazenar a resposta da função
            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList(); // Obtém todos os registros da tabela Funcionarios e os armazena na propriedade Dados do serviceResponse

                if (serviceResponse.Dados.Count == 0) // Verifica se não há nenhum registro na lista de funcionários
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado"; // Define uma mensagem indicando que nenhum dado foi encontrado
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message; // Em caso de exceção, define a mensagem de erro como a mensagem da exceção
                serviceResponse.Sucesso = false; // Define o sucesso como false, indicando que ocorreu um erro
            }
            return serviceResponse; // Retorna o ServiceResponse, que contém a lista de FuncionarioModel e informações sobre o sucesso ou falha da operação
        }

        //FUNÇÃO CREATE
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {

                if (novoFuncionario == null) //Caso o usuario não informar os dados do novoFuncionario a função encerra
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novoFuncionario); // adiciona novoFuncionario
                await _context.SaveChangesAsync(); // Salva novoFuncionario no banco de dados
                serviceResponse.Dados = _context.Funcionarios.ToList(); // faz uma consulta geral no banco de dados 


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse; // retorna a consulta com o novoFuncionario salvo

        }

       

        //FUÇÃO GTE POR ID
        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioByID(int id) //Repara que não estamos retornando uma List, Porque vamos retornar apenas um FuncionarioModel Dentro do ServiceResponse
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id); // Aqui é criada uma variavel funcionario do tipo FuncionarioModel que vai receber um select no banco de dados aonde ele vai pegar o id do funcionario e armazenar nessa variavel
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }


                serviceResponse.Dados = funcionario; // aqui atribuimos a variavel funcionario após a busca no banco de dados ao serviceResponse com os dados encontrados 


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse; //aqui retornamos o serviceResponse com o resultado da função
        }


        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id); //Aqui no inativaFuncionario ta recebendo uma consulta no banco e x representa um funcionario => x.Id representa o id do funcionario == id significa que o id digitado tem que ser igual ao id do funcionario
                if (funcionario == null) // verifica se não é null
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }
                funcionario.Ativo = false; // altera o Ativo para False
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();// alteroi Data

                _context.Funcionarios.Update(funcionario);// fiz o update no banco
                await _context.SaveChangesAsync();// salvei as alterações

                serviceResponse.Dados = _context.Funcionarios.ToList();// faço uma consulta no banco de dados novamente para trazer eles atualizados 

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;// trazendo os dados atualizados 
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFunconario(FuncionarioModel editadoFunconario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();


            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFunconario.Id); //NO CASO DO UPDATE FOI NECESSARIO COLOCAR .AsNoTracking() PARA EVITAR ERROS E CONFLITOS COM O BANCO DE DADOS

                if (funcionario == null) // verifica se não é null
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFunconario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;



           
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);


                if (funcionario == null) // verifica se não é null
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado";
                    serviceResponse.Sucesso = false;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;



        }
    }
}
