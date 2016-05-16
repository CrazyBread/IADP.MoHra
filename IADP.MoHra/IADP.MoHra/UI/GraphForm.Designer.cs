namespace IADP.MoHra.UI
{
    partial class GraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphA1Panel = new System.Windows.Forms.Panel();
            this.graphTabs = new System.Windows.Forms.TabControl();
            this.tabA1 = new System.Windows.Forms.TabPage();
            this.tabA2 = new System.Windows.Forms.TabPage();
            this.graphA2Panel = new System.Windows.Forms.Panel();
            this.tabA3 = new System.Windows.Forms.TabPage();
            this.graphA3Panel = new System.Windows.Forms.Panel();
            this.tabA4 = new System.Windows.Forms.TabPage();
            this.graphA4Panel = new System.Windows.Forms.Panel();
            this.tabA5 = new System.Windows.Forms.TabPage();
            this.graphA5Panel = new System.Windows.Forms.Panel();
            this.graphTabs.SuspendLayout();
            this.tabA1.SuspendLayout();
            this.tabA2.SuspendLayout();
            this.tabA3.SuspendLayout();
            this.tabA4.SuspendLayout();
            this.tabA5.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphA1Panel
            // 
            this.graphA1Panel.Location = new System.Drawing.Point(6, 6);
            this.graphA1Panel.Name = "graphA1Panel";
            this.graphA1Panel.Size = new System.Drawing.Size(500, 310);
            this.graphA1Panel.TabIndex = 0;
            this.graphA1Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphA1Panel_Paint);
            // 
            // graphTabs
            // 
            this.graphTabs.Controls.Add(this.tabA1);
            this.graphTabs.Controls.Add(this.tabA2);
            this.graphTabs.Controls.Add(this.tabA3);
            this.graphTabs.Controls.Add(this.tabA4);
            this.graphTabs.Controls.Add(this.tabA5);
            this.graphTabs.Location = new System.Drawing.Point(13, 13);
            this.graphTabs.Name = "graphTabs";
            this.graphTabs.SelectedIndex = 0;
            this.graphTabs.Size = new System.Drawing.Size(520, 347);
            this.graphTabs.TabIndex = 1;
            // 
            // tabA1
            // 
            this.tabA1.Controls.Add(this.graphA1Panel);
            this.tabA1.Location = new System.Drawing.Point(4, 22);
            this.tabA1.Name = "tabA1";
            this.tabA1.Padding = new System.Windows.Forms.Padding(3);
            this.tabA1.Size = new System.Drawing.Size(512, 321);
            this.tabA1.TabIndex = 0;
            this.tabA1.Text = "A1";
            this.tabA1.UseVisualStyleBackColor = true;
            // 
            // tabA2
            // 
            this.tabA2.Controls.Add(this.graphA2Panel);
            this.tabA2.Location = new System.Drawing.Point(4, 22);
            this.tabA2.Name = "tabA2";
            this.tabA2.Padding = new System.Windows.Forms.Padding(3);
            this.tabA2.Size = new System.Drawing.Size(512, 321);
            this.tabA2.TabIndex = 1;
            this.tabA2.Text = "A2";
            this.tabA2.UseVisualStyleBackColor = true;
            // 
            // graphA2Panel
            // 
            this.graphA2Panel.Location = new System.Drawing.Point(6, 5);
            this.graphA2Panel.Name = "graphA2Panel";
            this.graphA2Panel.Size = new System.Drawing.Size(500, 310);
            this.graphA2Panel.TabIndex = 1;
            this.graphA2Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphA2Panel_Paint);
            // 
            // tabA3
            // 
            this.tabA3.Controls.Add(this.graphA3Panel);
            this.tabA3.Location = new System.Drawing.Point(4, 22);
            this.tabA3.Name = "tabA3";
            this.tabA3.Size = new System.Drawing.Size(512, 321);
            this.tabA3.TabIndex = 2;
            this.tabA3.Text = "A3";
            this.tabA3.UseVisualStyleBackColor = true;
            // 
            // graphA3Panel
            // 
            this.graphA3Panel.Location = new System.Drawing.Point(6, 5);
            this.graphA3Panel.Name = "graphA3Panel";
            this.graphA3Panel.Size = new System.Drawing.Size(500, 310);
            this.graphA3Panel.TabIndex = 1;
            this.graphA3Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphA3Panel_Paint);
            // 
            // tabA4
            // 
            this.tabA4.Controls.Add(this.graphA4Panel);
            this.tabA4.Location = new System.Drawing.Point(4, 22);
            this.tabA4.Name = "tabA4";
            this.tabA4.Size = new System.Drawing.Size(512, 321);
            this.tabA4.TabIndex = 3;
            this.tabA4.Text = "A4";
            this.tabA4.UseVisualStyleBackColor = true;
            // 
            // graphA4Panel
            // 
            this.graphA4Panel.Location = new System.Drawing.Point(6, 5);
            this.graphA4Panel.Name = "graphA4Panel";
            this.graphA4Panel.Size = new System.Drawing.Size(500, 310);
            this.graphA4Panel.TabIndex = 1;
            this.graphA4Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphA4Panel_Paint);
            // 
            // tabA5
            // 
            this.tabA5.Controls.Add(this.graphA5Panel);
            this.tabA5.Location = new System.Drawing.Point(4, 22);
            this.tabA5.Name = "tabA5";
            this.tabA5.Size = new System.Drawing.Size(512, 321);
            this.tabA5.TabIndex = 4;
            this.tabA5.Text = "A5";
            this.tabA5.UseVisualStyleBackColor = true;
            // 
            // graphA5Panel
            // 
            this.graphA5Panel.Location = new System.Drawing.Point(6, 5);
            this.graphA5Panel.Name = "graphA5Panel";
            this.graphA5Panel.Size = new System.Drawing.Size(500, 310);
            this.graphA5Panel.TabIndex = 1;
            this.graphA5Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphA5Panel_Paint);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 373);
            this.Controls.Add(this.graphTabs);
            this.Name = "GraphForm";
            this.Text = "Графики функций принадлежности";
            this.graphTabs.ResumeLayout(false);
            this.tabA1.ResumeLayout(false);
            this.tabA2.ResumeLayout(false);
            this.tabA3.ResumeLayout(false);
            this.tabA4.ResumeLayout(false);
            this.tabA5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel graphA1Panel;
        private System.Windows.Forms.TabControl graphTabs;
        private System.Windows.Forms.TabPage tabA1;
        private System.Windows.Forms.TabPage tabA2;
        private System.Windows.Forms.TabPage tabA3;
        private System.Windows.Forms.TabPage tabA4;
        private System.Windows.Forms.TabPage tabA5;
        private System.Windows.Forms.Panel graphA2Panel;
        private System.Windows.Forms.Panel graphA3Panel;
        private System.Windows.Forms.Panel graphA4Panel;
        private System.Windows.Forms.Panel graphA5Panel;
    }
}