using System.Drawing;
using System.Windows.Forms;

namespace Formulaire_entretien_camions_Cora.Widgets.Tabs.Apercu
{
    public class ControlDataGridViewColumn : DataGridViewTextBoxColumn
    {
        public ControlDataGridViewColumn(string headerText)
        {
            HeaderText = headerText;
            Name = headerText;
            SortMode = DataGridViewColumnSortMode.NotSortable;
            HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            HeaderCell.Style.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Pixel);

        }
    }
}
