﻿using System.Collections.Generic;
using System.Linq;
using System;

namespace Alura.LeilaoOnline.Core
{
    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    public class Leilao
    {
        private IList<Lance> _lances;
        private Interessada _ultimoCliente;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao EstadoLeilao { get; private set; }
        public IModalidadeAvaliacao Avaliador { get; }

        public Leilao(string peca, IModalidadeAvaliacao avaliador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            EstadoLeilao = EstadoLeilao.LeilaoAntesDoPregao;
            Avaliador = avaliador;
        }

        // checar se as condições para um lance ser aceito
        private bool NovoEhLanceAceito(Interessada cliente)
        {
            return (EstadoLeilao == EstadoLeilao.LeilaoEmAndamento) && (cliente != _ultimoCliente);
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(NovoEhLanceAceito(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            // rodando os testes após essa inclusão - quase todos quebraram
            // código regrediu
            EstadoLeilao = EstadoLeilao.LeilaoEmAndamento;
        }

        public void TerminaPregao()
        {
            if (EstadoLeilao != EstadoLeilao.LeilaoEmAndamento)
            {
                throw new InvalidOperationException("Não é possivel terminar o pregão sem te-lo inicializado");
            }

            Ganhador = Avaliador.Avalia(this);

            EstadoLeilao = EstadoLeilao.LeilaoFinalizado;
        }
    }
}