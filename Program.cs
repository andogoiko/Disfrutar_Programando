using System;
using System.Collections.Generic;

namespace DisfrutarProgramando{

    class Program{

        static void Main(string[] args){

            //la lista a trabajar
            List<string> ciudades = new List<string>(){"Tokyo", "London", "Rome", "Donlon", "Kyoto", "Paris"};

            var res = ciudAnagrama(ciudades);

            ToString(res);

        }

        //método que devolverá la solución en una lista
        public static List<List<string>> ciudAnagrama(List<string> lista){

            List<List<string>> LCAnagrama = new List<List<string>>();

            List<string> LAux = new List<string>();

            for (var i = 0; i < lista.Count; i++){

                LAux.Add(lista[i]);

                for(var j = i + 1; j < lista.Count; j++){
                    
                    if(cambiarSilabas(lista[i].ToLower()) == cambiarSilabas(lista[j]).ToLower()){

                        LAux.Add(lista[j]);
                        lista.RemoveAt(j);
                    }

                }

                LCAnagrama.Add(LAux);
                LAux = new List<string>();
            }

            return LCAnagrama;
        }

        //método que cambia el orden de las sílabas

        public static string cambiarSilabas(string ciudad){

            
            /* VERSIÓN ANTIGÜA (SOLO FUNCIONA CON LOS CASOS ENTREGADOS)

                //aquí he usado contains para comparar si el caracter del string introducido es una vocal (es bastante interesante para usarlo a futuro)

                //https://docs.microsoft.com/es-es/dotnet/api/system.string.contains?view=net-5.0
            

                //if(!"aeiou".Contains(Char.ToLower(ciudad[0])) && "aeiou".Contains(Char.ToLower(ciudad[1])) && "n".Contains(Char.ToLower(ciudad[2]))){

                    //SAnagrama = ciudad.Substring(3) + ciudad.Substring(0, 3);
                //}else if(!"aeiou".Contains(Char.ToLower(ciudad[0])) && "aeiou".Contains(Char.ToLower(ciudad[1]))){

                    //SAnagrama = ciudad.Substring(2) + ciudad.Substring(0, 2);
                //}else{

                    //SAnagrama = ciudad.Substring(3) + ciudad.Substring(0, 3);
                //}

            */

            // VERSIÓN NUEVA  (FUNCIONA CON ANAGRAMAS ORDENADOS DE CUALQUIER MANERA)

            // cogí esta idea de reordenar un string alfebéticamente

            //https://www.c-sharpcorner.com/blogs/sort-string-in-alphabetical-order-in-c-sharp

            char[] SAnagrama = ciudad.ToCharArray();  

            for(var i=1;i< SAnagrama.Length;i++){  

                for(var j=0;j< SAnagrama.Length-1;j++){  

                    if(SAnagrama[j]> SAnagrama[j+1]){  

                        var aux = SAnagrama[j];  
                        SAnagrama[j] = SAnagrama[j + 1];  
                        SAnagrama[j + 1] = aux;  
                }  
           }  
       }  

            var res = new string(SAnagrama);

            return res;
        }

        //método que devuelve la lista convertida en string

        public static void ToString(List<List<string>> lista){

                var sRes = "[\n";
                
                for(var i = 0; i < lista.Count; i++){
                    sRes += "\t[ " + (string.Join( ", ", lista[i].ToArray()).ToString() + " ],\n");
                }

                sRes += "]\n";

                Console.Write(sRes);
        }
    }
}