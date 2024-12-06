using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    /// <summary>
    /// Clase lógica para cálculos relacionados con códigos verificadores.
    /// </summary>
    public static class VerificacionLogic
    {
        /// <summary>
        /// Calcula el código verificador basado en un número base.
        /// </summary>
        /// <param name="numeroBase">Número base como string.</param>
        /// <returns>Código verificador calculado.</returns>
        public static int CalcularCodigoVerificador(string numeroBase)
        {
            if (string.IsNullOrEmpty(numeroBase))
            {
                throw new ArgumentException("El número base no puede estar vacío o ser nulo.");
            }

            // Filtrar solo los dígitos numéricos
            numeroBase = new string(numeroBase.Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(numeroBase))
            {
                throw new ArgumentException("El número base debe contener solo dígitos.");
            }

            int[] pesos = { 7, 6, 5, 4, 3, 2 }; // Pesos decrecientes
            int suma = 0;

            for (int i = 0; i < numeroBase.Length; i++)
            {
                int digito = int.Parse(numeroBase[i].ToString());
                int peso = pesos[i % pesos.Length];
                suma += digito * peso;
            }

            int resto = suma % 11;
            int verificador = 11 - resto;

            return (verificador == 10 || verificador == 11) ? 0 : verificador;
        }
    }
}
