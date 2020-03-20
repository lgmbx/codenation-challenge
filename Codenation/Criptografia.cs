using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation {
    public class Criptografia {

        public static string Cripto(string txt) {

            //descriptografia da forma mais arcaica do mundo, inicialmente feito em C e adaptado pra C#
            //importante é que funciona

            string text = txt.ToLower();            
            
            char[] alfabeto = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] resultado = new char[text.Length];
            


            for (int i = 0; i < text.Length; i++) {

                for (int j = 0; j < alfabeto.Length; j++) {

                    if (text[i].Equals(alfabeto[j])) {

                        if ((j - 7) >= 0) {

                            resultado[i] = alfabeto[j - 7];
                        }
                        else {
                            int res = (j - 7) +  26;

                            resultado[i] = alfabeto[res];
                        }
                    }
                    else if(text[i] == ' ') {
                        resultado[i] = ' ';
                    }
                    else if (text[i] == ',') {

                        resultado[i] = ',';
                    }
                    else if (text[i] == '.') {

                        resultado[i] = '.';
                    }
                }

            }





            string result = new string(resultado);
            
            return result;
        }




    }











}

