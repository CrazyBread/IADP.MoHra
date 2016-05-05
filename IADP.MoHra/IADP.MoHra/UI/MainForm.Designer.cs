namespace IADP.MoHra.UI
{
    partial class MainForm
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
            this.spentTimeGridView = new System.Windows.Forms.DataGridView();
            this.spentToEstimateGridView = new System.Windows.Forms.DataGridView();
            this.onFixGridView = new System.Windows.Forms.DataGridView();
            this.outOfHoursGridView = new System.Windows.Forms.DataGridView();
            this.estimateTimeByRevisionGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.spentTimeGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spentToEstimateGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onFixGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outOfHoursGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateTimeByRevisionGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // spentTimeGridView
            // 
            this.spentTimeGridView.AllowUserToAddRows = false;
            this.spentTimeGridView.AllowUserToDeleteRows = false;
            this.spentTimeGridView.AllowUserToOrderColumns = true;
            this.spentTimeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spentTimeGridView.Location = new System.Drawing.Point(6, 19);
            this.spentTimeGridView.Name = "spentTimeGridView";
            this.spentTimeGridView.ReadOnly = true;
            this.spentTimeGridView.Size = new System.Drawing.Size(948, 288);
            this.spentTimeGridView.TabIndex = 0;
            // 
            // spentToEstimateGridView
            // 
            this.spentToEstimateGridView.AllowUserToAddRows = false;
            this.spentToEstimateGridView.AllowUserToDeleteRows = false;
            this.spentToEstimateGridView.AllowUserToOrderColumns = true;
            this.spentToEstimateGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spentToEstimateGridView.Location = new System.Drawing.Point(6, 19);
            this.spentToEstimateGridView.Name = "spentToEstimateGridView";
            this.spentToEstimateGridView.ReadOnly = true;
            this.spentToEstimateGridView.Size = new System.Drawing.Size(948, 288);
            this.spentToEstimateGridView.TabIndex = 0;
            // 
            // onFixGridView
            // 
            this.onFixGridView.AllowUserToAddRows = false;
            this.onFixGridView.AllowUserToDeleteRows = false;
            this.onFixGridView.AllowUserToOrderColumns = true;
            this.onFixGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.onFixGridView.Location = new System.Drawing.Point(6, 19);
            this.onFixGridView.Name = "onFixGridView";
            this.onFixGridView.ReadOnly = true;
            this.onFixGridView.Size = new System.Drawing.Size(948, 288);
            this.onFixGridView.TabIndex = 0;
            // 
            // outOfHoursGridView
            // 
            this.outOfHoursGridView.AllowUserToAddRows = false;
            this.outOfHoursGridView.AllowUserToDeleteRows = false;
            this.outOfHoursGridView.AllowUserToOrderColumns = true;
            this.outOfHoursGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outOfHoursGridView.Location = new System.Drawing.Point(6, 19);
            this.outOfHoursGridView.Name = "outOfHoursGridView";
            this.outOfHoursGridView.ReadOnly = true;
            this.outOfHoursGridView.Size = new System.Drawing.Size(948, 288);
            this.outOfHoursGridView.TabIndex = 1;
            // 
            // estimateTimeByRevisionGridView
            // 
            this.estimateTimeByRevisionGridView.AllowUserToAddRows = false;
            this.estimateTimeByRevisionGridView.AllowUserToDeleteRows = false;
            this.estimateTimeByRevisionGridView.AllowUserToOrderColumns = true;
            this.estimateTimeByRevisionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estimateTimeByRevisionGridView.Location = new System.Drawing.Point(6, 18);
            this.estimateTimeByRevisionGridView.Name = "estimateTimeByRevisionGridView";
            this.estimateTimeByRevisionGridView.ReadOnly = true;
            this.estimateTimeByRevisionGridView.Size = new System.Drawing.Size(948, 288);
            this.estimateTimeByRevisionGridView.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spentTimeGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 318);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оценка выполнения задач (S > 6; J < 2)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spentToEstimateGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(964, 318);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отношение затраченного времни к оценке времени (S < 1; J > 1.5)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.onFixGridView);
            this.groupBox3.Location = new System.Drawing.Point(12, 660);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(964, 318);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Число задач, вернувшихся к доработке ко всем задачам (S < 0.1; J > 0.2)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.outOfHoursGridView);
            this.groupBox4.Location = new System.Drawing.Point(12, 984);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(964, 318);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Число смен статусов задач в нерабочее время (S > 0.15; J < 0.05)";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.estimateTimeByRevisionGridView);
            this.groupBox5.Location = new System.Drawing.Point(12, 1308);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(964, 318);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Среднее число оценочных часов на одну ревизию (J < 2; S > 4)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1004, 681);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.spentTimeGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spentToEstimateGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onFixGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outOfHoursGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateTimeByRevisionGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView spentTimeGridView;
        private System.Windows.Forms.DataGridView spentToEstimateGridView;
        private System.Windows.Forms.DataGridView onFixGridView;
        private System.Windows.Forms.DataGridView outOfHoursGridView;
        private System.Windows.Forms.DataGridView estimateTimeByRevisionGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

