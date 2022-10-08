using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JpvApi.Servico.Servicos.Validacoes
{
    public interface IValidacaoJpv
    {
        Task<bool> ValidaCpf(string cnpj, int op);
        Task<bool> ValidacaoData(DateTime? dta, int op);
        Task<bool> ValidacaoValor(decimal? valor, int op);
        Task<bool> ValidacaoNome(string nome, int op);

    }
}
