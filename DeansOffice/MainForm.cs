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

        private List<Student> _students = new List<Student>();
        private Dictionary<int,string> _semesters = new Dictionary<int,string>();

        public MainForm()
        {
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
            //TODO
        }

        private void RemoveStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void ZaladujDane()
        {
            

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15092;Integrated Security=True"))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Student";

                con.Open();

                using(var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var newStudent = new Student();
                        newStudent.IdStudent = (int)dr["IdStudent"];
                        newStudent.Imie = dr["Imie"].ToString();
                        newStudent.Nazwisko = dr["Nazwisko"].ToString();
                        newStudent.Email = dr["Email"].ToString();
                        newStudent.Telefon = dr["Telefon"].ToString();
                        _students.Add(newStudent);
                    }
                }
                com.Dispose();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _students;
            StudentsDataGridView.DataSource = bs;
        }

        private void ZaladujComboBox() {
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15092;Integrated Security=True"))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Semestr";

                con.Open();

                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var newSemestr = new Semestr();
                        newSemestr.Nazwa = dr["NazwaSemestr"].ToString();
                        newSemestr.IdSemestr = (int)dr["IdSemestr"];
                        _semesters.Add(newSemestr.IdSemestr, newSemestr.Nazwa);
                    }
                }
                com.Dispose();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _semesters;
            SemesterComboBox.DataSource = bs;
        }

        private void SemesterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            _students = new List<Student>();
            //  int id = SemesterComboBox.;
            var control = ((KeyValuePair<int, string>)SemesterComboBox.SelectedItem).Key;
           
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15092;Integrated Security=True"))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "select * from Student where IdSemestr = @id";
                com.Parameters.Add("@id",SqlDbType.Int).Value = control;

                con.Open();

                using (var dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var newStudent = new Student();
                        newStudent.IdStudent = (int)dr["IdStudent"];
                        newStudent.Imie = dr["Imie"].ToString();
                        newStudent.Nazwisko = dr["Nazwisko"].ToString();
                        newStudent.Email = dr["Email"].ToString();
                        newStudent.Telefon = dr["Telefon"].ToString();
                        _students.Add(newStudent);
                    }
                }
                com.Dispose();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = _students;
            StudentsDataGridView.DataSource = bs;
        }
    }
}
