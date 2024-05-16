using Gerador_de_Senhas.classes;
using System;

namespace GeradorDeSenhas
{
  class App
  {
    static bool working = true;

    static void Main(string[] args)
    {
      Generate _generatePassword = new Generate();
      Consult _consultPassword = new Consult();
      Edit _editPassword = new Edit();
      Delete _deletePassword = new Delete();

      // Console.ForegroundColor = ConsoleColor.Black;

      while (working)
      {
        Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("                                                    Gerador de Senhas");
        Console.WriteLine("Selecione o que deseja fazer: ");
        Console.WriteLine("1. Gerar senha");
        Console.WriteLine("2. Editar senha");
        Console.WriteLine("3. Consultar senha");
        Console.WriteLine("4. Excluir senha");
        Console.WriteLine("5. Sair");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        int menuChoose = int.Parse(Console.ReadLine());

        switch (menuChoose)
        {
          case 1:
            {
              _generatePassword.GeneratePassword();
              break;
            }
          case 2:
            {
              _editPassword.EditPassword(Save.passwordsCache, Save.descriptionsCache, Save.howMuchPasswords); 
              break;
            }
          case 3:
            {
              _consultPassword.ConsultPassword(Save.passwordsCache, Save.descriptionsCache, Save.howMuchPasswords);
              break;
            }
          case 4:
            {
              _deletePassword.DeletePassword(Save.passwordsCache, Save.descriptionsCache, ref Save.howMuchPasswords);
              break;
            }
          case 5:
            {
              Console.WriteLine("Programa finalizado!");
              working = false;
              break;
            }
          default:
            {
              Console.Clear();
              Console.WriteLine("Digite uma opção válida!");
              break;
            }
        }
      }
    }
  }
}
