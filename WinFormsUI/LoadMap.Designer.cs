namespace WinFormsUI
{
    partial class LoadMap
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
            mapsGridView = new DataGridView();
            loadButton = new Button();
            label1 = new Label();
            mapCountLabel = new Label();
            deleteButton = new Button();
            generateButton = new Button();
            renameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)mapsGridView).BeginInit();
            SuspendLayout();
            // 
            // mapsGridView
            // 
            mapsGridView.AllowUserToAddRows = false;
            mapsGridView.AllowUserToDeleteRows = false;
            mapsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mapsGridView.Location = new Point(103, 12);
            mapsGridView.Name = "mapsGridView";
            mapsGridView.ReadOnly = true;
            mapsGridView.RowHeadersWidth = 51;
            mapsGridView.Size = new Size(430, 316);
            mapsGridView.TabIndex = 0;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(12, 81);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(85, 64);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 288);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "Total maps";
            // 
            // mapCountLabel
            // 
            mapCountLabel.AutoSize = true;
            mapCountLabel.Location = new Point(12, 308);
            mapCountLabel.Name = "mapCountLabel";
            mapCountLabel.Size = new Size(0, 20);
            mapCountLabel.TabIndex = 3;
            mapCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(12, 151);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(85, 64);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(12, 12);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(85, 64);
            generateButton.TabIndex = 5;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // renameButton
            // 
            renameButton.Location = new Point(12, 221);
            renameButton.Name = "renameButton";
            renameButton.Size = new Size(85, 64);
            renameButton.TabIndex = 6;
            renameButton.Text = "Rename";
            renameButton.UseVisualStyleBackColor = true;
            renameButton.Click += renameButton_Click;
            // 
            // LoadMap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 356);
            Controls.Add(renameButton);
            Controls.Add(generateButton);
            Controls.Add(deleteButton);
            Controls.Add(mapCountLabel);
            Controls.Add(label1);
            Controls.Add(loadButton);
            Controls.Add(mapsGridView);
            Name = "LoadMap";
            Text = "LoadMap";
            Load += LoadMap_Load;
            ((System.ComponentModel.ISupportInitialize)mapsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView mapsGridView;
        private Button loadButton;
        private Label label1;
        private Label mapCountLabel;
        private Button deleteButton;
        private Button generateButton;
        private Button renameButton;
    }
}