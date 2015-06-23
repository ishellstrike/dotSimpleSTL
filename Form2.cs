using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleSTL
{
    public partial class Form2 : Form
    {
        Mesh m;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.MainMesh_ = MeshTools.RemoveInternal(m, trackBar1.Value / (float) trackBar1.Maximum);
            Form1.MainMesh_.raw = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.MainMesh_ = new Mesh(m);
            Form1.MainMesh_.raw = true;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            m = new Mesh(Form1.MainMesh_);
        }
    }
}
