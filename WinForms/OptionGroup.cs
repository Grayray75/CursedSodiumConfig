using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursedSodiumConfig.WinForms.Controls;

namespace CursedSodiumConfig.WinForms
{
    internal class OptionGroup
    {
        private readonly Panel _panel;
        private int _optionCount;

        public OptionGroup(string name)
        {
            _panel = new Panel();
            _panel.Name = $"pnl{name}";
            _panel.BorderStyle = BorderStyle.FixedSingle;

            _optionCount = 0;
        }

        public void AddIntOption(string displayName, object dataSource, string dataMember, int minValue, int maxValue, int steps = 1)
        {
            Label label = new Label();
            label.Name = $"lbl{dataMember}";
            label.AutoSize = true;
            label.Location = new Point(3, 6 + 29 * _optionCount);
            label.Text = displayName;

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Name = $"nud{dataMember}";
            numericUpDown.Size = new Size(121, 23);
            numericUpDown.Location = new Point(190, 3 + 29 * _optionCount);
            numericUpDown.Minimum = new decimal(minValue);
            numericUpDown.Maximum = new decimal(maxValue);
            numericUpDown.Increment = new decimal(steps);

            numericUpDown.Value = new decimal((int)dataSource.GetType().GetProperty(dataMember).GetValue(dataSource));
            numericUpDown.ValueChanged += (s, e) =>
            {
                dataSource.GetType().GetProperty(dataMember).SetValue(dataSource, (int)numericUpDown.Value);
            };

            _panel.Controls.Add(label);
            _panel.Controls.Add(numericUpDown);
            _optionCount++;
        }

        public void AddBoolOption(string displayName, object dataSource, string dataMember)
        {
            Label label = new Label();
            label.Name = $"lbl{dataMember}";
            label.AutoSize = true;
            label.Location = new Point(3, 6 + 29 * _optionCount);
            label.Text = displayName;

            CheckBox checkBox = new CheckBox();
            checkBox.Name = $"chx{displayName}";
            checkBox.AutoSize = true;
            checkBox.Location = new Point(191, 8 + 29 * _optionCount);
            checkBox.UseVisualStyleBackColor = true;

            checkBox.Checked = (bool)dataSource.GetType().GetProperty(dataMember).GetValue(dataSource);
            checkBox.CheckedChanged += (s, e) =>
            {
                dataSource.GetType().GetProperty(dataMember).SetValue(dataSource, checkBox.Checked);
            };

            _panel.Controls.Add(label);
            _panel.Controls.Add(checkBox);
            _optionCount++;
        }

        public void AddEnumOption(string displayName, object dataSource, string dataMember, Type enumType)
        {
            Label label = new Label();
            label.Name = $"lbl{dataMember}";
            label.AutoSize = true;
            label.Location = new Point(3, 6 + 29 * _optionCount);
            label.Text = displayName;

            BetterComboBox comboBox = new BetterComboBox();
            comboBox.Name = $"cbx{displayName}";
            comboBox.Size = new Size(121, 23);
            comboBox.Location = new Point(190, 3 + 29 * _optionCount);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.DataSource = Enum.GetValues(enumType);

            comboBox.SelectedIndexChanged += (s, e) =>
            {
                dataSource.GetType().GetProperty(dataMember).SetValue(dataSource, comboBox.SelectedItem);
            };

            // This shouldn't be necessary but it's winforms so it is...
            comboBox.FormLoaded += (s, e) =>
            {
                comboBox.SelectedItem = dataSource.GetType().GetProperty(dataMember).GetValue(dataSource);
            };

            _panel.Controls.Add(label);
            _panel.Controls.Add(comboBox);
            _optionCount++;
        }

        public Panel GetControl()
        {
            _panel.Size = new Size(320, _optionCount * 29 + 2);
            return _panel;
        }
    }
}
