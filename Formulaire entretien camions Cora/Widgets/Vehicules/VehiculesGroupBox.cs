using Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Vehicules
{
    /// <summary>
    /// GroupBox regroupant les immatriculations disponibles.
    /// </summary>
    public class VehiculesGroupBox : GroupBox
    {
        public const string NAME = "vehiculesGroupBox";
        public const string TEXT = "Véhicules";
        public static ControlCollection VehiculesCollection { get; set; }
        public VehiculesGroupBox()
        {
            int _vehiculeCount = 1;

            VehiculesCollection = Controls;
            Name = NAME;
            Text = TEXT;
            Location = new System.Drawing.Point(204, 24);
            Size = new System.Drawing.Size(160, 450);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular);

            #region [ Création des VehiculesCheckBox ]
            foreach (VehiculeGroupBox vehiculeGb in VehiculesFlowLayoutPanel.VehiculesCollection)
            {
                _vehiculeCount++;
                if (vehiculeGb.ImmatriculationTextBox.Text != "")
                {
                    Controls.Add(new VehiculeCheckBox(vehiculeGb.ImmatriculationTextBox.Text));
                    // AJT CATEGORIE VEHICULE DANS LE TEXT
                }
            }
            #endregion
        }
    }
}
