using System;

class Program
{
  static void Main()
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
}
