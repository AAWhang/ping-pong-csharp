using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
  static void Main()
  {
    Console.WriteLine("1: Ping-Pong, 2: Sphynx, 3: QueenCheck, 4: Clock Hands, 5: Palendrome, 6: Binary, 7: High Low Game, 8: Rock-Paper-Scissors");

    string progChoice = Console.ReadLine();
    if(progChoice == "1"){
      PingPong();
    } else if(progChoice == "2"){
      Sphynx();
    } else if(progChoice == "3"){
      Queens();
    } else if(progChoice == "4"){
      clockHands();
    } else if(progChoice == "5"){
      palendrome();
    } else if(progChoice == "6"){
      Binary();
    } else if(progChoice == "7"){
      HighLow();
    } else if(progChoice == "8"){
      RockPaperScissors();
    }
  }

  static void PingPong()
  {
    Console.WriteLine("Enter number to ping-pong to:");
    string userInput = Console.ReadLine();
    int chosenNum = int.Parse(userInput);

    for(int i = 1; i <= chosenNum; i++){
      if(i % 15 == 0){
        Console.WriteLine("Ping-Pong");
      } else if ( i % 3 == 0 ) {
        Console.WriteLine("Ping");
      } else if ( i % 5 == 0 ) {
        Console.WriteLine("Pong");
      } else {
        Console.WriteLine(i.ToString());
      }
    }
    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();
  }


  static void Sphynx()
  {
    string result = SphynxQuestions();
    Console.WriteLine(result);
    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();

  }

  static string SphynxQuestions()
  {
    Random random = new Random();
    List<string> questions = new List<string>(new string[] {"What is the creature that walks on four legs in the morning, two legs at noon and three in the evening?", "What is a man?", "Say yes"});
    List<string> answers = new List<string>(new string[] {"man", "a miserable pile of secrets", "yes"});
    string win = "you survive!";
    string lose = "You died!";
    int rand = random.Next(3);
    Console.WriteLine("Answer the riddles correctly to survive!");
    int i = 0;
    while (i < 3) {
      Console.WriteLine(questions[rand]);
      string answer1 = Console.ReadLine().ToLower();
      if(answer1 == answers[rand]){
        Console.WriteLine("Correct...");
        rand = random.Next(3);
        i++;
      } else {
        Console.WriteLine("WRONG! *The Sphynx eats you whole*");
        return lose;
      }
    }
    return win;
  }


  static void Queens()
  {
    Console.WriteLine("Enter Queen Position!");
    Console.WriteLine("Queen X:");
    int queenX = int.Parse(Console.ReadLine());
    Console.WriteLine("Queen Y:");
    int queenY = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Pawn Position!");
    Console.WriteLine("Pawn X:");
    int pawnX = int.Parse(Console.ReadLine());
    Console.WriteLine("Pawn Y:");
    int pawnY = int.Parse(Console.ReadLine());
    Console.WriteLine(queenX);
    int xDiag = negativeCheck(queenX,pawnX);
    int yDiag = negativeCheck(queenY,pawnY);

    if (queenX == pawnX || queenY == pawnY || xDiag == yDiag) {
      Console.WriteLine("Queen takes Pawn!");
    } else {
      Console.WriteLine("Queen stares longingly at pawn");
    }

    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();

  }

  static int negativeCheck(int num1, int num2)
  {
    if (num1 > num2){
      return num1 - num2;
    } else {
      return num2 - num1;
    }
  }

  static float negativeFloat(float num1, float num2)
  {
    if (num1 > num2){
      return num1 - num2;
    } else {
      return num2 - num1;
    }
  }

  static void clockHands()
  {
    Console.WriteLine("Enter time!");
    Console.WriteLine("Hour:");
    float hour = float.Parse(Console.ReadLine());
    while (hour <= 0 || hour > 12) {
      Console.WriteLine("Enter Hour between 1-12 PLEASE:");
      hour = float.Parse(Console.ReadLine());
    }
    Console.WriteLine("Minute:");
    float minute = float.Parse(Console.ReadLine());
    while (minute < 0 || minute > 59) {
      Console.WriteLine("Enter minute between 0-59 PLEASE:");
      minute = float.Parse(Console.ReadLine());
    }
    if (hour == 12){
      hour = 0;
    }

    float minuteDegree = minute * 6;
    float hourDegree = hour * 30 + (minute / 2);
    float resultDegree = negativeFloat(minuteDegree,hourDegree);
    if (resultDegree > 180){
      resultDegree = 360 - resultDegree;
    }
    Console.WriteLine(resultDegree);

    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();
  }

  static void palendrome()
  {
    Regex rx = new Regex("[^a-zA-Z0-9 -]");

    Console.WriteLine("Please enter a word to check for palendrome status:");
    string str = Console.ReadLine();

    Console.WriteLine("Press enter to remove non alphanumeric characters.");
    Console.ReadLine();

    str = rx.Replace(str, "");
    Console.WriteLine(str);

    Console.WriteLine("Press enter to reverse string.");
    Console.ReadLine();

    char[] wordOriginal = str.ToCharArray();
    char[] wordReversed = new char[wordOriginal.Length];
    for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--) {
        wordReversed[i] = wordOriginal[j];
    }
    string result = new string(wordReversed);
    Console.WriteLine(result);

    if(str == result){
      Console.WriteLine("This string is a palendrome. Very cool");
    } else {
      Console.WriteLine("This is not a palendrome. Bummer :(");
    }

    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();
  }

  static void Binary()
  {
    Console.WriteLine("Please enter a number to make binary!");
    int userNum = int.Parse(Console.ReadLine());
    int maxLength = 0;
    int maxBin = 1;
    int realBin = 1;

    while (maxBin <= userNum) {
      maxLength++;
      realBin = maxBin;
      maxBin *= 2;
    }



    for (int numLength = maxLength; numLength > 0; numLength--) {
      if (realBin <= userNum) {
        Console.Write("1");
        userNum -= realBin;
      } else {
        Console.Write("0");
      }
      realBin /= 2;
    }
    Console.WriteLine("");
    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();
  }

  static void HighLow()
  {
    Random hiloRandom = new Random();
    Console.WriteLine("Think of a number between 0-100.");
    bool hiLo = false;
    int min = 0;
    int max = 101;
    int hiloRand = hiloRandom.Next(min, max);
    string answer;
    while (hiLo == false) {
      Console.WriteLine("Is your number higher or lower than " + hiloRand + "? (high/low/correct)");
      answer = Console.ReadLine();
      while (answer != "high" && answer != "low" && answer != "correct") {
          Console.WriteLine("Please enter high low or correct.");
          answer = Console.ReadLine();
      }
      if (min == max) {
        hiLo = true;
        Console.WriteLine("Your number is " + min);
      } else if (answer == "high") {
        min = hiloRand + 1;
      } else if (answer == "low") {
        max = hiloRand;
      } else if (answer == "correct"){
        hiLo = true;
      }
      hiloRand = hiloRandom.Next(min, max);
    }
    Console.WriteLine("I have learned what it is like to be a little more human.");
    Console.WriteLine("Press enter to return to the main menu.");
    Console.ReadLine();
    Main();

  }

  static void RockPaperScissors()
  {
    ConsoleKeyInfo moveA;
    ConsoleKeyInfo moveB;
    string move1 = "error: invalid move";
    string move2 = "error: invalid move";

    while(move1 == "error: invalid move" || move2 == "error: invalid move")
    {
      Console.WriteLine("Player 1 make your move: (a:rock b:paper c:scissors)");
      moveA = Console.ReadKey(true);
      Console.WriteLine("Player 2 make your move: (arrow keys left:rock down:paper right:scissors)");
      moveB = Console.ReadKey(true);
      move1 = moveA.Key.ToString();
      move2 = moveB.Key.ToString();
      move1 = findMove(move1);
      move2 = findMove2(move2);
      Console.WriteLine("____________________________________");
      Console.WriteLine("Player 1 move: " + move1);
      Console.WriteLine("Player 2 move: " + move2);
      if(move1 == "error: invalid move" || move2 == "error: invalid move"){
        Console.WriteLine("invalid move made, try again");
      }
    }
    Console.WriteLine(winCheck(move1, move2));

    Console.WriteLine("Play again? ( y / n )?");
    string rpsChoice = Console.ReadLine();
    if(rpsChoice == "y"){
      RockPaperScissors();
    } else {
      Main();
    }
  }

  static string findMove(string rawMove)
  {
    if(rawMove == "A") {
      rawMove = "rock";
    } else if (rawMove == "S"){
      rawMove = "paper";
    } else if (rawMove == "D"){
      rawMove = "scissors";
    } else {
      rawMove = "error: invalid move";
    }
    return rawMove;
  }

  static string findMove2(string rawMove)
  {
    if(rawMove == "LeftArrow") {
      rawMove = "rock";
    } else if (rawMove == "DownArrow"){
      rawMove = "paper";
    } else if (rawMove == "RightArrow"){
      rawMove = "scissors";
    } else {
      rawMove = "error: invalid move";
    }
    return rawMove;
  }

  static string winCheck(string aMove, string bMove)
  {
    string winner;
    if( (aMove == "rock" && bMove == "scissors") || (aMove == "paper" && bMove == "rock") || (aMove == "scissors" && bMove == "paper") ){
      winner = "Player 1 wins!";
    } else if (aMove == bMove) {
      winner = "Tie game!";
    } else {
      winner = "Player 2 wins!";
    }
    return winner;
  }

}
