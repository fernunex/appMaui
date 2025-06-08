using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCalc.Services
{
    public class CalculadoraDatosNutricionales
    {
        public static double CalcularIMC(double peso, double estatura)
        {
            return Math.Round(peso / Math.Pow(estatura / 100, 2), 2);
        }
        public static string ClasificarIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            if (imc < 24.9) return "Peso normal";
            if (imc < 29.9) return "Sobrepeso";
            if (imc < 34.9) return "Obesidad clase 1";
            if (imc < 39.9) return "Obesidad clasa 2";
            return "Obesidad clase 3";
        }

        public static int CalcularGrasaCorporal(double imc, int edad, int sexo)
        {
            if (sexo == 1) // Masculino
            {
                return (int)Math.Round((1.20 * imc) + (0.23 * edad) - 16.2);
            }
            else // Femenino
            {
                return (int)Math.Round((1.20 * imc) + (0.23 * edad) - 5.4);
            }
        }

        public static string ClasificarGC(int grasaCorporal, int sexo)
        {
            if (sexo == 1) // Masculino
            {
                if (grasaCorporal < 6) return "Grasa esencial";
                if (grasaCorporal < 14) return "Atletas";
                if (grasaCorporal < 18) return "Fitness";
                if (grasaCorporal < 25) return "Aceptable";
                return "Obesidad";
            }
            else // Femenino
            {
                if (grasaCorporal < 13) return "Grasa esencial";
                if (grasaCorporal < 21) return "Atletas";
                if (grasaCorporal < 25) return "Fitness";
                if (grasaCorporal < 32) return "Aceptable";
                return "Obesidad";
            }
        }

        public static int CalcularPesoIdeal(double estatura, int sexo)
        {
            if (sexo == 1) // Masculino
            {
                return (int)Math.Round(estatura - 100 - ((estatura - 150)/4));
            }
            else // Femenino
            {
                return (int)Math.Round(estatura - 100 - ((estatura - 150) / 2.5));
            }
        }

        public static double CalcularBMR(int peso, double estatura, int edad, int sexo)
        {
            if (sexo == 1) // Masculino
            {
                return (estatura * 6.25) + (peso * 9.99) - (edad * 4.92) + 5;
            }
            else // Femenino
            {
                return (estatura * 6.25) + (peso * 9.99) - (edad * 4.92) - 161;
            }
        }

        public static double CalcularGastoTotalEnergetico(double brm, int actividadFisica)
        {
            switch (actividadFisica)
            {
                case 1: // Rara vez
                    return brm * 1.2;
                case 2: // 1 a 3 veces a la semana
                    return brm * 1.375;
                case 3: // 3 a 5 veces a la semana
                    return brm * 1.55;
                case 4: // 6 a 7 veces a la semana
                    return brm * 1.725;
                case 5: // Trabajo físico intenso + Ejercicio
                    return brm * 1.9;
                default:
                    return brm; // Si no se especifica actividad física queda igual
            }
        }

    }
}
