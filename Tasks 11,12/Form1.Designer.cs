namespace Tasks_11_12
{
    partial class Sudoku
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonImport = new System.Windows.Forms.Button();
            this.ButtonNewGame = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonUnlock = new System.Windows.Forms.Button();
            this.ButtonCaptureCondition = new System.Windows.Forms.Button();
            this.ButtonAutoSolution = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonImport);
            this.groupBox1.Controls.Add(this.ButtonNewGame);
            this.groupBox1.Controls.Add(this.ButtonSave);
            this.groupBox1.Controls.Add(this.ButtonUnlock);
            this.groupBox1.Controls.Add(this.ButtonCaptureCondition);
            this.groupBox1.Controls.Add(this.ButtonAutoSolution);
            this.groupBox1.Location = new System.Drawing.Point(113, 886);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 291);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Элементы управления";
            // 
            // ButtonImport
            // 
            this.ButtonImport.Location = new System.Drawing.Point(480, 142);
            this.ButtonImport.Name = "ButtonImport";
            this.ButtonImport.Size = new System.Drawing.Size(222, 78);
            this.ButtonImport.TabIndex = 5;
            this.ButtonImport.Text = "Загрузить решение";
            this.ButtonImport.UseVisualStyleBackColor = true;
            this.ButtonImport.Click += new System.EventHandler(this.ButtonImport_Click);
            // 
            // ButtonNewGame
            // 
            this.ButtonNewGame.Location = new System.Drawing.Point(252, 58);
            this.ButtonNewGame.Name = "ButtonNewGame";
            this.ButtonNewGame.Size = new System.Drawing.Size(222, 78);
            this.ButtonNewGame.TabIndex = 1;
            this.ButtonNewGame.Text = "Новая игра";
            this.ButtonNewGame.UseVisualStyleBackColor = true;
            this.ButtonNewGame.Click += new System.EventHandler(this.ButtonNewGame_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(252, 142);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(222, 78);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "Сохранить решение";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonUnlock
            // 
            this.ButtonUnlock.Location = new System.Drawing.Point(24, 142);
            this.ButtonUnlock.Name = "ButtonUnlock";
            this.ButtonUnlock.Size = new System.Drawing.Size(222, 78);
            this.ButtonUnlock.TabIndex = 3;
            this.ButtonUnlock.Text = "Разблокирвоать ячейки";
            this.ButtonUnlock.UseVisualStyleBackColor = true;
            this.ButtonUnlock.Click += new System.EventHandler(this.ButtonUnlock_Click);
            // 
            // ButtonCaptureCondition
            // 
            this.ButtonCaptureCondition.Location = new System.Drawing.Point(480, 58);
            this.ButtonCaptureCondition.Name = "ButtonCaptureCondition";
            this.ButtonCaptureCondition.Size = new System.Drawing.Size(222, 78);
            this.ButtonCaptureCondition.TabIndex = 2;
            this.ButtonCaptureCondition.Text = "Условие введено";
            this.ButtonCaptureCondition.UseVisualStyleBackColor = true;
            this.ButtonCaptureCondition.Click += new System.EventHandler(this.ButtonCaptureCondition_Click);
            // 
            // ButtonAutoSolution
            // 
            this.ButtonAutoSolution.Location = new System.Drawing.Point(24, 58);
            this.ButtonAutoSolution.Name = "ButtonAutoSolution";
            this.ButtonAutoSolution.Size = new System.Drawing.Size(222, 78);
            this.ButtonAutoSolution.TabIndex = 0;
            this.ButtonAutoSolution.Text = "Автоматическое решение";
            this.ButtonAutoSolution.UseVisualStyleBackColor = true;
            this.ButtonAutoSolution.Click += new System.EventHandler(this.ButtonAutoSolution_Click);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(974, 1209);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sudoku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Судоку";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonCaptureCondition;
        private System.Windows.Forms.Button ButtonNewGame;
        private System.Windows.Forms.Button ButtonAutoSolution;
        private System.Windows.Forms.Button ButtonImport;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonUnlock;
    }
}

