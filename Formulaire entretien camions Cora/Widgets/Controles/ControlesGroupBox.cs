using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    /// <summary>
    /// GroupBox regroupant les tâches (contrôles) à effectuer
    /// </summary>
    public class ControlesGroupBox : GroupBox
    {
        public const string NAME = "controlesGroupBox";
        public const string TEXT = "Contrôles";

        public new static ControlCollection ControlCollection { get; set; }
        public ControlesGroupBox()
        {
            Name = NAME;
            Text = TEXT;
            ControlCollection = Controls;

            Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(32, 25);
            Size = new System.Drawing.Size(151, 163);
            TabStop = false;

            Controls.AddRange(new ControlesCheckBox[] { new ControlesCheckBox("Vitres"),
                                                        new ControlesCheckBox("AdBlue"),
                                                        new ControlesCheckBox("Carburant"),
                                                        new ControlesCheckBox("Lave Glace")
                                                       });
        }
    }
}
