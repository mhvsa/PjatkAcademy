using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeansOffice
{
    public partial class MainForm : Form
    {

        private List<DeansOffice.Student> _students = new List<DeansOffice.Student>();
        private Dictionary<int,string> _semesters = new Dictionary<int,string>();

        public MainForm()
        {
            DeansOfficeDB db = new DeansOfficeDB();
            InitializeComponent();
            ZaladujDane();
            ZaladujComboBox();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new StudentDialog();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                ZaladujDane();
            }
            
        }

        private void EditStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var studentID = (int)StudentsDataGridView.SelectedRows[0].Cells[0].Value;
            DeansOfficeDB db = new DeansOfficeDB();

            //db.Students.ToList().Where(s=>s.IdStudent = student.Cells.)
            var form = new StudentDialog();
            form.EditStudent(db.Students.ToList().Where(s=>s.IdStudent == studentID).ToList()[0]);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                ZaladujDane();
                ZaladujComboBox();

            }
        }

        private void RemoveStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeansOfficeDB db = new DeansOfficeDB();
            var studentID = (int)StudentsDataGridView.SelectedRows[0].Cells[0].Value;
            var student = db.Students.Where(s => s.IdStudent == studentID).First();
            db.Students.Remove(student);
            db.SaveChanges();
            ZaladujDane();
            ZaladujComboBox();
        }

        private void ZaladujDane()
        {
            DeansOfficeDB db = new DeansOfficeDB();

            StudentsDataGridView.DataSource = db.Students.ToList();
        }

        private void ZaladujComboBox() {

            DeansOfficeDB db = new DeansOfficeDB();

            SemesterComboBox.DataSource = db.Semestrs.ToList();
            SemesterComboBox.DisplayMember = "NazwaSemestr";

        }

        private void SemesterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeansOfficeDB db = new DeansOfficeDB();


            var selectedSemestrID = ((Semestr)SemesterComboBox.SelectedValue).IdSemestr;
            var result = db.Students.ToList().Where((student)=>student.IdSemestr == selectedSemestrID).ToList();
            StudentsDataGridView.DataSource = result;

        }
    }
}
