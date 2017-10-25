using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WMPLib;
using System.Media;

namespace Proyecto1
{
    public partial class Funcionalidad : Form
    {
        private List<string> cartas = new List<string>();
        private List<string> cartas_copia = new List<string>();
        private List<string> musica = new List<string>();
        private int filas;
        private int columnas;
        private bool[,] disponibilidad;
        ThreadStart delegado;
        Thread hilo;

        public Funcionalidad(string nickname, string nivel, int filas, int columnas, List<string> cartas, List<string> musica)
        {
            InitializeComponent();
            this.Visible = true;
            TB_Nickname.Text = nickname;
            TB_Nivel.Text = nivel;
            this.cartas = cartas;
            this.filas = filas;
            this.columnas = columnas;
            this.musica = musica;
            disponibilidad = new bool[filas, columnas]; 

            for(int i = 0; i < filas; i++)
            {
                for(int j=0; j<columnas; j++)
                {
                    disponibilidad[i, j] = true;
                }
            }
            if((filas > 0 && columnas > 0)&&(filas < 8 && columnas < 8))
            {
                /*delegado = new ThreadStart(Reproducir_Musica);
                hilo = new Thread(delegado);
                hilo.Start();*/

                foreach(string card in cartas)
                {
                    cartas_copia.Add(card);
                }
                Añadir_Cartas();
            }
            else if(filas > 7 && columnas > 7){
                MessageBox.Show("Es en serio, por que tantas? te pondre una de 7x7", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filas = 7;
                columnas = 7;
                foreach (string card in cartas)
                {
                    cartas_copia.Add(card);
                }
                Añadir_Cartas();
            }
            else
            {
                MessageBox.Show("Error de numero de filas y columnas (menor o igual a 0)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void Añadir_Cartas()
        {
            int tamaño;
            if (filas > 2)
            {
                tamaño = panel1.Size.Height / filas;
                panel1.Width = tamaño * columnas;
                panel1.Size = new Size(tamaño * columnas, panel1.Height);
            }
            else
            {
                tamaño = 150;
                panel1.Width = tamaño * columnas;
                panel1.Size = new Size(tamaño * columnas, tamaño*filas);
            }
            Random random = new Random();
            int f1, c1, f2, c2;

            while (true)
            {
                random = new Random();
                f1 = random.Next(0, filas);
                f2 = random.Next(0, filas);
                random = new Random();
                c1 = random.Next(0, columnas);
                c2 = random.Next(0, columnas);

                if (Disponibilidad())
                {
                    break;
                }

                if (cartas_copia.Count ==0)
                {
                    foreach(string cr in cartas)
                    {
                        cartas_copia.Add(cr);
                    }
                }

                if (disponibilidad[f1,c1] && disponibilidad[f2, c2] && (c1!=c2 || f1 != f2))
                {
                    string link = cartas_copia.First().Split(',')[1];
                    cartas_copia.RemoveAt(0);
                    Posicionar_Cartas(c1*tamaño, f1*tamaño, tamaño, link);
                    Posicionar_Cartas(c2 * tamaño, f2 * tamaño, tamaño, link);
                    disponibilidad[f1, c1] = false;
                    disponibilidad[f2, c2] = false;
                }

            }
        }

        public bool Disponibilidad()
        {
            foreach(bool valor in disponibilidad)
            {
                if (valor)
                {
                    return false;
                }
            }
            return true;
        }

        public void Posicionar_Cartas(int posX, int posY, int tamaño, string link)
        {
            Button boton = new Button();
            boton.Location = new Point(posX, posY);
            boton.Size = new Size(tamaño, tamaño);
            try
            {
                Image img = redimensionar(link, tamaño);
                if(img == null)
                {
                    boton.Image = Image.FromFile(link);
                }
                else
                {
                    boton.Image = img;
                }
                
                boton.ImageAlign = ContentAlignment.MiddleCenter;
            }
            catch(Exception ex)
            {
                boton.Text = "N/F";
            }
            panel1.Controls.Add(boton);
        }

        public static Image redimensionar(string link, int tamaño)
        {
            try
            {
                Stream stream = File.OpenRead(link);
                Bitmap vieja = new Bitmap(stream);
                Size size = new Size(tamaño, tamaño);

                var radio = Math.Max((double)tamaño/size.Width, (double)tamaño/size.Height);

                var ancho = (int)(size.Width * radio);
                var alto = (int)(size.Height * radio);

                var nueva = new Bitmap(ancho, alto);

                Graphics.FromImage(nueva).DrawImage(vieja, 0, 0, ancho, alto);
                Bitmap final = new Bitmap(nueva);
                return (Image)final;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        
        private void Reproducir_Musica()
        {
            while (musica.Count != 0)
            {
                try
                {
                    if (musica[0].Split('.')[1].ToLower() == "mp3")
                    {
                        TB_Musica.Text = musica[0];
                        WindowsMediaPlayer player = new WindowsMediaPlayer();
                        player.URL = musica[0];
                        player.controls.play();
                    }
                    else if(musica[0].Split('.')[1].ToLower() == "wav")
                    {
                        TB_Musica.Text = musica[0];
                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = musica[0];
                        player.Play();
                    }
                    else
                    {
                        TB_Musica.Text = "Formato no reconocido";
                    }
                }
                catch (Exception ex)
                {
                    TB_Musica.Text = "Error de reproduccion";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hilo.IsAlive)
            {
                hilo.Suspend();
            }
        }
    }
}
