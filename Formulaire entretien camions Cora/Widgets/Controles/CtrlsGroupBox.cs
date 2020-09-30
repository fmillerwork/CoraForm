using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Controles
{
    /// <summary>
    /// GroupBox regroupant les tâches (contrôles) à effectuer
    /// </summary>
    public class CtrlsGroupBox : GroupBox
    {
        private const string NAME = "controlesGroupBox";
        private const string TEXT = "Contrôles";

        public new static ControlCollection ControlCollection { get; set; }
        public CtrlsGroupBox()
        {
            Name = NAME;
            Text = TEXT;
            ControlCollection = Controls;

            Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular);
            Location = new System.Drawing.Point(30, 25);
            Size = new System.Drawing.Size(150, 210);
            TabStop = false;

            Controls.AddRange(new CtrlCheckBox[] { new CtrlCheckBox("Vitres"),
                                                        new CtrlCheckBox("AdBlue"),
                                                        new CtrlCheckBox("Carburant"),
                                                        new CtrlCheckBox("Liquide de Refr."),
                                                        new CtrlCheckBox("Huile"),
                                                        new CtrlCheckBox("Nettoyage Ext."),
                                                        new CtrlCheckBox("Nettoyage Int."),
                                                        new CtrlCheckBox("Lave Glace")
                                                       });
        }
    }
}
