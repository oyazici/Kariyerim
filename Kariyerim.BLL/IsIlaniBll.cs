using Kariyerim.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kariyerim.DAL;
using Kariyerim.Entity;
using Kariyerim.Core;

namespace Kariyerim.BLL
{
    public interface IIsIlaniBll
    {
        List<IsIlaniMessage> GetIsIlani();
        void YeniIsIlani(IsIlaniMessage isIlani);

    }
    public class IsIlaniBll: IIsIlaniBll
    {
        const int MIN_ESS= 1;
        public List<IsIlaniMessage> GetIsIlani()
        {
            //IsIlaniDal dal = new IsIlaniDal();
            var dal = Ioc.Instance<IIsIlaniDal>();
            List<IsIlani> isIlanlari = dal.GetAll();
            //List<IsIlaniMessage> isIlanlariMessage = new List<IsIlaniMessage>();
            //foreach (var isIlani in isIlanlari)
            //{
            //    var isIlaniMessage = new IsIlaniMessage
            //    {
            //        Aciklama = isIlani.Aciklama,
            //        Baslik = isIlani.Baslik,
            //        IlanBitisTarihi = isIlani.IlanBitisTarihi,
            //        IlanNumarasi = isIlani.IlanNumarasi,
            //        IlanTarihi = isIlani.IlanTarihi,
            //        SirketAdi = isIlani.SirketAdi
            //    };
            //    isIlanlariMessage.Add(isIlaniMessage);
            //}
            //return isIlanlariMessage;

            return isIlanlari.Select(x => new IsIlaniMessage
            {
                Aciklama = x.Aciklama,
                Baslik = x.Baslik,
                IlanBitisTarihi = x.IlanBitisTarihi,
                IlanNumarasi = x.IlanNumarasi,
                IlanTarihi = x.IlanTarihi,
                SirketAdi = x.SirketAdi
            }).ToList();
        }

        public void YeniIsIlani(IsIlaniMessage isIlani)
        {
            if(isIlani==null) throw new ArgumentNullException(nameof(isIlani));

            //IsIlaniDal dal = new IsIlaniDal();
            var dal = Ioc.Instance<IIsIlaniDal>();
            IsIlani ilan = isIlani.IsIlaniMessageToIsIlani();
            ilan.AktifMi = true;
            ilan.IlaniOlusturan = ContextHelper.CurrentUser;

            int ess = dal.Add(ilan);
            if (ess < MIN_ESS)
            {
                throw new Exception("bir hata nedeniyle yeni ilan oluşturulamadı");
            }
        }

    }
    public class IsIlaniBll2 : IIsIlaniBll
    {
        const int MIN_ESS = 1;
        public List<IsIlaniMessage> GetIsIlani()
        {
            IsIlaniDal dal = new IsIlaniDal();
            List<IsIlani> isIlanlari = dal.GetAll();
            //List<IsIlaniMessage> isIlanlariMessage = new List<IsIlaniMessage>();
            //foreach (var isIlani in isIlanlari)
            //{
            //    var isIlaniMessage = new IsIlaniMessage
            //    {
            //        Aciklama = isIlani.Aciklama,
            //        Baslik = isIlani.Baslik,
            //        IlanBitisTarihi = isIlani.IlanBitisTarihi,
            //        IlanNumarasi = isIlani.IlanNumarasi,
            //        IlanTarihi = isIlani.IlanTarihi,
            //        SirketAdi = isIlani.SirketAdi
            //    };
            //    isIlanlariMessage.Add(isIlaniMessage);
            //}
            //return isIlanlariMessage;

            return isIlanlari.Select(x => new IsIlaniMessage
            {
                Aciklama = x.Aciklama,
                Baslik = x.Baslik,
                IlanBitisTarihi = x.IlanBitisTarihi,
                IlanNumarasi = x.IlanNumarasi
            }).ToList();
        }

        public void YeniIsIlani(IsIlaniMessage isIlani)
        {
            if (isIlani == null) throw new ArgumentNullException(nameof(isIlani));

            IsIlaniDal dal = new IsIlaniDal();
            IsIlani ilan = new IsIlani
            {
                Aciklama = isIlani.Aciklama,
                IlanBitisTarihi = isIlani.IlanBitisTarihi,
                IlanNumarasi = isIlani.IlanNumarasi,
                Baslik = isIlani.Baslik,
                IlanTarihi = isIlani.IlanTarihi,
                SirketAdi = isIlani.SirketAdi,
                AktifMi = true,
                IlaniOlusturan = GetCurrentUser()
            };

            int ess = dal.Add(ilan);
            if (ess < MIN_ESS)
            {
                throw new Exception("bir hata nedeniyle yeni ilan oluşturulamadı");
            }

        }

        public int GetCurrentUser()
        {
            return 35;
        }
    }
}
