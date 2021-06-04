using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Series
{
    public class Serie : EntidadeBase
    {
        //Atributos 
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {// Esse metodo adiciona os parametros para as variaveis privadas
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
        }
        //
        public override string ToString()// esse método retorna todas as informações dos filmes
        {
            string retorno = "";
            retorno += $"Gênero {this.Genero} " + Environment.NewLine;
            retorno += $"Titulo {this.Titulo} " + Environment.NewLine;
            retorno += $"Descrição {this.Descricao} " + Environment.NewLine;
            retorno += $"Ano {this.Ano} " + Environment.NewLine;
            retorno += $"Excluído ? {this.Excluido}";
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
