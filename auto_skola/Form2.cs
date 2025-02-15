using auto_skola.models;
using auto_skola.repositories;
using System;
using System.Windows.Forms;

namespace auto_skola
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private int kandidatId = 0;

        public void UrediKandidata(kandidat kandidat)
        {
            this.Text = "Uredi kandidata";
            this.label2.Text = "Uredi kandidata";

            this.lbId.Text = kandidat.id.ToString();
            this.tbIme.Text = kandidat.ime;
            this.tbPrezime.Text = kandidat.prezime;
            this.tbTelefon.Text = kandidat.brTelefona;
            this.tbLjekarsko.Text = kandidat.ljekarsko;
            this.tbTestovi.Text = kandidat.testovi;
            this.tbPrvapomoc.Text = kandidat.prvapomoc;
            this.tbUplata.Text = kandidat.uplata;

            this.kandidatId = kandidat.id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            kandidat kandidat = new kandidat
            {
                id = this.kandidatId,
                ime = this.tbIme.Text,
                prezime = this.tbPrezime.Text,
                brTelefona = this.tbTelefon.Text,
                ljekarsko = this.tbLjekarsko.Text,
                testovi = this.tbTestovi.Text,
                prvapomoc = this.tbPrvapomoc.Text,
                uplata = this.tbUplata.Text
            };

            var repo = new kandidatRepository();

            if (kandidat.id == 0)
            {
                repo.CreateKandidat(kandidat);
                MessageBox.Show("Kandidat uspješno spremljen!");
            }
            else
            {
                repo.UpdateKandidat(kandidat);
            }

            this.DialogResult = DialogResult.OK;
           
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
