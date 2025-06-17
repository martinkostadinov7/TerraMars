namespace WinFormsUI
{
    partial class mainMenu
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
            matrixGridView = new DataGridView();
            label4 = new Label();
            label7 = new Label();
            label8 = new Label();
            xLabel = new Label();
            yLabel = new Label();
            loginButton = new Button();
            actionSelectComboBox = new ComboBox();
            placeButton = new Button();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            mapsButton = new Button();
            removeButton = new Button();
            label2 = new Label();
            label3 = new Label();
            stoneCountLabel = new Label();
            laserButton = new Button();
            ((System.ComponentModel.ISupportInitialize)matrixGridView).BeginInit();
            SuspendLayout();
            // 
            // matrixGridView
            // 
            matrixGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrixGridView.Location = new Point(97, 11);
            matrixGridView.Name = "matrixGridView";
            matrixGridView.RowHeadersWidth = 51;
            matrixGridView.Size = new Size(579, 336);
            matrixGridView.TabIndex = 0;
            matrixGridView.CellClick += matrixGridView_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(5, 342);
            label4.Name = "label4";
            label4.Size = new Size(0, 17);
            label4.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(7, 304);
            label7.Name = "label7";
            label7.Size = new Size(16, 20);
            label7.TabIndex = 16;
            label7.Text = "x";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(51, 304);
            label8.Name = "label8";
            label8.Size = new Size(16, 20);
            label8.TabIndex = 17;
            label8.Text = "y";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.BackColor = Color.Transparent;
            xLabel.Location = new Point(29, 304);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(0, 20);
            xLabel.TabIndex = 18;
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new Point(67, 304);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(0, 20);
            yLabel.TabIndex = 19;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(7, 12);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(84, 50);
            loginButton.TabIndex = 20;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // actionSelectComboBox
            // 
            actionSelectComboBox.FormattingEnabled = true;
            actionSelectComboBox.Location = new Point(7, 153);
            actionSelectComboBox.Name = "actionSelectComboBox";
            actionSelectComboBox.Size = new Size(84, 28);
            actionSelectComboBox.TabIndex = 25;
            // 
            // placeButton
            // 
            placeButton.Location = new Point(7, 187);
            placeButton.Name = "placeButton";
            placeButton.Size = new Size(84, 29);
            placeButton.TabIndex = 26;
            placeButton.Text = "Place";
            placeButton.UseVisualStyleBackColor = true;
            placeButton.Click += placeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 130);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 27;
            label1.Text = "Structure";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 324);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 29;
            label5.Text = "Seleced Tile";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 287);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 30;
            label6.Text = "Tile Coords";
            // 
            // mapsButton
            // 
            mapsButton.Location = new Point(7, 68);
            mapsButton.Name = "mapsButton";
            mapsButton.Size = new Size(84, 50);
            mapsButton.TabIndex = 33;
            mapsButton.Text = "Maps";
            mapsButton.UseVisualStyleBackColor = true;
            mapsButton.Click += mapsButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(7, 222);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(84, 29);
            removeButton.TabIndex = 34;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 381);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 35;
            label2.Text = "Resources";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 405);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 36;
            label3.Text = "Stone";
            // 
            // stoneCountLabel
            // 
            stoneCountLabel.AutoSize = true;
            stoneCountLabel.Location = new Point(51, 405);
            stoneCountLabel.Name = "stoneCountLabel";
            stoneCountLabel.Size = new Size(17, 20);
            stoneCountLabel.TabIndex = 37;
            stoneCountLabel.Text = "0";
            // 
            // laserButton
            // 
            laserButton.Location = new Point(7, 257);
            laserButton.Name = "laserButton";
            laserButton.Size = new Size(84, 29);
            laserButton.TabIndex = 38;
            laserButton.Text = "Laser";
            laserButton.UseVisualStyleBackColor = true;
            laserButton.Click += laserButton_Click;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 440);
            Controls.Add(laserButton);
            Controls.Add(stoneCountLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(removeButton);
            Controls.Add(mapsButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(placeButton);
            Controls.Add(actionSelectComboBox);
            Controls.Add(loginButton);
            Controls.Add(yLabel);
            Controls.Add(xLabel);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(matrixGridView);
            Name = "mainMenu";
            Text = "Form1";
            Load += menuLoad;
            ((System.ComponentModel.ISupportInitialize)matrixGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView matrixGridView;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label xLabel;
        private Label yLabel;
        private Button loginButton;
        private ComboBox actionSelectComboBox;
        private Button placeButton;
        private Label label1;
        private Label label5;
        private Label label6;
        private Button mapsButton;
        private Button removeButton;
        private Label label2;
        private Label label3;
        private Label stoneCountLabel;
        private Button laserButton;
    }
}
