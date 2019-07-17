using System;

namespace DoggyDogWorld.Animal
{
  class Animals
  {
    private string _name;
    private string _status;


    public Animals(string name, string status)
    {
      _name = name;
      _status = status;
    }

    public string GetStatus()
    {
      return _status;
    }

    public string GetName()
    {
      return _name;
    }

  }
}