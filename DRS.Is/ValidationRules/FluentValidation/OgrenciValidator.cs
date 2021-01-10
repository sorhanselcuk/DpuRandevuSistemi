using DRS.Veriler.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.ValidationRules.FluentValidation
{
    public class OgrenciValidator:AbstractValidator<Ogrenci>
    {
        public OgrenciValidator()
        {
            RuleFor(p => p.OgrNo).NotEmpty();
            RuleFor(p => p.Ad).NotEmpty();
            RuleFor(p => p.Soyad).NotEmpty();
            RuleFor(p=>p.Fakulte.FakulteId).NotEmpty();
            RuleFor(p=>p.Bolum.BolumId).NotEmpty();
            RuleFor(p => p.EPosta).NotEmpty();
            RuleFor(p=>p.Parola).NotEmpty();
            RuleFor(p => p.Parola).MinimumLength(8);
        }
    }
}
