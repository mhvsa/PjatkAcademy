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

        private const String _rokZapisaniaMock = "2016";
        private const int _semestrMock = 2;
 
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

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s15092;Integrated Security=True"))
            {
                var com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "insert into Student values(@imie,@nazwisko,@email,@telefon,@pesel,@nrPaszportu,@obywatelstwo,@index,@rokZapisania,@semestr)";
                com.Parameters.Add("@imie", SqlDbType.NVarChar).Value = imie;
                com.Parameters.Add("@nazwisko", SqlDbType.NVarChar).Value = nazwisko;
                com.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                com.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = "123123123";
                com.Parameters.Add("@pesel", SqlDbType.NVarChar).Value = pesel;
                com.Parameters.Add("@nrPaszportu", SqlDbType.NVarChar).Value = nrPaszportu;
                com.Parameters.Add("@obywatelstwo", SqlDbType.NVarChar).Value = obywatelstwo;
                com.Parameters.Add("@index", SqlDbType.NVarChar).Value = index;
                com.Parameters.Add("@rokZapisania", SqlDbType.NVarChar).Value = rokZapisania;
                com.Parameters.Add("@semestr", SqlDbType.Int).Value = semestr;

                con.Open();
                com.ExecuteNonQuery();
                com.Dispose();

                this.DialogResult = DialogResult.OK;
            }

        }
    }
}
