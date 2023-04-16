using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_string_expressoes_regulares_classe_Object
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("_Teste de comparação de objetos do tipo Cliente: ana_1 == ana_2 _");

            Cliente ana_1 = new Cliente();
            ana_1.Nome = "Ana";
            ana_1.CPF = "123.456.789-10";
            ana_1.Profissao = "Desenvolvedora";

            Cliente ana_2 = new Cliente();
            ana_2.Nome = "Ana";
            ana_2.CPF = "123.456.789-10";
            ana_2.Profissao = "Desenvolvedora";

            // Usando "==" são comparadas as referências, não o conteúdo de cada propriedade
            // Apesar de "ana_1 == ana_2" possuírem as mesmas informações, são objetos diferentes que ocupam locais distintos na memória do computador
            if (ana_1 == ana_2)
            {
                Console.WriteLine("O objetos são iguais.");
            }
            else
            {
                Console.WriteLine("O objetos são diferentes.");
            }

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de comparação de objetos do tipo Cliente com Equals: beatriz_1 Equals conta2 _");

            Cliente beatriz_1 = new Cliente();
            beatriz_1.Nome = "Beatriz";
            beatriz_1.CPF = "109.876.543-21";
            beatriz_1.Profissao = "Desenvolvedora";

            Cliente beatriz_2 = new Cliente();
            beatriz_2.Nome = "Beatriz";
            beatriz_2.CPF = "109.876.543-21";
            beatriz_2.Profissao = "Desenvolvedora";

            ContaCorrente conta_2 = new ContaCorrente(123, 123456);

            // Realizando a comparação dos valores dos objetos
            // O método Equals está na classe Object
            // Trata-se de um método virtual, que permite sobrescrita e a alteração de comportamento (feita na classe Cliente)
            if (beatriz_1.Equals(conta_2))
            {
                Console.WriteLine("O objetos são iguais.");
            }
            else
            {
                Console.WriteLine("O objetos são diferentes.");
            }

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de comparação de objetos do tipo Cliente com Equals: fulano_1 Equals fulano_2 _");

            Cliente fulano_1 = new Cliente();
            fulano_1.Nome = "Fulano";
            fulano_1.CPF = "109.876.543-22";
            fulano_1.Profissao = "Desenvolvedor";

            Cliente fulano_2 = new Cliente();
            fulano_2.Nome = "Fulano";
            fulano_2.CPF = "109.876.543-22";
            fulano_2.Profissao = "Desenvolvedor";

            // Realizando a comparação se o cliente da instância é igual ao recebido por argumento
            if (fulano_1.Equals(fulano_2))
            {
                Console.WriteLine("O objetos são iguais.");
            }
            else
            {
                Console.WriteLine("O objetos são diferentes.");
            }

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Análise do Console.WriteLine_");

            // WriteLine() é um método por ter um ponto antes e não um new, logo não se trata de um construtor
            // Ele pode ser usado fora de Console e na classe Program, indicando que se trata de um método público
            // É um método público estático, pois em nenhum momento é necessário criar um objeto do tipo Console para acessá-lo

            // Console é uma classe, pois Console é a primeira palavra da linha de código, vindo logo antes da chamada do método, logo o método habita, é criado e definido, dentro de classes
            // Console é uma classe pública, pois é possível ter acesso a ela fora do projeto do .NET

            // "Olá, mundo!" é uma string sendo usada como argumento

            Console.WriteLine("Olá, mundo!"); // string
                // Seria: public static void WriteLine(string argumento)

            Console.WriteLine(123); // int
                // Seria: public static void WriteLine(int argumento)
                // Número inteiro não cabe em uma variável do tipo string, por isso é necessária a implementação com uma sobrecarga do WriteLine com o tipo int como argumento

            Console.WriteLine(10.5); // double
                // Seria: public static void WriteLine(double argumento)
                // Número quebrado, o double não cabe em uma variável do tipo string, por isso é necessária a implementação com uma sobrecarga do WriteLine com o tipo double como argumento

            Console.WriteLine(true); // boolean
                                     // Seria: public static void WriteLine(bool argumento)
                                     // Um boolean não cabe em uma variável do tipo string, por isso é necessária a implementação com uma sobrecarga do WriteLine com o tipo bool como argumento
            Console.ReadLine();

            // A classe ContaCorrente foi criada após a existência do .NET, logo é desconhecida pela Microsoft
            // Não seria possível criar uma conta com número de agência e conta, escrevendo Console.WriteLine(conta), mas ao escrever Visual Studio não acusa erro
            // A forma do WriteLine() funcionar, sem a existência de uma sobrecarga para ContaCorrente, é com a existência de uma sobrecarga para um tipo base da mesma
            // A ContaCorrente não deriva de nenhum tipo, mas mesmo não colocando nenhuma herança, o compilador assumirá que existe uma herança para o tipo object, a partir do qual se derivam todas as classes no C# no .NET, pois quando não incluímos ": object" na classe, ela automaticamente deriva deste mesmo tipo por ser a mãe de todos os outros tipos dentro de um código
            object conta = new ContaCorrente(123, 123457);

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de ToString e sobrescrição_");

            string contaToString = conta.ToString();

            // O ToString retorna uma cadeia de caracteres que representa o objeto atual
            // Será impresso "Resultado: ByteBank.Modelos.ContaCorrente", ou seja, ao usar object o Console.WriteLine() chama o método ToString() e escreve o resultado
            // ToString() é um método é virtual, pode ser subscrito (feito na classe ContaCorrente)
            Console.WriteLine("Resultado: " + contaToString);

            // Verificando se o WriteLine() usa o ToString() com a validação se o mesmo retorna a mensagem do método sobrescrito 
            Console.WriteLine(conta);

            Console.ReadLine();            
        }

        static void TestaString() 
        {
            // _Análise de URLs_

            // Esse é um padrão de preenchimento de argumentos de páginas dinâmicas utilizado em muitos portais e sites:
            // Link da página + ? +  argumentos. Exemplo: http://www.banco_virtual.com/cambio + ? + moedaOrigem=real&moedaDestino=dolar&valor=1500
            // Após o ponto de interrogação, estão os parâmetros que enviados ao servidor no momento de renderização ou criação da página

            // URL é uma string que pode ser guardada em uma variável, exemplo: 
            // string url = "http://www.banco_virtual.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            // O índice de cada caractere de uma string no C# ou .NET começa com 0.

            // ----------------------------------------------------------------------------------------------

            // Expressão regular

            // Melhoramento de expressão regular - Formas de representar o intervalo de números para cada caracter do padrão aceito para o telefone:
            // Há uma sequência de quatro dígitos - o caractere vai de 0 a 9, seguidos de um hífen e mais quatro dígitos.

            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // Esta é a forma mais extensa de representar o padrão: [0123456789]            

            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // Esta é uma forma mais resumida de representar o padrão: [0-9]
            // Utilizando o [0-9], o motor de expressões regulares no .NET entende que o primeiro caractere da expressão regular (o código do primeiro dígito do telefone) está entre o código de 0 e 9, pois um caractere (char) é representado como um código na memória do computador e segue a tabela ASCII, dessa forma não é necessário verificar caractere por caractere, basta colocar o "intervalo".

            // string padrao = "[0-9]{4}[-][0-9]{4}";
            // Esta é a forma mais compacta de representar o padrão: [0-9]{4}
            // Utilizando o [0-9]{4} é possível quantificar as vezes em que um padrão de um caractere se repete (no caso são quatro), usando as chaves {}. 
            // Se usar {4} aceitará apenas números de telefone fixo (1234-1234), não imprimindo o número correto se for celular.

            // string padrao = "[0-9]{5}[-][0-9]{4}";
            // Se tratando de um número de celular, pode começar com 9, seguido de oito dígitos, dessa forma contendo 5 dígitos no começo ao invés de 4.                    
            // Se usar {5} aceitará apenas números de telefone celular (91234-1234), não imprimindo o número correto se for fixo.

            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // Usando {4,5} informo ao motor de Regex que o primeiro grupo de dígitos terá a quantidade de caracteres de 4 a 5.

            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // Usando [-]{0,1} aceitaremos o telefone como válido mesmo que não haja o hífen, exemplo 912341234

            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            // Removendo os colchetes no [-] paro de criar um grupo apenas para incluir o hífen, pois é desnecessário e pode dificultar a leitura da expressão regular

            // string padrao = "[0-9]{4,5}-?[0-9]{4}";
            // O quantificador representado pelo ponto de interrogação "?" nesse caso é um caractere curinga que pode ser utilizado para simplificar o {0,1}

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de recuperação de número de telefone fixo com IsMatch e Quantificadores_");

            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoTesteUm = "Meu nome é Ana, me ligue em 1234-5678.";
            Console.WriteLine("Texto com o telefone: " + textoTesteUm);

            // A classe Regex (Regular Expressions) auxilia na recuperação das expressões regulares.
            // Definida uma expressão regular — regular é a linguagem criada que define o nosso número de telefone e precisa estar dentro das regras.
            // Regex possui o método estático IsMatch() que verifica se uma string contém o padrão buscado, e retorna verdadeiro ou falso.
            // textoTesteUm é a string que deve ser testada, o texto que queremos visitar em busca do padrão.
            Console.WriteLine("Vericação com número que atende aos requisitos do padrão. O telefone é: " + Regex.IsMatch(textoTesteUm, padrao));

            // Teste com telefone não aceito, número de telefone sem o hífen
            // O método IsMatch() não retorna o número de telefone, ele apenas valida se é verdadeiro ou falso, ou seja, verifica se é um telefone
            string textoTesteUmDois = "Meu nome é Ana. Entre em contato comigo através do número 12345678!";

            Console.WriteLine("Vericação com número que NÃO atende aos requisitos do padrão. O telefone é: " + Regex.IsMatch(textoTesteUmDois, padrao));
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de recuperação de número de telefone fixo com Match e Value_");

            // O método Match() é capaz de retornar um objeto que define as propriedades do texto encontrado, ou seja, ele respeita o padrão e pode ser encontrado no texto original, o textoTesteUm

            // Guardando em uma variável
            Match retornado = Regex.Match(textoTesteUm, padrao);

            // Utilizando o método Match() com o Value é retornado o número de telefone
            Console.WriteLine("Texto com o telefone: " + textoTesteUm);
            Console.WriteLine("Número de telefone extraído com o método: " + retornado.Value);
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de recuperação de número de telefone celular com IsMatch e Quantificadores_");

            string textoTesteDois = "Meu nome é Ana. Me ligue no número 912345678.";

            Match retornadoDois = Regex.Match(textoTesteDois, padrao);

            Console.WriteLine("Texto com o telefone: " + textoTesteDois);
            Console.WriteLine("Número de telefone extraído com o método: " + retornadoDois.Value);
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de URL_");

            string urlTeste = "http://google.com/http://www.banco_virtual.com/cambio";
            Console.WriteLine("A URL é: " + urlTeste);

            // A preocupação com o índice e a utilização do "IndexOf" pode nos induzir ao erro na lógica da aplicação, como nesse exemplo "int indiceBancoVirtual = urlTeste.IndexOf("http://www.banco_virtual.com")"

            // Verificação com expressão booleana, poir o IndexOf() retorna -1 quando buscamos um texto não encontrado, logo, se o retornado for 0 a Substring foi encontrada, ou seja, a página é do banco virtual.            
            // Utilizando ">= 0", será confirmada que a URL pertence ao banco virtual mesmo são sendo e tendo algo no começo que diferencia.
            // Para a validação correta é necessário utilizar o "=="
            // Console.WriteLine(indiceBancoVirtual == 0);

            // É possível utilizar o método StartsWith() para acessar diretamente a urlTeste, traduzido do inglês significa "começa com", 
            // Este método que não retorna um índice, e sim um booleano
            Console.WriteLine("O início da URL pertence ao Banco Virtual: " + urlTeste.StartsWith("http://www.banco_virtual.com"));

            // Existe um método denominado EndsWith(), ou seja, "termina com", para verificar se uma string termina com outra
            Console.WriteLine("O final da URL pertence ao Banco Virtual: " + urlTeste.EndsWith("cambio"));

            Console.WriteLine("A URL contém banco_virtual: " + urlTeste.Contains("banco_virtual"));

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste do GetValor_");

            string urlParametros = "http://www.banco_virtual.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            // Criado o extrator "extratorDeValores" para evitar conflitos dos nomes, pois já existe a classe "extrator"
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);

            string valorDestino = extratorDeValores.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valorDestino);

            string valorOrigem = extratorDeValores.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valorOrigem);

            Console.WriteLine("Valor: " + extratorDeValores.GetValor("VALOR"));

            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------                      

            Console.WriteLine("_Teste - Buscar o retornado do IndexOf() de uma string que não existe_");

            string testeNaoExiste = "textoteste";
            // Escrever na tela o retornado do IndexOf de um caracter que não existe na string (o texto teste)
            Console.WriteLine(testeNaoExiste.IndexOf('1'));
            Console.ReadLine();
            // Ao executar o código, o retornado na tela será o "-1", pois quando o IndexOf não encontra o que foi solicitado na busca, ele não lança uma exceção, e sim retorna o "-1"
            // A Microsoft optou por não lançar exceções nesses casos, pois buscar o índice de algo que a string original não contém é bastante comum, assim em vez de precisar que escrever Try, Catch e Finally, pode-se verificar se é igual a "-1"

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de case-sensitive da PALAVRA_");

            string testeLetras = "PALAVRA";

            Console.WriteLine("Teste de IndexOf com índice em maisculo: " + testeLetras.IndexOf("RA"));
            Console.WriteLine("Teste de IndexOf com índice em minúsculo: " + testeLetras.IndexOf("ra"));
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de case-sensitive da PALAVRA com Replace_");

            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            termoBusca = termoBusca.Replace('r', 'R');
            Console.WriteLine(termoBusca);

            termoBusca = termoBusca.Replace('a', 'A');
            Console.WriteLine(termoBusca);

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste de case-sensitive da PALAVRA com ToUpper e ToLower_");

            string mensagemParaMinusculo = "PALAVRA";
            string termoParaMaisculo = "ra";

            // O ToUpper deixa o texto em caixa alta - Maiúsculo
            Console.WriteLine(termoParaMaisculo.ToUpper());

            // O ToLower deixa o texto em caixa baixa - Minúsculo
            Console.WriteLine(mensagemParaMinusculo.ToLower());
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------                      

            Console.WriteLine("_Teste do método Remove - Remoção a partir de um índice_");

            // Pegar apenas a primeira parte e remover após o indice "&" 
            string testeRemocao = "primeiraParte&parteRemover";
            int indiceEComercial = testeRemocao.IndexOf('&');
            // No método Remove() chamo o indiceEComercial removendo a partir do "&" (pois é inclusivo) até o final da string
            // O indice de início é o "indiceEComercial"
            Console.WriteLine("Usando: primeiraParte&primeiraParte&parteRemover");
            Console.WriteLine("Resultado: " + testeRemocao.Remove(indiceEComercial));
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste do método Remove - Remoção com parâmetro Count");

            // Esta sobrecarga no método Remove() permite remover apenas uma porção, no teste abaixo removo quatro caracteres
            string testeRemocaoContagem = "primeiraParte&12345678910";
            Console.WriteLine("Usando: primeiraParte&12345678910");
            Console.WriteLine("Resultado: " + testeRemocaoContagem.Remove(indiceEComercial, 4));
            Console.ReadLine();

            string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
            // Como o nome de um argumento sempre vem antes do sinal de igual, e a sintaxe de argumentos de páginas da internet é <nome>=<valor>, é possível aplicar uma forma de evitar erros futuros: em vez de buscarmos por "moedaDestino", buscarmos por "moedaDestino=". Desta forma a primeira ocorrência será sempre o nome de um argumento, e não o valor, por se encontrar antes do sinal de igual
            string nomeArgumento = "moedaDestino=";

            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);

            Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

            Console.WriteLine(palavra);

            // O método Substring retorna uma string, e não a altera.
            Console.WriteLine(palavra.Substring(indice));

            // Era "nomeArgumento.Length + 1" para pegar o texto sem que o sinal de igual (=) fosse contabilizado
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));
            Console.ReadLine();

            // ----------------------------------------------------------------------------------------------

            Console.WriteLine("_Teste do IsNullOrEmpty_");

            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "ABC";

            // O objeto String é imutável.
            // Uma característica de todos os métodos da classe String é a imutabilidade.
            // Uma característica de classes imutáveis é que o valor do objeto referenciado pela variável nunca será alterado, por isso na hora de realizar operações é necessário criar um novo objeto.

            Console.WriteLine(String.IsNullOrEmpty(textoVazio));
            Console.WriteLine(String.IsNullOrEmpty(textoNulo));
            Console.WriteLine(String.IsNullOrEmpty(textoQualquer));
            Console.ReadLine();

            // pagina?argumentos
            // 012345678
            string url = "paginas?argumentos";

            // string temporaria = url + "sufixo";
            // url = temporaria;

            int indiceInterrogacao = url.IndexOf('?');
            Console.WriteLine(indiceInterrogacao);

            Console.WriteLine(url);

            string argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);
        }
    }
}
