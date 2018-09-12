using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    class Document
    {
        public string nome { get; set; }
        public string criador { get; set; }
        public string nomeArquivo { get; set; }
        public string path { get; set; }
        public string newPath { get; set; }
        public DateTime criacao { get; set; }

        public Document()
        {

        }

        public Document(string nome, string criador, string nomeArquivo, string path, string newPath, DateTime criacao)
        {
            this.nome = nome;
            this.criador = criador;
            this.nomeArquivo = nomeArquivo;
            this.path = path;
            this.newPath = newPath;
            this.criacao = criacao;
        }
    }


}
