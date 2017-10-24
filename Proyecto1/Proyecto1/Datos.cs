using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Datos : Form
    {
        public Datos()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void CB_Nickname_Click(object sender, EventArgs e)
        {
            TB_Nickname.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
