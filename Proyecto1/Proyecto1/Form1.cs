using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Proyecto1
{
    public partial class Form1 : Form

    {
        private LinkedList<Token> tokens = new LinkedList<Token>();
        private LinkedList<Error> errores = new LinkedList<Error>();
        private LinkedList<Error> sintacticos = new LinkedList<Error>();
        private Analizador_Sintactico analizador_sintactico;
        private Analisis_Sintactico asin;
        private String[] palabras_reservadas = {"configuracion","usuarios","niveles","facil","intermedio","dificil","juego","nombre","carta","ruta","x","sonido"};
        private String archivo_actual = "";
        private String entrada = "";
        private String lexema = "";
        private String tipo_dato = "";
        private char caracter;
        private int valor;
        private int fila = 0;
        private int columna = 0;
        private Boolean permiso = true;
        private Boolean bandera = true;
        private Boolean ids8 = true;
        private bool jugar = false;
        private int contador_tokens = 0;
        private int contador_errores = 0;
        
 
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb_entrada.Text = "";
            archivo_actual = "";
            label_archivo.Text = "Sin Guardar*";
            label_errores.Text = "0";
            label_tokens.Text = "0";
            Token tk = new Token();
            Error err = new Error();
            tokens = new LinkedList<Token>();
            errores = new LinkedList<Error>();
            sintacticos = new LinkedList<Error>();
            fila = 0;
            columna = 0;
            lexema = "";
            permiso = true;
            jugar = false;
            contador_errores = 0;
            contador_tokens = 0;

            
        }

        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Texto|*.lfp";

            if (rtb_entrada.Text != string.Empty)
            {
                StreamWriter sw;
                if (archivo_actual != "")
                {
                    sw = new StreamWriter(archivo_actual);
                    sw.WriteLine(rtb_entrada.Text);
                    sw.Close();
                    MessageBox.Show("Guardado con exito", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (sfd.FileName != string.Empty))
                    {
                        sw = new StreamWriter(sfd.FileName);
                        archivo_actual = sfd.FileName;
                        String[] carpetas = sfd.FileName.Split('\\');
                        label_archivo.Text = carpetas.Last();
                        sw.WriteLine(rtb_entrada.Text);
                        sw.Close();
                        MessageBox.Show("Guardado con exito", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }

            else
            {
                MessageBox.Show("No hay texto que guardar", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Texto|*.lfp";
            StreamWriter sw;

            if (rtb_entrada.Text != "")
            {
                if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (sfd.FileName != string.Empty))
                {
                    sw = new StreamWriter(sfd.FileName);
                    archivo_actual = sfd.FileName;
                    String[] carpetas = sfd.FileName.Split('\\');
                    label_archivo.Text = carpetas.Last();
                    sw.WriteLine(rtb_entrada.Text);
                    sw.Close();
                    MessageBox.Show("Guardado con exito", "Guardar Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay texto que guardar", "Guardar Archivo Como...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Texto|*.lfp";
            StreamReader sr;

            if ((ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (ofd.FileName != string.Empty))
            {
                sr = new StreamReader(ofd.FileName);
                archivo_actual = ofd.FileName;
                String[] carpetas = ofd.FileName.Split('\\');
                label_archivo.Text = carpetas.Last();
                rtb_entrada.Text = sr.ReadToEnd();
                sr.Close();
                MessageBox.Show("Abierto con exito", "Abrir Archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_entrada.Text != "")
            {
                Token tk = new Token();
                Error err = new Error();
                tokens = new LinkedList<Token>();
                errores = new LinkedList<Error>();
                fila = 0;
                columna = 0;
                lexema = "";
                permiso = true;
                contador_errores = 0;
                contador_tokens = 0;


                entrada = rtb_entrada.Text;
                analisis_lexico();
                label_errores.Text = contador_errores + "";
                label_tokens.Text = contador_tokens + "";
            }
            else
            {
                MessageBox.Show("No hay datos que Analizar ", "Error de Analisis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void listaDeTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tokens.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "HTML|*.html";
                StreamWriter sw;

                if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (sfd.FileName != string.Empty))
                {
                    sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine("<HTML>");
                    sw.WriteLine("<BODY>");
                    sw.WriteLine("<P> Reporte de Tokens </P>");
                    sw.WriteLine("<TABLE border = '1'>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td>   No   </td><td>    Lexema   </td><td>    Token    </td><td>    Fila   </td><td>   Columna  </td> ");
                    sw.WriteLine("</tr>");

                    LinkedList<Token> copia1 = new LinkedList<Token>();

                    foreach (Token elemento in tokens)
                    {
                        copia1.AddLast(elemento);
                    }

                    foreach (Token temporal in copia1)
                    {
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td>  "+temporal.getNumero()+"   </td><td>  "+temporal.getLexema()+"   </td><td>   "+temporal.getToken()+"   </td><td>    "+temporal.getFila()+"   </td><td>   "+temporal.getColumna()+"  </td> ");
                        sw.WriteLine("</tr>");
                    }

                    sw.WriteLine("</TABLE>");
                    sw.WriteLine("</BODY>");
                    sw.WriteLine("</HTML>");
                    sw.Close();

                    Process.Start(sfd.FileName);
                }

            }
            else
            {
                MessageBox.Show("No Hay Tokens Que Reportar", "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void listaDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errores.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "HTML|*.html";
                StreamWriter sw;

                if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (sfd.FileName != string.Empty))
                {
                    sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine("<HTML>");
                    sw.WriteLine("<BODY>");
                    sw.WriteLine("<P> Reporte de Tokens </P>");
                    sw.WriteLine("<TABLE border = '1'>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td>   No   </td><td>    Lexema   </td><td>    Fila   </td><td>   Columna  </td><td>    Error    </td> ");
                    sw.WriteLine("</tr>");

                    LinkedList<Error> copia = new LinkedList<Error>();

                    foreach (Error elemento in errores)
                    {
                        copia.AddLast(elemento);
                    }
                    foreach (Error temporal in copia)
                    {
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td>  " + temporal.getNumero() + "   </td><td>  " + temporal.getLexema() + "   </td><td>    " + temporal.getFila() + "   </td><td>   " + temporal.getColumna() + "  </td><td>   " + temporal.getError() + "   </td> ");
                        sw.WriteLine("</tr>");
                    }

                    sw.WriteLine("</TABLE>");
                    sw.WriteLine("</BODY>");
                    sw.WriteLine("</HTML>");
                    sw.Close();

                    Process.Start(sfd.FileName);
                }

            }
            else
            {
                MessageBox.Show("No Hay Errores Que Reportar", "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anthony Amilcar Barrios Herrera \n201503868 \nLenguajes Formales y de Programacion ", "Acerca de...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void boton_analisis_Click(object sender, EventArgs e)
        {
            if (rtb_entrada.Text != "")
            {
                Token tk = new Token();
                Error err = new Error();
                tokens = new LinkedList<Token>();
                errores = new LinkedList<Error>();
                sintacticos = new LinkedList<Error>();
                fila = 0;
                columna = 0;
                lexema = "";
                permiso = true;
                contador_errores = 0;
                contador_tokens = 0;


                entrada = rtb_entrada.Text;
                analisis_lexico();
                label_errores.Text = contador_errores + "";
                label_tokens.Text = contador_tokens + "";
            }
            else
            {
                MessageBox.Show("No hay datos que Analizar ", "Error de Analisis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void analisis_lexico()
        {
            while (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada=entrada.Remove(0, 1);
                valor = (int)caracter;

                if ((valor>=65 && valor<=90) || (valor>=97 && valor<=122)) //  letra
                {
                    lexema += caracter;
                    columna++;
                    if (permiso)
                    {
                        S1();
                    }
                }
                
                
                else if (valor == 34) //  comillas
                {
                    
                    if (permiso)
                    {
                        lexema += caracter;
                        columna++;
                        S4();
                    }
                    else
                    {
                        errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                        contador_errores++;
                        lexema = "";
                        MessageBox.Show(caracter+"");
                        lexema += caracter;
                        columna++;
                        S4();
                    }
                }
                else if (valor == 61 || valor == 91 || valor == 93 || valor == 47 || valor == 59)  //  Simbolos aceptados
                {
                    if (!permiso && lexema!="")
                    {
                        errores.AddLast(new Error(lexema,fila,columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                        contador_errores++;
                        lexema = "";
                    }
                    permiso = true;
                    tokens.AddLast(new Token(caracter+"","Tk_"+caracter,fila,columna));
                    contador_tokens++;
                    columna++;
                    
                }
                else if (valor == 9 || valor == 32) //  tab y espacio en blanco
                {
                    if (!permiso && lexema != "")
                    {
                        errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                        contador_errores++;
                        lexema = "";
                    }
                    permiso = true;
                    columna++;
                }
                else if (valor == 10)  //  enter  
                {
                    if (!permiso && lexema != "")
                    {
                        errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                        contador_errores++;
                        lexema = "";
                    }
                    permiso = true;
                    columna = 0;
                    fila++;
                }
                else
                {
                    permiso = false;
                    lexema += caracter;
                    columna++;
                }
            }
            if (lexema != "")
            {
                errores.AddLast(new Error(lexema, fila, columna-lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
                permiso = true;
            }
            label_errores.Text = contador_errores+"";
            label_tokens.Text = contador_tokens + "";
            MessageBox.Show("Analisis Completado", "Analisis", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void S1()
        {
            if(entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;

                if ((valor >= 65 && valor <= 90) || (valor >= 97 && valor <= 122))
                {
                    lexema += caracter;
                    columna++;
                    S1();
                }
                else if (valor == 61 || valor == 91 || valor == 93 || valor == 47 || valor == 59 || valor == 9 || valor == 32 || valor == 10)
                {
                    prueba_Palabras_Reservadas(lexema);
                    lexema = "";
                    entrada = entrada.Insert(0,caracter+"");
                }
                else
                {
                    if (lexema.ToLower()=="x" && valor == 34)
                    {
                        prueba_Palabras_Reservadas(lexema);
                        lexema = "";
                        entrada = entrada.Insert(0, caracter + "");
                    }
                    else
                    {
                        permiso = false;
                        entrada = entrada.Insert(0, caracter + "");
                    }
                }
            }
            else
            {
                prueba_Palabras_Reservadas(lexema);
                lexema = "";
            }
        }

        private void S2()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
                //MessageBox.Show("S2: " + caracter);

                if (valor >= 48 && valor <= 57)
                {
                    lexema += caracter;
                    columna++;
                    S2();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Entero";
                    S6();
                }
                else if (valor == 9 || valor == 32)
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Entero";
                    S4();
                }
                else if(valor == 10)
                {
                    lexema += caracter;
                    columna=0;
                    fila++;
                    bandera = false;
                    tipo_dato = "Entero";
                    S4();
                }
                else if (valor == 46)
                {
                    lexema += caracter;
                    columna++;
                    S5();
                }
                else
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S3()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
                //MessageBox.Show("S3: " + caracter);

                if (valor >= 48 && valor <= 57)
                {
                    lexema += caracter;
                    columna++;
                    S2();
                }
                else
                {
                    entrada = entrada.Insert(0, caracter + "");
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S4()
        {
            while (true)
            {
                if (entrada != "")
                {
                    caracter = entrada.First<char>();
                    entrada = entrada.Remove(0, 1);
                    valor = (int)caracter;
                   // MessageBox.Show("S4: " + caracter);

                    if (valor == 34)
                    {
                        lexema += caracter;
                        columna++;
                        tipo_dato = "Error";
                        S6();
                        break;
                    }
                    else if ((valor >= 65 && valor <= 90) || (valor >= 97 && valor <= 122))
                    {
                        lexema += caracter;
                        columna++;
                        if (bandera)
                        {
                            S8();
                            break;
                        }
                        continue;
                    }
                    else if (valor >= 48 && valor <= 57)
                    {
                        lexema += caracter;
                        columna++;
                        if (bandera)
                        {
                            S2();
                            break;
                        }
                        continue;
                    }
                    else if (valor == 43 || valor == 45)
                    {
                        lexema += caracter;
                        columna++;
                        if (bandera)
                        {
                            S3();
                            break;
                        }
                        continue;
                    }
                    else if (valor == 9 || valor == 32)
                    {
                        lexema += caracter;
                        columna++;
                        continue;
                    }
                    else if (valor == 10)
                    {
                        lexema += caracter;
                        columna = 0;
                        fila++;
                        continue;
                    }
                    else
                    {
                        lexema += caracter;
                        columna++;
                        bandera = false;
                        tipo_dato = "Error";
                        continue;
                    }

                }
                else
                {
                    errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                    contador_errores++;
                    lexema = "";
                    break;
                }
            }
        }

        private void S5()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;

                if (valor >= 48 && valor <= 57)
                {
                    lexema += caracter;
                    columna++;
                    S7();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Error";
                    S6();
                }
                else if (valor == 9 || valor == 32 || valor == 10)
                {
                    entrada = entrada.Insert(0, caracter + "");
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
                else
                {
                    bandera = false;
                    entrada = entrada.Insert(0, caracter + "");
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S6()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;

                if (valor == 61 || valor == 91 || valor == 93 || valor == 47 || valor == 59 || valor == 9 || valor == 32 || valor == 10 || valor == 88 || valor == 120)
                {
                    prueba_Cadenas(lexema);
                    lexema = "";
                    entrada = entrada.Insert(0, caracter + "");
                }
                else
                {
                    permiso = false;
                    entrada = entrada.Insert(0, caracter + "");
                }
                bandera = true;
                ids8 = true;
            }
            else
            {
                prueba_Cadenas(lexema);
                lexema = "";
            }
        }

        private void S7()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;

                if (valor >= 48 && valor <= 57)
                {
                    lexema += caracter;
                    columna++;
                    S7();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Decimal";
                    S6();
                }
                else if (valor == 9 || valor == 32 || valor == 10)
                {
                    entrada = entrada.Insert(0, caracter + "");
                    bandera = false;
                    tipo_dato = "Decimal";
                    S4();
                }
                else
                {
                    bandera = false;
                    entrada = entrada.Insert(0, caracter + "");
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S8()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
                //MessageBox.Show("S8: " + caracter);

                if (((valor >= 48 && valor <= 57) || (valor >= 65 && valor <= 90) || (valor >= 97 && valor <= 122)) || valor == 95)
                {
                    lexema += caracter;
                    columna++;
                    ids8 = false;
                    S8();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Id";
                    S6();
                }
                else if (valor == 9 || valor == 32)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Id";
                    S8();
                }
                else if (valor == 10)
                {
                    lexema += caracter;
                    columna=0;
                    fila++;
                    tipo_dato = "Id";
                    S8();
                }
                else if (valor == 58)
                {
                    lexema += caracter;
                    columna++;
                    if (ids8)
                    {
                        S9();
                    }
                    else
                    {
                        bandera = false;
                        tipo_dato = "Error";
                        S4();
                    }
                }
                else
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S9()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
                //MessageBox.Show("S9: " + caracter);

                if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Error";
                    S6();
                }
                else if (valor == 9 || valor == 32)
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
                else if (valor == 10)
                {
                    lexema += caracter;
                    columna = 0;
                    bandera = false;
                    fila++;
                    tipo_dato = "Error";
                    S4();
                }
                else if (valor == 92)
                {
                    lexema += caracter;
                    columna++;
                    S10();
                }
                else
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S10()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
               // MessageBox.Show("S10: " + caracter);

                if (((valor >= 48 && valor <= 57) || (valor >= 65 && valor <= 90) || (valor >= 97 && valor <= 122)) || valor == 92 || valor == 95)
                {
                    lexema += caracter;
                    columna++;
                    S10();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Error";
                    S6();
                }
                else if (valor == 9 || valor == 32)
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
                else if (valor == 10)
                {
                    lexema += caracter;
                    columna=0;
                    fila++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
                else if (valor == 46)
                {
                    lexema += caracter;
                    columna++;
                    S11();
                }

                else
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private void S11()
        {
            if (entrada != "")
            {
                caracter = entrada.First<char>();
                entrada = entrada.Remove(0, 1);
                valor = (int)caracter;
               // MessageBox.Show("S11: " + caracter);

                if (((valor >= 48 && valor <= 57) || (valor >= 65 && valor <= 90) || (valor >= 97 && valor <= 122)))
                {
                    lexema += caracter;
                    columna++;
                    S11();
                }
                else if (valor == 34)
                {
                    lexema += caracter;
                    columna++;
                    tipo_dato = "Ruta";
                    S6();
                }
                else if (valor == 9 || valor == 32)
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Ruta";
                    S4();
                }
                else if (valor ==10)
                {
                    lexema += caracter;
                    columna=0;
                    fila++;
                    bandera = false;
                    tipo_dato = "Ruta";
                    S4();
                }
                else
                {
                    lexema += caracter;
                    columna++;
                    bandera = false;
                    tipo_dato = "Error";
                    S4();
                }
            }
            else
            {
                errores.AddLast(new Error(lexema, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                lexema = "";
            }
        }

        private Boolean prueba_Palabras_Reservadas(String cadena)
        {
            
            for (int n=0; n < palabras_reservadas.Length; n++)
            {
                if (palabras_reservadas[n] == cadena.ToLower())
                {
                    tokens.AddLast(new Token(cadena, "Tk_"+cadena.ToUpper(), fila, columna - lexema.Length));
                    contador_tokens++;
                    return true;
                }
            }
            errores.AddLast(new Error(cadena, fila, columna - lexema.Length, "Error Léxico, Token No Reconocido"));
            contador_errores++;
            return true;
        }

        private void prueba_Cadenas(String cadena)
        {
           if (tipo_dato != "")
            {
                if (tipo_dato == "Error")
                {
                    errores.AddLast(new Error(cadena, fila, columna - cadena.Length, "Error Léxico, Token No Reconocido"));
                    contador_errores++;
                    permiso = false;
                }
                else
                {
                    tokens.AddLast(new Token(cadena + "", "Tk_" + tipo_dato, fila, columna));
                    contador_tokens++;
                }
            }
            else
            {
                errores.AddLast(new Error(cadena, fila, columna - cadena.Length, "Error Léxico, Token No Reconocido"));
                contador_errores++;
                permiso = false;
            }
            tipo_dato = "";
            bandera = true;
            ids8 = true;
        }

        private void analisisLexicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_entrada.Text != "")
            {
                Token tk = new Token();
                Error err = new Error();
                tokens = new LinkedList<Token>();
                errores = new LinkedList<Error>();
                fila = 0;
                columna = 0;
                lexema = "";
                permiso = true;
                bandera = true;
                ids8 = true;
                contador_errores = 0;
                contador_tokens = 0;


                entrada = rtb_entrada.Text;
                analisis_lexico();
                label_errores.Text = contador_errores + "";
                label_tokens.Text = contador_tokens + "";
            }
            else
            {
                MessageBox.Show("No hay datos que Analizar ", "Error de Analisis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void analisisSintacticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (errores.Count() == 0 && tokens.Count()!=0)
            {
                LinkedList<Token> copia = new LinkedList<Token>();
                
                foreach (Token elemento in tokens){
                    copia.AddLast(elemento);
                }

                asin = new Analisis_Sintactico(copia);
                asin.AS0();

                sintacticos = asin.Devolver_Errores();
                if (sintacticos != null)
                {
                    jugar = false;
                    label_errores.Text = sintacticos.Count + "" ;
                    MessageBox.Show("Analisis Sintactico Realizado Con Errores", "Analisis Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    jugar = true;
                    label_errores.Text = "0";
                    MessageBox.Show("Analisis Sintactico Realizado Sin Errores", "Analisis Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*analizador_sintactico = new Analizador_Sintactico(copia);
                analizador_sintactico.AS0();

                if (analizador_sintactico.getHayError())
                {
                    Error es = analizador_sintactico.Mostrar_Error();
                    MessageBox.Show( " Lexema: " + es.getLexema() + "\n Fila: " + es.getFila() + "\n Columna: " + es.getColumna() + "\n Descripcion: " + es.getError(), "Error Sintactico", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    contador_errores=1;
                    label_errores.Text = contador_errores + "";
                }
                else
                {
                    MessageBox.Show("Analisis Sintactico Realizado Sin Errores","Analisis Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
            else
            {
                MessageBox.Show("No es posible analizar sintacticamente \n debido a que no ha analizado lexicamente una entrada o existen errores lexicos", "Error de Analisis Sintactico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void listaDeErroresSintacticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sintacticos.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "HTML|*.html";
                StreamWriter sw;

                if ((sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) && (sfd.FileName != string.Empty))
                {
                    sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine("<HTML>");
                    sw.WriteLine("<BODY>");
                    sw.WriteLine("<P> Reporte de Tokens </P>");
                    sw.WriteLine("<TABLE border = '1'>");
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td>   No   </td><td>    Lexema   </td><td>    Fila   </td><td>   Columna  </td><td>    Error    </td> ");
                    sw.WriteLine("</tr>");

                    LinkedList<Error> copia = new LinkedList<Error>();

                    foreach (Error elemento in sintacticos)
                    {
                        copia.AddLast(elemento);
                    }
                    foreach (Error temporal in copia)
                    {
                        sw.WriteLine("<tr>");
                        sw.WriteLine("<td>  " + temporal.getNumero() + "   </td><td>  " + temporal.getLexema() + "   </td><td>    " + temporal.getFila() + "   </td><td>   " + temporal.getColumna() + "  </td><td>   " + temporal.getError() + "   </td> ");
                        sw.WriteLine("</tr>");
                    }

                    sw.WriteLine("</TABLE>");
                    sw.WriteLine("</BODY>");
                    sw.WriteLine("</HTML>");
                    sw.Close();

                    Process.Start(sfd.FileName);
                }

            }
            else
            {
                MessageBox.Show("No Hay Errores Que Reportar", "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void jugarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (asin != null && jugar)
            {
                Datos datos = new Datos(asin.Dar_Usuarios(), asin.Dar_Cartas(), asin.Dar_Musica(), asin.Niveles);
            }
        }
    }
}
