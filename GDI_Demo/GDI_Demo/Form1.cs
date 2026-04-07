
namespace GDI_Demo
{
  public partial class Form1 : Form
  {
    // NOTE : the DLL as posted in BS was added to the project, and dependency to the DLL Browsed/Added.
    List<MultiDraw2022.LineSegment> _lsLines = new();
    public Form1()
    {
      InitializeComponent();
      Text = "GDI Demo - Click to draw 100 random lines";
      MouseClick += Form1_MouseClick;
    }

    private void Form1_MouseClick(object? sender, MouseEventArgs e)
    {

      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        using (Graphics gr = CreateGraphics()) // 
          gr.Clear(Color.White); // clear the form's drawing context.
      }
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        // Need a context to draw on RIGHT NOW, not in Paint where it is free
        Random r = new Random();
        _lsLines.Clear(); // remove old
        {
          for (int i = 0; i < 100; i++)
          {
            MultiDraw2022.LineSegment ls = new();
            ls.C = Color.Red;
            ls.T = (byte)r.Next(1, 10);
            ls.SX = (Int16)r.Next(ClientRectangle.Width);
            ls.SY = (Int16)r.Next(ClientRectangle.Height);
            ls.EX = (Int16)r.Next(ClientRectangle.Width);
            ls.EY = (Int16)r.Next(ClientRectangle.Height);
            _lsLines.Add(ls);
          }
          // Done whatever, lets show, like your would in the data ready callback.
          // These are NOT persistent and will be lost when the the form refreshes. This is acceptable behaviour for us,
          //   we do not want to store them, just show what we got on top of whatever the form has displayed.

          using (Graphics gr = CreateGraphics()) // only for immediate use... get it, use it, dispose it. Do not keep it around, it might be invalidated by the system.
            _lsLines.ForEach(x => x.Render(gr));
        }
      }
    }
  }
}
