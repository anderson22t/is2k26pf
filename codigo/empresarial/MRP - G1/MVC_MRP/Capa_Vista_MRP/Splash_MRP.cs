using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_MRP
{
    public partial class Splash_MRP : Form
    {

        public Splash_MRP()
        {
            InitializeComponent();
            ConfigurarDiseño();
        }


        private void ConfigurarDiseño()
        {
            LbTitulo.BackColor = Color.Transparent;
            LbSubtitulo.BackColor = Color.Transparent;

            LbTitulo.BackColor = Color.Transparent;
            LbSubtitulo.BackColor = Color.Transparent;

            LbTitulo.Parent = this;
            LbSubtitulo.Parent = this;
        }

        private void Splash_MRP_Load(object sender, EventArgs e)
        {

        }
    }
}
