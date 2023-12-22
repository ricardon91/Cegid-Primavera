using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customers.Application.Behaviors
{
    public static class NifValidatorBehavior
    {
        public static IRuleBuilderOptions<T, string> IsNifValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(IsNif).WithMessage("This is not a valid NIF.");
        }

        private static bool IsNif(string nif)
        {
            // Verifica se o NIF tem 9 dígitos
            if (nif.Length != 9)
            {
                return false;
            }

            // Verifica se todos os caracteres são dígitos
            if (!int.TryParse(nif, out _))
            {
                return false;
            }

            // Calcula o dígito de controlo
            int[] weights = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int sum = 0;

            for (int i = 0; i < 8; i++)
            {
                sum += (nif[i] - '0') * weights[i];
            }

            int remainder = sum % 11;
            int controlDigit = remainder < 2 ? 0 : 11 - remainder;

            // Verifica se o dígito de controlo é igual ao último dígito do NIF
            return controlDigit == (nif[8] - '0');
        }
    }
}
