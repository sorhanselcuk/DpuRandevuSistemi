using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.Concrete;

namespace DRS.Is.ValidationRules.FluentValidation
{
    public class YetkiValidator : AbstractValidator<Kullanici>
    {
        public YetkiValidator()
        {
            RuleFor(p => p.Yetki).Must(Yonetici).WithMessage("Bu işlem için yetkiniz yok !");
        }

        private bool Yonetici(bool arg)
        {
            return arg;
        }
    }
}
