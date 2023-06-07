using Kariyerim.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kariyerim.Core;

namespace Kariyerim.DAL
{
    public class IsIlaniDal : IIsIlaniDal
    {
        public List<IsIlani> GetAll()
        {
            SqlConnection cnn = new SqlConnection("Server=.\\SQLEXPRESS;Database=KariyerimDB;User Id=sa;Password=1234;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ilanlar", cnn);

            if (cnn.State != System.Data.ConnectionState.Open)
            {
                cnn.Open();
            }
            var reader = cmd.ExecuteReader();
            List<IsIlani> ilanlar = new List<IsIlani>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var ilan = new IsIlani
                    {
                        Aciklama = reader["Aciklama"].ToString(),
                        SirketAdi = reader["SirketAdi"].ToString(),
                        AktifMi = Convert.ToBoolean(reader["AktifMi"]),
                        Baslik = reader["Baslik"].ToString(),
                        IlanBitisTarihi = Convert.ToDateTime(reader["IlanBitisTarihi"]),
                        IlanTarihi = Convert.ToDateTime(reader["IlanTarihi"]),
                        IlaniOlusturan = Convert.ToInt32(reader["IlaniOlusturan"]),
                        IlanNumarasi = Convert.ToInt32(reader["IlanNumarasi"])
                    };

                    ilanlar.Add(ilan);
                } //ORM tool
            }
            return ilanlar;
        }

        public int Add(IsIlani isIlani)
        {
            SqlConnection cnn = new SqlConnection("Server=.\\SQLEXPRESS;Database=KariyerimDB;User Id=sa;Password=1234;");
            SqlCommand cmd = new SqlCommand("Insert into Ilanlar(Baslik,Aciklama,SirketAdi,IlanTarihi,IlanBitisTarihi,IlaniOlusturan,AktifMi) values(@Baslik,@Aciklama,@SirketAdi,@IlanTarihi,@IlanBitisTarihi,@IlaniOlusturan,@AktifMi)", cnn);
            cmd.ParameterLoad( isIlani);

            if (cnn.State != System.Data.ConnectionState.Open)
            {
                cnn.Open();
            }

            int ess = cmd.ExecuteNonQuery();
            cnn.Close();
            cnn.Dispose();
            cmd.Dispose();

            return ess;
        }

      

    }
}
