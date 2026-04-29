using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_RO
{
    public partial class Frm_Detalle_Orden : Form
    {
        private int _idOrden;
        public Frm_Detalle_Orden()
        {
            InitializeComponent();
        }
        public Frm_Detalle_Orden(int idOrden) 
        {
            InitializeComponent();
            _idOrden = idOrden;
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
