// Server Async Demo
using static System.Diagnostics.Trace;

namespace Server
{
  public partial class Server : Form
  {
    const string _msgPrefix = "Server:";
    public Server()
    {
      InitializeComponent();
      BackColor = Color.LightGreen;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

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
