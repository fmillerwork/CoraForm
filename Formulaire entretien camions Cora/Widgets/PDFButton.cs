using Formulaire_entretien_camions_Cora.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Widgets.Controles;
using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Controls
{
    class PDFButton : Button
    {
        private const string NAME = "pdfButton";
        private const string TEXT = "Générer PDF";
        private const string FILEPATH = @"S:\Bureau\Entretiens.pdf"; // CHANGER
        public PDFButton()
        {
            Name = NAME;
            Text = TEXT;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(35, 359);
            Margin = new Padding(100);
            Name = "pdfButton";
            Size = new System.Drawing.Size(148, 73);

            this.Click += (s, e) =>
            {
                Document docPdf = new Document(PageSize.A4.Rotate()); // PageSize.A4.Rotate() => page en paysage

                try
                {
                    PdfWriter.GetInstance(docPdf, new FileStream(FILEPATH, FileMode.OpenOrCreate));
                    docPdf.Open();

                    PdfPTable table = new PdfPTable(getColumnsNames().Count);

                    table.TotalWidth = 800; // où 800 est la largeur du tableau(en points typo)
                    table.LockedWidth = true; // sert à empêcher la méthode document.add de redimensionner le tableau.


                    foreach (string colName in getColumnsNames())
                    {
                        table.AddCell(colName);
                    }

                    foreach (DataGridViewRow row in MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView.Rows)
                    {
                        //var subTab = new PdfPTable(1);
                        //subTab.AddCell((string)row.Cells[0].Value);
                        table.AddCell((string)row.Cells[0].Value);
                    }

                    docPdf.Add(table);
                    docPdf.Close();
                    System.Diagnostics.Process.Start(FILEPATH); // Ouverture du document PDF
                }
                catch (IOException)
                {
                    MessageBox.Show("Veuillez fermer le document !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            };
        }
        /// <summary>
        /// Retourne le nombre de ControlesCheckBox cochées 
        /// </summary>
        /// <returns></returns>
        private List<string> getColumnsNames()
        {
            List<string> columnsList = new List<string>();
            foreach (ControlDataGridViewColumn col in MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView.Columns)
            {
                columnsList.Add(col.HeaderText);
            }
            return columnsList;
        }
    }
}


// création fichier tempo au lieu de save sur bureau