using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursedSodiumConfig.WinForms.Controls
{
    internal class RgbLabel : Label
    {
        private const int ColorChange = 5;

        private int[] _colors;
        private readonly Timer _timer;

        public RgbLabel() : base()
        {
            _colors = new int[] { 255, 0, 0 };

            _timer = new Timer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = 100;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (_colors[0] > 0 && _colors[2] == 0)
            {
                _colors[0] -= ColorChange;
                _colors[1] += ColorChange;
            }
            if (_colors[1] > 0 && _colors[0] == 0)
            {
                _colors[1] -= ColorChange;
                _colors[2] += ColorChange;
            }
            if (_colors[2] > 0 && _colors[1] == 0)
            {
                _colors[2] -= ColorChange;
                _colors[0] += ColorChange;
            }

            this.ForeColor = Color.FromArgb(_colors[0], _colors[1], _colors[2]);
        }
    }
}
