using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    [Serializable]
    class Error
    {
        private static int contador = 0;
        private String lexema, error;
        private int fila, columna, numero;

        public Error(String lexema, int fila, int columna, String error)
        {
            numero = contador;
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
            this.error = error;
            contador++;
        }

        public Error()
        {
            setContador();
        }

        public String getLexema()
        {
            return lexema;
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

        public String getError()
        {
            return error;
        }

        public void setContador()
        {
            contador = 0;
        }
    }
}
