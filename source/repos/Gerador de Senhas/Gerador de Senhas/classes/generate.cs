using System;
using System.Reflection;

namespace Gerador_de_Senhas.classes
{
  class Generate
  {
    static int passwordRange, passwordOption = 0, cont = 1;
    // static char passwordChoose;
    static int[] choosedPasswordOptions = new int[4];
    private bool useExistingDescription = false;
    private string existingDescription = "", passwordChars, passwordDescription, passwordChoose;
    static Random rnd = new Random();

    public void SetDescriptionUsage(bool useDescription, string description)
    {
      useExistingDescription = useDescription;
      existingDescription = description;
    }

    public void GeneratePassword( int index = -1)
    {
      Console.Clear();
      Console.WriteLine("Você deseja quantos caracteres na sua senha(1-100): ");
      passwordRange = int.Parse(Console.ReadLine());

      if (passwordRange <= 0 || passwordRange >= 100)
      {
        Console.WriteLine("A senha só pode conter de 1 à 100 caracteres!");
        return;
      }

      passwordChars = "";

      while (true)
      {
        Console.WriteLine("\nQuanto a complexidade de sua senha, selecione uma opção para adicionar a sua senha: ");
        Console.WriteLine("1. Letras minúsculas");
        Console.WriteLine("2. Letras maiúsculas");
        Console.WriteLine("3. Números");
        Console.WriteLine("4. Caracteres especiais");
        passwordOption = int.Parse(Console.ReadLine());

        choosedPasswordOptions[cont] = passwordOption;
        cont++;

        for (int i = 1; i < cont; i++)
        {
          if(passwordOption == choosedPasswordOptions[i-1])
          {
            Console.WriteLine("Essa opção já foi adicionada!");
          }
        }

        switch (passwordOption)
        {
          case 1:
            {
              passwordChars += "abcdefghijklmnopqrstuvwxyz";
              break;
            }
          case 2:
            {
              passwordChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
              break;
            }
          case 3:
            {
              passwordChars += "0123456789";
              break;
            }
          case 4:
            {
              passwordChars += "!@#$%^&*()-_=+[]{}|;:',.<>/?";
              break;
            }
          default:
            {
              Console.WriteLine("Digite uma opção válida!");
              return;
            }
        }

        Console.WriteLine("\nDeseja adicionar outra opção? Se sim digite 'S'.");
        passwordChoose = Console.ReadLine().ToUpper();

        if (passwordChoose != "S" && passwordChoose != "SIM")
        {
          
          if (useExistingDescription)
          {
            passwordDescription = existingDescription;
          }

          else
          {
            Console.WriteLine("\nAdicione uma descrição para a senha: ");
            passwordDescription = Console.ReadLine();

            checkDescription(passwordDescription);
          }

          char[] password = new char[passwordRange];
          for (int i = 0; i < passwordRange; i++)
          {
            password[i] = passwordChars[rnd.Next(passwordChars.Length)];
          }

          string generatedPassword = new string(password);
          Console.WriteLine($"\nSenha gerada: '{generatedPassword}', descrição da senha: {passwordDescription}");
          Save.SavePassword(generatedPassword, passwordDescription, index);
          return;
        }
      }
    }

    static void checkDescription(string passwordDescription)
    {
      for (int i = 0; i < Save.descriptionsCache.Length; i++)
      {
        if (passwordDescription == Save.descriptionsCache[i])
        {
          Console.WriteLine("Ja existe uma senha com essa descrição");
          Console.WriteLine("\nAdicione uma descrição para a senha: ");
          passwordDescription = Console.ReadLine();
          checkDescription(passwordDescription);
        }
      }
    }

  }
}
