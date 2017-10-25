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
        List<string> usuarios;
        List<string> cartas;
        List<string> musica;
        string[] niveles;
        public Datos(List<string> usuarios, List<string> cartas, List<string> musica, string[] niveles)
        {
            InitializeComponent();
            this.Visible = true;
            this.usuarios = usuarios;
            this.cartas = cartas;
            this.musica = musica;
            this.niveles = niveles;
            Unicidad(usuarios);
            Unicidad(cartas);
            CB_Nickname.DataSource = usuarios.ToArray();
            CB_Nickname.SelectedIndex = 0;
            CB_Nivel.DataSource = niveles;
            CB_Nivel.SelectedIndex = 0;
        }

        private void Unicidad(List<string> lista)
        {
            for(int i = 0; i < lista.Count; i++)
            {
                for(int j = 0; j < lista.Count; j++)
                {
                    if(lista[i]==lista[j] && i != j)
                    {
                        lista.RemoveAt(j);
                    }
                }
            }
        }

        private void CB_Nickname_Click(object sender, EventArgs e)
        {
            TB_Nickname.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nick;
            if (TB_Nickname.Text == "") { nick = CB_Nickname.Text; }
            else { nick = TB_Nickname.Text; }
            int filas = int.Parse(CB_Nivel.Text.Split('[')[1].Split('x')[0]);
            int columnas = int.Parse(CB_Nivel.Text.Split('[')[1].Split('x')[1].Split(']')[0]);
            if((filas*columnas)%2 != 0)
            {
                columnas += 1;
            }
            Funcionalidad funcionalidad = new Funcionalidad(nick, CB_Nivel.Text, filas, columnas, cartas, musica);
        }
    }
}
