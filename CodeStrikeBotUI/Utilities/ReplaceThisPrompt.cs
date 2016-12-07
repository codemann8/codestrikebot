using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeStrikeBot
{
    public static class ReplaceThisPrompt
    {
        public static T ShowDialog<T>(string text, string caption, List<T> items)
        {
            Form prompt = new Form();
            prompt.Width = 440;
            prompt.Height = 350;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text };
            ListBox listBox = new ListBox() { Left = 10, Top = 50, Width = 400, Height = 200 };
            foreach (T o in items)
            {
                listBox.Items.Add(o);
            }
            Button confirmation = new Button() { Text = "OK", Left = 310, Width = 100, Top = 270 };
            confirmation.Click += (sender, e) => {
                if (listBox.SelectedIndex >= 0)
                {
                    prompt.DialogResult = DialogResult.OK;
                    prompt.Close();
                }
                else
                {
                    MessageBox.Show(prompt, "Please select an emulator");
                }
            };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(listBox);
            prompt.ShowDialog();
            if (prompt.DialogResult == DialogResult.OK)
            {
                return (T)listBox.SelectedItem;
            }
            else
            {
                return default(T);
            }
        }
    }
}
