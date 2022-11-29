using System;

namespace Stampin.Api.IntegrationTests
{
  class Program
  {
    static void Main(string[] args)
    {
       IntegrationTest tests = new IntegrationTest();
      tests.RunTests();
      Console.ReadLine();
    }
  }
}
