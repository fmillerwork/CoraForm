using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    public class AllCtrlsRadioBtn : RadioButton
    {
        private const string NAME = "allControlesCheckBox";
        private const string TEXT = "Tous les contrôles";
        public AllCtrlsRadioBtn()
        {
            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(2, 10);
            Name = NAME;
            Text = TEXT;

            this.Click += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (CtrlCheckBox control in CtrlsGroupBox.ControlCollection)  // pour chaque CheckBox dans ControlCollection (= Controls de MainTabControl)
                {
                    control.Checked = true; // coche le CheckBox

                }
            };
        }
    }
}
