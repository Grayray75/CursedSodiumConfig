using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursedSodiumConfig.WinForms.Controls
{
    internal class BetterComboBox : ComboBox
    {
        public event EventHandler FormLoaded;

        public void PerformFormLoadedEvent(object s, EventArgs e)
        {
            this.FormLoaded?.Invoke(s, e);
        }
    }
}
