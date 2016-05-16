using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class frm : Form
    {
        enum TipoFigura  {Rectangulo, Circulo, linea};

        private TipoFigura figura_actual; 
        private List<Figura> rectangulos;
        

        public frm()
        {
            figura_actual = TipoFigura.Circulo;
           
            rectangulos = new List<Figura>();
            InitializeComponent();
            circuloToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                
                contextMenuStrip1.Show(this, e.X,e.Y);
            }
            else if (MouseButtons.Left == e.Button)
            {
                if (figura_actual == TipoFigura.Circulo)
                    {
                    Circulo c = new Circulo(e.X, e.Y);
                    c.Draw(this);
                    rectangulos.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y);
                    r.Draw(this);
                    rectangulos.Add(r);
                }
                else if (figura_actual == TipoFigura.linea)
                {
                    Linea l = new Linea(e.X, e.Y);
                    l.Draw(this);
                    rectangulos.Add(l);
                }

            }
          

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Polimorfismo
            foreach (Figura r in rectangulos)
                r.Draw(this);
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rectanguloToolStripMenuItem.Checked = true;
            this.circuloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Circulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart(); 
            
        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = true;
            figura_actual = TipoFigura.linea;
        }
    }
}
