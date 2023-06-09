﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_string_expressoes_regulares_classe_Object
{
    /// <summary>
    /// Define uma Conta Corrente do banco.
    /// </summary>
    public class ContaCorrente
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados
        /// </summary>
        ///<param name="agencia">Representa o valor da proprieddae <see cref="Agencia" /> e deve possuir um valor maior que zero.</param>
        ///<param name="numero">Representa o valor da proprieddae <see cref="Numero"/> e deve possuir um valor maior que zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// <exception cref="ArgumentException">Execção lançada quando o valor de <paramref name="valor"/>é maior que o valor da propriedade <see cref="Saldo">. </exception>
        /// <exception cref="SaldoInsufienteException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>. </exception>
        /// </summary>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que 0 e menor que <see cref="Saldo"/>. </param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        // Sobrescrição do método ToString
        // public - repetindo o modificador de acesso
        // override - indicando a sobrescrição ao compilador
        // string - respeitando o tipo de retorno
        // ToString - informando o nome
        // () - método sem argumento
        public override string ToString()
        {
            // Forma de escrever cortando strings, usando concatenações e repetições 
            // return "Número da conta: " + Numero + " | Agência: " + Agencia + " | Saldo: " + Saldo;

            // Forma mais simplificada de escrever utilizando recurso adicionado ao C# a partir da versão 6 que roda a partir do Visual Studio 2017
            return $"Número da conta: {Numero} | Agência: {Agencia} | Saldo: {Saldo}";
        }
    }

}
