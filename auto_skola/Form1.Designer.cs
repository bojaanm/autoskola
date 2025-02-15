namespace auto_skola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.Dodaj = new System.Windows.Forms.Button();
            this.Izbrisi = new System.Windows.Forms.Button();
            this.Uredi = new System.Windows.Forms.Button();
            this.kandidatiTable = new System.Windows.Forms.DataGridView();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kandidatiTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auto Škola \"TIM\"";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Dodaj
            // 
            this.Dodaj.Location = new System.Drawing.Point(12, 54);
            this.Dodaj.Name = "Dodaj";
            this.Dodaj.Size = new System.Drawing.Size(133, 30);
            this.Dodaj.TabIndex = 1;
            this.Dodaj.Text = "Dodaj kandidata";
            this.Dodaj.UseVisualStyleBackColor = true;
            this.Dodaj.Click += new System.EventHandler(this.Dodaj_Click);
            // 
            // Izbrisi
            // 
            this.Izbrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Izbrisi.Location = new System.Drawing.Point(726, 54);
            this.Izbrisi.Name = "Izbrisi";
            this.Izbrisi.Size = new System.Drawing.Size(133, 30);
            this.Izbrisi.TabIndex = 2;
            this.Izbrisi.Text = "Izbriši kandidata";
            this.Izbrisi.UseVisualStyleBackColor = true;
            this.Izbrisi.Click += new System.EventHandler(this.Izbrisi_Click);
            // 
            // Uredi
            // 
            this.Uredi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Uredi.Location = new System.Drawing.Point(448, 54);
            this.Uredi.Name = "Uredi";
            this.Uredi.Size = new System.Drawing.Size(133, 30);
            this.Uredi.TabIndex = 3;
            this.Uredi.Text = "Uredi";
            this.Uredi.UseVisualStyleBackColor = true;
            this.Uredi.Click += new System.EventHandler(this.Uredi_Click);
            // 
            // kandidatiTable
            // 
            this.kandidatiTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kandidatiTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kandidatiTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kandidatiTable.Location = new System.Drawing.Point(12, 90);
            this.kandidatiTable.MultiSelect = false;
            this.kandidatiTable.Name = "kandidatiTable";
            this.kandidatiTable.RowHeadersVisible = false;
            this.kandidatiTable.RowHeadersWidth = 51;
            this.kandidatiTable.RowTemplate.Height = 24;
            this.kandidatiTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kandidatiTable.Size = new System.Drawing.Size(847, 377);
            this.kandidatiTable.TabIndex = 4;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAll.Location = new System.Drawing.Point(587, 54);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(133, 30);
            this.btnDeleteAll.TabIndex = 5;
            this.btnDeleteAll.Text = "Izbriši sve";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 479);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.kandidatiTable);
            this.Controls.Add(this.Uredi);
            this.Controls.Add(this.Izbrisi);
            this.Controls.Add(this.Dodaj);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AutoSkolaTim";
            ((System.ComponentModel.ISupportInitialize)(this.kandidatiTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Dodaj;
        private System.Windows.Forms.Button Izbrisi;
        private System.Windows.Forms.Button Uredi;
        private System.Windows.Forms.DataGridView kandidatiTable;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}

