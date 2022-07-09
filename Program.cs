using System;
using System.IO;//usado para abrir e fechar o arquivo.

namespace editordetexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer? ");
            Console.WriteLine("1 - Abrir arquivo. ");
            Console.WriteLine("2 - Criar novo arquivo. ");
            Console.WriteLine("0 - Sair. ");
            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break; 
                default: Menu(); break;
            }
        }

        static void Abrir()
        {

        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------------");
            string text = "";//Vamos armazenar tudo que foi digitado pelo usuário aqui.

            do //Aqui criamos o do para que o usuário digite tudo primeiro e depois seja digitado ESC para sair.
            {
                text += Console.ReadLine();//Tudo que for digitado será concatenado à cadeia de caracteres, o texto. se fosse = seria substituido a cada texto digitado.
                text += Environment.NewLine;//Comando que faz uma quebra de linha quando a leitura dos valores digitados é terminada.
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);//Laço de repetição criado para que, enquanto o usuário não digitar ESC, a tela
            //registra tudo que for digitado por ele, e o laço não sai.

            Salvar(text);  
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();//Aqui criamos uma variável que armazenará o arquivo segundo as preferências e endereço do cliente.

            //As 4 linhas abaixo são a forma como escrevemos um texto em .Net.
            using(var file = new StreamWriter(path))//Esse recurso using() abre, usa e fecha um arquivo automaticamente, usado até em banco de dados.
            //o StreamWriter() representa um fluxo de bites, ou fluxo de escrita. Ele pede sempre o caminho do arquivo, que é o path.
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquvo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }


    }
}

