using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backup
{
    class Program
    {
        static void CriarArquivoComWriter(string path, string nome, string criador, string nomeArquivo, string newPath, DateTime criacao)
        {

            using (var fluxoDeArquivo = new FileStream(path, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                escritor.Write("Nome do arquivo: " + nome + "\n" + "Quem criou: " + criador +
                    "\n" + "Nome do arquivo relacionado: " +nomeArquivo + "\n" + "Caminho: " + path + 
                    "\n" + "Caminho de backup: " + newPath + "\n" + "Data de criação: " + criacao);
            }
        }

        static void LendoArquivo(string caminho, string caminhoBack)
        {
            FileStream fs = new FileStream(caminho, FileMode.Open);
            FileStream fsb = new FileStream(caminhoBack, FileMode.Create);

            using (StreamReader reader = new StreamReader(fs))
            using (StreamWriter writer = new StreamWriter(fsb))
            {
                {
                    writer.Write(reader.ReadToEnd());
                }
                Console.Read();
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;
            List<Document> documents = new List<Document>();

            while (!exit)
            {
                Document document = new Document();

                Console.WriteLine("Nome do documento:");
                document.nome = Console.ReadLine();

                Console.WriteLine("Seu nome:");
                document.criador = Console.ReadLine();

                Console.WriteLine("Nome do aquivo relacionado");
                document.nomeArquivo = Console.ReadLine();

                Console.WriteLine("Caminho:");
                document.path = Console.ReadLine();

                Console.WriteLine("Caminho do backup:");
                document.newPath = Console.ReadLine();

                document.criacao = DateTime.UtcNow;

                documents.Add(document);

                Console.WriteLine("Deseja sair? aperte END");

                
                var ret = Console.ReadKey();
                if (ret.Key == ConsoleKey.End)
                {
                    exit = true;
                }
            }

            foreach(Document d in documents)
            {
                Console.WriteLine(d.nome);
                Console.WriteLine(d.nomeArquivo);
                Console.WriteLine(d.path);
                Console.WriteLine(d.newPath);
                Console.WriteLine(d.criador);
                Console.WriteLine(d.criacao);

                // invoca aqui
                CriarArquivoComWriter(d.path, d.nome, d.criador, d.nomeArquivo, d.newPath, d.criacao);
                LendoArquivo(d.path, d.newPath);

                Console.ReadLine();
            }

        }
        static void EscreverBuffer(byte[] buffer)
        {
            var uft8 = new UTF8Encoding();

            var texto = uft8.GetString(buffer);
            Console.Write(texto);
        }

    }
}
