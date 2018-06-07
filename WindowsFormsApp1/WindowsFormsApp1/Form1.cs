using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDB
{
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        int currentElement_Edit;
        int currentElement_View;

        public Form1()
        {
            InitializeComponent();
            comboCourseEdit.SelectedIndex = 1;
            comboGenderEdit.SelectedIndex = 0;

            comboCourseInput.SelectedIndex = 1;
            comboGenderInput.SelectedIndex = 0;

            comboDepatmentEdit.SelectedIndex = 0;
            comboDepatmentInput.SelectedIndex = 0;

            tabControl1.SelectedIndex = 0;

            currentElement_Edit = -1;
            currentElement_View = -1;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Students database (c) 2018");
        }

        private void txtBirthdayEdit_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            txtBirthdayEdit.Text = monthCalendar1.SelectionStart.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentElement_Edit >= 0)
            {
                db.Db.ElementAt((int)currentElement_Edit).Name = txtNameEdit.Text;
                db.Db.ElementAt((int)currentElement_Edit).SecondName = txtSecondNameEdit.Text;
                db.Db.ElementAt((int)currentElement_Edit).SurName = txtSurnameEdit.Text;

                db.Db.ElementAt((int)currentElement_Edit).Birthday = monthCalendar1.SelectionStart;
                db.Db.ElementAt((int)currentElement_Edit).Gender = (short)comboGenderView.SelectedIndex;
                db.Db.ElementAt((int)currentElement_Edit).Course = (short)comboCourseView.SelectedIndex;
                db.Db.ElementAt((int)currentElement_Edit).Department = comboDepatmentView.Text;
            }
        }

        private void Save_Input_Click(object sender, EventArgs e)
        {
            db.AddStudent(new Student(txtNameInput.Text, txtSecondNameInput.Text, txtSurnameInput.Text,
                monthCalendar2.SelectionStart, (short)comboGenderInput.SelectedIndex,
                (short)comboCourseInput.SelectedIndex, comboDepatmentInput.Text));

            txtNameInput.Text = "";
            txtSecondNameInput.Text = "";
            txtSurnameInput.Text = "";
            txtBirthdayInput.Text = "";
            comboGenderInput.SelectedIndex = 0;
            comboCourseInput.SelectedIndex = 1;
            comboDepatmentInput.Text = "";

            currentElement_Edit = db.Db.Count - 1;
            currentElement_View = db.Db.Count - 1;
            
            ActiveForm.Text = "Students database (" + db.Db.Count + ")";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentElement_Edit > 0)
            {
                currentElement_Edit--;
                this.ShowStudent();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentElement_Edit < (db.Db.Count - 1))
            {
                currentElement_Edit++;
                this.ShowStudent();
            }
        }

        private void ShowStudent()
        {
            txtNameEdit.Text = db.Db.ElementAt((int)currentElement_Edit).Name;
            txtSecondNameEdit.Text = db.Db.ElementAt((int)currentElement_Edit).SecondName;
            txtSurnameEdit.Text = db.Db.ElementAt((int)currentElement_Edit).SurName;

            txtBirthdayEdit.Text = db.Db.ElementAt((int)currentElement_Edit).Birthday.ToString();
            comboGenderEdit.SelectedIndex = db.Db.ElementAt((int)currentElement_Edit).Gender;
            comboCourseEdit.SelectedIndex = db.Db.ElementAt((int)currentElement_Edit).Course;
            comboDepatmentEdit.Text = db.Db.ElementAt((int)currentElement_Edit).Department;

        }

        private void ShowStudentView()
        {
            txtNameView.Text = db.Db.ElementAt((int)currentElement_View).Name;
            txtSecondNameView.Text = db.Db.ElementAt((int)currentElement_View).SecondName;
            txtSurnameView.Text = db.Db.ElementAt((int)currentElement_View).SurName;


            txtBirthdayView.Text = db.Db.ElementAt((int)currentElement_View).Birthday.ToString();
            comboGenderView.SelectedIndex = db.Db.ElementAt((int)currentElement_View).Gender;
            comboCourseView.SelectedIndex = db.Db.ElementAt((int)currentElement_View).Course;
            comboDepatmentView.Text = db.Db.ElementAt((int)currentElement_View).Department;

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.Visible = false;
            txtBirthdayInput.Text = monthCalendar2.SelectionStart.ToString();
        }

        private void textBox_Birthday_input_Enter(object sender, EventArgs e)
        {
            monthCalendar2.Visible = true;
        }

        private void Prev_Button_View_Click(object sender, EventArgs e)
        {
            if (currentElement_View > 0)
            {
                currentElement_View--;
                this.ShowStudentView();
            }
        }

        private void Next_Button_View_Click(object sender, EventArgs e)
        {
            if (currentElement_View < (db.Db.Count - 1))
            {
                currentElement_View++;
                this.ShowStudentView();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (currentElement_View >= 0)
            {
                this.ShowStudentView();
                this.ShowStudent();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
