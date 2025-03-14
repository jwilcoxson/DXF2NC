﻿using netDxf;
using netDxf.Entities;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;


namespace DXF2NC
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            numFeedRate = new NumericUpDown();
            label1 = new Label();
            txtOutput = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            transformToolStripMenuItem = new ToolStripMenuItem();
            translateToolStripMenuItem = new ToolStripMenuItem();
            rotateLeftToolStripMenuItem = new ToolStripMenuItem();
            rotateRightToolStripMenuItem = new ToolStripMenuItem();
            rotateToolStripMenuItem2 = new ToolStripMenuItem();
            scaleToolStripMenuItem1 = new ToolStripMenuItem();
            invertXToolStripMenuItem = new ToolStripMenuItem();
            invertYToolStripMenuItem = new ToolStripMenuItem();
            precisionToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabCode = new TabPage();
            tabPoints = new TabPage();
            dgvPoints = new DataGridView();
            colIndex = new DataGridViewTextBoxColumn();
            colX = new DataGridViewTextBoxColumn();
            colY = new DataGridViewTextBoxColumn();
            colB = new DataGridViewTextBoxColumn();
            tabView = new TabPage();
            pictureBox1 = new PictureBox();
            tabTraversing = new TabPage();
            dgvTraversing = new DataGridView();
            colTraversingIndex = new DataGridViewTextBoxColumn();
            colCmd = new DataGridViewTextBoxColumn();
            colTraversingX = new DataGridViewTextBoxColumn();
            colTraversingY = new DataGridViewTextBoxColumn();
            colTraversingVX = new DataGridViewTextBoxColumn();
            colTraversingVY = new DataGridViewTextBoxColumn();
            cmbLayer = new ComboBox();
            lblLayer = new Label();
            lblPolyline = new Label();
            cmbPolyline = new ComboBox();
            toolStrip1 = new ToolStrip();
            rotLeftToolStripButton1 = new ToolStripButton();
            rotRightToolStripButton1 = new ToolStripButton();
            invertXToolStripButton = new ToolStripButton();
            invertYToolStripButton = new ToolStripButton();
            reversePathToolStripButton = new ToolStripButton();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)numFeedRate).BeginInit();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabCode.SuspendLayout();
            tabPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPoints).BeginInit();
            tabView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabTraversing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTraversing).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // numFeedRate
            // 
            numFeedRate.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            numFeedRate.Location = new System.Drawing.Point(582, 59);
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
            label1.Location = new System.Drawing.Point(501, 61);
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
            txtOutput.Size = new Size(769, 539);
            txtOutput.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(813, 28);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, closeToolStripMenuItem, exitToolStripMenuItem });
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
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(181, 26);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { transformToolStripMenuItem, invertXToolStripMenuItem, invertYToolStripMenuItem, precisionToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // transformToolStripMenuItem
            // 
            transformToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { translateToolStripMenuItem, rotateLeftToolStripMenuItem, rotateRightToolStripMenuItem, rotateToolStripMenuItem2, scaleToolStripMenuItem1 });
            transformToolStripMenuItem.Name = "transformToolStripMenuItem";
            transformToolStripMenuItem.Size = new Size(224, 26);
            transformToolStripMenuItem.Text = "Transform";
            // 
            // translateToolStripMenuItem
            // 
            translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            translateToolStripMenuItem.Size = new Size(175, 26);
            translateToolStripMenuItem.Text = "Translate...";
            translateToolStripMenuItem.Click += translateToolStripMenuItem_Click;
            // 
            // rotateLeftToolStripMenuItem
            // 
            rotateLeftToolStripMenuItem.Name = "rotateLeftToolStripMenuItem";
            rotateLeftToolStripMenuItem.Size = new Size(175, 26);
            rotateLeftToolStripMenuItem.Text = "Rotate Left";
            rotateLeftToolStripMenuItem.Click += rotLeftToolStripButton_Click;
            // 
            // rotateRightToolStripMenuItem
            // 
            rotateRightToolStripMenuItem.Name = "rotateRightToolStripMenuItem";
            rotateRightToolStripMenuItem.Size = new Size(175, 26);
            rotateRightToolStripMenuItem.Text = "Rotate Right";
            rotateRightToolStripMenuItem.Click += rotRightToolStripButton_Click;
            // 
            // rotateToolStripMenuItem2
            // 
            rotateToolStripMenuItem2.Name = "rotateToolStripMenuItem2";
            rotateToolStripMenuItem2.Size = new Size(175, 26);
            rotateToolStripMenuItem2.Text = "Rotate...";
            rotateToolStripMenuItem2.Click += rotateToolStripMenuItem1_Click;
            // 
            // scaleToolStripMenuItem1
            // 
            scaleToolStripMenuItem1.Name = "scaleToolStripMenuItem1";
            scaleToolStripMenuItem1.Size = new Size(175, 26);
            scaleToolStripMenuItem1.Text = "Scale...";
            scaleToolStripMenuItem1.Click += scaleToolStripMenuItem_Click;
            // 
            // invertXToolStripMenuItem
            // 
            invertXToolStripMenuItem.Name = "invertXToolStripMenuItem";
            invertXToolStripMenuItem.Size = new Size(224, 26);
            invertXToolStripMenuItem.Text = "Invert X";
            invertXToolStripMenuItem.Click += invertXToolStripButton_Click;
            // 
            // invertYToolStripMenuItem
            // 
            invertYToolStripMenuItem.Name = "invertYToolStripMenuItem";
            invertYToolStripMenuItem.Size = new Size(224, 26);
            invertYToolStripMenuItem.Text = "Invert Y";
            invertYToolStripMenuItem.Click += invertYToolStripButton_Click;
            // 
            // precisionToolStripMenuItem
            // 
            precisionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10 });
            precisionToolStripMenuItem.Name = "precisionToolStripMenuItem";
            precisionToolStripMenuItem.Size = new Size(224, 26);
            precisionToolStripMenuItem.Text = "Precision";
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Checked = true;
            toolStripMenuItem7.CheckState = CheckState.Checked;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(224, 26);
            toolStripMenuItem7.Text = "0.000";
            toolStripMenuItem7.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(224, 26);
            toolStripMenuItem8.Text = "0.0000";
            toolStripMenuItem8.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(224, 26);
            toolStripMenuItem9.Text = "0.00000";
            toolStripMenuItem9.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(224, 26);
            toolStripMenuItem10.Text = "0.000000";
            toolStripMenuItem10.Click += toolStripMenuItem5_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCode);
            tabControl1.Controls.Add(tabPoints);
            tabControl1.Controls.Add(tabView);
            tabControl1.Controls.Add(tabTraversing);
            tabControl1.Location = new System.Drawing.Point(12, 92);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(789, 584);
            tabControl1.TabIndex = 15;
            // 
            // tabCode
            // 
            tabCode.Controls.Add(txtOutput);
            tabCode.Location = new System.Drawing.Point(4, 29);
            tabCode.Name = "tabCode";
            tabCode.Padding = new Padding(3);
            tabCode.Size = new Size(781, 551);
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
            tabPoints.Size = new Size(781, 551);
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
            dgvPoints.Location = new System.Drawing.Point(6, 6);
            dgvPoints.Name = "dgvPoints";
            dgvPoints.RowHeadersWidth = 51;
            dgvPoints.Size = new Size(769, 539);
            dgvPoints.TabIndex = 0;
            dgvPoints.CellEndEdit += dgvPoints_CellEndEdit;
            // 
            // colIndex
            // 
            colIndex.HeaderText = "Index";
            colIndex.MinimumWidth = 6;
            colIndex.Name = "colIndex";
            colIndex.Width = 75;
            // 
            // colX
            // 
            colX.HeaderText = "X";
            colX.MinimumWidth = 6;
            colX.Name = "colX";
            colX.Width = 125;
            // 
            // colY
            // 
            colY.HeaderText = "Y";
            colY.MinimumWidth = 6;
            colY.Name = "colY";
            colY.Width = 125;
            // 
            // colB
            // 
            colB.HeaderText = "B";
            colB.MinimumWidth = 6;
            colB.Name = "colB";
            colB.Width = 125;
            // 
            // tabView
            // 
            tabView.Controls.Add(pictureBox1);
            tabView.Location = new System.Drawing.Point(4, 29);
            tabView.Name = "tabView";
            tabView.Size = new Size(781, 551);
            tabView.TabIndex = 2;
            tabView.Text = "View";
            tabView.UseVisualStyleBackColor = true;
            tabView.Paint += tabView_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(775, 545);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tabTraversing
            // 
            tabTraversing.Controls.Add(dgvTraversing);
            tabTraversing.Location = new System.Drawing.Point(4, 29);
            tabTraversing.Name = "tabTraversing";
            tabTraversing.Padding = new Padding(3);
            tabTraversing.Size = new Size(781, 551);
            tabTraversing.TabIndex = 3;
            tabTraversing.Text = "Traversing";
            tabTraversing.UseVisualStyleBackColor = true;
            // 
            // dgvTraversing
            // 
            dgvTraversing.AllowUserToAddRows = false;
            dgvTraversing.AllowUserToDeleteRows = false;
            dgvTraversing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTraversing.Columns.AddRange(new DataGridViewColumn[] { colTraversingIndex, colCmd, colTraversingX, colTraversingY, colTraversingVX, colTraversingVY });
            dgvTraversing.Location = new System.Drawing.Point(0, 0);
            dgvTraversing.Name = "dgvTraversing";
            dgvTraversing.ReadOnly = true;
            dgvTraversing.RowHeadersWidth = 51;
            dgvTraversing.Size = new Size(781, 534);
            dgvTraversing.TabIndex = 0;
            // 
            // colTraversingIndex
            // 
            colTraversingIndex.HeaderText = "Index";
            colTraversingIndex.MinimumWidth = 6;
            colTraversingIndex.Name = "colTraversingIndex";
            colTraversingIndex.ReadOnly = true;
            colTraversingIndex.Width = 80;
            // 
            // colCmd
            // 
            colCmd.HeaderText = "Command";
            colCmd.MinimumWidth = 6;
            colCmd.Name = "colCmd";
            colCmd.ReadOnly = true;
            colCmd.Width = 125;
            // 
            // colTraversingX
            // 
            colTraversingX.HeaderText = "X";
            colTraversingX.MinimumWidth = 6;
            colTraversingX.Name = "colTraversingX";
            colTraversingX.ReadOnly = true;
            colTraversingX.Width = 125;
            // 
            // colTraversingY
            // 
            colTraversingY.HeaderText = "Y";
            colTraversingY.MinimumWidth = 6;
            colTraversingY.Name = "colTraversingY";
            colTraversingY.ReadOnly = true;
            colTraversingY.Width = 125;
            // 
            // colTraversingVX
            // 
            colTraversingVX.HeaderText = "Vx";
            colTraversingVX.MinimumWidth = 6;
            colTraversingVX.Name = "colTraversingVX";
            colTraversingVX.ReadOnly = true;
            colTraversingVX.Width = 125;
            // 
            // colTraversingVY
            // 
            colTraversingVY.HeaderText = "Vy";
            colTraversingVY.MinimumWidth = 6;
            colTraversingVY.Name = "colTraversingVY";
            colTraversingVY.ReadOnly = true;
            colTraversingVY.Width = 125;
            // 
            // cmbLayer
            // 
            cmbLayer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLayer.Enabled = false;
            cmbLayer.FormattingEnabled = true;
            cmbLayer.Location = new System.Drawing.Point(64, 58);
            cmbLayer.Name = "cmbLayer";
            cmbLayer.Size = new Size(178, 28);
            cmbLayer.TabIndex = 16;
            cmbLayer.SelectedIndexChanged += cmbLayer_SelectedIndexChanged;
            // 
            // lblLayer
            // 
            lblLayer.AutoSize = true;
            lblLayer.Location = new System.Drawing.Point(16, 61);
            lblLayer.Name = "lblLayer";
            lblLayer.Size = new Size(44, 20);
            lblLayer.TabIndex = 17;
            lblLayer.Text = "Layer";
            // 
            // lblPolyline
            // 
            lblPolyline.AutoSize = true;
            lblPolyline.Location = new System.Drawing.Point(248, 61);
            lblPolyline.Name = "lblPolyline";
            lblPolyline.Size = new Size(63, 20);
            lblPolyline.TabIndex = 20;
            lblPolyline.Text = "PolyLine";
            // 
            // cmbPolyline
            // 
            cmbPolyline.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPolyline.Enabled = false;
            cmbPolyline.FormattingEnabled = true;
            cmbPolyline.Location = new System.Drawing.Point(317, 58);
            cmbPolyline.Name = "cmbPolyline";
            cmbPolyline.Size = new Size(178, 28);
            cmbPolyline.TabIndex = 21;
            cmbPolyline.SelectedIndexChanged += cmbPolyline_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { rotLeftToolStripButton1, rotRightToolStripButton1, invertXToolStripButton, invertYToolStripButton, reversePathToolStripButton, toolStripDropDownButton1 });
            toolStrip1.Location = new System.Drawing.Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(813, 27);
            toolStrip1.TabIndex = 22;
            toolStrip1.Text = "toolStrip1";
            // 
            // rotLeftToolStripButton1
            // 
            rotLeftToolStripButton1.Enabled = false;
            rotLeftToolStripButton1.Image = (System.Drawing.Image)resources.GetObject("rotLeftToolStripButton1.Image");
            rotLeftToolStripButton1.ImageTransparentColor = Color.Magenta;
            rotLeftToolStripButton1.Name = "rotLeftToolStripButton1";
            rotLeftToolStripButton1.Size = new Size(106, 24);
            rotLeftToolStripButton1.Text = "Rotate Left";
            rotLeftToolStripButton1.Click += rotLeftToolStripButton_Click;
            // 
            // rotRightToolStripButton1
            // 
            rotRightToolStripButton1.Enabled = false;
            rotRightToolStripButton1.Image = (System.Drawing.Image)resources.GetObject("rotRightToolStripButton1.Image");
            rotRightToolStripButton1.ImageTransparentColor = Color.Magenta;
            rotRightToolStripButton1.Name = "rotRightToolStripButton1";
            rotRightToolStripButton1.Size = new Size(116, 24);
            rotRightToolStripButton1.Text = "Rotate Right";
            rotRightToolStripButton1.Click += rotRightToolStripButton_Click;
            // 
            // invertXToolStripButton
            // 
            invertXToolStripButton.Enabled = false;
            invertXToolStripButton.Image = (System.Drawing.Image)resources.GetObject("invertXToolStripButton.Image");
            invertXToolStripButton.ImageTransparentColor = Color.Magenta;
            invertXToolStripButton.Name = "invertXToolStripButton";
            invertXToolStripButton.Size = new Size(83, 24);
            invertXToolStripButton.Text = "Invert X";
            invertXToolStripButton.Click += invertXToolStripButton_Click;
            // 
            // invertYToolStripButton
            // 
            invertYToolStripButton.Enabled = false;
            invertYToolStripButton.Image = (System.Drawing.Image)resources.GetObject("invertYToolStripButton.Image");
            invertYToolStripButton.ImageTransparentColor = Color.Magenta;
            invertYToolStripButton.Name = "invertYToolStripButton";
            invertYToolStripButton.Size = new Size(82, 24);
            invertYToolStripButton.Text = "Invert Y";
            invertYToolStripButton.Click += invertYToolStripButton_Click;
            // 
            // reversePathToolStripButton
            // 
            reversePathToolStripButton.Enabled = false;
            reversePathToolStripButton.Image = (System.Drawing.Image)resources.GetObject("reversePathToolStripButton.Image");
            reversePathToolStripButton.ImageTransparentColor = Color.Magenta;
            reversePathToolStripButton.Name = "reversePathToolStripButton";
            reversePathToolStripButton.Size = new Size(116, 24);
            reversePathToolStripButton.Text = "Reverse Path";
            reversePathToolStripButton.Click += reversePathToolStripButton_Click;
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5 });
            toolStripDropDownButton1.Enabled = false;
            toolStripDropDownButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(102, 24);
            toolStripDropDownButton1.Text = "Precision";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem2.CheckState = CheckState.Checked;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(151, 26);
            toolStripMenuItem2.Text = "0.000";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(151, 26);
            toolStripMenuItem3.Text = "0.0000";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(151, 26);
            toolStripMenuItem4.Text = "0.00000";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(151, 26);
            toolStripMenuItem5.Text = "0.000000";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 688);
            Controls.Add(toolStrip1);
            Controls.Add(cmbPolyline);
            Controls.Add(lblPolyline);
            Controls.Add(lblLayer);
            Controls.Add(cmbLayer);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(numFeedRate);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabTraversing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTraversing).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private NumericUpDown numFeedRate;
        private Label label1;
        private TextBox txtOutput;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabCode;
        private TabPage tabPoints;
        private DataGridView dgvPoints;
        private TabPage tabView;
        private ComboBox cmbLayer;
        private Label lblLayer;
        private Label lblPolyline;
        private ComboBox cmbPolyline;
        private ToolStrip toolStrip1;
        private ToolStripButton rotLeftToolStripButton1;
        private ToolStripButton rotRightToolStripButton1;
        private ToolStripButton invertXToolStripButton;
        private ToolStripButton invertYToolStripButton;
        private ToolStripButton reversePathToolStripButton;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private DataGridViewTextBoxColumn colIndex;
        private DataGridViewTextBoxColumn colX;
        private DataGridViewTextBoxColumn colY;
        private DataGridViewTextBoxColumn colB;
        private TabPage tabTraversing;
        private DataGridView dgvTraversing;
        private DataGridViewTextBoxColumn colTraversingIndex;
        private DataGridViewTextBoxColumn colCmd;
        private DataGridViewTextBoxColumn colTraversingX;
        private DataGridViewTextBoxColumn colTraversingY;
        private DataGridViewTextBoxColumn colTraversingVX;
        private DataGridViewTextBoxColumn colTraversingVY;
        private ToolStripMenuItem closeToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem transformToolStripMenuItem;
        private ToolStripMenuItem translateToolStripMenuItem;
        private ToolStripMenuItem rotateLeftToolStripMenuItem;
        private ToolStripMenuItem rotateRightToolStripMenuItem;
        private ToolStripMenuItem rotateToolStripMenuItem2;
        private ToolStripMenuItem scaleToolStripMenuItem1;
        private ToolStripMenuItem invertXToolStripMenuItem;
        private ToolStripMenuItem invertYToolStripMenuItem;
        private ToolStripMenuItem precisionToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
    }
}
