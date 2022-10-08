using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JpvApi.Servico.Servicos.Validacoes
{
    public class ValidacaoJpv : IValidacaoJpv
    {
        public async Task<bool> ValidacaoData(DateTime? dta, int op)
        {
			return false;
        }

        public async Task<bool> ValidacaoNome(string nome, int op)
        {
			if (op == 1)
			{
				if (nome.IsNullOrEmpty())
				{
					return true;
				}
			}
			if (op == 2 && nome.IsNullOrEmpty())
			{

			}
			return false;
		}

        public async Task<bool> ValidacaoValor(decimal? valor, int op)
        {
            if (op == 1)
            {
                if (!valor.HasValue)
                {
					return true;
                }
            }
            if (op == 2 && valor.HasValue)
            {

            }
			return false;
        }

        public async Task<bool> ValidaCpf(string cpf, int op)
        {
			if (op == 1)
			{
				if (cpf.IsNullOrEmpty())
				{
					return true;
				}

				int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				string tempCpf;
				string digito;
				int soma;
				int resto;

				cpf = cpf.Trim();
				cpf = cpf.Replace(".", "").Replace("-", "");

				if (cpf.Length != 11)
					return true;

				tempCpf = cpf.Substring(0, 9);
				soma = 0;

				for (int i = 0; i < 9; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;

				digito = resto.ToString();

				tempCpf = tempCpf + digito;

				soma = 0;
				for (int i = 0; i < 10; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;

				digito = digito + resto.ToString();

				if (cpf.EndsWith(digito))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			if(op == 2 && !cpf.IsNullOrEmpty())
            {
				int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				string tempCpf;
				string digito;
				int soma;
				int resto;

				cpf = cpf.Trim();
				cpf = cpf.Replace(".", "").Replace("-", "");

				if (cpf.Length != 11)
					return true;

				tempCpf = cpf.Substring(0, 9);
				soma = 0;

				for (int i = 0; i < 9; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;

				digito = resto.ToString();

				tempCpf = tempCpf + digito;

				soma = 0;
				for (int i = 0; i < 10; i++)
					soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

				resto = soma % 11;
				if (resto < 2)
					resto = 0;
				else
					resto = 11 - resto;

				digito = digito + resto.ToString();

				if (cpf.EndsWith(digito))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			return false;
		}
    }
}
