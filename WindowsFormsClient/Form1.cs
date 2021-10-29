﻿using Messanger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsClient
{
  public partial class Form1 : Form
  {
    private static int MessageID;
    private static string UserName;
    private static MeesangerClientAPI API = new MeesangerClientAPI();
    public Form1()
    {
      InitializeComponent();
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      string UserName = UserNameTB.Text;
      string Message = MessageTB.Text;
      if ((UserName.Length > 1) && (UserName.Length > 1))
      {
        Messanger.Message msg = new Messanger.Message(UserName, Message, DateTime.Now);
        API.SendMessage(msg);
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      var getMessage = new Func<Task>(async () =>
      {
        Messanger.Message msg = await API.GetMessageHTTPAsync(MessageID);
        while (msg != null)
        {
          MessagesLB.Items.Add(msg);
          MessageID++;
          msg = await API.GetMessageHTTPAsync(MessageID);
        }
      });
      getMessage.Invoke();
    }
  }
}