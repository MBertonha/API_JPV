using FluentValidation;
using FluentValidation.Results;

namespace Jpv.Dominio.Modelos.Entidade
{
    public abstract class Entidade<T> : AbstractValidator<T> where T : Entidade<T>
    {
        public ValidationResult ResultadoValidacao { get; protected set; }
        public abstract bool EstaValido();
        protected Entidade()
        {
            ResultadoValidacao = new ValidationResult();
        }

        protected virtual void Validar(T obj)
        {
            ResultadoValidacao = Validate(obj);
        }
    }
}
