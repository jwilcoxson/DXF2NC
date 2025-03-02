using netDxf;
using netDxf.Entities;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;


namespace WinFormsApp1
{
    partial class Form1
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
            chkInvertX = new CheckBox();
            chkInvertY = new CheckBox();
            chkReversePath = new CheckBox();
            numFeedRate = new NumericUpDown();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtOutput = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            txtFileName = new Label();
            chkStartAbs = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numFeedRate).BeginInit();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // chkInvertX
            // 
            chkInvertX.AutoSize = true;
            chkInvertX.Location = new System.Drawing.Point(23, 57);
            chkInvertX.Name = "chkInvertX";
            chkInvertX.Size = new Size(81, 24);
            chkInvertX.TabIndex = 2;
            chkInvertX.Text = "Invert X";
            chkInvertX.UseVisualStyleBackColor = true;
            chkInvertX.CheckedChanged += chkInvertX_CheckedChanged;
            // 
            // chkInvertY
            // 
            chkInvertY.AutoSize = true;
            chkInvertY.Location = new System.Drawing.Point(23, 87);
            chkInvertY.Name = "chkInvertY";
            chkInvertY.Size = new Size(80, 24);
            chkInvertY.TabIndex = 3;
            chkInvertY.Text = "Invert Y";
            chkInvertY.UseVisualStyleBackColor = true;
            chkInvertY.CheckedChanged += chkInvertY_CheckedChanged;
            // 
            // chkReversePath
            // 
            chkReversePath.AutoSize = true;
            chkReversePath.Location = new System.Drawing.Point(23, 117);
            chkReversePath.Name = "chkReversePath";
            chkReversePath.Size = new Size(114, 24);
            chkReversePath.TabIndex = 4;
            chkReversePath.Text = "Reverse Path";
            chkReversePath.UseVisualStyleBackColor = true;
            chkReversePath.CheckedChanged += chkReversePath_CheckedChanged;
            // 
            // numFeedRate
            // 
            numFeedRate.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            numFeedRate.Location = new System.Drawing.Point(23, 231);
            numFeedRate.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            numFeedRate.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numFeedRate.Name = "numFeedRate";
            numFeedRate.Size = new Size(114, 27);
            numFeedRate.TabIndex = 5;
            numFeedRate.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            numFeedRate.ValueChanged += numFeedRate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 208);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 6;
            label1.Text = "Feed Rate";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtOutput);
            groupBox1.Location = new System.Drawing.Point(201, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(587, 557);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "G-code";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.Window;
            txtOutput.BorderStyle = BorderStyle.FixedSingle;
            txtOutput.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutput.Location = new System.Drawing.Point(6, 30);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(575, 521);
            txtOutput.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F;
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(181, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            exitToolStripMenuItem.Size = new Size(181, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(177, 26);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // txtFileName
            // 
            txtFileName.AutoSize = true;
            txtFileName.Location = new System.Drawing.Point(12, 31);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(125, 20);
            txtFileName.TabIndex = 13;
            txtFileName.Text = "<No file loaded>";
            // 
            // chkStartAbs
            // 
            chkStartAbs.AutoSize = true;
            chkStartAbs.Location = new System.Drawing.Point(23, 147);
            chkStartAbs.Name = "chkStartAbs";
            chkStartAbs.Size = new Size(148, 24);
            chkStartAbs.TabIndex = 14;
            chkStartAbs.Text = "Abs move to start";
            chkStartAbs.UseVisualStyleBackColor = true;
            chkStartAbs.CheckedChanged += chkStartAbs_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 621);
            Controls.Add(chkStartAbs);
            Controls.Add(txtFileName);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(numFeedRate);
            Controls.Add(chkReversePath);
            Controls.Add(chkInvertY);
            Controls.Add(chkInvertX);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "DXF2NC";
            ((System.ComponentModel.ISupportInitialize)numFeedRate).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private CheckBox chkInvertX;
        private CheckBox chkInvertY;
        private CheckBox chkReversePath;
        private NumericUpDown numFeedRate;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtOutput;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label txtFileName;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private CheckBox chkStartAbs;
    }
}
