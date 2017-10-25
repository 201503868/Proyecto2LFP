using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Analisis_Sintactico
    {
        private LinkedList<Token> tokens;
        private LinkedList<Error> errores = new LinkedList<Error>();
        private LinkedList<string> log = new LinkedList<string>();
        private List<string> usuarios = new List<string>(); //ya
        private List<string> musica = new List<string>(); //ya
        private List<string> cartas = new List<string>(); //ya
        private string[] niveles = {"Facil[2x2]","Intermedio[3x4]","Dificil[4x4]"}; //ya
        private string error_ejecucion;
        private Error error_sintactico;
        private Token preanalisis;
        private bool exito = true;
        private bool opcional = true;
        private bool usuario = true;
        private bool es_carta = true;
        private string camino = "";
        private string token_temporal = "";
        private string card = "";

        public Analisis_Sintactico(LinkedList<Token> tokens)
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
        public string[] Niveles { get => niveles; set => niveles = value; }

        public LinkedList<Error> Devolver_Errores()
        {
            if (errores.Count != 0)
            {
                LinkedList<Error> copia = new LinkedList<Error>();
                foreach (Error error in errores)
                {
                    copia.AddLast(error);
                }
                return copia;
            }
            return null;
        }

        public List<string> Dar_Usuarios()
        {
            List<string> copia = new List<string>();

            foreach(string valor in usuarios)
            {
                copia.Add(valor);
            }
            if(copia.Count == 0)
            {
                copia.Add("Anonimo");
            }
            return copia;
        }

        public List<string> Dar_Musica()
        {
            List<string> copia = new List<string>();

            foreach (string valor in musica)
            {
                copia.Add(valor);
            }
            return copia;
        }

        public List<string> Dar_Cartas()
        {
            List<string> copia = new List<string>();

            foreach (string valor in cartas)
            {
                copia.Add(valor);
            }
            return copia;
        }

        private bool Parea(string terminal, string siguiente, string siguiente2)
        {
            
            if (token_temporal == preanalisis.getToken())
            {
                errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
                preanalisis = tokens.First();
                tokens.RemoveFirst();
                Parea(terminal, siguiente, siguiente2);
                return true;
            }

            if (preanalisis.getToken() == "Tk_#")
            {
                exito = false;
                return false;
            }
            
            foreach(string valor in terminal.Split(','))
            {
                if (preanalisis.getToken() == terminal)
                {
                    token_temporal = preanalisis.getToken();
                    preanalisis = tokens.First();
                    tokens.RemoveFirst();
                    return true;
                }
            }

            if (Adelante())
            {
                foreach (string valor in siguiente.Split(','))
                {
                    if (preanalisis.getToken() == valor)
                    {
                        errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));

                        return true;
                    }
                }


                foreach (string valor in siguiente2.Split(','))
                {
                    if (preanalisis.getToken() == valor)
                    {
                        errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
                        errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + siguiente + " y se encontró " + preanalisis.getLexema()));
                        tokens.AddFirst(preanalisis);
                        token_temporal = preanalisis.getToken();
                        preanalisis = new Token("vacio", siguiente, preanalisis.getFila(), preanalisis.getColumna());
                        return true;
                    }
                }
            }

            


            errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
            token_temporal = preanalisis.getToken();
            preanalisis = tokens.First();
            tokens.RemoveFirst();
            return Parea(terminal, siguiente, siguiente2);
        }

        private bool Parea_especial(string terminal, string siguiente, string siguiente2, int capa, string breakpoints)
        {
            if (token_temporal == preanalisis.getToken())
            {
                errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
                preanalisis = tokens.First();
                tokens.RemoveFirst();
                Parea_especial(terminal, siguiente, siguiente2,capa,breakpoints);
                return true;
            }

            if (preanalisis.getToken() == "Tk_#")
            {
                exito = false;
                return false;
            }

            foreach (string valor in terminal.Split(',')){
                if (valor == preanalisis.getToken())
                {
                    token_temporal = preanalisis.getToken();
                    preanalisis = tokens.First();
                    tokens.RemoveFirst();
                    return true;
                }
            }

            if (Adelante())
            {
                foreach (string valor in siguiente.Split(','))
                {
                    if (preanalisis.getToken() == valor )
                    {
                        errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
                        camino = Manejo_Predicciones(capa, breakpoints);
                        if (camino == null)
                        {
                            exito = false;
                            return false;
                        }
                        return true;
                    }

                }

                if (preanalisis.getToken() == siguiente2 )
                {
                    errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
                    errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + siguiente + " y se encontró " + preanalisis.getLexema()));
                    tokens.AddFirst(preanalisis);
                    token_temporal = terminal;
                    camino = Manejo_Predicciones(capa, breakpoints);
                    if (camino == null)
                    {
                        exito = false;
                        return false;
                    }
                    return true;
                }
            }
            
            
                
            errores.AddLast(new Error(preanalisis.getLexema(), preanalisis.getFila(), preanalisis.getColumna(), "Error Sintactico, se esperaba " + terminal + " y se encontró " + preanalisis.getLexema()));
            token_temporal = preanalisis.getToken();
            preanalisis = tokens.First();
            tokens.RemoveFirst();
            return Parea_especial(terminal, siguiente, siguiente2, capa, breakpoints);
        }

        private string Manejo_Predicciones(int capa, string breakpoints)
        {
            switch (capa)
            {
                case 1:
                    string[] items = {"Tk_NIVELES", "Tk_SONIDO", "Tk_NOMBRE", "Tk_RUTA"};
                    string res = Predecir(items, breakpoints);
                    if (res == null)
                    {
                        if (breakpoints.Split(',').Count() != 1)
                        {
                            return "Tk_/";
                        }
                        return null;
                    }
                    items = res.Split(',');
                    if (((items[0] == "Tk_NOMBRE" && items[2] == "Tk_RUTA") || (items[2] == "Tk_NOMBRE" && items[0] == "Tk_RUTA")) && (items[1] != "0" && items[3] != "0"))
                    {
                        return "Tk_CARTA";
                    }
                    else if ((items[0] == "Tk_NOMBRE" && items[3]=="0"))
                    {
                        return "Tk_USUARIOS";
                    }
                    else if ((items[0]=="Tk_NIVELES" || items[2]=="Tk_SONIDO" || items[0] == "Tk_SONIDO" || items[2] == "Tk_NIVELES") && (items[1]!="0" || items[3] != "0"))
                    {
                        return "Tk_JUEGO";
                    }
                    else
                    {
                        return null;
                    }
                case 2:
                    string[] items1 = { "Tk_FACIL", "Tk_INTERMEDIO", "Tk_DIFICIL", "Tk_RUTA" };
                    string res1 = Predecir(items1, breakpoints);
                    if (res1 == null)
                    {
                        if (breakpoints.Split(',').Count() != 1)
                        {
                            return "Tk_/";
                        }
                        return null;
                    }
                    items1 = res1.Split(',');
                    if(items1[0]=="Tk_FACIL" || items1[0] == "Tk_INTERMEDIO" || items1[0] == "Tk_DIFICIL")
                    {
                        return "Tk_NIVELES";
                    }
                    else
                    {
                        return "Tk_SONIDO";
                    }
                default:
                    return null;

            }
        }

        private string Predecir(string[] parametros, string breakpoints)
        {
            int contador = 0;
            bool permiso = true;
            Dictionary<string, int> estadisticos = new Dictionary<string, int>();
            foreach (string parametro in parametros)
            {
                estadisticos.Add(parametro, 0);
            }

            foreach (Token tok in tokens)
            {
                if (tok.getToken() == "Tk_#") { return null; }
                foreach(string valor in breakpoints.Split(','))
                {
                    if (tok.getToken() == valor)
                    {
                        permiso = false;
                    }
                }

                if (!permiso) { break; }

                foreach (string parametro in parametros)
                {
                    if (tok.getToken() == parametro)
                    {
                        estadisticos[parametro] += 1;
                        contador++;
                    }
                }
                
            }

            if (contador != 0)
            {
                foreach(string parametro in parametros)
                {
                    estadisticos[parametro] *= 100 / contador;
                }

                var ordenado = estadisticos.OrderByDescending(x => x.Value);
                estadisticos = ordenado.ToDictionary(x=> x.Key, x=> x.Value);

                string logA="";
                foreach(KeyValuePair<string, int> par in estadisticos)
                {
                    logA += par.Key + ": " + par.Value+"%, ";
                }

                log.AddLast(logA+" En Fila: " + preanalisis.getFila()+ ", En Columna: "+  preanalisis.getColumna());
                return estadisticos.First().Key+","+estadisticos.First().Value+","+estadisticos.ElementAt(1).Key+","+ estadisticos.ElementAt(1).Value;
            }

            return null;
        }

        private bool Adelante()
        {
            if(token_temporal == "Tk_[")
            {
                return true;
            }
            return false;
        }

        public void AS0()
        {
            while (exito)
            {
                if (!Parea("Tk_[", "Tk_CONFIGURACION", "Tk_]")) { break; }
                if (!Parea("Tk_CONFIGURACION", "Tk_]", "Tk_[")) { break; }
                if(!Parea("Tk_]", "Tk_[", "Tk_JUEGO,Tk_USUARIOS,Tk_CARTA")) { break; }
                CUERPO();
                //if (!Parea("Tk_/", "Tk_CONFIGURACION", "]")) { break; }
                if (!Parea("Tk_CONFIGURACION","Tk_]","Tk_#")) { break; }
                if (!Parea("Tk_]", "Tk_#", "Tk_#")) { break; }
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
                        if (!Parea("Tk_[", "Tk_CONFIGURACION", "Tk_]" )) { break; }
                        if (!Parea("Tk_CONFIGURACION", "Tk_]", "Tk_[")) { break; }
                        if (!Parea("Tk_]", "[", "Tk_JUEGO, Tk_USUARIOS, Tk_CARTA")) { break; }
                        CUERPO();
                        //if (!Parea("Tk_/", "Tk_CONFIGURACION", "Tk_]")) { break; }
                        if (!Parea("Tk_CONFIGURACION", "Tk_]", "Tk_#")) { break; }
                        if (!Parea("Tk_]", "Tk_#", "Tk_#")) { break; }
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
                if (!Parea_especial("Tk_[", "Tk_JUEGO,Tk_USUARIOS,Tk_CARTA", "Tk_]", 1, "Tk_/")) { break; }
                camino = preanalisis.getToken();
                if (!Parea_especial("Tk_JUEGO,Tk_USUARIOS,Tk_CARTA", "Tk_]", "Tk_[", 1, "Tk_/")) { break; }
                CUERPOP();
                break;
            }
        }

        private void CUERPOP()
        {
            while (exito)
            {
                

                switch (camino)
                {
                    case "Tk_JUEGO":
                       // MessageBox.Show("tomo a juego");
                        JUEGO();
                        RCUERPO();
                        break;
                    case "Tk_USUARIOS":
                       // MessageBox.Show("Tomo a usuarios");
                        USUARIOS();
                        RCUERPO();
                        break;
                    case "Tk_CARTA":
                        //MessageBox.Show("Tomo a cartas");
                        CARTAS();
                        RCUERPO();
                        break;
                }
                break;
            }
        }

        private void RCUERPO()
        {
            while (exito)
            {
                if (!Parea_especial("Tk_[", "Tk_JUEGO,Tk_USUARIOS,Tk_CARTA,Tk_/", "Tk_],Tk_CONFIGURACION",1,"Tk_CONFIGURACION,Tk_/")) { break; }
                // if (preanalisis.getToken() == "Tk_JUEGO" || preanalisis.getToken() == "Tk_USUARIOS" || preanalisis.getToken() == "Tk_CARTA")
                // {
                camino = preanalisis.getToken();
                if (!Parea_especial("Tk_JUEGO,Tk_USUARIOS,Tk_CARTA,Tk_/", "Tk_],Tk_CONFIGURACION", "Tk_[,Tk_]", 1, "Tk_CONFIGURACION,Tk_/")) { break; }
                CUERPOP();
                //}
                break;
            }
               
        }

        private void JUEGO()
        {
            while (exito)
            {
                //if (!Parea("Tk_JUEGO","Tk_]", "Tk_[")) { break; }
                if (!Parea("Tk_]","Tk_[", "Tk_NIVELES,Tk_SONIDO")) { break; }
                BJUEGO();
                //if (!Parea("Tk_/", "Tk_JUEGO", "Tk_]")) { break; }
                if (!Parea("Tk_JUEGO", "Tk_]", "Tk_[")) { break; }
                if (!Parea("Tk_]", "Tk_[", "Tk_JUEGO,Tk_USUARIOS,Tk_CARTA,Tk_/" )) { break; }
                break;
            }
        }  //hasta aca

        private void BJUEGO()
        {
            while (exito)
            {
                if (!Parea_especial("Tk_[", "Tk_NIVELES,Tk_SONIDO", "Tk_]",2, "Tk_/")) { break; }
                camino = preanalisis.getToken();
                if (!Parea_especial("Tk_SONIDO,Tk_NIVELES", "Tk_]", "Tk_[", 2, "Tk_/")) { break; }
                BJUEGOP();
                break;
            }
            
        }

        private void BJUEGOP()
        {
            while (exito)
            {
                switch (camino)
                {
                    case "Tk_SONIDO":
                        //Parea("Tk_SONIDO","Tk_]", "Tk_[");
                        if (!Parea("Tk_]", "Tk_[", "Tk_Ruta")) { break; }
                        BSONIDO();
                        if (!Parea("Tk_/", "Tk_SONIDO", "Tk_]")) { break; }
                        if (!Parea("Tk_SONIDO", "Tk_]", "Tk_[")) { break; }
                        if (!Parea("Tk_]", "Tk_[", "Tk_SONIDO,Tk_/,Tk_NIVELES")) { break; }
                        RBJUEGO();
                        break;
                    case "Tk_NIVELES":
                        //Parea("Tk_NIVELES","Tk_]","Tk_[");
                        if (!Parea("Tk_]", "Tk_[", "Tk_FACIL,Tk_INTERMEDIO,Tk_DIFICIL")) { break; }
                        BNIVELES();
                        if (!Parea("Tk_/", "Tk_NIVELES", "Tk_]")) { break; }
                        if (!Parea("Tk_NIVELES", "Tk_]", "Tk_[")) { break; }
                        if (!Parea("Tk_]", "Tk_[", "Tk_SONIDO,Tk_/,Tk_NIVELES")) { break; }
                        RBJUEGO();
                        break;
                    default:
                        break;
                }
                break;
            }
            
        }

        private void RBJUEGO()
        {
            while (exito)
            {
                if (!Parea_especial("Tk_[", "Tk_NIVELES,Tk_SONIDO,Tk_/", "Tk_],Tk_JUEGO", 2, "Tk_/,Tk_JUEGO")) { break; }
                camino = preanalisis.getToken();
                if (!Parea_especial("Tk_SONIDO,Tk_NIVELES,Tk_/", "Tk_],Tk_JUEGO", "Tk_[,Tk_]", 2, "Tk_JUEGO,Tk_/")) { break; }
                RBJUEGOP();
                break;
            }
        }

        private void RBJUEGOP()
        {
            while (exito)
            {
                switch (camino)
                {
                    case "Tk_SONIDO":
                        //Parea("Tk_SONIDO", "Tk_]", "Tk_[");
                        if (!Parea("Tk_]", "Tk_[", "Tk_Ruta")) { break; }
                        BSONIDO();
                        if (!Parea("Tk_/", "Tk_SONIDO", "Tk_]")) { break; }
                        if (!Parea("Tk_SONIDO", "Tk_]", "Tk_[")) { break; }
                        if (!Parea("Tk_]", "Tk_[", "Tk_SONIDO,Tk_/,Tk_NIVELES")) { break; }
                        RBJUEGO();
                        break;
                    case "Tk_NIVELES":
                        //Parea("Tk_NIVELES", "Tk_]", "Tk_[");
                        if (!Parea("Tk_]", "Tk_[", "Tk_FACIL,Tk_INTERMEDIO,Tk_DIFICIL")) { break; }
                        BNIVELES();
                        if (!Parea("Tk_/", "Tk_NIVELES", "Tk_]")) { break; }
                        if (!Parea("Tk_NIVELES", "Tk_]", "Tk_[")) { break; }
                        if (!Parea("Tk_]", "Tk_[", "Tk_SONIDO,Tk_/,Tk_NIVELES")) { break; }
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
                if (!Parea("Tk_[", "Tk_FACIL,Tk_INTERMEDIO,Tk_DIFICIL", "Tk_]")) { break; }
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
                        Parea("Tk_FACIL","Tk_]","Tk_=");
                        niveles[0] = "Facil[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(0);
                        RBNIVELES();
                        break;
                    case "Tk_INTERMEDIO":
                        Parea("Tk_INTERMEDIO", "Tk_]", "Tk_=");
                        niveles[1] = "Intermedio[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(1);
                        RBNIVELES();
                        break;
                    case "Tk_DIFICIL":
                        Parea("Tk_DIFICIL","Tk_]", "Tk_=");
                        niveles[2] = "Dificil[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(2);
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
                if (!Parea("Tk_[", "Tk_FACIL,Tk_INTERMEDIO,Tk_DIFICIL,Tk_/", "Tk_],Tk_NIVELES")) { break; }
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
                        Parea("Tk_FACIL", "Tk_]", "Tk_=");
                        niveles[0] = "Facil[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(0);
                        RBNIVELES();
                        break;
                    case "Tk_INTERMEDIO":
                        Parea("Tk_INTERMEDIO", "Tk_]", "Tk_=");
                        niveles[1] = "Intermedio[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(1);
                        RBNIVELES();
                        break;
                    case "Tk_DIFICIL":
                        Parea("Tk_DIFICIL", "Tk_]", "Tk_=");
                        niveles[2] = "Dificil[";
                        if (!Parea("Tk_]", "Tk_=", "Tk_[")) { break; }
                        if (!Parea("Tk_=", "Tk_[", "Tk_Entero,Tk_Decimal")) { break; }
                        ASIG(2);
                        RBNIVELES();
                        break;
                    default:
                        break;
                }
                break;
            }
        }

        private void ASIG(int indice)
        {
            while (exito)
            {
                if (!Parea("Tk_[", "Tk_Entero,Tk_Decimal", "Tk_X")) { break; }
                NUM(indice);
                if (!Parea("Tk_X", "Tk_Entero,Tk_Decimal", "Tk_]")) { break; } else { niveles[indice] += "x"; }
                NUM(indice);
                if (!Parea("Tk_]", "Tk_;", "Tk_[")) { break; } else { niveles[indice] += "]"; }
                if (!Parea("Tk_;", "Tk_[", "Tk_/,Tk_FACIL,Tk_INTERMEDIO,Tk_DIFICIL")) { break; }
                break;
            }
        }

        private void BSONIDO()
        {
            while (exito)
            {
                es_carta = false;
                if (!Parea("Tk_[", "Tk_RUTA", "Tk_]")) { break; }
                RUTA();
                BSONIDOP();
                break;
            }
        }

        private void BSONIDOP()
        {
            while (exito)
            {
                if (!Parea("Tk_[","Tk_RUTA,Tk_/","Tk_],Tk_SONIDO")) { break; }
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
                if (!Parea("Tk_RUTA","Tk_]", "Tk_=")) { break; }
                if (!Parea("Tk_]","Tk_=","Tk_[")) { break; }
                if (!Parea("Tk_=","Tk_[","Tk_Ruta")) { break; }
                if (!Parea("Tk_[","Tk_Ruta","Tk_]")) { break; }
                else
                {
                    if (es_carta) { cartas[cartas.Count - 1] += "," + preanalisis.getLexema().Replace('"', ' ').Trim(); }
                    else { musica.Add(preanalisis.getLexema().Replace('"', ' ').Trim());}
                }
                if (!Parea("Tk_Ruta","Tk_]","Tk_;")) { break; }
                if (!Parea("Tk_]","Tk_;","Tk_[")) { break; }
                if (!Parea("Tk_;","Tk_[","Tk_Ruta,Tk_/")) { break; }
                break;
            }
        }

        private void NUM(int indice)
        {
            if (exito)
            {
                switch (preanalisis.getToken())
                {
                    case "Tk_Entero":
                        niveles[indice] += preanalisis.getLexema().Replace('"', ' ').Trim();
                        Parea("Tk_Entero","Tk_X,Tk_]","Tk_Entero,Tk_Decimal,Tk_;");
                        break;
                    case "Tk_Decimal":
                        niveles[indice] += (int)Convert.ToDouble(preanalisis.getLexema().Replace("\"", "").Replace(".",","));
                        Parea("Tk_Decimal", "Tk_X,Tk_]", "Tk_Entero,Tk_Decimal,Tk_;");
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
                //if (!Parea("Tk_USUARIOS","Tk_]","[")) { break; }
                usuario = true;
                if (!Parea("Tk_]","Tk_[","Tk_NOMBRE")) { break; }
                BUSUARIOS();
                if (!Parea("Tk_/","Tk_USUARIOS","Tk_]")) { break; }
                if (!Parea("Tk_USUARIOS","Tk_]","Tk_[")) { break; }
                if (!Parea("Tk_]","Tk_[","Tk_USUARIOS,Tk_CARTA,Tk_JUEGO,Tk_/")) { break; }
                break;
            }
        }

        private void BUSUARIOS()
        {
            while (exito)
            {
                if (!Parea("Tk_[","Tk_NOMBRE","Tk_]")) { break; }
                NOMBRE();
                BUSUARIOSP();
                break;
            }
        }

        private void BUSUARIOSP()
        {
            while (exito)
            {
                if (!Parea("Tk_[", "Tk_NOMBRE,Tk/", "Tk_],Tk_USUARIOS")) { break; }
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
                if (!Parea("Tk_NOMBRE","Tk_]","Tk_=")) { break; }
                if (!Parea("Tk_]","Tk_=","Tk_[")) { break; }
                if (!Parea("Tk_=","Tk_[","Tk_Id")) { break; }
                if (!Parea("Tk_[","Tk_Id","Tk_]")) { break; }
                else
                {
                    if (usuario){usuarios.Add(preanalisis.getLexema().Replace('"',' ').Trim());}
                    else { cartas.Add(preanalisis.getLexema().Replace('"', ' ').Trim()); }
                }
                if (!Parea("Tk_Id","Tk_]","Tk_;")) { break; } 
                if (!Parea("Tk_]","Tk_;","Tk_[")) { break; }
                if (!Parea("Tk_;","Tk_[","Tk_NOMBRE,Tk/")) { break; }
                break;
            }
        }

        private void CARTAS()
        {
            while (exito)
            {
                //if (!Parea("Tk_CARTA","Tk_]","Tk_[")) { break; }
                usuario = false;
                es_carta = true;
                if (!Parea("Tk_]","Tk_[","Tk_NOMBRE,Tk_RUTA")) { break; }
                BCARTA();
                if (!Parea("Tk_[", "Tk_/", "Tk_CARTA")) { break; }
                if (!Parea("Tk_/","Tk_CARTA","Tk_]")) { break; }
                if (!Parea("Tk_CARTA","Tk_]","Tk_;")) { break; }
                if (!Parea("Tk_]","Tk_[", "Tk_USUARIOS,Tk_CARTA,Tk_JUEGO,Tk_/")) { break; }
                break;
            }
        }

        private void BCARTA()
        {
            while (exito)
            {
                if (!Parea("Tk_[", "Tk_NOMBRE,Tk_RUTA", "Tk_]")) { break; }
                RBCARTAP();
                break;
            }
        }

        private void BCARTAP()
        {
            while (exito)
            {
                if (preanalisis.getToken()=="Tk_NOMBRE" || preanalisis.getToken() == "Tk_RUTA") {

                    RBCARTAP();
                }
                
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
                    if (!Parea("Tk_[","Tk_RUTA","Tk_]")) { break; }
                    RUTA();
                    BCARTAP();
                }
                else if (preanalisis.getToken() == "Tk_RUTA")
                {
                    RUTA();
                    if (!Parea("Tk_[","Tk_NOMBRE", "Tk_]")) { break; }
                    NOMBRE();
                    BCARTAP();
                }
                break;
            }
        }
    }
}
