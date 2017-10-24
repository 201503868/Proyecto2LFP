using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    [Serializable]
    class Token 
    {
        private static int contador = 0;
        private String lexema,token;
        private int fila, columna,numero;

        public Token(String lexema, String token, int fila, int columna)
        {
            numero = contador;
            this.lexema = lexema;
            this.token = token;
            this.fila = fila;
            this.columna = columna;
            contador++;
        }

        public Token()
        {
            setContador();
        }

        public String getLexema()
        {
            return lexema;
        }

        public String getToken()
        {
            return token;
        }

        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setContador()
        {
            contador = 0;
        }
    }
}
