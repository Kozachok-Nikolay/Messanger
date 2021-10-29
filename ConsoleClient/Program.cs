using System;
using Newtonsoft.Json;
namespace Messanger
{
  class Program
  {
    private static int MessageID;
    private static string UserName;
    private static MeesangerClientAPI API = new MeesangerClientAPI();

    private static void GetNewMessages()
    {
      Message msg = API.GetMessage(MessageID);
      while (msg != null)
      {
        Console.WriteLine(msg);
        MessageID++;
        msg = API.GetMessage(MessageID);
      }
    }
    static void Main(string[] args)
    {
      MessageID = 1;
      Console.WriteLine("Введите ваше имя: ");
      UserName = Console.ReadLine();
      string MessageText = "";
      while (MessageText != "exit")
      {
        GetNewMessages();
        MessageText = Console.ReadLine();
        if (MessageText.Length > 1)
        {
          Message Sendmsg = new Message(UserName, MessageText, DateTime.Now);
          API.SendMessage(Sendmsg);
        }
      }

      //Message msg = new Message("Kolya", "Privet", DateTime.UtcNow);
      //string output = JsonConvert.SerializeObject(msg);
      //Console.WriteLine(output);
      //Message normalOutput = JsonConvert.DeserializeObject<Message>(output);
      //Console.WriteLine(normalOutput);
      //{ "UserName":"Kolya","MessageText":"Privet","TimeStamp":"2021-10-15T13:17:03.9820482Z"}
      //Kolya < 15.10.2021 13:17:03 >: Privet
    }
  }
}