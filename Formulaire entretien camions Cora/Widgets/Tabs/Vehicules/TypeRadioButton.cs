using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules
{
    /// <summary>
    /// RadioButton pour le type du véhicule dans l'onglet Camions
    /// </summary>
    public class TypeRadioButton : RadioButton
    {
        public TypeRadioButton(string text, int x, int y)
        {
            Text = text;
            Location = new System.Drawing.Point(x, y);
            AutoSize = true;
        }
    }
}
