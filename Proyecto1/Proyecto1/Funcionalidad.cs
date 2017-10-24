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
        private List<string> musica = new List<string>();
        private int filas;
        private int columnas;
        private bool[,] disponibilidad;
        ThreadStart delegado;
        Thread hilo;

        public Funcionalidad(string nickname, string nivel, int filas, int columnas, List<string> cartas, List<string> musica)
        {
            InitializeComponent();

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
            if(filas > 0 && columnas > 0)
            {
                delegado = new ThreadStart(Reproducir_Musica);
                hilo = new Thread(delegado);
                hilo.Start();
                Añadir_Cartas();
            }
            else
            {
                MessageBox.Show("Error de numero de filas y columnas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void Añadir_Cartas()
        {
            
            int tamaño = panel1.Size.Height/filas;
            panel1.Width = tamaño * columnas;
            Random random = new Random();
            int f1, c1, f2, c2;

            while (true)
            {
                f1 = random.Next(0, filas - 1);
                f2 = random.Next(0, filas - 1);
                c1 = random.Next(0, columnas - 1);
                c2 = random.Next(0, columnas - 1);

                if (cartas.Count == 0)
                {
                    break;
                }

                if (disponibilidad[f1,c1] && disponibilidad[f2, c2] && (c1!=c2 || f1 != f2))
                {
                    string link = cartas.First();
                    cartas.RemoveAt(0);
                    Posicionar_Cartas(f1*tamaño, c1*tamaño, tamaño, link);
                    Posicionar_Cartas(f2 * tamaño, c2 * tamaño, tamaño, link);
                }

            }
        }

        public void Posicionar_Cartas(int posX, int posY, int tamaño, string link)
        {
            Button boton = new Button();
            boton.Location = new Point(posX, posY);
            boton.Size = new Size(tamaño, tamaño);
            try
            {
                redimensionar(link, tamaño);
                boton.Image = Image.FromFile(link);
            }
            catch(Exception ex)
            {
                boton.Text = "N/F";
            }
            panel1.Controls.Add(boton);
        }

        public static void redimensionar(string link, int tamaño)
        {
            try
            {
                Stream stream = File.OpenRead(link);
                Bitmap vieja = new Bitmap(stream);
                Size size = new Size(tamaño, tamaño);

                int alto_vieja = vieja.Width;
                int ancho_vieja = vieja.Height;

                float proporcion = 0;
                float proporcionH = 0;
                float proporcionW = 0;

                proporcionH = ((float)size.Height / (float)alto_vieja);
                proporcionW = ((float)size.Width / (float)ancho_vieja);

                if(proporcionH < proporcionW)
                {
                    proporcion = proporcionH;
                }
                else
                {
                    proporcion = proporcionW;
                }

                int ancho_nueva = (int)(ancho_vieja * proporcion);
                int alto_nueva = (int)(alto_vieja * proporcion);

                Bitmap nueva = new Bitmap(ancho_nueva, alto_nueva);
                Graphics graficos = Graphics.FromImage((Image)nueva);
                graficos.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graficos.DrawImage(vieja, 0, 0, ancho_nueva, alto_nueva);
                graficos.Dispose();

                ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
                EncoderParameter calidad = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 99L);
                EncoderParameters eps = new EncoderParameters(1);
                eps.Param[0] = calidad;
                nueva.Save(link, ici, eps);

                vieja.Dispose();
                stream.Close();
                stream.Dispose();
                nueva.Dispose();
                graficos.Dispose();

            }
            catch (Exception ex)
            {

            }
        }

        private static ImageCodecInfo GetEncoderInfo(string v)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();

            for(j = 0; j<encoders.Length; ++j)
            {
                if(encoders[j].MimeType == v)
                {
                    return encoders[j];
                }
            }
            return null;
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
