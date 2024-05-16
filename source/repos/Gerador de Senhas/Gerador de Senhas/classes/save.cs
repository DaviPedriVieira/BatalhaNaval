using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_de_Senhas.classes
{
  internal class Save
  {
    public static string[] passwordsCache = new string[100];
    public static string[] descriptionsCache = new string[100];
    public static int howMuchPasswords = 0;

    public static void SavePassword(string password, string description, int index = -1)
    {
      if (index >= 0 && index < howMuchPasswords)
      {
        passwordsCache[index] = password;
        descriptionsCache[index] = description;
        Console.WriteLine($"Senha e descrição atualizadas com sucesso!");
      }
      else
      {
        passwordsCache[howMuchPasswords] = password;
        descriptionsCache[howMuchPasswords] = description;
        Console.WriteLine($"Senha e descrição salvas com sucesso!");
        howMuchPasswords++;
      }
    }
  }
}
