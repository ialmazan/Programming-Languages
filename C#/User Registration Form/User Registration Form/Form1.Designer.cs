namespace User_Registration_Form
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
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.specialtyBox = new System.Windows.Forms.ComboBox();
            this.majorBox = new System.Windows.Forms.ComboBox();
            this.confirmPasswordBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.passwordCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameBox
            // 
            this.firstNameBox.Location = new System.Drawing.Point(100, 12);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(126, 20);
            this.firstNameBox.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Load Last";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Specialty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Major";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Conf. Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "First Name";
            // 
            // specialtyBox
            // 
            this.specialtyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.specialtyBox.FormattingEnabled = true;
            this.specialtyBox.Location = new System.Drawing.Point(100, 181);
            this.specialtyBox.Name = "specialtyBox";
            this.specialtyBox.Size = new System.Drawing.Size(147, 21);
            this.specialtyBox.TabIndex = 6;
            // 
            // majorBox
            // 
            this.majorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.majorBox.FormattingEnabled = true;
            this.majorBox.Items.AddRange(new object[] {
            "ComputerScience",
            "Mathematics",
            "Physics",
            "Biology",
            "Economics"});
            this.majorBox.Location = new System.Drawing.Point(100, 154);
            this.majorBox.Name = "majorBox";
            this.majorBox.Size = new System.Drawing.Size(147, 21);
            this.majorBox.TabIndex = 5;
            this.majorBox.SelectedIndexChanged += new System.EventHandler(this.majorBox_SelectedIndexChanged);
            // 
            // confirmPasswordBox
            // 
            this.confirmPasswordBox.Location = new System.Drawing.Point(100, 116);
            this.confirmPasswordBox.Name = "confirmPasswordBox";
            this.confirmPasswordBox.PasswordChar = '*';
            this.confirmPasswordBox.Size = new System.Drawing.Size(126, 20);
            this.confirmPasswordBox.TabIndex = 4;
            this.confirmPasswordBox.Leave += new System.EventHandler(this.passwordBox_Leave);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(100, 90);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(126, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.Leave += new System.EventHandler(this.passwordBox_Leave);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(100, 64);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(126, 20);
            this.usernameBox.TabIndex = 2;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Location = new System.Drawing.Point(100, 38);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(126, 20);
            this.lastNameBox.TabIndex = 1;
            // 
            // passwordCheck
            // 
            this.passwordCheck.AutoSize = true;
            this.passwordCheck.ForeColor = System.Drawing.Color.Red;
            this.passwordCheck.Location = new System.Drawing.Point(98, 138);
            this.passwordCheck.Name = "passwordCheck";
            this.passwordCheck.Size = new System.Drawing.Size(128, 13);
            this.passwordCheck.TabIndex = 17;
            this.passwordCheck.Text = "Passwords Do Not Match";
            this.passwordCheck.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.passwordCheck);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.specialtyBox);
            this.Controls.Add(this.majorBox);
            this.Controls.Add(this.confirmPasswordBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.lastNameBox);
            this.Controls.Add(this.firstNameBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox specialtyBox;
        private System.Windows.Forms.ComboBox majorBox;
        private System.Windows.Forms.TextBox confirmPasswordBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.Label passwordCheck;

    }
}

