using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ConnectionDialogLibrary
{
  public partial class ConDlg : Form
  {
    //DialogResult r = DialogResult.
    System.Windows.Forms.Timer _tim = new System.Windows.Forms.Timer();
    public string Name { get; set; }
    public ConDlg()
    {
      InitializeComponent();
      BackColor = Color.Coral;
      _tim.Interval = 4000;
      _tim.Tick += (s, e) => // Close Dialog on Tick
        { 
          Name = DateTime.Now.ToShortTimeString(); // public dialog property
          DialogResult = DialogResult.OK; // Force dialog to close by setting DialogResult
        };
      _tim.Start();
    }
  }
}
