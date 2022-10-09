namespace GeniyIdiotWinFormsApp
{
    partial class mainForm
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
            this.nextButton = new System.Windows.Forms.Button();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionTextLabel = new System.Windows.Forms.Label();
            this.userAnswerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextButton.Location = new System.Drawing.Point(216, 349);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(196, 80);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Далее";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Location = new System.Drawing.Point(12, 10);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(79, 17);
            this.questionNumberLabel.TabIndex = 1;
            this.questionNumberLabel.Text = "Вопрос № 1";
            // 
            // questionTextLabel
            // 
            this.questionTextLabel.AutoSize = true;
            this.questionTextLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.questionTextLabel.Location = new System.Drawing.Point(12, 88);
            this.questionTextLabel.Name = "questionTextLabel";
            this.questionTextLabel.Size = new System.Drawing.Size(124, 19);
            this.questionTextLabel.TabIndex = 2;
            this.questionTextLabel.Text = "Текст вопроса";
            // 
            // userAnswerTextBox
            // 
            this.userAnswerTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userAnswerTextBox.Location = new System.Drawing.Point(12, 187);
            this.userAnswerTextBox.Name = "userAnswerTextBox";
            this.userAnswerTextBox.Size = new System.Drawing.Size(236, 25);
            this.userAnswerTextBox.TabIndex = 3;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 510);
            this.Controls.Add(this.userAnswerTextBox);
            this.Controls.Add(this.questionTextLabel);
            this.Controls.Add(this.questionNumberLabel);
            this.Controls.Add(this.nextButton);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Name = "mainForm";
            this.Text = "Гений Идиот";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button nextButton;
        private Label questionNumberLabel;
        private Label questionTextLabel;
        private TextBox userAnswerTextBox;
    }
}