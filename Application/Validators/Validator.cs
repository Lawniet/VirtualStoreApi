using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Extensions;

namespace Application.Validators
{
    public abstract class Validator<T> : IValidator<T> where T : BaseEntity
    {
        public List<string> ErrorMessages { get; set; }

        public bool IsValid { get; set; }

        public Validator()
        {
            ErrorMessages = new List<string>();
        }

        public abstract void Validate(T entity);

        protected void SetValidity()
        {
            IsValid = !ErrorMessages.Any();
        }

        protected bool IsNull(BaseEntity product, string message)
        {
            if (product == null)
            {
                ErrorMessages.Add(message);
                return true;
            }
            return false;
        }
    }
}
