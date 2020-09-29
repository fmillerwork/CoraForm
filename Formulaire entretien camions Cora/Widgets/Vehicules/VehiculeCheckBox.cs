using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Widgets.Controles;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    /// <summary>
    /// CheckBox contenant une immatriculation de vehicules.
    /// </summary>
    public class VehiculeCheckBox : CheckBox
    {
        public VehiculeCheckBox(string text)
        {
            Text = text;
            Dock = DockStyle.Top;

            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(23, 37);
            Size = new System.Drawing.Size(80, 24);

            this.CheckedChanged += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView

                AddVehiculesRows(gridView); // ajout des lignes
                CtrlCheckBox.AddControlesColumns(gridView); // ajout des colonnes

                MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView = gridView; // Remplassement de MainForm.MainTabControl.ApercuTabPage.ApercuDataGridView par gridView 
                MainForm.MainTabControl.ApercuTabPage.Controls.Clear(); //vider l'onglet ApercuTabPage
                MainForm.MainTabControl.ApercuTabPage.Controls.Add(gridView); // ajout de ApercuDataGridView dans ApercuTabPage
            };
        }

        /// <summary>
        /// Ajoute les lignes correspondantes aux VehiculeCheckBox cochées issues de VehiculesGroupBox.VehiculesCollection
        /// Les ajoute dans la ApercuDataGridView passée en paramètre.
        /// </summary>
        /// <param name="gridView">ApercuDataGridView accueillant les lignes</param>
        public static void AddVehiculesRows(ApercuDataGridView gridView)
        {
            bool cbNonChecked = false;
            foreach (VehiculeCheckBox control in VehiculesGroupBox.VehiculesCollection)  // pour chaque CheckBox dans VehiculesGroupBox.VehiculesCollection
            {
                if (control.Checked) // si CheckBox Checked
                {
                    gridView.Rows.Add(control.Text.Split(':')[0]);   // ajout de la ligne avec immatriculation
                }
                else   // si CheckBox non Checked
                {
                    cbNonChecked = true;
                }
            }
            if (!cbNonChecked)   // si tous les CheckBox sont Checked
                MainForm.AllVehiculesGroupBox.AllVehiculesRadioBtn.Checked = true;    // coche AllVehiculesRadioBtn
            else
                MainForm.AllVehiculesGroupBox.AllVehiculesRadioBtn.Checked = false;  // décoche AllVehiculesRadioBtn
        }
    }
}
