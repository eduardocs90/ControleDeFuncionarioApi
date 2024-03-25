using WebAPI_Video.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Video.Models
{
    public class FuncionarioModel
    {
        [Key] // esse[Key] serve para dizer para o sistema que o id vai ser o identificador unico do funcionario
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DepartamentoEnum Departamento { get; set; } // foi criado um enum para tipar esse atributo (porque esse atributo pode ser diversificado ex: RH ou Atendimento ou Compras etc...)
        public bool Ativo { get; set; } 
        public TurnoEnum Turno { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime(); //Instancia que que atualiza a data no ato da criação e alteração
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
