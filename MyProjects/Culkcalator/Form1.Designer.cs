namespace Culkcalator
{
    partial class Culcalator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Culcalator));
            Number1 = new Button();
            Number7 = new Button();
            Number4 = new Button();
            Number5 = new Button();
            Number3 = new Button();
            Number2 = new Button();
            Number6 = new Button();
            Number8 = new Button();
            Number9 = new Button();
            Number0 = new Button();
            button2 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            textBox = new TextBox();
            Number10 = new Button();
            Clear = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // Number1
            // 
            Number1.Location = new Point(90, 100);
            Number1.Name = "Number1";
            Number1.Size = new Size(72, 64);
            Number1.TabIndex = 0;
            Number1.Text = "1";
            Number1.UseVisualStyleBackColor = true;
            Number1.Click += Num1;
            // 
            // Number7
            // 
            Number7.Location = new Point(90, 240);
            Number7.Name = "Number7";
            Number7.Size = new Size(72, 64);
            Number7.TabIndex = 2;
            Number7.Text = "7";
            Number7.UseVisualStyleBackColor = true;
            Number7.Click += Num7;
            // 
            // Number4
            // 
            Number4.Location = new Point(90, 170);
            Number4.Name = "Number4";
            Number4.Size = new Size(72, 64);
            Number4.TabIndex = 3;
            Number4.Text = "4";
            Number4.UseVisualStyleBackColor = true;
            Number4.Click += Num4;
            // 
            // Number5
            // 
            Number5.Location = new Point(168, 170);
            Number5.Name = "Number5";
            Number5.Size = new Size(72, 64);
            Number5.TabIndex = 4;
            Number5.Text = "5";
            Number5.UseVisualStyleBackColor = true;
            Number5.Click += Num5;
            // 
            // Number3
            // 
            Number3.Location = new Point(12, 170);
            Number3.Name = "Number3";
            Number3.Size = new Size(72, 64);
            Number3.TabIndex = 5;
            Number3.Text = "3";
            Number3.UseVisualStyleBackColor = true;
            // 
            // Number2
            // 
            Number2.Location = new Point(168, 100);
            Number2.Name = "Number2";
            Number2.Size = new Size(72, 64);
            Number2.TabIndex = 6;
            Number2.Text = "2";
            Number2.UseVisualStyleBackColor = true;
            Number2.Click += Num2;
            // 
            // Number6
            // 
            Number6.Location = new Point(12, 240);
            Number6.Name = "Number6";
            Number6.Size = new Size(72, 64);
            Number6.TabIndex = 7;
            Number6.Text = "6";
            Number6.UseVisualStyleBackColor = true;
            Number6.Click += Num6;
            // 
            // Number8
            // 
            Number8.Location = new Point(168, 240);
            Number8.Name = "Number8";
            Number8.Size = new Size(72, 64);
            Number8.TabIndex = 8;
            Number8.Text = "8";
            Number8.UseVisualStyleBackColor = true;
            Number8.Click += Num8;
            // 
            // Number9
            // 
            Number9.Location = new Point(12, 310);
            Number9.Name = "Number9";
            Number9.Size = new Size(72, 64);
            Number9.TabIndex = 9;
            Number9.Text = "9";
            Number9.UseVisualStyleBackColor = true;
            Number9.Click += Num9;
            // 
            // Number0
            // 
            Number0.Location = new Point(168, 310);
            Number0.Name = "Number0";
            Number0.Size = new Size(72, 64);
            Number0.TabIndex = 10;
            Number0.Text = "0";
            Number0.UseVisualStyleBackColor = true;
            Number0.Click += Num0;
            // 
            // button2
            // 
            button2.Location = new Point(246, 151);
            button2.Name = "button2";
            button2.Size = new Size(51, 45);
            button2.TabIndex = 11;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OperatorPlus;
            // 
            // button12
            // 
            button12.Location = new Point(246, 202);
            button12.Name = "button12";
            button12.Size = new Size(51, 45);
            button12.TabIndex = 12;
            button12.Text = "-";
            button12.UseVisualStyleBackColor = true;
            button12.Click += OperatorMinus;
            // 
            // button13
            // 
            button13.Location = new Point(246, 250);
            button13.Name = "button13";
            button13.Size = new Size(51, 45);
            button13.TabIndex = 13;
            button13.Text = "/";
            button13.UseVisualStyleBackColor = true;
            button13.Click += OperatorDivision;
            // 
            // button14
            // 
            button14.Location = new Point(246, 301);
            button14.Name = "button14";
            button14.Size = new Size(51, 45);
            button14.TabIndex = 14;
            button14.Text = "*";
            button14.UseVisualStyleBackColor = true;
            button14.Click += OperatorMultiplication;
            // 
            // textBox
            // 
            textBox.Font = new Font("Segoe UI", 25F);
            textBox.Location = new Point(5, 12);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(289, 67);
            textBox.TabIndex = 15;
            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.TextChanged += TextBox;
            // 
            // Number10
            // 
            Number10.Location = new Point(90, 310);
            Number10.Name = "Number10";
            Number10.Size = new Size(72, 64);
            Number10.TabIndex = 16;
            Number10.Text = "10";
            Number10.UseVisualStyleBackColor = true;
            Number10.Click += Num10;
            // 
            // Clear
            // 
            Clear.Location = new Point(12, 100);
            Clear.Name = "Clear";
            Clear.Size = new Size(72, 64);
            Clear.TabIndex = 17;
            Clear.Text = "C";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += TextBoxClear;
            // 
            // button1
            // 
            button1.Location = new Point(246, 100);
            button1.Name = "button1";
            button1.Size = new Size(51, 45);
            button1.TabIndex = 18;
            button1.Text = "=";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Result;
            // 
            // Culcalator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(306, 401);
            Controls.Add(button1);
            Controls.Add(Clear);
            Controls.Add(Number10);
            Controls.Add(textBox);
            Controls.Add(button14);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button2);
            Controls.Add(Number0);
            Controls.Add(Number9);
            Controls.Add(Number8);
            Controls.Add(Number6);
            Controls.Add(Number2);
            Controls.Add(Number3);
            Controls.Add(Number5);
            Controls.Add(Number4);
            Controls.Add(Number7);
            Controls.Add(Number1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Culcalator";
            RightToLeft = RightToLeft.No;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Number1;
        private Button Number7;
        private Button Number4;
        private Button Number5;
        private Button Number3;
        private Button Number2;
        private Button Number6;
        private Button Number8;
        private Button Number9;
        private Button Number0;
        private Button button2;
        private Button button12;
        private Button button13;
        private Button button14;
        private TextBox textBox;
        private Button Number10;
        private Button Clear;
        private Button button1;
    }
}
