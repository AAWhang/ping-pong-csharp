using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DoggyDogWorld.Animal;


namespace DoggyDogWorld
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("1: Ping-Pong, 2: Sphynx, 3: QueenCheck, 4: Clock Hands, 5: Palendrome, 6: Binary, 7: High Low Game, 8: Rock-Paper-Scissors, 9: Wild Life Park");

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
      } else if(progChoice == "9"){
        WildlifePark();
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


      


        

        
    static void WildlifePark()
    {
      string userChoice;
      List<Animals> Park = new List<Animals>();
      List<string> kanye = new List<string>() {
        "I hate when I'm on a flight and I wake up with a water bottle next to me like oh great now I gotta be responsible for this water bottle",
        "If I got any cooler I would freeze to death",
        "I wish I had a friend like me",
        "People only get jealous when they care.",
        "One of my favorite of many things about what the Trump hat represents to me is that people can’t tell me what to do because I’m black",
        "Fur pillows are hard to actually sleep on",
        "Tweeting is legal and also therapeutic",
        "I'm nice at ping pong",
        "Shut the fuck up I will fucking laser you with alien fucking eyes and explode your fucking head",
        "Sometimes I push the door close button on people running towards the elevator. I just need my own elevator sometimes. My sanctuary.",
        "I'm the best",
        "I love sleep; it's my favorite.",
        "Believe in your flyness…conquer your shyness.",
        "You can’t look at a glass half full or empty if it’s overflowing.",
        "I care. I care about everything. Sometimes not giving a f#%k is caring the most.",
        "Only free thinkers",
        "I leave my emojis bart Simpson color",
        "Just stop lying about shit. Just stop lying.",
        "I feel like me and Taylor might still have sex",
        "Truth is my goal. Controversy is my gym. I'll do a hundred reps of controversy for a 6 pack of truth",
        "I really love my Tesla. I'm in the future. Thank you Elon.",
        "Have you ever thought you were in love with someone but then realized you were just staring in a mirror for 20 minutes?",
        "Style is genderless",
        "Today is the best day ever and tomorrow's going to be even better",
        "I give up drinking every week",
        "Burn that excel spread sheet",
        "I feel calm but energized",
        "The thought police want to suppress freedom of thought",
        "I feel like I'm too busy writing history to read it.",
        "Man... whatever happened to my antique fish tank?",
        "My dad got me a drone for Christmas 🔥🔥🔥",
        "I make awesome decisions in bike stores!!!",
        "Perhaps I should have been more like water today",
        "The world is our office",
        "Everything you do in life stems from either fear or love",
        "My greatest award is what I’m about to do.",
        "For me, money is not my definition of success. Inspiring people is a definition of success",
        "The world is our family",
        "One day I’m gon' marry a porn star",
        "distraction is the enemy of vision",
        "I want the world to be better! All I want is positive! All I want is dopeness!",
        "Decentralize",
        "George Bush doesn't care about black people",
        "I think I do myself a disservice by comparing myself to Steve Jobs and Walt Disney and human beings that we’ve seen before. It should be more like Willy Wonka…and welcome to my chocolate factory.",
        "Sometimes you have to get rid of everything",
        "2024",
        "I'm a creative genius",
        "I still think I am the greatest.",
        "People always tell you ‘Be humble. Be humble.’ When was the last time someone told you to be amazing? Be great! Be awesome! Be awesome!",
        "People always say that you can’t please everybody. I think that’s a cop-out. Why not attempt it? ‘Cause think of all the people that you will please if you try.",
        "Let's be like water",
        "Pulling up in the may bike 😂",
        "I'd like to meet with Tim Cook. I got some ideas",
        "If I don’t scream, if I don’t say something then no one’s going to say anything.",
        "All you have to be is yourself",
        "We came into a broken world. And we're the cleanup crew.",
        "Keep squares out yo circle",
        "I’ll say things that are serious and put them in a joke form so people can enjoy them. We laugh to keep from crying.",
        "For me giving up is way harder than trying.",
        "We all self-conscious. I'm just the first to admit it.",
        "My greatest pain in life is that I will never be able to see myself perform live.",
        "Keep your nose out the sky, keep your heart to god, and keep your face to the rising sun."
      };
      bool endPark = false;
      while (endPark == false) {
        Console.WriteLine("To add an animal press 1. To check on the status of an animal press 2. To exit program press 3.");
        userChoice = Console.ReadLine();
        if (userChoice == "1") {
          Park.Add(addAnimals());
        } else if (userChoice == "2") {
          listAnimals(Park,kanye);
        } else if (userChoice == "3") {
          endPark = true;
        } else {
          Console.WriteLine("Invalid input.");
        }
      }
      Console.WriteLine("Press enter to return to the main menu.");
      Console.ReadLine();
      Main();
    }

    static Animals addAnimals() 
    {
      Console.WriteLine("Enter animal name/type");
      string animalName = Console.ReadLine();
      Console.WriteLine("Enter a description/status for that animal.");
      string animalStatus = Console.ReadLine();
      Animals animal = new Animals(animalName,animalStatus);
      return animal;
    }

    static void listAnimals(List<Animals> Park, List<string> kanye) 
    {
      int listLength = Park.Count;
      if (listLength == 0) 
      {
        Console.WriteLine("The list is currently empty!");
      } else 
      {
        for (var i = 0; i < listLength; i++) 
        {
          Console.WriteLine(i + ": " + Park[i].GetName());
          Console.WriteLine("   Description: " + Park[i].GetStatus());
        }
        chooseAnimals(Park, kanye);
      }
    }
    static void chooseAnimals(List<Animals> Park, List<string> kanye) 
    {
      Console.WriteLine("Would you like to talk to an animal? (y/n) ");
      Random kandom = new Random();
      int kand = kandom.Next(kanye.Count);
      string kanyeQuote = kanye[kand];
      string ynChoice = Console.ReadLine();
      if (ynChoice == "y") {
          Console.WriteLine("Please enter animal ID number");
          int animalNum = int.Parse(Console.ReadLine());
          if (animalNum >= 0 || animalNum <= Park.Count ) {
            Console.WriteLine(Park[animalNum].GetName() + " says: " + kanyeQuote);
          }

      } else {

      }
    }


  }
}  