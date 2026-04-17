using System.Net;
using System.Net.Sockets;

namespace Server
{
  public partial class Server : Form
  {
    Socket _listener;
    public Server()
    {
      InitializeComponent();
      Text = "Server";
      KeyPreview = true; // allows form to capture key events before controls
      KeyDown += Form1_KeyDown;

      try
      {
        _listener?.Close();
        _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Hook up socket to port for all interfaces
        _listener.Bind(new IPEndPoint(IPAddress.Any, 1666));

        // NOW start listening
        _listener.Listen(1); 
      }
      catch (Exception exc)
      {
        Log(exc.Message);
        return;
      }
      Log($"Listening...");
      Shown += (s,e) => AttemptAccept(); // Defer until form is shown.
    }

    private async void AttemptAccept()
    {
      try
      {
        Socket tmpClient = await _listener?.AcceptAsync();
        Log($"Client Connected : {tmpClient.RemoteEndPoint}");
      }
      catch (Exception exc)
      {
        Log( exc.Message);
      }
    }

    private async void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
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
