using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Vehicules
{
    public class ImmatriculationTextBox : TextBox
    {
        public ImmatriculationTextBox()
        {
            Location = new System.Drawing.Point(6, 19);
            Size = new System.Drawing.Size(100, 20);
        }

        public ImmatriculationTextBox(string text)
        {
            Location = new System.Drawing.Point(6, 19);
            Size = new System.Drawing.Size(100, 20);
            Text = text;
        }
    }
}
