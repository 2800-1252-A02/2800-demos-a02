//using ConnectionDialogLibrary;
using static System.Diagnostics.Trace;

namespace ConnectionDialogTestHarness
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      Text = "Dialog Test Harness";
      KeyDown += Form1_KeyDown;
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
      // Cases of trying the Dialog and verifying the result
      if( e.KeyCode == Keys.Enter )
      {
        ConnectionDialogLibrary.ConDlg dlg = new();
        if( dlg.ShowDialog() == DialogResult.OK )
        {
          Text = dlg.Name; // Ok meant the name got set,
        }
        Text += " : " + dlg.DialogResult; // Append how it closed
      }
    }
  }
}
