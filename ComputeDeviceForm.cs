using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cloo;

namespace SimpleSTL
{
    public partial class ComputeDeviceForm : Form
    {
        public ComputeDeviceForm()
        {
            InitializeComponent();
        }

        List<RadioButton> rbl = new List<RadioButton>();
        List<RadioButton> rbl2 = new List<RadioButton>();
        private void ComputeDevice_Load(object sender, EventArgs e) {
            foreach (var rb in rbl) {
                Controls.Remove(rb);
            }
            rbl.Clear();

            var a = ComputePlatform.Platforms;

            foreach (var computePlatform in a) {
                var t = new RadioButton();
                t.Location = new Point(30, 30 + 20*rbl.Count);
                t.Text = string.Format("{0} ext:{1}", computePlatform.Name, computePlatform.Extensions.Count);
                t.Tag = computePlatform;
                t.CheckedChanged += new EventHandler(t_CheckedChanged);
                rbl.Add(t);
                Controls.Add(t);
            }
        }

        void t_CheckedChanged(object sender, EventArgs e) {
            Form1.compP = (((RadioButton) sender).Tag as ComputePlatform);
        }
    }
}
