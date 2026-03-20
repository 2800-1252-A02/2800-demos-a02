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
          // re-entrant ? blow away the old one ?
          // Depends on Spec
          // Try if not null.
          if (_client != null)
          {
            // Soft-Disco to let other side know we're done.
            _client?.Shutdown(SocketShutdown.Both);
            _client?.Close();
          }
        }
        catch // Don't care
        {}

        // Ok, start from scratch
        try
        {
          _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          string addr = "localhost";
          int port = 1666;
          await _client.ConnectAsync(addr, port);
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
        // All is well !
        // Start receiving...
        RxTask(_client);
      }
      if (e.KeyCode == Keys.Up)
      {

      }

    }
    async private void RxTask(Socket? client)
    {
      if (client == null) return; // no socket, no work

      // forever, until error/disco, recv into buffer.
      byte[] bytebuff = new byte[100]; // our actual buffer

      // map the ArraySegment to the buffer, all of it, for use in ReceiveAsync.
      //ArraySegment<byte> buffSegment = new ArraySegment<byte>(bytebuff);

      int iNumBytes = 0;
      while (true)// until, disconnect or error ( kinda the same.. )
      {
        // Target your try/catch to the smallest possible block, on functions that 
        //  can throw exceptions that you can't control.
        try
        {
          iNumBytes = await client.ReceiveAsync(bytebuff, SocketFlags.None);
          //iNumBytes = await client.ReceiveAsync(buffSegment, SocketFlags.None);
        }
        catch (SocketException exc)
        {
          Msgs("RxThread:SocketException : " + exc.Message);
          return;
        }
        catch (Exception exc)
        {
          Msgs("RxThread:GenericException : " + exc.Message);
          return;
        }
        // Got here ? it was successful, BUT it may be 0 bytes indicating
        // A Soft Disconnect from the OTHER side - if we disconnect, we'll get an exception.
        if (iNumBytes == 0) // Soft Disco ? What now ?
        {
          Msgs("Soft Disco Encountered");
          client = null; // ? maybe ? depends on spec
          return; // Why stay ? Socket is disconnected
        }
        // HERE ? Do something with the data...
        Msgs($"RxThread Got {iNumBytes} :  {bytebuff[0]:0b}, {bytebuff[1]:0b}");

        // Rinse and Repeat while() we are not disconnected.
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
