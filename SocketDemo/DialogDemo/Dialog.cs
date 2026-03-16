using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogDemo
{
  public partial class Dialog : Form
  {
    System.Windows.Forms.Timer timer = new(); // To auto-close the dialog
    public Dialog()
    {
      InitializeComponent();
      timer.Interval = 3000;
      // On timeout, Set the DialogResult to have the Dialog auto-close..
      // Whomever opened this will get this result from ShowDialog();
      timer.Tick += (s, e) => { DialogResult = DialogResult.OK; };
      // Let'er rip
      timer.Start();
    }
  }
}
