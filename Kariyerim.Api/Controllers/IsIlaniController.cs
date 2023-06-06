using Kariyerim.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kariyerim.BLL;

namespace Kariyerim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsIlaniController : ControllerBase
    {
        [HttpGet]
        public List<IsIlaniMessage> GetIsIlani()
        {
            var bll = Ioc.Instance<IIsIlaniBll>();
            //IsIlaniBll bll = new IsIlaniBll();
            return bll.GetIsIlani();
        }


        [HttpPost]
        public string YeniIsIlaniOlustur(IsIlaniMessage isIlani)
        {
            var bll = Ioc.Instance<IIsIlaniBll>();
            //IsIlaniBll bll = new IsIlaniBll();
            try
            {
                bll.YeniIsIlani(isIlani);
                return "Başarıyla yeni ilan oluşturuldu";
            }
            catch (Exception)
            {
                return "Giriş sırasında bir hata oluştu";
            } 
        }


        //SOLID 
        //Single-responsibility principle -- Görevlere dikkat et. (Süpermen-Hero)
        //Open-closed principle -- Kod güncellemesinde eski kodlar değiştirilmemeli ama yeni geliştirmeler yapılabilir. Core kodu koru (base e git)  (new den kaç)
        //Liskov's substitution principle -- Ust class child class özelliklerini tam yansıtabilmeli
        //Interface segregation principle -- Ust interface child class yada interfaceleri kapsayabilir olmalı
        //Dependency Inversion Principle -- Bağımlılığı kır, Core kodu koru (base e git) (new den kaç)

        //Design Pattern (singleton, factory, proxy, adapter...)

        interface IUcabilir
        {
            void Uc();
        }

        class Ucak : IUcabilir
        {
            public void Uc()
            {
               //Kod Yazılabilir
            }
        }
        abstract class Kus
        {
            public abstract void Beslen();
        }


        class Karga : Kus,IUcabilir
        {
            public override void Beslen()
            {
               //Kod yazılabilir
            }

            public void Uc()
            {
                //KOd yazılabilir
            }
        }


        class MuhabbetKusu : Kus,IUcabilir
        {
            public override void Beslen()
            {
                //Kod yazılabilir
            }

            public void Uc()
            {
                //KOd yazılabilir
            }
        }

        class DeveKusu : Kus
        {
            public override void Beslen()
            {
                //kod yazılabilir. 
            }
        }


        class Program
        {
            public void KusIslemleri(Kus kus)
            {
                kus.Beslen();
 
            }

            public void UcarakTasi(IUcabilir ucan)
            {
                ucan.Uc();
            }

        }
    }
}
