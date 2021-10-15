using System;
using Newtonsoft.Json;
namespace Messanger
{
  class Program
  {
    static void Main(string[] args)
    {
      Message msg = new Message("Kolya", "Privet", DateTime.UtcNow);
      string output = JsonConvert.SerializeObject(msg);
      Console.WriteLine(output);
      Message normalOutput = JsonConvert.DeserializeObject<Message>(output);
      Console.WriteLine(normalOutput);
      //{ "UserName":"Kolya","MessageText":"Privet","TimeStamp":"2021-10-15T13:17:03.9820482Z"}
      //Kolya < 15.10.2021 13:17:03 >: Privet
    }
  }
}