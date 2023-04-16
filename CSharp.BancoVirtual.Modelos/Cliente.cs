using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_string_expressoes_regulares_classe_Object
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        // Sobrescrição do método Equals
        // O Equals() recebe por argumento um object, e qualquer coisa é um object
        // Realizando a comparação se o cliente da instância é igual ao recebido por argumento
        public override bool Equals(object obj)
        {
            // "(Cliente)obj" para conversão do object para um tipo Cliente, criando a variável que recebe obj e solicitando conversão, pois o objeto não cabe em uma variável do tipo Cliente
            // Conversão explícita com resultado armazenando na variável "outroCliente"

            // Outra forma de fazer a conversão: Cliente outroCliente = (Cliente)obj;

            // Realizado cast usando a palavra reservada "as" seguida pelo tipo esperado "Cliente"
            Cliente outroCliente = obj as Cliente;

            // Verificação se outroCliente é nulo
            if (outroCliente == null)
            {
                return false;
            }

            // Definindo o que é igualdade entre duas entidades comparando propriedade
            // Sobrescrição do método Equals() e implementação que compara os campos
            return
                // O Nome e a Profissao não são identificadores da classe, por isso não é necessário comparar campo a campo
                    // Nome == outroCliente.Nome &&
                    // Profissao == outroCliente.Profissao &&
                // Comparação realizada apenas com o identificador
                CPF == outroCliente.CPF;
        }
    }
}
