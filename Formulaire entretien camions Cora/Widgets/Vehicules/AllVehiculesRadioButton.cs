using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    public class AllVehiculesRadioButton : RadioButton
    {
        public const string NAME = "allVechiculesCheckBox";
        public const string TEXT = "Tous les véhicules";
        public AllVehiculesRadioButton()
        {
            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(213, 480);
            Name = NAME;
            Size = new System.Drawing.Size(85, 17);
            Text = TEXT;

            this.Click += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (VehiculeCheckBox control in VehiculesGroupBox.VehiculesCollection)  // pour chaque CheckBox dans ControlCollection (= Controls de MainTabControl)
                {
                    control.Checked = true; // coche le CheckBox
                    var column = new ControlDataGridViewColumn(control.Text);   // création nouvelle colonne avec HeaderText valant le Text de la CheckBox
                    gridView.Columns.Add(column);   // ajout de la colonne dans le ApercuDataGridView

                }
            };

        }


    }
}
