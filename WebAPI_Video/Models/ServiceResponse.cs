namespace WebAPI_Video.Models
{
    public class ServiceResponse<T> //O T dentro do diamante indica que essa classe ServiceResponse pode receber dados genericos, ou seja ea pode receber dados de outros models, não só de funcionario(mas nessa api esse caso não acontece porque so temos funcionariomodel)
    {
        public T? Dados { get; set; } // O tipo T? especifica que pode receber qualquer dado, por exempro: FuncionarioModel, produtoModel(se tivesse nessa api) e etc... reprensetado pelo T, e o ? especifica que o dado pode ser nulo
        public string Mensagem { get; set; } = string.Empty;// = string.Empty; com isso a string ja esta sendo instanciada, começando vazia
        public bool Sucesso { get; set; } = true; 
    }
}
