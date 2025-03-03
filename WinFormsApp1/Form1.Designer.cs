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
            txtOutput = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            chkStartAbs = new CheckBox();
            tabControl1 = new TabControl();
            tabCode = new TabPage();
            tabPoints = new TabPage();
            dgvPoints = new DataGridView();
            colIndex = new DataGridViewTextBoxColumn();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            colB = new DataGridViewTextBoxColumn();
            tabView = new TabPage();
            panel1 = new Panel();
            cmbLayer = new ComboBox();
            lblLayer = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            scaleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)numFeedRate).BeginInit();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabCode.SuspendLayout();
            tabPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPoints).BeginInit();
            tabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // chkInvertX
            // 
            chkInvertX.AutoSize = true;
            chkInvertX.Location = new System.Drawing.Point(602, 74);
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
            chkInvertY.Location = new System.Drawing.Point(602, 104);
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
            chkReversePath.Location = new System.Drawing.Point(602, 134);
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
            numFeedRate.Location = new System.Drawing.Point(683, 38);
            numFeedRate.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            numFeedRate.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numFeedRate.Name = "numFeedRate";
            numFeedRate.Size = new Size(81, 27);
            numFeedRate.TabIndex = 5;
            numFeedRate.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            numFeedRate.ValueChanged += numFeedRate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(602, 40);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 6;
            label1.Text = "Feed Rate";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.Window;
            txtOutput.BorderStyle = BorderStyle.FixedSingle;
            txtOutput.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutput.Location = new System.Drawing.Point(6, 6);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(564, 513);
            txtOutput.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(779, 28);
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { scaleToolStripMenuItem, toolStripSeparator1, copyToolStripMenuItem });
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
            // chkStartAbs
            // 
            chkStartAbs.AutoSize = true;
            chkStartAbs.Location = new System.Drawing.Point(602, 164);
            chkStartAbs.Name = "chkStartAbs";
            chkStartAbs.Size = new Size(148, 24);
            chkStartAbs.TabIndex = 14;
            chkStartAbs.Text = "Abs move to start";
            chkStartAbs.UseVisualStyleBackColor = true;
            chkStartAbs.CheckedChanged += chkStartAbs_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCode);
            tabControl1.Controls.Add(tabPoints);
            tabControl1.Controls.Add(tabView);
            tabControl1.Location = new System.Drawing.Point(12, 118);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(584, 558);
            tabControl1.TabIndex = 15;
            // 
            // tabCode
            // 
            tabCode.Controls.Add(txtOutput);
            tabCode.Location = new System.Drawing.Point(4, 29);
            tabCode.Name = "tabCode";
            tabCode.Padding = new Padding(3);
            tabCode.Size = new Size(576, 525);
            tabCode.TabIndex = 0;
            tabCode.Text = "Code";
            tabCode.UseVisualStyleBackColor = true;
            // 
            // tabPoints
            // 
            tabPoints.Controls.Add(dgvPoints);
            tabPoints.Location = new System.Drawing.Point(4, 29);
            tabPoints.Name = "tabPoints";
            tabPoints.Padding = new Padding(3);
            tabPoints.Size = new Size(576, 525);
            tabPoints.TabIndex = 1;
            tabPoints.Text = "Points";
            tabPoints.UseVisualStyleBackColor = true;
            // 
            // dgvPoints
            // 
            dgvPoints.AllowUserToAddRows = false;
            dgvPoints.AllowUserToDeleteRows = false;
            dgvPoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPoints.Columns.AddRange(new DataGridViewColumn[] { colIndex, colX, colY, colB });
            dgvPoints.Location = new System.Drawing.Point(4, 4);
            dgvPoints.Name = "dgvPoints";
            dgvPoints.ReadOnly = true;
            dgvPoints.RowHeadersWidth = 51;
            dgvPoints.Size = new Size(571, 512);
            dgvPoints.TabIndex = 0;
            // 
            // colIndex
            // 
            colIndex.HeaderText = "Index";
            colIndex.MinimumWidth = 6;
            colIndex.Name = "colIndex";
            colIndex.ReadOnly = true;
            colIndex.Width = 75;
            // 
            // colX
            // 
            colX.HeaderText = "X";
            colX.MinimumWidth = 6;
            colX.Name = "colX";
            colX.ReadOnly = true;
            colX.Width = 125;
            // 
            // colY
            // 
            colY.HeaderText = "Y";
            colY.MinimumWidth = 6;
            colY.Name = "colY";
            colY.ReadOnly = true;
            colY.Width = 125;
            // 
            // colB
            // 
            colB.HeaderText = "B";
            colB.MinimumWidth = 6;
            colB.Name = "colB";
            colB.ReadOnly = true;
            colB.Width = 125;
            // 
            // tabView
            // 
            tabView.Controls.Add(panel1);
            tabView.Location = new System.Drawing.Point(4, 29);
            tabView.Name = "tabView";
            tabView.Size = new Size(576, 525);
            tabView.TabIndex = 2;
            tabView.Text = "View";
            tabView.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(1, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 516);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // cmbLayer
            // 
            cmbLayer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayer.FormattingEnabled = true;
            cmbLayer.Location = new System.Drawing.Point(64, 31);
            cmbLayer.Name = "cmbLayer";
            cmbLayer.Size = new Size(178, 28);
            cmbLayer.TabIndex = 16;
            cmbLayer.SelectedIndexChanged += cmbLayer_SelectedIndexChanged;
            // 
            // lblLayer
            // 
            lblLayer.AutoSize = true;
            lblLayer.Location = new System.Drawing.Point(14, 34);
            lblLayer.Name = "lblLayer";
            lblLayer.Size = new Size(44, 20);
            lblLayer.TabIndex = 17;
            lblLayer.Text = "Layer";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(676, 199);
            numericUpDown1.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(58, 27);
            numericUpDown1.TabIndex = 18;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            numericUpDown1.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(602, 201);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 19;
            label2.Text = "Precision";
            // 
            // scaleToolStripMenuItem
            // 
            scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            scaleToolStripMenuItem.Size = new Size(224, 26);
            scaleToolStripMenuItem.Text = "Scale";
            scaleToolStripMenuItem.Click += scaleToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 688);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(lblLayer);
            Controls.Add(cmbLayer);
            Controls.Add(tabControl1);
            Controls.Add(chkStartAbs);
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabCode.ResumeLayout(false);
            tabCode.PerformLayout();
            tabPoints.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPoints).EndInit();
            tabView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private TextBox txtOutput;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private CheckBox chkStartAbs;
        private TabControl tabControl1;
        private TabPage tabCode;
        private TabPage tabPoints;
        private DataGridView dgvPoints;
        private DataGridViewTextBoxColumn colIndex;
        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
        private DataGridViewTextBoxColumn colB;
        private TabPage tabView;
        private Panel panel1;
        private ComboBox cmbLayer;
        private Label lblLayer;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private ToolStripMenuItem scaleToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
    }
}
