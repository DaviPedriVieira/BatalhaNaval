using System;

namespace Gerador_de_Senhas.classes
{
  internal class Delete
  {
    public void DeletePassword(string[] passwordsCache, string[] descriptionsCache, ref int howMuchPasswords)
    {
      bool found = false;
      Console.Clear();
      Console.WriteLine("Digite a descrição da senha que deseja deletar: ");
      string? description = Console.ReadLine();

      if (howMuchPasswords != 0)
      {
        for (int i = 0; i < howMuchPasswords; i++)
        {
          if (description == descriptionsCache[i])
          {
            found = true;

            for (int cont = i; cont < howMuchPasswords - 1; cont++)
            {
              passwordsCache[cont] = passwordsCache[cont + 1];
              descriptionsCache[cont] = descriptionsCache[cont + 1];
            }

            passwordsCache[howMuchPasswords - 1] = "";
            descriptionsCache[howMuchPasswords - 1] = "";
            howMuchPasswords--;

            Console.WriteLine("Senha deletada com sucesso!");
            break;
          }
        }
        if (!found)
        {
          Console.WriteLine("Não há nenhuma senha com essa descrição!");
        }
      }
      else
      {
        Console.WriteLine("Não há nenhuma senha para ser deletada!");
      }
    }
  }
}
