using Kariyerim.DTO;
using Kariyerim.Entity;

namespace Kariyerim.Core
{
    public static class ConvertHelper
    {
        public static IsIlani IsIlaniMessageToIsIlani(this IsIlaniMessage isIlani)
        {
            IsIlani ilan = new IsIlani
            {
                Aciklama = isIlani.Aciklama,
                IlanBitisTarihi = isIlani.IlanBitisTarihi,
                IlanNumarasi = isIlani.IlanNumarasi,
                Baslik = isIlani.Baslik,
                IlanTarihi = isIlani.IlanTarihi,
                SirketAdi = isIlani.SirketAdi,
            };
            return ilan;
        }
    }
}