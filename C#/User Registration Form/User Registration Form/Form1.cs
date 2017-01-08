using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace User_Registration_Form
{
    
    enum MajorType { ComputerScience, Mathematics, Physics, Biology, LiberalArts }

    public partial class Form1 : Form
    {
        private User lastUser;
        enum MajorType { ComputerScience, Mathematics, Physics, Biology, Economics }


        public Form1()
        {
            InitializeComponent();
        }

        private void passwordBox_Leave(object sender, EventArgs e)
        {
            if (passwordBox.Text != confirmPasswordBox.Text && (passwordBox.Text != string.Empty && confirmPasswordBox.Text != string.Empty))
            {
                passwordCheck.Visible = true;
            }
            else
            {
                passwordCheck.Visible = false;
            }
        }

        private void majorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            specialtyBox.Items.Clear();
            string major = majorBox.Text.ToString();

            if (major != null)
                UpdateSpecialties(major);
        }

        private void UpdateSpecialties(string s)
        {
            switch (s)
            {
                case "ComputerScience":
                    specialtyBox.Items.Add("Artificial Intelligence");
                    specialtyBox.Items.Add("Bioinformatics");
                    specialtyBox.Items.Add("Databases");
                    specialtyBox.Items.Add("Networking");
                    break;
                case "Mathematics":
                    specialtyBox.Items.Add("Teaching");
                    specialtyBox.Items.Add("Group Theory");
                    specialtyBox.Items.Add("Fluid Mechanics");
                    specialtyBox.Items.Add("Approximations");
                    break;
                case "Physics":
                    specialtyBox.Items.Add("Quantum");
                    specialtyBox.Items.Add("String Theory");
                    specialtyBox.Items.Add("Molecular");
                    specialtyBox.Items.Add("Relativity");
                    break;
                case "Biology":
                    specialtyBox.Items.Add("Environmental");
                    specialtyBox.Items.Add("BioPhysics");
                    specialtyBox.Items.Add("Genetics");
                    specialtyBox.Items.Add("Anatomy");
                    break;

                case "Economics":
                    specialtyBox.Items.Add("Macroeconomics");
                    specialtyBox.Items.Add("Microecnonomics");
                    specialtyBox.Items.Add("Management");
                    specialtyBox.Items.Add("Game Theory");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check())
            {
                lastUser = new User();
                lastUser.Username = usernameBox.Text;
                lastUser.FirstName = firstNameBox.Text;
                lastUser.LastName = lastNameBox.Text;
                lastUser.Password = passwordBox.Text;
                lastUser.Specialty = specialtyBox.SelectedIndex;
                lastUser.Major = majorBox.SelectedIndex;

                MessageBox.Show("Submitted");
            }
            else
                MessageBox.Show("Please double check that the form fields are filled correctly");
        }

        private bool check()
        {
            foreach (Control control in this.Controls)
                if (control.Text == string.Empty)
                    return false;

            if (passwordBox.Text != confirmPasswordBox.Text && (passwordBox.Text != string.Empty && confirmPasswordBox.Text != string.Empty))
                return false;
            else
                return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lastUser != null)
            {
                firstNameBox.Text = lastUser.FirstName;
                lastNameBox.Text = lastUser.LastName;
                usernameBox.Text = lastUser.Username;
                passwordBox.Text = lastUser.Password;
                majorBox.SelectedIndex = lastUser.Major;
                specialtyBox.SelectedIndex = lastUser.Specialty;
            }
            else
            {
                MessageBox.Show("No user exist");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox box = (TextBox)control;
                    box.Clear();
                }
            }
            passwordCheck.Visible = false;
            majorBox.SelectedIndex = -1;
        }


    }

    class User
    {
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Major
        {
            get { return major; }
            set { major = value; }
        }

        public int Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        private string firstname;
        private string lastname;
        private string username;
        private string password;
        private int major;
        private int specialty;
    }
}
