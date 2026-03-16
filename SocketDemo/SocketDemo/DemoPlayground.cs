using DialogDemo;
using System.Diagnostics;
namespace SocketDemo
{
  public partial class DemoPlayground : Form
  {
    public DemoPlayground()
    {
      InitializeComponent();
      Text = "Playground";
      BackColor = Color.LightCyan; // Just a playground, not client or server
      KeyDown += Form1_KeyDown;
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
      Dialog dlg = new();
      DialogResult why = dlg.ShowDialog(); // save return to see why closed.
      if (why == DialogResult.OK)
        Trace.Write("ALL IS WELL ! : ");
      Trace.WriteLine($"{why}");
    }
  }
}
