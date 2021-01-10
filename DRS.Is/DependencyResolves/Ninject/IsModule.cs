using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.Abstracts;
using DRS.Is.Concrete;
using DRS.VeriErisim.Abstracts;
using DRS.VeriErisim.Concrete.Sql;
using DRS.Is.Abstract;
using DRS.VeriErisim.Abstract;

namespace DRS.Is.DependencyInjection.Ninject
{
    public class IsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAdminGirisServis>().To<AdminGirisYonetimi>().InSingletonScope();
            Bind<IAdminGirisDal>().To<SQLAdminGirisDal>().InSingletonScope();

            Bind<IAkademisyenGirisServis>().To<AkademisyenGirisYonetimi>().InSingletonScope();
            Bind<IAkademisyenGirisDal>().To<SQLAkademisyenGirisDal>().InSingletonScope();

            Bind<IOgrenciGirisServis>().To<OgrenciGirisYonetimi>().InSingletonScope();
            Bind<IOgrenciGirisDal>().To<SQLOgrenciGirisDal>().InSingletonScope();

            Bind<IAkademisyenServis>().To<AkademisyenYonetimi>().InSingletonScope();
            Bind<IAkademisyenDal>().To<SQLAkademisyenDal>().InSingletonScope();

            Bind<IBolumServis>().To<BolumYonetimi>().InSingletonScope();
            Bind<IBolumDal>().To<SQLBolumDal>().InSingletonScope();

            Bind<IEPostaServis>().To<EPostaYonetimi>().InSingletonScope();

            Bind<IFakulteServis>().To<FakulteYonetimi>().InSingletonScope();
            Bind<IFakulteDal>().To<SQLFakulteDal>().InSingletonScope();

            Bind<IOgrenciServis>().To<OgrenciYonetimi>().InSingletonScope();
            Bind<IOgrenciDal>().To<SQLOgrenciDal>().InSingletonScope();

            Bind<IRandevuServis>().To<RandevuYonetimi>().InSingletonScope();
            Bind<IRandevuDal>().To<SQLRandevuDal>().InSingletonScope();

            Bind<ISaatServis>().To<SaatYonetimi>().InSingletonScope();
            Bind<ISaatDal>().To<SQLSaatDal>().InSingletonScope();

            Bind<IMusaitlikServis>().To<MusaitlikYonetimi>().InSingletonScope();
            Bind<IMusaitlikDal>().To<SQLMusaitlikDal>().InSingletonScope();

            Bind<IGecmisRandevuServis>().To<GecmisRandevuYonetimi>().InSingletonScope();
            Bind<IGecmisRandevuDal>().To<SQLGecmisRandevuDal>().InSingletonScope();
        }
    }
}
