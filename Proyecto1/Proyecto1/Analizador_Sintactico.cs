using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Analizador_Sintactico
    {

        private LinkedList<Token> tokens;
        private Error error_sintactico;
        private Token temporal,temporal2;
        private Boolean hayError = false;
        

        public Analizador_Sintactico(LinkedList<Token> t)
        {
            tokens = t;
        }

        public Boolean getHayError()
        {
            return hayError;
        }

        public Error Mostrar_Error()
        {
            if (hayError)
            {
                return error_sintactico;
            }
            return null;
        }

        public void AS0()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0 " + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_CONFIGURACION");

                    if (temporal.getToken() != "Tk_CONFIGURACION")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Configuracion\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS1();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_/");

                    if (temporal.getToken() != "Tk_/")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_CONFIGURACION");

                    if (temporal.getToken() != "Tk_CONFIGURACION")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Configuracion\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS0" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    if (tokens.Count() != 0)
                    {
                        AS0();
                        break;
                    }
                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0 , 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   //AS0  y AS0'

        private void AS1()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS2();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();

                    if (temporal.getToken() == "Tk_JUEGO" || temporal.getToken() == "Tk_USUARIOS" || temporal.getToken() == "Tk_CARTA")
                    {
                        tokens.AddFirst(temporal2);
                        AS1();
                        break;
                    }
                    tokens.AddFirst(temporal2);
                    break;


                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   //CUERPO y RCUERPO

        private void AS2()
        {
            try
            {
                temporal = tokens.First();
                tokens.RemoveFirst();
                //MessageBox.Show("AS2" + temporal.getToken() + " : Tk_JUEGO, Tk_USUARIOS, Tk_CARTA");

                switch (temporal.getToken())
                {
                    case "Tk_JUEGO":
                        temporal = tokens.First();
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_]");

                        if (temporal.getToken() != "Tk_]")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }
                        AS3();
                        break;

                    case "Tk_USUARIOS":
                        temporal = tokens.First();
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_]");

                        if (temporal.getToken() != "Tk_]")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }
                        AS4();
                        break;

                    case "Tk_CARTA":
                        temporal = tokens.First();
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_]");

                        if (temporal.getToken() != "Tk_]")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }
                        AS5();
                        break;
                    default:
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Juego\", \"Usuarios\" o \"Carta\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   //CUERPO'

        private void AS3()
        {
            try
            {
                while (true)
                {
                    AS3_1();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_/");

                    if (temporal.getToken() != "Tk_/")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_JUEGO");

                    if (temporal.getToken() != "Tk_JUEGO")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Juego\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   //JUEGO

        private void AS3_1()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3_1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS3_2();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS3_1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();

                    if (temporal.getToken() == "Tk_SONIDO" || temporal.getToken() == "Tk_NIVELES")
                    {
                        tokens.AddFirst(temporal2);
                        AS3_1();
                        break;
                    }
                    tokens.AddFirst(temporal2);
                    break;

                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   // BJUEGO

        private void AS3_2()
        {
            try
            {
                temporal = tokens.First();
                tokens.RemoveFirst();
                //MessageBox.Show("AS3_2" + temporal.getToken() + " : Tk_SONIDO, Tk_NIVELES");

                switch (temporal.getToken())
                {
                    case "Tk_SONIDO":
                        AS6();
                        break;
                    case "Tk_NIVELES":
                        AS7();
                        break;
                    default:
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Sonido\" o \"Niveles\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }   // BJUEGO'

        private void AS4()
        {
            try
            {
                while (true)
                {

                    AS10();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS4" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();

                    if (temporal.getToken() == "Tk_NOMBRE")
                    {
                        tokens.AddFirst(temporal2);
                        AS4();
                    }
                    else if (temporal.getToken() == "Tk_/")
                    {
                        tokens.RemoveFirst();

                        temporal = tokens.First();
                        tokens.RemoveFirst();

                        if (temporal.getToken() != "Tk_USUARIOS")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Usuarios\" y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();
                        tokens.RemoveFirst();

                        if (temporal.getToken() != "Tk_]")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();
                        temporal2 = temporal;
                        tokens.RemoveFirst();

                        if (temporal.getToken() != "Tk_[")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();

                        if (temporal.getToken() == "Tk_USUARIOS" || temporal.getToken() == "Tk_JUEGO" || temporal.getToken() == "Tk_CARTA")
                        {
                            tokens.AddFirst(temporal2);
                            AS1();
                            break;
                        }

                        tokens.AddFirst(temporal2);
                        break;
                    }
                    else
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }     //BUSUARIOS

        private void AS5()
        {
            try
            {
                while (true)
                {

                    AS10();

                    if (hayError)
                    {
                        break;
                    }

                    AS8();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_NOMBRE");

                    if (temporal.getToken() == "Tk_NOMBRE")
                    {
                        tokens.AddFirst(temporal2);
                        AS5();
                        break;
                    }
                    else if (temporal.getToken() == "Tk_/")
                    {
                        //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_/");
                        tokens.RemoveFirst();

                        temporal = tokens.First();
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_CARTA");

                        if (temporal.getToken() != "Tk_CARTA")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Carta\" y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_]");

                        if (temporal.getToken() != "Tk_]")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();
                        temporal2 = temporal;
                        tokens.RemoveFirst();
                        //MessageBox.Show("AS5" + temporal.getToken() + " : Tk_[");

                        if (temporal.getToken() != "Tk_[")
                        {
                            error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                            hayError = true;
                            break;
                        }

                        temporal = tokens.First();

                        if (temporal.getToken() == "Tk_USUARIOS" || temporal.getToken() == "Tk_JUEGO" || temporal.getToken() == "Tk_CARTA")
                        {
                            tokens.AddFirst(temporal2);
                            AS1();
                            break;
                        }

                        tokens.AddFirst(temporal2);
                        break;
                    }
                    else
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }
                    
                }
            }
            catch (Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }     //BCARTAS

        private void AS6()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS6_1();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6" + temporal.getToken() + " : Tk_/");

                    if (temporal.getToken() != "Tk_/")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6" + temporal.getToken() + " : Tk_SONIDO");

                    if (temporal.getToken() != "Tk_SONIDO")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Sonido\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    break;

                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  //Hecho

        private void AS7()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS7_1();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7" + temporal.getToken() + " : Tk_/");

                    if (temporal.getToken() != "Tk_/")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba / y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7" + temporal.getToken() + " : Tk_NIVELES");

                    if (temporal.getToken() != "Tk_NIVELES")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Niveles\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    break;

                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  //Hecho

        private void AS6_1()
        {
            try
            {
                while (true)
                {
                    AS8();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS6_1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();

                    if (temporal.getToken() == "Tk_RUTA")
                    {
                        tokens.AddFirst(temporal2);
                        AS6_1();
                        break;
                    }
                    tokens.AddFirst(temporal2);
                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  //Hecho

        private void AS7_1()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7_1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7_1" + temporal.getToken() + " : Tk_FACIL, Tk_INTERMEDIO, Tk_DIFICIL");

                    if (temporal.getToken() != "Tk_FACIL" && temporal.getToken() != "Tk_INTERMEDIO" && temporal.getToken() != "Tk_DIFICIL")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Facil\", \"Intermedio\" o \"Dificil\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7_1" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7_1" + temporal.getToken() + " : Tk_=");

                    if (temporal.getToken() != "Tk_=")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba = y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    AS9();

                    if (hayError)
                    {
                        break;
                    }

                    temporal = tokens.First();
                    temporal2 = temporal;
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS7_1" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();

                    if (temporal.getToken() == "Tk_FACIL" || temporal.getToken() == "Tk_INTERMEDIO" || temporal.getToken() == "Tk_DIFICIL")
                    {
                        tokens.AddFirst(temporal2);
                        AS7_1();
                        break;
                    }
                    tokens.AddFirst(temporal2);
                    break;

                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  //Hecho 

        private void AS8()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_RUTA");

                    if (temporal.getToken() != "Tk_RUTA")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Ruta\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_=");

                    if (temporal.getToken() != "Tk_=")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba = y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_Ruta");

                    if (temporal.getToken() != "Tk_Ruta")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba Ruta Válida y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS8" + temporal.getToken() + " : Tk_];");

                    if (temporal.getToken() != "Tk_;")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ; y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }
                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  // RUTA

        private void AS9()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_Entero, Tk_Decimal");

                    if (temporal.getToken() != "Tk_Entero" && temporal.getToken() != "Tk_Decimal")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba Entero o Decimal y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_X");

                    if (temporal.getToken() != "Tk_X")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"X\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_Entero, Tk_Decimal");

                    if (temporal.getToken() != "Tk_Entero" && temporal.getToken() != "Tk_Decimal")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba Entero o Decimal y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS9" + temporal.getToken() + " : Tk_;");

                    if (temporal.getToken() != "Tk_;")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ; y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }
                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  // Asignacion de matrices

        private void AS10()
        {
            try
            {
                while (true)
                {
                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_NOMBRE");

                    if (temporal.getToken() != "Tk_NOMBRE")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba \"Nombre\" y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_=");

                    if (temporal.getToken() != "Tk_=")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba = y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_[");

                    if (temporal.getToken() != "Tk_[")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_Id");

                    if (temporal.getToken() != "Tk_Id")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba Identificador y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_]");

                    if (temporal.getToken() != "Tk_]")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ] y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }

                    temporal = tokens.First();
                    tokens.RemoveFirst();
                    //MessageBox.Show("AS10" + temporal.getToken() + " : Tk_;");

                    if (temporal.getToken() != "Tk_;")
                    {
                        error_sintactico = new Error(temporal.getLexema(), temporal.getFila(), temporal.getColumna(), "Error Sintactico, se esperaba ; y se encontró " + temporal.getLexema());
                        hayError = true;
                        break;
                    }
                    break;
                }
            }
            catch(Exception e)
            {
                error_sintactico = new Error("Falta de Tokens", 0, 0, "Error de Ejecucion Por falta de Tokens ");
                hayError = true;
            }
            
        }  // Nombres
    
    }
}
