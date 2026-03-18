// Client Async Demo
using System.Net;
using System.Net.Sockets;
using static System.Diagnostics.Trace;

namespace Client
{
  public partial class Client : Form
  {
    const string _msgPrefix = "Client:";
    Socket? _client = null;
    public Client()
    {
      InitializeComponent();
      BackColor = Color.LightBlue;
      KeyDown += Client_KeyDown;
    }

    private async void Client_KeyDown(object? sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        try
        {
          _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          await _client.ConnectAsync("w213-inst", 1666);
          await _client.SendAsync(new byte[80], SocketFlags.None);
        }
        catch (SocketException exc)
        {
          Msgs($"Client:SocketException : {exc.Message}");
          return;
        }
        catch (Exception exc)
        {
          Msgs($"Client:Exception : {exc.Message}");
          return;
        }
        Msgs($"Client:Done connecting");
      }
      if (e.KeyCode == Keys.Up)
      {

      }

    }

    /// <summary>
    /// UI Helper method, thread-safe to localize UI updates,
    ///  would be good to pass an ENUM in with application state : eConnected, eConnectFailed...etc
    ///  or other additional flags/params to maximize utility.
    /// </summary>
    /// <param name="s">message to display</param>
    private void Msgs(string s)
    {
      if (InvokeRequired)
      {
        WriteLine("InvokeRequired.. you shouldn't see this..");
        Invoke(new Action(() => Msgs(s)));
        WriteLine(s);
        return;
      }
      Text = s;
      WriteLine($"{_msgPrefix}{s}");
    }
  }
}
