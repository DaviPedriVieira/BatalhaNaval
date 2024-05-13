using System;

class Program
{
  static char[,] userBoard = new char[5, 5];
  static char[,] computerBoard = new char[5, 5];
  static char[,] triesBoard = new char[5, 5];
  static int userShipI, userBoardJ, computerShipI, computerShipJ, cont = 0;
  static bool game = true;
  static int attackI, attackJ;

  static void Main(string[] args)
  {
    Console.WriteLine("Bem-vindo ao jogo de Batalha Naval!");

    Console.WriteLine("Já sabe jogar?? Se sim digite 's', caso contrário digite 'n'.");
    char tutorial = char.Parse(Console.ReadLine());

    if (tutorial != 's')
    {
      Console.WriteLine("\n                                                 Explicação");
      Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
      Console.WriteLine("A cada rodada você deve informar uma posição na qual você quer atacar, se você acertar o navio do computador você ganha.");
      Console.WriteLine("Porém o computador também ataca a cada rodada, e, se ele acertar seu navio, você perde.");
      Console.WriteLine("O 'N' no seu tabuleiro indica onde seu navio está posicionado e a cada rodada será marcado um 'O' no seu tabuleiro, istoindica aonde o computador já atacou.");
      Console.WriteLine("Você também terá um tabuleiro de tentativas, onde será marcado um 'X' nos lugares que você já atacou para que você não  se confunda e ataque duas vezes o mesmo lugar.");
      Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    }
    Console.WriteLine("\nVamos começar!\n");

    InitializeBoards();
    positionateUserShip();
    positionateComputerShip();

    while (game == true)
    {
      showUserBoard();
      showTriesBoard();
      userAttack();

      if (game == true)
      {
        computerAttack();
      }
    }

    static void InitializeBoards()
    {
      for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          computerBoard[i, j] = '-';
          userBoard[i, j] = '-';
          triesBoard[i, j] = '-';
        }
      }
    }

    static void positionateUserShip()
    {
      Console.WriteLine("Posicione seu navio de 0 à 4 na linha e na coluna. ");
      Console.Write("Digite a linha para posicionar: ");
      userShipI = int.Parse(Console.ReadLine());
      Console.Write("Digite a coluna para posicionar: ");
      userBoardJ = int.Parse(Console.ReadLine());
      userBoard[userShipI, userBoardJ] = 'N';
    }

    static void positionateComputerShip()
    {
      Random rnd = new Random();
      computerShipI = rnd.Next(0, 5);
      computerShipJ = rnd.Next(0, 5);
      computerBoard[computerShipI, computerShipJ] = 'N';
    }

    static void showUserBoard()
    {
      Console.WriteLine("\nSeu tabuleiro: ");
      for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Console.Write(userBoard[i, j] + " ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    static void showTriesBoard()
    {
      Console.WriteLine("\nTabuleiro de tentativas: ");
      for (int i = 0; i < 5; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Console.Write(triesBoard[i, j] + " ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }

  static void userAttack()
  {

    Console.WriteLine("\nSua vez de atacar!");
    Console.Write("Digite a linha para atacar: ");
    attackI = int.Parse(Console.ReadLine());

    Console.Write("Digite a coluna para atacar: ");
    attackJ = int.Parse(Console.ReadLine());

    cont++;

    if (attackI == computerShipI && attackJ == computerShipJ)
    {
      computerBoard[attackI, attackJ] = 'X';
      Console.WriteLine("Parabéns! Você acertou o navio do computador e venceu.\n\n");
      game = false;
    }
    else
    {
      Console.WriteLine("Você errou!");
      triesBoard[attackI, attackJ] = 'X';
      computerBoard[attackI, attackJ] = 'O';
    }
  }

  static void computerAttack()
  {
    Console.WriteLine("\nVez do computador de atacar!");
    Random rnd = new Random();
    attackI = rnd.Next(0, 5);
    attackJ = rnd.Next(0, 5);

    if (attackI == userShipI && attackJ == userBoardJ)
    {
      computerBoard[attackI, attackJ] = 'X';
      Console.WriteLine("Você perdeu. O computador acertou seu navio.");
      game = false;
    }
    else
    {
      Console.WriteLine("O computador errou!");
      userBoard[attackI, attackJ] = 'O';
    }
  }
}

