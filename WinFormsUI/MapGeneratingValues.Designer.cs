namespace WinFormsUI
{
    partial class MapGeneratingValues
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
            label1 = new Label();
            cancelButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            generateButton = new Button();
            button1 = new Button();
            button2 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 0;
            label1.Text = "Rows";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(12, 116);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(61, 29);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(42, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(62, 39);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(42, 27);
            textBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 3;
            label2.Text = "Cols";
            // 
            // generateButton
            // 
            generateButton.Location = new Point(79, 116);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(82, 29);
            generateButton.TabIndex = 5;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += okButton_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(110, 6);
            button1.Name = "button1";
            button1.Size = new Size(51, 29);
            button1.TabIndex = 6;
            button1.Text = "Min";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(110, 38);
            button2.Name = "button2";
            button2.Size = new Size(51, 29);
            button2.TabIndex = 7;
            button2.Text = "Max";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(62, 73);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(99, 27);
            textBox3.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 8;
            label3.Text = "Name";
            // 
            // MapGenerating
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(173, 157);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(generateButton);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(cancelButton);
            Controls.Add(label1);
            Text = "MapGeneratingValues";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button cancelButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Button generateButton;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private Label label3;
    }
}