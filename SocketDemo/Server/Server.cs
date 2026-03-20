// Server Async Demo
using System.Net;
using System.Net.Sockets;
using static System.Diagnostics.Trace;

namespace Server
{
  public partial class Server : Form
  {
    const string _msgPrefix = "Server:";
    Socket? _listener = null;
    Socket? _client = null;

    public Server()
    {
      InitializeComponent();
      BackColor = Color.LightGreen;
      KeyDown += Server_KeyDown;
    }

    private async void Server_KeyDown(object? sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        try
        {
          // re-entrant ? blow away the old one ?
          // Depends on Spec
          // Try if not null.

          // Listener sockets ONLY need Close(), not Shutdown()
          _listener?.Close();
        }
        catch (Exception)
        {
        }

        try
        {
          // Establish Socket, same as client
          _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          // Bind will attempt to put a listening socket on the system, 
          //  may or may not have privilege to do this
          //  here we will listen for ANYone, but can be a single or filtered address too
          //  Port must known/shared with client
          _listener.Bind(new IPEndPoint(IPAddress.Any, 1666)); // Any incoming address for port 1666

          // Start formal listening, with a backlog Q of 5, allowing for 5 connections
          //  to be in the processing of connecting, without losing them.
          // 0 means infinite backlog, but may be limited by system
          _listener.Listen(0);
          Msgs("Listening...");
        }
        catch (SocketException exc)
        {
          Msgs($"Listener:SocketException : {exc.Message}");
          return;
        }
        catch (Exception exc)
        {
          Msgs($"Listener:Exception : {exc.Message}");
          return;
        }
      }
      if (e.KeyCode == Keys.Add)
      {
        try
        {
          // Allow a full connection to be formed ? Yes, - Accept() the connection..
          Msgs("Accepting...");
          Socket client = await _listener.AcceptAsync();

          // Add to client list, or just use it - here overwrite member _client
          _client = client;
          _client.NoDelay = true; // Turn off Nagel efficiency algorithm..
          Msgs("Accept Complete, _client socket is good.");

        }
        catch (SocketException exc)
        {
          _client = null;
          Msgs($"Accept:SocketException : {exc.Message}");
          return;
        }
        catch (Exception exc)
        {
          _client = null;
          Msgs($"Accept:Exception : {exc.Message}");
          return;
        }
        // Send a message
        try
        {
          // Attempt to send something
          Random r = new();
          byte[] buff = new byte[2] { (byte)r.Next(256), (byte)r.Next(256) };
          //int iNumBytesSent = await _client.SendAsync(new ArraySegment<byte>(buff), SocketFlags.None); // Actual
          int iNumBytesSent = await _client.SendAsync(buff, SocketFlags.None); // Implicit conversion to ArraySegment
          Msgs($"Sent {iNumBytesSent} bytes {buff[0]:0b},{buff[1]:0b}");
        }
        catch (SocketException exc)
        {
          _client = null;
          Msgs($"Send:SocketException : {exc.Message}");
          return;
        }
        catch (Exception exc)
        {
          _client = null;
          Msgs("Send:Exception : " + exc.Message);
          return;
        }
        Msgs("Send Complete, NOW Soft Disco You");
        try
        {
          _client.Shutdown(SocketShutdown.Both);
          _client.Close();
        }
        catch (Exception)
        {}
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
