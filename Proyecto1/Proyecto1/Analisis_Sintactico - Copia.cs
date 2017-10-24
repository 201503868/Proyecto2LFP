using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Analisis_Sintactico_2
    {
        private LinkedList<Token> tokens;
        private string error_ejecucion;
        private Error error_sintactico;
        private Token preanalisis;
        private bool exito = true;

        public Analisis_Sintactico_2(LinkedList<Token> tokens)
        {
            this.tokens = tokens;
            Token temp = this.tokens.Last();
            Token temporal = new Token("Fin", "Tk_#", temp.getFila(), temp.getColumna() + temp.getLexema().Length);
            this.tokens.AddLast(temporal);
            if(this.tokens.Count != 0)
            {
                preanalisis = this.tokens.First();
                this.tokens.RemoveFirst();
            }
            else
            {
                error_ejecucion = "No hay Tokens";
                Exito = false;
            }
            
        }

        public bool Exito { get => exito; set => exito = value; }
        internal Error Error_sintactico { get => error_sintactico; set => error_sintactico = value; }

        private bool Parea(string terminal)
        {
            if (exito)
            {
                if (preanalisis.getToken() == terminal)
                {
                    preanalisis = tokens.First();
                    tokens.RemoveFirst();
                    return true;
                }
                Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema());
                exito = false;
                return false;
            }
            return false;
        }

        public void AS0()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                if (!Parea("Tk_CONFIGURACION")) { break; }
                if (!Parea("Tk_]")) { break; }
                CUERPO();
                if (!Parea("Tk_/")) { break; }
                if (!Parea("Tk_CONFIGURACION")) { break; }
                if (!Parea("Tk_]")) { break; }
                AS0P();
                break;
            }
        }

        private void AS0P()
        {
            while (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_[":
                        if (!Parea("Tk_[")) { break; }
                        if (!Parea("Tk_CONFIGURACION")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        CUERPO();
                        if (!Parea("Tk_/")) { break; }
                        if (!Parea("Tk_CONFIGURACION")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        AS0P();
                        break;
                    case "Tk_#":
                        break;
                    default:
                        Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba [ y se encontró " + preanalisis.getLexema());
                        exito = false;
                        break;
                }
                break;
            }
        }

        private void CUERPO()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                CUERPOP();
                break;
            }
        }

        private void CUERPOP()
        {
            while (exito)
            {
                
                switch (preanalisis.getToken())
                {
                    case "Tk_JUEGO":
                       // MessageBox.Show("tomo a juego");
                        JUEGO();
                        break;
                    case "Tk_USUARIOS":
                       // MessageBox.Show("Tomo a usuarios");
                        USUARIOS();
                        break;
                    case "Tk_CARTA":
                        //MessageBox.Show("Tomo a cartas");
                        CARTAS();
                        break;
                    default:
                        Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba 'JUEGO', 'USUARIOS' O 'CARTAS' y se encontró " + preanalisis.getLexema());
                        exito = false;
                        break;
                }

                RCUERPO();
                break;
            }
        }

        private void RCUERPO()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                if (preanalisis.getToken() == "Tk_JUEGO" || preanalisis.getToken() == "Tk_USUARIOS" || preanalisis.getToken() == "Tk_CARTA")
                {
                    CUERPOP();
                }
                break;
            }
               
        }

        private void JUEGO()
        {
            while (exito)
            {
                if (!Parea("Tk_JUEGO")) { break; }
                if (!Parea("Tk_]")) { break; }
                BJUEGO();
                if (!Parea("Tk_/")) { break; }
                if (!Parea("Tk_JUEGO")) { break; }
                if (!Parea("Tk_]")) { break; }
                break;
            }
        }

        private void BJUEGO()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                BJUEGOP();
                break;
            }
            
        }

        private void BJUEGOP()
        {
            while (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_SONIDO":
                        Parea("Tk_SONIDO");
                        if (!Parea("Tk_]")) { break; }
                        BSONIDO();
                        if (!Parea("Tk_/")) { break; }
                        if (!Parea("Tk_SONIDO")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        RBJUEGO();
                        break;
                    case "Tk_NIVELES":
                        Parea("Tk_NIVELES");
                        if (!Parea("Tk_]")) { break; }
                        BNIVELES();
                        if (!Parea("Tk_/")) { break; }
                        if (!Parea("Tk_NIVELES")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        RBJUEGO();
                        break;
                    default:
                        Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba 'SONIDO' O 'NIVELES' y se encontró " + preanalisis.getLexema());
                        exito = false;
                        break;
                }
                break;
            }
            
        }

        private void RBJUEGO()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RBJUEGOP();
                break;
            }
        }

        private void RBJUEGOP()
        {
            while (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_SONIDO":
                        Parea("Tk_SONIDO");
                        if (!Parea("Tk_]")) { break; }
                        BSONIDO();
                        if (!Parea("Tk_[")) { break; }
                        if (!Parea("Tk_/")) { break; }
                        if (!Parea("Tk_SONIDO")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        RBJUEGO();
                        break;
                    case "Tk_NIVELES":
                        Parea("Tk_NIVELES");
                        if (!Parea("Tk_]")) { break; }
                        BNIVELES();
                        if (!Parea("Tk_[")) { break; }
                        if (!Parea("Tk_/")) { break; }
                        if (!Parea("Tk_NIVELES")) { break; }
                        if (!Parea("Tk_]")) { break; }
                        RBJUEGO();
                        break;
                    default:
                        break;
                }
                break;
            }
        }

        private void BNIVELES()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                BNIVELESP();
                break;
            }
        }

        private void BNIVELESP()
        {
            while (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_FACIL":
                        Parea("Tk_FACIL");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    case "Tk_INTERMEDIO":
                        Parea("Tk_INTERMEDIO");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    case "Tk_DIFICIL":
                        Parea("Tk_DIFICIL");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    default:
                        Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba 'FACIL', 'INTERMEDIO' O 'DIFICIL' y se encontró " + preanalisis.getLexema());
                        exito = false;
                        break;
                }
                break;
            }

        }

        private void RBNIVELES()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RBNIVELESP();
                break;
            }
        }

        private void RBNIVELESP()
        {
            while (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_FACIL":
                        Parea("Tk_FACIL");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    case "Tk_INTERMEDIO":
                        Parea("Tk_INTERMEDIO");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    case "Tk_DIFICIL":
                        Parea("Tk_DIFICIL");
                        if (!Parea("Tk_]")) { break; }
                        if (!Parea("Tk_=")) { break; }
                        ASIG();
                        RBNIVELES();
                        break;
                    default:
                        break;
                }
                break;
            }
        }

        private void ASIG()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                NUM();
                if (!Parea("Tk_X")) { break; }
                NUM();
                if (!Parea("Tk_]")) { break; }
                if (!Parea("Tk_;")) { break; }
                break;
            }
        }

        private void BSONIDO()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RUTA();
                BSONIDOP();
                break;
            }
        }

        private void BSONIDOP()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RBSONIDOP();
                break;
            }
        }

        private void RBSONIDOP()
        {
            while (exito)
            {
                if(preanalisis.getToken() == "Tk_RUTA")
                {
                    RUTA();
                    BSONIDOP();
                }
                break;
            }
        }

        private void RUTA()
        {
            while (exito)
            {
                if (!Parea("Tk_RUTA")) { break; }
                if (!Parea("Tk_]")) { break; }
                if (!Parea("Tk_=")) { break; }
                if (!Parea("Tk_[")) { break; }
                if (!Parea("Tk_Ruta")) { break; }
                if (!Parea("Tk_]")) { break; }
                if (!Parea("Tk_;")) { break; }
                break;
            }
        }

        private void NUM()
        {
            if (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_Entero":
                        Parea("Tk_Entero");
                        break;
                    case "Tk_Decimal":
                        Parea("Tk_Decimal");
                        break;
                    default:
                        Error_sintactico = new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba numero entero o decimal y se encontró " + preanalisis.getLexema());
                        exito = false;
                        break;
                }
            }
        }

        private void USUARIOS()
        {
            while (exito)
            {
                //MessageBox.Show("Llego a usuarios");
                if (!Parea("Tk_USUARIOS")) { break; }
                if (!Parea("Tk_]")) { break; }
                BUSUARIOS();
                if (!Parea("Tk_/")) { break; }
                if (!Parea("Tk_USUARIOS")) { break; }
                if (!Parea("Tk_]")) { break; }
                break;
            }
        }

        private void BUSUARIOS()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                NOMBRE();
                BUSUARIOSP();
                break;
            }
        }

        private void BUSUARIOSP()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RBUSUARIOSP();
                break;
            }
        }

        private void RBUSUARIOSP()
        {
            while (exito)
            {
                if (preanalisis.getToken() == "Tk_NOMBRE")
                {
                    NOMBRE();
                    BUSUARIOSP();
                }
                break;
            }
        }

        private void NOMBRE()
        {
            while (exito)
            {
              //  MessageBox.Show("Llego a nombre");
                if (!Parea("Tk_NOMBRE")) { break; }
                if (!Parea("Tk_]")) { break; }
                if (!Parea("Tk_=")) { break; }
                if (!Parea("Tk_[")) { break; }
                if (!Parea("Tk_Id")) { break; }
                if (!Parea("Tk_]")) { break; }
                if (!Parea("Tk_;")) { break; }
                break;
            }
        }

        private void CARTAS()
        {
            while (exito)
            {
                if (!Parea("Tk_CARTA")) { break; }
                if (!Parea("Tk_]")) { break; }
                BCARTA();
                if (!Parea("Tk_/")) { break; }
                if (!Parea("Tk_CARTA")) { break; }
                if (!Parea("Tk_]")) { break; }
                break;
            }
        }

        private void BCARTA()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                NOMBRE();
                if (!Parea("Tk_[")) { break; }
                RUTA();
                BCARTAP();
                break;
            }
        }

        private void BCARTAP()
        {
            while (exito)
            {
                if (!Parea("Tk_[")) { break; }
                RBCARTAP();
                break;
            }
        }

        private void RBCARTAP()
        {
            while (exito)
            {
                if (preanalisis.getToken() == "Tk_NOMBRE")
                {
                    NOMBRE();
                    if (!Parea("Tk_[")) { break; }
                    RUTA();
                    BCARTAP();
                }
                break;
            }
        }
    }
}
