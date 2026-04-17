// Add your Absoc dependency and a 'using' if you want.
using System.Net;
using System.Net.Sockets;
namespace Client
{
  public partial class Client : Form
  {
    public Client()
    {
      InitializeComponent();
      Text = "Client";
      KeyPreview = true; // allows form to capture key events before controls
      KeyDown += Form1_KeyDown;
    }

    private async void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.C)
      {
        Socket soc = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        try
        {
          Log($"Connecting... ");
          await soc.ConnectAsync("127.0.0.1", 1666);
          Log($"Connected!");
          // Make your AbSoc here, pass in the socket, and start your communication
          // Populate your data callback with the state machine logic to start Encrypto
        }
        catch (Exception exc)
        {
          Log($"Connect Error : {exc.Message}");
        }
        e.Handled = true; // prevent further processing of the key event
      }
    }
    private void Log(string msg)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<string>(Log), msg);
        return;
      }
      _output.Items.Insert(0, msg);
    }
  }
}
