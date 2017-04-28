using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //libreria de expresiones regulares


namespace WindowsFormsApplication1
{
    public class Analizador
    {
        
        string cadenaParaAnalizar;
        bool valor = false;
        //metodos
        public Analizador() { }//constructor por default
        public Analizador(string cadenaParaAnalizar, bool valor)//constructor con valores
        {
            this.cadenaParaAnalizar = cadenaParaAnalizar;
            this.valor = valor;
        }
        public bool Verdadero()
        {
            return valor;
        }
        public void SoyEntero()
        {
            Regex EsEntero = new Regex("^[0-9]+$");
            
                                                    
            if (EsEntero.IsMatch(cadenaParaAnalizar))
            {
                valor = true;

            }
           
        }
        public void SoyString()
        {
            Regex CadenaNoVacia = new Regex("^$");
            if (CadenaNoVacia.IsMatch(cadenaParaAnalizar))
            {
                //devuelve un booleano
            }
        }

        public void SoyFlotante()
        {
            Regex Flotante = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (Flotante.IsMatch(cadenaParaAnalizar))
            {
                //devuelve el booleano
            }
        }

        }
}
    