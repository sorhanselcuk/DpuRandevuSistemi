using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Concrete;

namespace DRS.Is.ValidationRules.FluentValidation
{
    public class RandevuValidator : AbstractValidator<Randevu>
    {
        public RandevuValidator()
        {
            RuleFor(p => p.Ogrenci.OgrId).NotEmpty().WithMessage("Öğrenci olması zorunludur !");
            RuleFor(p => p.Akademisyen.AkmId).NotEmpty().WithMessage("Akademisyen olması zorunludur !");
            RuleFor(p => p.Konu).NotEmpty().WithMessage("Hangi konu ile alakalı görüşeceğinizi seçiniz !");
            RuleFor(p => p.Tarih).NotEmpty();
            RuleFor(p => p.Saat.SaatId).NotEmpty();
            RuleFor(p => p.Konu).Must(KonuLength).WithMessage("Konu 50 karakterden uzun olamaz !");
        }

        private bool KonuLength(string arg)
        {
            return arg.Length < 50 ? true : false;
        }
    }
}
