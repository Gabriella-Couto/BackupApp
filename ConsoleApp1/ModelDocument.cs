using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backup
{
    class ModelDocument
    {
        List<Document> document;

        public ModelDocument()
        {
            document = new List<Document>();
        }

        public void adiciona(string nome, string criador, string nomeArquivo, string path, string newPath, DateTime criacao)
        {
            Document doc = new Document(nome, criador, nomeArquivo, path, newPath, criacao);
            document.Add(doc);
        }
    }
}
