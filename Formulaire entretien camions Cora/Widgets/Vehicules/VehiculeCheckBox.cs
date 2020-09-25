using Formulaire_entretien_camions_Cora.Tabs.Apercu;
using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    /// <summary>
    /// CheckBox contenant une immatriculation de vehicules.
    /// </summary>
    class VehiculeCheckBox : CheckBox
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
                bool cbNonChecked = false;
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (VehiculeCheckBox control in VehiculesGroupBox.VehiculesCollection)  // pour chaque CheckBox dans VehiculesGroupBox.VehiculesCollection
                {
                    if (control.Checked) // si CheckBox Checked
                    {
                        gridView.Rows.Add(control.Text);   // ajout de la ligne avec immatriculation
                    }
                    else   // si CheckBox non Checked
                    {
                        cbNonChecked = true;
                    }
                }
                if (!cbNonChecked)   // si tous les CheckBox sont Checked
                    MainForm.AllVehiculesRadioButton.Checked = true;    // coche AllVehiculesRadioButton
                else
                    MainForm.AllVehiculesRadioButton.Checked = false;  // décoche AllVehiculesRadioButton

                ApercuTabPage.ApercuDataGridView = gridView;
                MainForm.MainTabControl.ApercuTabPage.Controls.Clear(); //vider l'onglet ApercuTabPage
                MainForm.MainTabControl.ApercuTabPage.Controls.Add(gridView); // ajout de ApercuDataGridView dans ApercuTabPage
            };
        }
    }
}
