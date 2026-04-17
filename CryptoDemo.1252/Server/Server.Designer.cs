namespace Server
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _output = new ListBox();
            SuspendLayout();
            // 
            // _output
            // 
            _output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _output.BackColor = Color.FromArgb(192, 255, 255);
            _output.FormattingEnabled = true;
            _output.ItemHeight = 15;
            _output.Location = new Point(0, 0);
            _output.Name = "_output";
            _output.Size = new Size(800, 454);
            _output.TabIndex = 0;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_output);
            Name = "Server";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox _output;
    }
}
