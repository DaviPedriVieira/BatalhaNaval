using System;

namespace Gerador_de_Senhas.classes
{
  internal class Edit
  {
    static Generate _generatePassword = new Generate();
    public void EditPassword(string[] passwordsCache, string[] descriptionsCache, int howMuchPasswords)
    {
      bool found = false;
      Console.Clear();
      Console.WriteLine("Digite a descrição da senha que deseja editar: ");
      string description = Console.ReadLine();

      if (howMuchPasswords != 0)
      {
        for (int i = 0; i < howMuchPasswords; i++)
        {
          if (description == descriptionsCache[i])
          {
            found = true;
            _generatePassword.SetDescriptionUsage(true, descriptionsCache[i]);
            _generatePassword.GeneratePassword(i);
            return;
          }
        }

        if (!found)
        {
          Console.WriteLine("Não há nenhuma senha com essa descrição!");
        }
      }
      else
      {
        Console.WriteLine("Não há senhas para editar!");
      }
    }
  }
}
