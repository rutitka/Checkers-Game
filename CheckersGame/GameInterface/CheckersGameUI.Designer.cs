namespace GameInterface
{
    public partial class CheckersGameUI
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
            this.labelPlayer1Score = new System.Windows.Forms.Label();
            this.labelPlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayer1Score
            // 
            this.labelPlayer1Score.AutoSize = true;
            this.labelPlayer1Score.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer1Score.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Score.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPlayer1Score.Location = new System.Drawing.Point(41, 14);
            this.labelPlayer1Score.Name = "labelPlayer1Score";
            this.labelPlayer1Score.Size = new System.Drawing.Size(76, 17);
            this.labelPlayer1Score.TabIndex = 2;
            this.labelPlayer1Score.Text = "Player1: ";
            // 
            // labelPlayer2Score
            // 
            this.labelPlayer2Score.AutoSize = true;
            this.labelPlayer2Score.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayer2Score.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Score.Location = new System.Drawing.Point(41, 43);
            this.labelPlayer2Score.Name = "labelPlayer2Score";
            this.labelPlayer2Score.Size = new System.Drawing.Size(80, 17);
            this.labelPlayer2Score.TabIndex = 3;
            this.labelPlayer2Score.Text = "Player2: ";
            // 
            // CheckersGameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::GameInterface.Properties.Resources.ActiveSquare;
            this.ClientSize = new System.Drawing.Size(362, 382);
            this.Controls.Add(this.labelPlayer2Score);
            this.Controls.Add(this.labelPlayer1Score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CheckersGameUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers";
            this.Load += new System.EventHandler(this.GameBoardUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPlayer1Score;
        private System.Windows.Forms.Label labelPlayer2Score;
    }
}