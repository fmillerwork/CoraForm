using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    public class AllVehiculesRadioBtn : RadioButton
    {
        private const string NAME = "allVechiculesCheckBox";
        private const string TEXT = "Tous les véhicules";
        public AllVehiculesRadioBtn()
        {
            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            Name = NAME; 
            Text = TEXT;
            Checked = false;

            this.Click += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (VehiculeCheckBox control in VehiculesGroupBox.VehiculesCollection)  // pour chaque CheckBox dans ControlCollection (= Controls de MainTabControl)
                {
                    control.Checked = true; // coche le CheckBox
                }
            };

        }


    }
}
