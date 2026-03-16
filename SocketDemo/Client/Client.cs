// Client Async Demo
using static System.Diagnostics.Trace;

namespace Client
{
  public partial class Client : Form
  {
    const string _msgPrefix = "Client:";
    public Client()
    {
      InitializeComponent();
      BackColor = Color.LightBlue;
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
