using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c=> c.CompanyId); //primary key
            builder.Property(c=>c.CompanyName).IsRequired();
            builder.Property(c=>c.CompanyPhone).IsRequired();
            builder.Property(c=>c.CompanyAddress).IsRequired();

            builder.HasData(
                   new Company
                   {
                       CompanyId = 1,
                       CompanyName = "Ahmet Mercan Tekstil",
                       CompanyAddress = "Sanayi Mh. 3589 Sk. No:6 Kocasinan / KAYSERİ",
                       CompanyPhone = "0(352) 336 55 25",
                       CompanyLogoUrl = "images/logo1.PNG",
                       CompanyWebSite = "https://ahmetmercantekstil.com/"

                   },
                new Company
                {
                    CompanyId = 2,
                    CompanyName = "Erciyes Elektrik",
                    CompanyAddress = "Eski Sanayi Bölgesi 6004 Cad. No:9/A Kocasinan/Kayseri",
                    CompanyPhone = "0 (352) 231 82 77",
                    CompanyLogoUrl = "images/logo2.PNG",
                    CompanyWebSite = "https://www.erciyeselectric.com/"
                },
                new Company
                {
                    CompanyId = 3,
                    CompanyName = "Akgünler Otomotiv",
                    CompanyAddress = "Yeşil mahalle Atatürk Bulvarı No:36 KARABÜK",
                    CompanyPhone = "(370) 424 44 55",
                    CompanyLogoUrl = "images/logo3.PNG",
                    CompanyWebSite = "https://www.akgunlerotomotiv.com.tr/"

                },
                new Company
                {
                    CompanyId = 4,
                    CompanyName = "Ceren Gıda",
                    CompanyAddress = "Cumhuriyet Mahallesi Yavuz Sultan Selim Caddesi No: 14/B KOCASİNAN/KAYSERİ",
                    CompanyPhone = "0 352 245 0753",
                    CompanyLogoUrl = "images/logo4.PNG",
                    CompanyWebSite = "https://www.cerengida.com/"
                },
                new Company
                {
                    CompanyId = 5,
                    CompanyName = "Elif Mobilya",
                    CompanyAddress = "Karpuzsekisi Mah. Kayseri O.S.B. 14.Cd No:49 HACILAR/Kayseri",
                    CompanyPhone = "0(352)322 07 47",
                    CompanyLogoUrl = "images/logo5.PNG",
                    CompanyWebSite = "https://elifmobilya.com.tr/"
                }
            );
        }
    }



}