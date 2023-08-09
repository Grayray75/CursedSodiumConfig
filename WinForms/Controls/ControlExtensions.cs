using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursedSodiumConfig.WinForms.Controls
{
    internal static class ControlExtensions
    {
        // https://stackoverflow.com/a/53283086
        public static IEnumerable<Control> RecursiveControls(this Control parent)
        {
            if (null == parent)
            {
                throw new ArgumentNullException(nameof(parent));
            }

            Queue<Control> agenda = new Queue<Control>(parent.Controls.OfType<Control>());

            while (agenda.Any())
            {
                yield return agenda.Peek();

                foreach (var item in agenda.Dequeue().Controls.OfType<Control>())
                    agenda.Enqueue(item);
            }
        }
    }
}
