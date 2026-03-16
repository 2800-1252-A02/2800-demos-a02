using DialogDemo;
namespace SocketDemo
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      KeyDown += Form1_KeyDown;
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
      Dialog dlg = new();
      dlg.ShowDialog();
    }
  }
}
