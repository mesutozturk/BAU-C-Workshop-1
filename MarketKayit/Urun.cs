using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace MarketKayit
{
    [Table("Urunler")]
    public class Urun
    {
        public Urun()
        {
            EklenmeZamani = DateTime.Now;
            Barkod = Guid.NewGuid().ToString();
        }

        public Urun(string ad, decimal fiyat, DateTime sonKullanmaTarihi)
        {
            this.Ad = ad;
            this.Fiyat = fiyat;
            this.SonKullanmaTarihi = sonKullanmaTarihi;
            EklenmeZamani = DateTime.Now;
        }

        private string _ad;
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Urun adi 2 karakterden fazla maksimum 50 karakter olabilir")]
        public string Ad
        {
            get { return _ad; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("urun adi bos olamaz");

                for (int i = 0; i < value.Length; i++)
                {
                    char harf = value[i];
                    if (!char.IsLetterOrDigit(harf))
                        throw new Exception("Urun adinda ozel karakter bulunamaz");
                }

                _ad = value;
            }
        }
        [Range(0.5, 1000)]
        public decimal Fiyat { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Barkod { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public DateTime EklenmeZamani { get; private set; }

        public override string ToString()
        {
            return $"{Ad} - {Fiyat:c2}";
        }
    }
}
