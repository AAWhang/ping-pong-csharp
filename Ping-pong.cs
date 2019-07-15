using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
  static void Main()
  {
    Console.WriteLine("1: Ping-Pong, 2: Sphynx, 3: QueenCheck, 4: Clock Hands, 5: Palendrome");

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
  }

}
