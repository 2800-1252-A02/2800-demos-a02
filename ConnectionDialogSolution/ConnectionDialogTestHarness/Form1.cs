//using ConnectionDialogLibrary;
using static System.Diagnostics.Trace;

namespace ConnectionDialogTestHarness
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
      // Cases of trying the Dialog and verifying the result
      if( e.KeyCode == Keys.Enter )
      {
        ConnectionDialogLibrary.ConDlg dlg = new();
        WriteLine(dlg.ShowDialog());
        //dlg.Name
      }
    }
  }
}
