namespace Dice_Rolling
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.setPlayer1NameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player1TextBox = new System.Windows.Forms.ToolStripTextBox();
            this.setPlayer2NameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player2TextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rollButton = new System.Windows.Forms.Button();
            this.standButton = new System.Windows.Forms.Button();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.rolledTextBox = new System.Windows.Forms.TextBox();
            this.total2TextBox = new System.Windows.Forms.TextBox();
            this.total1TextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.player2Label = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.playerSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(200, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // playerSettingsToolStripMenuItem
            // 
            this.playerSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ofPlayersToolStripMenuItem,
            this.setPlayer1NameToolStripMenuItem,
            this.setPlayer2NameToolStripMenuItem});
            this.playerSettingsToolStripMenuItem.Name = "playerSettingsToolStripMenuItem";
            this.playerSettingsToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.playerSettingsToolStripMenuItem.Text = "Player Settings";
            // 
            // ofPlayersToolStripMenuItem
            // 
            this.ofPlayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.ofPlayersToolStripMenuItem.Name = "ofPlayersToolStripMenuItem";
            this.ofPlayersToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ofPlayersToolStripMenuItem.Text = "Set Number of players";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // setPlayer1NameToolStripMenuItem
            // 
            this.setPlayer1NameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player1TextBox});
            this.setPlayer1NameToolStripMenuItem.Name = "setPlayer1NameToolStripMenuItem";
            this.setPlayer1NameToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.setPlayer1NameToolStripMenuItem.Text = "Set player 1 name";
            // 
            // player1TextBox
            // 
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(100, 23);
            this.player1TextBox.Text = "Player 1";
            this.player1TextBox.TextChanged += new System.EventHandler(this.playerTextBox_TextChanged);
            // 
            // setPlayer2NameToolStripMenuItem
            // 
            this.setPlayer2NameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player2TextBox});
            this.setPlayer2NameToolStripMenuItem.Name = "setPlayer2NameToolStripMenuItem";
            this.setPlayer2NameToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.setPlayer2NameToolStripMenuItem.Text = "Set Player 2 Name";
            // 
            // player2TextBox
            // 
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(100, 23);
            this.player2TextBox.Text = "Bot";
            this.player2TextBox.TextChanged += new System.EventHandler(this.playerTextBox_TextChanged);
            // 
            // rollButton
            // 
            this.rollButton.Location = new System.Drawing.Point(24, 184);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(75, 23);
            this.rollButton.TabIndex = 1;
            this.rollButton.Text = "Roll";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // standButton
            // 
            this.standButton.Location = new System.Drawing.Point(105, 184);
            this.standButton.Name = "standButton";
            this.standButton.Size = new System.Drawing.Size(75, 23);
            this.standButton.TabIndex = 2;
            this.standButton.Text = "Stand";
            this.standButton.UseVisualStyleBackColor = true;
            this.standButton.Click += new System.EventHandler(this.standButton_Click);
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.Location = new System.Drawing.Point(93, 19);
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.Size = new System.Drawing.Size(75, 20);
            this.pointsTextBox.TabIndex = 3;
            this.pointsTextBox.Text = "0";
            this.pointsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rolledTextBox
            // 
            this.rolledTextBox.Location = new System.Drawing.Point(93, 61);
            this.rolledTextBox.Name = "rolledTextBox";
            this.rolledTextBox.Size = new System.Drawing.Size(75, 20);
            this.rolledTextBox.TabIndex = 4;
            this.rolledTextBox.Text = "0";
            this.rolledTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // total2TextBox
            // 
            this.total2TextBox.Location = new System.Drawing.Point(93, 32);
            this.total2TextBox.Name = "total2TextBox";
            this.total2TextBox.Size = new System.Drawing.Size(75, 20);
            this.total2TextBox.TabIndex = 5;
            this.total2TextBox.Text = "0";
            this.total2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // total1TextBox
            // 
            this.total1TextBox.Location = new System.Drawing.Point(12, 32);
            this.total1TextBox.Name = "total1TextBox";
            this.total1TextBox.Size = new System.Drawing.Size(75, 20);
            this.total1TextBox.TabIndex = 6;
            this.total1TextBox.Text = "0";
            this.total1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.turnLabel);
            this.groupBox1.Controls.Add(this.rolledTextBox);
            this.groupBox1.Controls.Add(this.pointsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Turn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Points :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rolled :";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(6, 43);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(45, 13);
            this.turnLabel.TabIndex = 5;
            this.turnLabel.Text = "Player 1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.player2Label);
            this.groupBox2.Controls.Add(this.player1Label);
            this.groupBox2.Controls.Add(this.total1TextBox);
            this.groupBox2.Controls.Add(this.total2TextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 58);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scores";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(90, 16);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(23, 13);
            this.player2Label.TabIndex = 9;
            this.player2Label.Text = "Bot";
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(9, 16);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(45, 13);
            this.player1Label.TabIndex = 8;
            this.player1Label.Text = "Player 1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 217);
            this.Controls.Add(this.standButton);
            this.Controls.Add(this.rollButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ofPlayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem setPlayer1NameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPlayer2NameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox player1TextBox;
        private System.Windows.Forms.ToolStripTextBox player2TextBox;
        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Button standButton;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.TextBox rolledTextBox;
        private System.Windows.Forms.TextBox total2TextBox;
        private System.Windows.Forms.TextBox total1TextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Timer timer1;
    }
}

