using auto_skola.models;
using auto_skola.repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auto_skola
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ReadKandidati();
        }

        private void ReadKandidati()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Ime");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Telefon");
            dataTable.Columns.Add("Potvrda ljekarskog uvjerenja");
            dataTable.Columns.Add("Potvrda prva pomoć");
            dataTable.Columns.Add("Potvrda testova");
            dataTable.Columns.Add("Plaćeno");

            var repo = new kandidatRepository();
            var kandidati = repo.GetKandidats();

            foreach( var kandidat in kandidati )
            {
                var row = dataTable.NewRow();

                row["ID"] = kandidat.id;
                row["Ime"] = kandidat.ime;
                row["Prezime"] = kandidat.prezime;
                row["Telefon"] = kandidat.brTelefona;
                row["Potvrda ljekarskog uvjerenja"] = kandidat.ljekarsko;
                row["Potvrda prva pomoć"] = kandidat.prvapomoc;
                row["Potvrda testova"] = kandidat.testovi;
                row["Plaćeno"] = kandidat.uplata;

                dataTable.Rows.Add(row);
            }

            this.kandidatiTable.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Dodaj_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if(form.ShowDialog() == DialogResult.OK) { ReadKandidati(); }
        }

        private void Uredi_Click(object sender, EventArgs e)
        {
            var val = this.kandidatiTable.SelectedRows[0].Cells[0].Value.ToString();
            if (val == null || val.Length == 0) return;

            int clientId = int .Parse(val);

            var repo = new kandidatRepository();
            var kandidat = repo.GetClient(clientId);

            if(kandidat == null) return;

            Form2 form = new Form2();
            form.UrediKandidata(kandidat);
            if(form.ShowDialog() == DialogResult.OK)
            {
                ReadKandidati();
            }
        }

        private void Izbrisi_Click(object sender, EventArgs e)
        {
            var val = this.kandidatiTable.SelectedRows[0].Cells[0].Value.ToString();
            if(val == null || val.Length == 0) { return; }

            int clientId = int .Parse(val);

            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite obrisati ovog kandidata?", "Izbriši kandidata", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            var repo = new kandidatRepository();
            repo.DeleteKandidat(clientId);

            ReadKandidati();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var repo = new kandidatRepository(); // Kreiraš instancu repozitorijuma
            repo.DeleteAllRecords(); // metoda za brisanje svih elemenata
            repo.DropTable(); // Pozivaš metodu za brisanje tabele

            MessageBox.Show("Tabela je obrisana."); // Obaveštavaš korisnika
        }
    }
}
