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
    public partial class StudentDialog : Form
    {
        private Student student = null;
        private const String _rokZapisaniaMock = "2016";
        private const int _semestrMock = 2;
        private const string _nrIndeksuMock = "s15092";

        public StudentDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            var imie = FirstNameTextBox.Text;
            var nazwisko = LastNameTextBox.Text;
            var email = EmailTextBox.Text;
            var pesel = PeselTextBox.Text;
            var nrPaszportu = PassportNumberTextBox.Text;
            var obywatelstwo = CitizenshipTextBox.Text;
            var index = IndexNumberTextBox.Text;
            // DO ZMIANY
            var rokZapisania = _rokZapisaniaMock;
            var semestr = _semestrMock;
            var nrIndeksuMock = IndexNumberTextBox.Text;

            var db = new DeansOfficeDB();
            var student = new Student()
            {
                Email = email,
                IdSemestr = _semestrMock,
                Imie = imie,
                Nazwisko = nazwisko,
                Pesel = pesel,
                NumerIndeksu = nrIndeksuMock,
                NumerPaszportu = nrPaszportu,
                Obywatelstwo = obywatelstwo,
                Semestr = db.Semestrs.ToList()[0],
                RokZapisania = rokZapisania,
                Telefon = TelephoneTextBox.Text
            };

            if (this.student == null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            else {
                var studentToEdit = db.Students.Where(s => s.IdStudent == this.student.IdStudent).First();
                studentToEdit.Email = email;
                studentToEdit.IdSemestr = _semestrMock;
                studentToEdit.Imie = imie;
                studentToEdit.Nazwisko = nazwisko;
                studentToEdit.Pesel = pesel;
                studentToEdit.NumerIndeksu = nrIndeksuMock;
                studentToEdit.NumerPaszportu = nrPaszportu;
                studentToEdit.Obywatelstwo = obywatelstwo;
                studentToEdit.Semestr = db.Semestrs.ToList()[0];
                studentToEdit.RokZapisania = rokZapisania;
                studentToEdit.Telefon = TelephoneTextBox.Text;
                db.SaveChanges();
                this.DialogResult = DialogResult.OK;
            }
            
           

        }

        public void EditStudent(Student student) {
            FirstNameTextBox.Text = student.Imie;
            LastNameTextBox.Text = student.Nazwisko;
            IndexNumberTextBox.Text = student.NumerIndeksu;
            EmailTextBox.Text = student.Email;
            CitizenshipTextBox.Text = student.Obywatelstwo;
            PassportNumberTextBox.Text = student.NumerPaszportu;
            PeselTextBox.Text = student.Pesel;

            this.student = student;
        }

    }
}
