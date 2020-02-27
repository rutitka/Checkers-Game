namespace GameInterface
{
    public partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.BoardSize = new System.Windows.Forms.Label();
            this.radioButtonSize6x6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize8x8 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize10x10 = new System.Windows.Forms.RadioButton();
            this.Players = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(9, 9);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(61, 13);
            this.BoardSize.TabIndex = 0;
            this.BoardSize.Text = "Board Size:";
            // 
            // radioButtonSize6x6
            // 
            this.radioButtonSize6x6.AutoSize = true;
            this.radioButtonSize6x6.Location = new System.Drawing.Point(22, 25);
            this.radioButtonSize6x6.Name = "radioButtonSize6x6";
            this.radioButtonSize6x6.Size = new System.Drawing.Size(48, 17);
            this.radioButtonSize6x6.TabIndex = 1;
            this.radioButtonSize6x6.TabStop = true;
            this.radioButtonSize6x6.Text = "6 x 6";
            this.radioButtonSize6x6.UseVisualStyleBackColor = true;
            this.radioButtonSize6x6.CheckedChanged += new System.EventHandler(this.radioButtonSize6x6_CheckedChanged);
            // 
            // radioButtonSize8x8
            // 
            this.radioButtonSize8x8.AutoSize = true;
            this.radioButtonSize8x8.Location = new System.Drawing.Point(76, 25);
            this.radioButtonSize8x8.Name = "radioButtonSize8x8";
            this.radioButtonSize8x8.Size = new System.Drawing.Size(48, 17);
            this.radioButtonSize8x8.TabIndex = 2;
            this.radioButtonSize8x8.TabStop = true;
            this.radioButtonSize8x8.Text = "8 x 8";
            this.radioButtonSize8x8.UseVisualStyleBackColor = true;
            this.radioButtonSize8x8.CheckedChanged += new System.EventHandler(this.radioButtonSize8x8_CheckedChanged);
            // 
            // radioButtonSize10x10
            // 
            this.radioButtonSize10x10.AutoSize = true;
            this.radioButtonSize10x10.Location = new System.Drawing.Point(130, 25);
            this.radioButtonSize10x10.Name = "radioButtonSize10x10";
            this.radioButtonSize10x10.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSize10x10.TabIndex = 3;
            this.radioButtonSize10x10.TabStop = true;
            this.radioButtonSize10x10.Text = "10 x 10";
            this.radioButtonSize10x10.UseVisualStyleBackColor = true;
            this.radioButtonSize10x10.CheckedChanged += new System.EventHandler(this.radioButtonSize10x10_CheckedChanged);
            // 
            // Players
            // 
            this.Players.AutoSize = true;
            this.Players.Location = new System.Drawing.Point(9, 50);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(44, 13);
            this.Players.TabIndex = 4;
            this.Players.Text = "Players:";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(19, 75);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(45, 13);
            this.Player1.TabIndex = 5;
            this.Player1.Text = "Player1:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(22, 102);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(64, 17);
            this.checkBoxPlayer2.TabIndex = 8;
            this.checkBoxPlayer2.Text = "Player2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.HideSelection = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(90, 100);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.ReadOnly = true;
            this.textBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer2.TabIndex = 9;
            this.textBoxPlayer2.Text = "Computer";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(115, 136);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(90, 68);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayer1.TabIndex = 11;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 174);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.Players);
            this.Controls.Add(this.radioButtonSize10x10);
            this.Controls.Add(this.radioButtonSize8x8);
            this.Controls.Add(this.radioButtonSize6x6);
            this.Controls.Add(this.BoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers game login";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.RadioButton radioButtonSize6x6;
        private System.Windows.Forms.RadioButton radioButtonSize8x8;
        private System.Windows.Forms.RadioButton radioButtonSize10x10;
        private System.Windows.Forms.Label Players;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxPlayer1;
    }
}