namespace IADP.MoHra.UI
{
    partial class ClassificationForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.codePointsLabel = new System.Windows.Forms.Label();
            this.databasePointsLabel = new System.Windows.Forms.Label();
            this.experienceLabel = new System.Windows.Forms.Label();
            this.educationLabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.codePoints = new System.Windows.Forms.TextBox();
            this.databasePoints = new System.Windows.Forms.TextBox();
            this.experience = new System.Windows.Forms.TextBox();
            this.education = new System.Windows.Forms.TextBox();
            this.getClassBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(16, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "ФИО";
            // 
            // codePointsLabel
            // 
            this.codePointsLabel.AutoSize = true;
            this.codePointsLabel.Location = new System.Drawing.Point(16, 42);
            this.codePointsLabel.Name = "codePointsLabel";
            this.codePointsLabel.Size = new System.Drawing.Size(134, 13);
            this.codePointsLabel.TabIndex = 0;
            this.codePointsLabel.Text = "Колличество баллов (C#)";
            // 
            // databasePointsLabel
            // 
            this.databasePointsLabel.AutoSize = true;
            this.databasePointsLabel.Location = new System.Drawing.Point(16, 68);
            this.databasePointsLabel.Name = "databasePointsLabel";
            this.databasePointsLabel.Size = new System.Drawing.Size(157, 13);
            this.databasePointsLabel.TabIndex = 0;
            this.databasePointsLabel.Text = "Колличество баллов (MSSQL)";
            // 
            // experienceLabel
            // 
            this.experienceLabel.AutoSize = true;
            this.experienceLabel.Location = new System.Drawing.Point(16, 94);
            this.experienceLabel.Name = "experienceLabel";
            this.experienceLabel.Size = new System.Drawing.Size(74, 13);
            this.experienceLabel.TabIndex = 0;
            this.experienceLabel.Text = "Опыт работы";
            // 
            // educationLabel
            // 
            this.educationLabel.AutoSize = true;
            this.educationLabel.Location = new System.Drawing.Point(16, 120);
            this.educationLabel.Name = "educationLabel";
            this.educationLabel.Size = new System.Drawing.Size(75, 13);
            this.educationLabel.TabIndex = 0;
            this.educationLabel.Text = "Образование";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(182, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(157, 20);
            this.name.TabIndex = 1;
            // 
            // codePoints
            // 
            this.codePoints.Location = new System.Drawing.Point(182, 39);
            this.codePoints.Name = "codePoints";
            this.codePoints.Size = new System.Drawing.Size(157, 20);
            this.codePoints.TabIndex = 1;
            // 
            // databasePoints
            // 
            this.databasePoints.Location = new System.Drawing.Point(182, 65);
            this.databasePoints.Name = "databasePoints";
            this.databasePoints.Size = new System.Drawing.Size(157, 20);
            this.databasePoints.TabIndex = 1;
            // 
            // experience
            // 
            this.experience.Location = new System.Drawing.Point(182, 91);
            this.experience.Name = "experience";
            this.experience.Size = new System.Drawing.Size(157, 20);
            this.experience.TabIndex = 1;
            // 
            // education
            // 
            this.education.Location = new System.Drawing.Point(182, 117);
            this.education.Name = "education";
            this.education.Size = new System.Drawing.Size(157, 20);
            this.education.TabIndex = 1;
            // 
            // getClassBtn
            // 
            this.getClassBtn.Location = new System.Drawing.Point(19, 146);
            this.getClassBtn.Name = "getClassBtn";
            this.getClassBtn.Size = new System.Drawing.Size(320, 23);
            this.getClassBtn.TabIndex = 2;
            this.getClassBtn.Text = "Определить класс";
            this.getClassBtn.UseVisualStyleBackColor = true;
            this.getClassBtn.Click += new System.EventHandler(this.getClassBtn_Click);
            // 
            // ClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 183);
            this.Controls.Add(this.getClassBtn);
            this.Controls.Add(this.education);
            this.Controls.Add(this.experience);
            this.Controls.Add(this.databasePoints);
            this.Controls.Add(this.codePoints);
            this.Controls.Add(this.name);
            this.Controls.Add(this.educationLabel);
            this.Controls.Add(this.experienceLabel);
            this.Controls.Add(this.databasePointsLabel);
            this.Controls.Add(this.codePointsLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "ClassificationForm";
            this.Text = "Классификация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label codePointsLabel;
        private System.Windows.Forms.Label databasePointsLabel;
        private System.Windows.Forms.Label experienceLabel;
        private System.Windows.Forms.Label educationLabel;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox codePoints;
        private System.Windows.Forms.TextBox databasePoints;
        private System.Windows.Forms.TextBox experience;
        private System.Windows.Forms.TextBox education;
        private System.Windows.Forms.Button getClassBtn;
    }
}