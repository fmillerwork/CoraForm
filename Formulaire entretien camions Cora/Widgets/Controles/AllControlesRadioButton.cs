using Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    public class AllControlesRadioButton : RadioButton
    {
        public const string NAME = "allControlesCheckBox";
        public const string TEXT = "Tous les contrôles";
        public AllControlesRadioButton()
        {
            AutoSize = true;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Location = new System.Drawing.Point(35, 205);
            Name = NAME;
            Size = new System.Drawing.Size(156, 24);
            Text = TEXT;

            this.Click += (s, e) =>
            {
                ApercuDataGridView gridView = new ApercuDataGridView(); // création nouveau ApercuDataGridView
                foreach (ControlesCheckBox control in ControlesGroupBox.ControlCollection)  // pour chaque CheckBox dans ControlCollection (= Controls de MainTabControl)
                {
                    control.Checked = true; // coche le CheckBox
                    var column = new ControlDataGridViewColumn(control.Text);   // création nouvelle colonne avec HeaderText valant le Text de la CheckBox 
                    gridView.Columns.Add(column);   // ajout de la colonne dans le ApercuDataGridView

                }
                MainForm.MainTabControl.ApercuTabPage.Controls.Clear(); //vider l'onglet ApercuTabPage
                MainForm.MainTabControl.ApercuTabPage.Controls.Add(gridView); // ajout de ApercuDataGridView dans ApercuTabPage
            };
        }
    }
}
