using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_string_expressoes_regulares_classe_Object
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;        

        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {
            if(String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;            
        }

        // moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            // O ToUpper deixa o texto em caixa alta - Para trabalhar apenas com caracteres em maiúsculo
            nomeParametro = nomeParametro.ToUpper(); // Vai transformar "valor" em "VALOR"
            string argumentoEmCaixaAlta = _argumentos.ToUpper(); // Vai transformar em "MOEDAORIGEM=REAL&MOEDADESTINO=DOLAR"

            // Guardando a string em outra variável para depois tratar ela, e não simplesmente retornar a Substring
            string termo = nomeParametro + "="; // moedaDestino=
            // Indice do Termo, no caso o "m" após o & (moedaOrigem=real& -> m <- oedaDestino=dolar), vou colocar como "x" para não precisar contar todos os caracteres antes dele  
            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo); // x

            // Guardada na variável resultado uma Substring dos argumentos do indiceTermo, o primeiro caracter da "moedaDestino", mais o tamanho da "moedaDestino"
            // Assim a Substring vem com o valor "dolar", pois foi pego o índice do "m", somado com o tamanho de "moedaDestino=", ficando com com o "d" de "dolar"
            string resultado = _argumentos.Substring(indiceTermo + termo.Length); // dolar

            // Aqui pega o índice do "&" do resultado, mas no resultado obtido como "dolar" não existe "&". Só haveria "&" se não se tratasse do último argumento
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
            {
                //  Retorna o resultado se estiver no último argumento
                return resultado;
            }

            // Se a condição acima não for satisfeita, ou seja o IndexOf não encontra o que foi solicitado, simplesmente não executa o "if" e passa para a linha abaixo
            return resultado.Remove(indiceEComercial);
        }
    }
}
