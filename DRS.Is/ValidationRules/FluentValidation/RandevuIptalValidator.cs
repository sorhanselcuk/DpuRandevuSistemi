using DRS.Veriler.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.ValidationRules.FluentValidation
{
    public class RandevuIptalValidator:AbstractValidator<Randevu>
    {
        public RandevuIptalValidator()
        {
            RuleFor(p => p.Tarih).Must(GecerliTarih);
            //RuleFor(p => p.Saat.saat).Must(Gecerlilik);
        }

        private bool GecerliTarih(DateTime arg)
        {
            DateTime dateTime = DateTime.Now;
            int result = DateTime.Compare(dateTime,arg);
            bool status = true;
            if (result < 0 || result == 0)
                status = true;
            else
                status = false;
            return status;
        }

        private bool Gecerlilik(TimeSpan arg)
        {
            TimeSpan timeSpan = new TimeSpan();
            DateTime dateTime = DateTime.Now;
            dateTime.AddMinutes(30);
            string time = dateTime.Hour +":"+ dateTime.Minute;
            timeSpan = TimeSpan.Parse(time);
            int result = TimeSpan.Compare(arg,timeSpan);
            bool status = true;
            if (result == -1)
                status = false;
            return status;
        }
    }
}
