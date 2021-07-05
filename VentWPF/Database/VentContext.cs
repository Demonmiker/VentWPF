using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;



#nullable disable

namespace VentWPF
{
    public partial class VentContext : DbContext
    {
        public static VentContext Instance { get; private set; } = new VentContext();

        ~VentContext()
        {
            Debug.WriteLine("БД закрыта");
        }

        private VentContext() { Debug.WriteLine("БД открыта"); } 

        private VentContext(DbContextOptions<VentContext> options) : base(options) {  Debug.WriteLine("БД открыта"); }

        public virtual DbSet<_1с0> _1с0s { get; set; }
        public virtual DbSet<_1с> _1сs { get; set; }
        public virtual DbSet<_1сШу> _1сШуs { get; set; }
        public virtual DbSet<AвтоматикаДатчики> AвтоматикаДатчикиs { get; set; }
        public virtual DbSet<CтепеньЗащитыШу> CтепеньЗащитыШуs { get; set; }
        public virtual DbSet<Hаценка> Hаценкаs { get; set; }
        public virtual DbSet<K3g250At3972> K3g250At3972s { get; set; }
        public virtual DbSet<K3g250Av29B2> K3g250Av29B2s { get; set; }
        public virtual DbSet<K3g280At0472> K3g280At0472s { get; set; }
        public virtual DbSet<K3g280Au06B2> K3g280Au06B2s { get; set; }
        public virtual DbSet<K3g280Au11C2> K3g280Au11C2s { get; set; }
        public virtual DbSet<K3g310Ax5202> K3g310Ax5202s { get; set; }
        public virtual DbSet<K3g310Ax5422> K3g310Ax5422s { get; set; }
        public virtual DbSet<K3g310Az8802> K3g310Az8802s { get; set; }
        public virtual DbSet<K3g310Bb4902> K3g310Bb4902s { get; set; }
        public virtual DbSet<K3g355Ax5602> K3g355Ax5602s { get; set; }
        public virtual DbSet<K3g355Ay4002> K3g355Ay4002s { get; set; }
        public virtual DbSet<K3g355Ay4322> K3g355Ay4322s { get; set; }
        public virtual DbSet<K3g355Bc9202> K3g355Bc9202s { get; set; }
        public virtual DbSet<K3g400Aq2301> K3g400Aq2301s { get; set; }
        public virtual DbSet<K3g400Aq2368> K3g400Aq2368s { get; set; }
        public virtual DbSet<K3g400Ay8702> K3g400Ay8702s { get; set; }
        public virtual DbSet<K3g450Aq2568> K3g450Aq2568s { get; set; }
        public virtual DbSet<K3g450Az2468> K3g450Az2468s { get; set; }
        public virtual DbSet<K3g500Ap2501> K3g500Ap2501s { get; set; }
        public virtual DbSet<K3g500Aq3368> K3g500Aq3368s { get; set; }
        public virtual DbSet<K3g560Aq0868> K3g560Aq0868s { get; set; }
        public virtual DbSet<K3g560Aр2168> K3g560Aр2168s { get; set; }
        public virtual DbSet<K3g> K3gs { get; set; }
        public virtual DbSet<K3gЗаготовка> K3gЗаготовкаs { get; set; }
        public virtual DbSet<K3gЭконом> K3gЭкономs { get; set; }
        public virtual DbSet<Tэнры> Tэнрыs { get; set; }
        public virtual DbSet<Tэны> Tэныs { get; set; }
        public virtual DbSet<ZiehlAbegg> ZiehlAbeggs { get; set; }
        public virtual DbSet<Вентиляторы> Вентиляторыs { get; set; }
        public virtual DbSet<ВентиляторыУлитка> ВентиляторыУлиткаs { get; set; }
        public virtual DbSet<ВентиляторыШу> ВентиляторыШуs { get; set; }
        public virtual DbSet<ВентиляторыШуЭконом> ВентиляторыШуЭкономs { get; set; }
        public virtual DbSet<ВентиляторыЭксперт> ВентиляторыЭкспертs { get; set; }
        public virtual DbSet<ВодаТепло> ВодаТеплоs { get; set; }
        public virtual DbSet<ВодаХолод> ВодаХолодs { get; set; }
        public virtual DbSet<Габариты> Габаритыs { get; set; }
        public virtual DbSet<ГабаритыЭксперт> ГабаритыЭкспертs { get; set; }
        public virtual DbSet<ГазовыйНагреватель> ГазовыйНагревательs { get; set; }
        public virtual DbSet<Датчики> Датчикиs { get; set; }
        public virtual DbSet<ДатчикиЭконом> ДатчикиЭкономs { get; set; }
        public virtual DbSet<Двигатели> Двигателиs { get; set; }
        public virtual DbSet<Зип> Зипs { get; set; }
        public virtual DbSet<КомплектующиеСу> КомплектующиеСуs { get; set; }
        public virtual DbSet<КонтроллерыDanfoss> КонтроллерыDanfosses { get; set; }
        public virtual DbSet<КонтроллерыDanfossЭконом> КонтроллерыDanfossЭкономs { get; set; }
        public virtual DbSet<Контроллеры> Контроллерыs { get; set; }
        public virtual DbSet<КонтроллерыЩитыКод1С> КонтроллерыЩитыКод1Сs { get; set; }
        public virtual DbSet<КонтроллерыЭконом> КонтроллерыЭкономs { get; set; }
        public virtual DbSet<Коэффициент> Коэффициентs { get; set; }
        public virtual DbSet<Массы> Массыs { get; set; }
        public virtual DbSet<Материалы> Материалыs { get; set; }
        public virtual DbSet<МощНагрОхл> МощНагрОхлs { get; set; }
        public virtual DbSet<НагревГаз> НагревГазs { get; set; }
        public virtual DbSet<НагревГазЭконом> НагревГазЭкономs { get; set; }
        public virtual DbSet<НагревЖидк> НагревЖидкs { get; set; }
        public virtual DbSet<НагревЖидкЭконом> НагревЖидкЭкономs { get; set; }
        public virtual DbSet<НагревЭл> НагревЭлs { get; set; }
        public virtual DbSet<НагревЭлЭконом> НагревЭлЭкономs { get; set; }
        public virtual DbSet<НасосУвлажнителя> НасосУвлажнителяs { get; set; }
        public virtual DbSet<ОбвязкаОхладителя> ОбвязкаОхладителяs { get; set; }
        public virtual DbSet<Опции> Опцииs { get; set; }
        public virtual DbSet<Охладители> Охладителиs { get; set; }
        public virtual DbSet<ОхладителиЭконом> ОхладителиЭкономs { get; set; }
        public virtual DbSet<ОхладительОбвязка> ОхладительОбвязкаs { get; set; }
        public virtual DbSet<ОшибкиВставки> ОшибкиВставкиs { get; set; }
        public virtual DbSet<ПитаниеШу> ПитаниеШуs { get; set; }
        public virtual DbSet<ПитаниеШуЭконом> ПитаниеШуЭкономs { get; set; }
        public virtual DbSet<ПластинчатыйРекуператор> ПластинчатыйРекуператорs { get; set; }
        public virtual DbSet<Привода> Приводаs { get; set; }
        public virtual DbSet<ПриводаКв> ПриводаКвs { get; set; }
        public virtual DbSet<ПриводаШу> ПриводаШуs { get; set; }
        public virtual DbSet<ПриводаШуЭконом> ПриводаШуЭкономs { get; set; }
        public virtual DbSet<Примечание> Примечаниеs { get; set; }
        public virtual DbSet<РазмерКлапанаРекуператора> РазмерКлапанаРекуператораs { get; set; }
        public virtual DbSet<РазмерыAdh> РазмерыAdhs { get; set; }
        public virtual DbSet<РазмерыRdh> РазмерыRdhs { get; set; }
        public virtual DbSet<Размеры> Размерыs { get; set; }
        public virtual DbSet<РазмерыЭксперт> РазмерыЭкспертs { get; set; }
        public virtual DbSet<Рекуператоры> Рекуператорыs { get; set; }
        public virtual DbSet<РекуператорыЭконом> РекуператорыЭкономs { get; set; }
        public virtual DbSet<РоторныйРегенератор> РоторныйРегенераторs { get; set; }
        public virtual DbSet<Служебная> Служебнаяs { get; set; }
        public virtual DbSet<СмесительныеУзлы> СмесительныеУзлыs { get; set; }
        public virtual DbSet<СмесительныеУзлыТренд> СмесительныеУзлыТрендs { get; set; }
        public virtual DbSet<Список0> Список0s { get; set; }
        public virtual DbSet<СписокK3g> СписокK3gs { get; set; }
        public virtual DbSet<Список> Списокs { get; set; }
        public virtual DbSet<СписокШу> СписокШуs { get; set; }
        public virtual DbSet<СуВсбореЦена> СуВсбореЦенаs { get; set; }
        public virtual DbSet<СуГабариты> СуГабаритыs { get; set; }
        public virtual DbSet<СуКомплектующие> СуКомплектующиеs { get; set; }
        public virtual DbSet<СуКомплектующиеТренд> СуКомплектующиеТрендs { get; set; }       
        public virtual DbSet<ТэныЭконом> ТэныЭкономs { get; set; }
        public virtual DbSet<Увлажнители> Увлажнителиs { get; set; }
        public virtual DbSet<УвлажнителиЭконом> УвлажнителиЭкономs { get; set; }
        public virtual DbSet<Уе> Уеs { get; set; }
        public virtual DbSet<УлиткаВыхлоп> УлиткаВыхлопs { get; set; }
        public virtual DbSet<Фильтры> Фильтрыs { get; set; }
        public virtual DbSet<ФреонХолод> ФреонХолодs { get; set; }
        public virtual DbSet<ЧпУпп> ЧпУппs { get; set; }
        public virtual DbSet<Элементы> Элементыs { get; set; }
        public virtual DbSet<ЭлементыЭксперт> ЭлементыЭкспертs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                string connection =
                    $"Data Source=(LocalDB)\\MSSQLLocalDB;" +                
                    $"AttachDbFilename={ Path.GetFullPath("Database/DataBase.mdf")};" +
                    $"Integrated Security=True";
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AвтоматикаДатчики>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Aвтоматика_датчики");

                entity.Property(e => e.Датчики).HasMaxLength(255);

                entity.Property(e => e.ДляКж)
                    .HasMaxLength(255)
                    .HasColumnName("Для КЖ");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Оборудование).HasMaxLength(255);

                entity.Property(e => e.Примечание).HasMaxLength(255);

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<CтепеньЗащитыШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cтепень_защиты_ШУ");

                entity.Property(e => e._)
                    .HasMaxLength(255)
                    .HasColumnName("-");

                entity.Property(e => e.Контроллер).HasMaxLength(255);
            });

            modelBuilder.Entity<Hаценка>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Hаценка");

                entity.Property(e => e.Наценка1)
                    .HasMaxLength(255)
                    .HasColumnName("Наценка 1");

                entity.Property(e => e.Наценка2)
                    .HasMaxLength(255)
                    .HasColumnName("Наценка 2");

                entity.Property(e => e.Обозначение1)
                    .HasMaxLength(255)
                    .HasColumnName("Обозначение 1");

                entity.Property(e => e.Обозначение2)
                    .HasMaxLength(255)
                    .HasColumnName("Обозначение 2");

                entity.Property(e => e.Типоряд).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("№1");

                entity.Property(e => e._2).HasColumnName("№2");

                entity.Property(e => e._3).HasColumnName("№3");

                entity.Property(e => e._4).HasColumnName("№4");
            });

            modelBuilder.Entity<K3g250At3972>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G250_AT39_72");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g250Av29B2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G250_AV29_B2");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g280At0472>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G280_AT04_72");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g280Au06B2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G280_AU06_B2");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g280Au11C2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G280_AU11_C2");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g310Ax5202>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G310_AX52_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g310Ax5422>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G310_AX54_22");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g310Az8802>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G310_AZ88_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g310Bb4902>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G310_BB49_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g355Ax5602>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G355_AX56_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g355Ay4002>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G355_AY40_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g355Ay4322>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G355_AY43_22");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g355Bc9202>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G355_BC92_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g400Aq2301>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G400_AQ23_01");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g400Aq2368>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G400_AQ23_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g400Ay8702>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G400_AY87_02");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g450Aq2568>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G450_AQ25_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g450Az2468>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G450_AZ24_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g500Ap2501>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G500_AP25_01");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g500Aq3368>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G500_AQ33_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g560Aq0868>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G560_AQ08_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3g560Aр2168>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G560_AР21_68");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3gЗаготовка>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G_заготовка");

                entity.Property(e => e.NВт).HasColumnName("N, Вт");

                entity.Property(e => e.NОбМин).HasColumnName("n, об/мин");

                entity.Property(e => e.PПа).HasColumnName("P, Па");

                entity.Property(e => e.PпредПа).HasColumnName("Pпред, Па");

                entity.Property(e => e.UВ).HasColumnName("U, В");

                entity.Property(e => e.VМ3Ч).HasColumnName("V, м3/ч");

                entity.Property(e => e.VпредМ3Ч).HasColumnName("Vпред, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("_");

                entity.Property(e => e.Кпд).HasColumnName("КПД, %");

                entity.Property(e => e.Сведения).HasMaxLength(255);
            });

            modelBuilder.Entity<K3gЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("K3G_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("№1");

                entity.Property(e => e._2).HasColumnName("№2");

                entity.Property(e => e._3).HasColumnName("№3");

                entity.Property(e => e._4).HasColumnName("№4");
            });

            modelBuilder.Entity<Tэнры>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TЭНРы");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Маркировка).HasMaxLength(255);

                entity.Property(e => e.Мощность).HasMaxLength(50);

                entity.Property(e => e.Типоряд).HasMaxLength(255);
            });

            modelBuilder.Entity<Tэны>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TЭНы");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.КолВоПоШирине)
                    .HasMaxLength(255)
                    .HasColumnName("Кол-во по ширине");

                entity.Property(e => e.Маркировка).HasMaxLength(255);

                entity.Property(e => e.Типоряд).HasMaxLength(255);
            });

            modelBuilder.Entity<ZiehlAbegg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ziehl_Abegg");

                entity.Property(e => e.PкКВт)
                    .HasMaxLength(255)
                    .HasColumnName("Pк кВт");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.ВAbb1000)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_1000");

                entity.Property(e => e.ВAbb1000Э)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_1000_Э");

                entity.Property(e => e.ВAbb1500)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_1500");

                entity.Property(e => e.ВAbb1500Э)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_1500_Э");

                entity.Property(e => e.ВAbb3000)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_3000");

                entity.Property(e => e.ВAbb3000Э)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_3000_Э");

                entity.Property(e => e.ВAbb750)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_750");

                entity.Property(e => e.ВAbb750Э)
                    .HasMaxLength(255)
                    .HasColumnName("В_ABB_750_Э");

                entity.Property(e => e.ВАир1000)
                    .HasMaxLength(255)
                    .HasColumnName("В_АИР_1000");

                entity.Property(e => e.ВАир1500)
                    .HasMaxLength(255)
                    .HasColumnName("В_АИР_1500");

                entity.Property(e => e.ВАир3000)
                    .HasMaxLength(255)
                    .HasColumnName("В_АИР_3000");

                entity.Property(e => e.ВАир750)
                    .HasMaxLength(255)
                    .HasColumnName("В_АИР_750");

                entity.Property(e => e.Д).HasMaxLength(255);

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Колесо).HasMaxLength(255);

                entity.Property(e => e.Ш).HasMaxLength(255);
            });

            modelBuilder.Entity<_1с>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("1С");

                entity.Property(e => e.Втулки).HasMaxLength(255);

                entity.Property(e => e.Код1сВтулки)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Втулки");

                entity.Property(e => e.Код1сРоторРеген)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Ротор реген");

                entity.Property(e => e.Код1сСу)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С СУ");

                entity.Property(e => e.Код1сУпп)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С УПП");

                entity.Property(e => e.Код1сФильтры)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Фильтры");

                entity.Property(e => e.Код1сЧп)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С ЧП");

                entity.Property(e => e.КомплектующиеСуИОбвОхл)
                    .HasMaxLength(255)
                    .HasColumnName("Комплектующие СУ и обв охл");

                entity.Property(e => e.Упп)
                    .HasMaxLength(255)
                    .HasColumnName("УПП");

                entity.Property(e => e.Фильтры).HasMaxLength(255);

                entity.Property(e => e.Чп)
                    .HasMaxLength(255)
                    .HasColumnName("ЧП");

                entity.Property(e => e.ЧпРоторРеген)
                    .HasMaxLength(255)
                    .HasColumnName("ЧП Ротор реген");
            });

            modelBuilder.Entity<_1с0>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("1С_0");

                entity.Property(e => e.Код1сПривода)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С привода");

                entity.Property(e => e.Привода).HasMaxLength(255);
            });

            modelBuilder.Entity<_1сШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("1С_ШУ");

                entity.Property(e => e.Код1сКонтроллеры)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Контроллеры");

                entity.Property(e => e.Код1сЩиты)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Щиты");

                entity.Property(e => e.Контроллеры).HasMaxLength(255);

                entity.Property(e => e.Щиты).HasMaxLength(255);
            });

            modelBuilder.Entity<Вентиляторы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вентиляторы");

                entity.Property(e => e.Nxn).HasMaxLength(255);

                entity.Property(e => e.Vilmann).HasMaxLength(255);

                entity.Property(e => e.Аир)
                    .HasMaxLength(255)
                    .HasColumnName("АИР");

                entity.Property(e => e.Медведь).HasMaxLength(255);

                entity.Property(e => e.Никотра).HasMaxLength(255);

                entity.Property(e => e.Солер).HasMaxLength(255);

                entity.Property(e => e.ЦенаVilmann).HasColumnName("Цена Vilmann");

                entity.Property(e => e.ЦенаАир).HasColumnName("Цена АИР");

                entity.Property(e => e.ЦенаМедведь).HasColumnName("Цена Медведь");

                entity.Property(e => e.ЦенаНикотра).HasColumnName("Цена Никотра");

                entity.Property(e => e.ЦенаСолер).HasColumnName("Цена Солер");

                entity.Property(e => e.ЦенаЦильАбегг).HasColumnName("Цена Циль Абегг");

                entity.Property(e => e.ЦильАбегг)
                    .HasMaxLength(255)
                    .HasColumnName("Циль Абегг");
            });

            modelBuilder.Entity<ВентиляторыУлитка>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вентиляторы_Улитка");

                entity.Property(e => e.Код1сНикотра)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Никотра");

                entity.Property(e => e.Код1сСолер)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Солер");

                entity.Property(e => e.Никотра).HasMaxLength(255);

                entity.Property(e => e.НикотраЦена)
                    .HasMaxLength(255)
                    .HasColumnName("Никотра цена");

                entity.Property(e => e.НикотраЦенаЭксперт)
                    .HasMaxLength(255)
                    .HasColumnName("Никотра цена Эксперт");

                entity.Property(e => e.Солер).HasMaxLength(255);

                entity.Property(e => e.СолерЦена)
                    .HasMaxLength(255)
                    .HasColumnName("Солер цена");

                entity.Property(e => e.СолерЦенаЭксперт)
                    .HasMaxLength(255)
                    .HasColumnName("Солер цена Эксперт");
            });

            modelBuilder.Entity<ВентиляторыШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вентиляторы_ШУ");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._037КВт).HasColumnName("0,37 кВт");

                entity.Property(e => e._055КВт).HasColumnName("0,55 кВт");

                entity.Property(e => e._075КВт).HasColumnName("0,75 кВт");

                entity.Property(e => e._11КВт).HasColumnName("1,1 кВт");

                entity.Property(e => e._11КВт1).HasColumnName("11 кВт");

                entity.Property(e => e._15КВт).HasColumnName("1,5 кВт");

                entity.Property(e => e._15КВт1).HasColumnName("15 кВт");

                entity.Property(e => e._185КВт).HasColumnName("18,5 кВт");

                entity.Property(e => e._22КВт).HasColumnName("2,2 кВт");

                entity.Property(e => e._22КВт1).HasColumnName("22 кВт");

                entity.Property(e => e._30КВт).HasColumnName("3,0 кВт");

                entity.Property(e => e._30КВт1).HasColumnName("30 кВт");

                entity.Property(e => e._37КВт).HasColumnName("37 кВт");

                entity.Property(e => e._40КВт).HasColumnName("4,0 кВт");

                entity.Property(e => e._45КВт).HasColumnName("45 кВт");

                entity.Property(e => e._55КВт).HasColumnName("5,5 кВт");

                entity.Property(e => e._55КВт1).HasColumnName("55 кВт");

                entity.Property(e => e._75КВт).HasColumnName("7,5 кВт");

                entity.Property(e => e._75КВт1).HasColumnName("75 кВт");
            });

            modelBuilder.Entity<ВентиляторыШуЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вентиляторы_ШУ_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._037КВт).HasColumnName("0,37 кВт");

                entity.Property(e => e._055КВт).HasColumnName("0,55 кВт");

                entity.Property(e => e._075КВт).HasColumnName("0,75 кВт");

                entity.Property(e => e._11КВт).HasColumnName("1,1 кВт");

                entity.Property(e => e._11КВт1).HasColumnName("11 кВт");

                entity.Property(e => e._15КВт).HasColumnName("1,5 кВт");

                entity.Property(e => e._15КВт1).HasColumnName("15 кВт");

                entity.Property(e => e._185КВт).HasColumnName("18,5 кВт");

                entity.Property(e => e._22КВт).HasColumnName("2,2 кВт");

                entity.Property(e => e._22КВт1).HasColumnName("22 кВт");

                entity.Property(e => e._30КВт).HasColumnName("3,0 кВт");

                entity.Property(e => e._30КВт1).HasColumnName("30 кВт");

                entity.Property(e => e._37КВт).HasColumnName("37 кВт");

                entity.Property(e => e._40КВт).HasColumnName("4,0 кВт");

                entity.Property(e => e._45КВт).HasColumnName("45 кВт");

                entity.Property(e => e._55КВт).HasColumnName("5,5 кВт");

                entity.Property(e => e._55КВт1).HasColumnName("55 кВт");

                entity.Property(e => e._75КВт).HasColumnName("7,5 кВт");

                entity.Property(e => e._75КВт1).HasColumnName("75 кВт");
            });

            modelBuilder.Entity<ВентиляторыЭксперт>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вентиляторы_Эксперт");

                entity.Property(e => e.Abb)
                    .HasMaxLength(255)
                    .HasColumnName("ABB");

                entity.Property(e => e.Nxn).HasMaxLength(255);

                entity.Property(e => e.Никотра).HasMaxLength(255);

                entity.Property(e => e.Солер).HasMaxLength(255);

                entity.Property(e => e.ЦенаAbb).HasColumnName("Цена ABB");

                entity.Property(e => e.ЦенаНикотра).HasColumnName("Цена Никотра");

                entity.Property(e => e.ЦенаСолер).HasColumnName("Цена Солер");

                entity.Property(e => e.ЦенаЦильАбегг).HasColumnName("Цена Циль Абегг");

                entity.Property(e => e.ЦильАбегг)
                    .HasMaxLength(255)
                    .HasColumnName("Циль Абегг");
            });

            modelBuilder.Entity<ВодаТепло>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вода_тепло");

                entity.Property(e => e.DPConst)
                    .HasMaxLength(255)
                    .HasColumnName("dP const");

                entity.Property(e => e.LВозд).HasColumnName("L возд");

                entity.Property(e => e.NКвт).HasColumnName("N Квт");

                entity.Property(e => e.VDP0)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_0");

                entity.Property(e => e.VDP1)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_1");

                entity.Property(e => e.VDP2)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_2");

                entity.Property(e => e.VDP3)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_3");

                entity.Property(e => e.VDP4)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_4");

                entity.Property(e => e.VDP5)
                    .HasMaxLength(255)
                    .HasColumnName("V/dP_5");

                entity.Property(e => e.ВысотаГабарит).HasColumnName("Высота габарит");

                entity.Property(e => e.ВысотаЖс).HasColumnName("Высота ЖС");

                entity.Property(e => e.ДПрисоединения)
                    .HasMaxLength(255)
                    .HasColumnName("Д присоединения");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Типоряд).HasMaxLength(255);

                entity.Property(e => e.ШиринаГабарит).HasColumnName("Ширина габарит");

                entity.Property(e => e.ШиринаЖс).HasColumnName("Ширина ЖС");
            });

            modelBuilder.Entity<ВодаХолод>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Вода_холод");

                entity.Property(e => e.LВозд).HasColumnName("L возд");

                entity.Property(e => e.NКвт).HasColumnName("N Квт");

                entity.Property(e => e.АШиринаЖс).HasColumnName("А  ширина ЖС");

                entity.Property(e => e.ВВысотаЖс).HasColumnName("В высота ЖС");

                entity.Property(e => e.ВысотаГабарит).HasColumnName("Высота габарит");

                entity.Property(e => e.ДПрисоединения)
                    .HasMaxLength(255)
                    .HasColumnName("Д присоединения");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Типоряд).HasMaxLength(255);

                entity.Property(e => e.ШиринаГабарит).HasColumnName("Ширина габарит");
            });

            modelBuilder.Entity<Габариты>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Габариты");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasMaxLength(255)
                    .HasColumnName("10");

                entity.Property(e => e._100)
                    .HasMaxLength(255)
                    .HasColumnName("100");

                entity.Property(e => e._12)
                    .HasMaxLength(255)
                    .HasColumnName("12");

                entity.Property(e => e._16)
                    .HasMaxLength(255)
                    .HasColumnName("16");

                entity.Property(e => e._2)
                    .HasMaxLength(255)
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasMaxLength(255)
                    .HasColumnName("20");

                entity.Property(e => e._25)
                    .HasMaxLength(255)
                    .HasColumnName("25");

                entity.Property(e => e._3)
                    .HasMaxLength(255)
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasMaxLength(255)
                    .HasColumnName("30");

                entity.Property(e => e._4)
                    .HasMaxLength(255)
                    .HasColumnName("4");

                entity.Property(e => e._40)
                    .HasMaxLength(255)
                    .HasColumnName("40");

                entity.Property(e => e._5)
                    .HasMaxLength(255)
                    .HasColumnName("5");

                entity.Property(e => e._50)
                    .HasMaxLength(255)
                    .HasColumnName("50");

                entity.Property(e => e._6)
                    .HasMaxLength(255)
                    .HasColumnName("6");

                entity.Property(e => e._60)
                    .HasMaxLength(255)
                    .HasColumnName("60");

                entity.Property(e => e._7)
                    .HasMaxLength(255)
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasMaxLength(255)
                    .HasColumnName("8");

                entity.Property(e => e._80)
                    .HasMaxLength(255)
                    .HasColumnName("80");
            });

            modelBuilder.Entity<ГабаритыЭксперт>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Габариты_Эксперт");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasMaxLength(255)
                    .HasColumnName("10");

                entity.Property(e => e._100)
                    .HasMaxLength(255)
                    .HasColumnName("100");

                entity.Property(e => e._12)
                    .HasMaxLength(255)
                    .HasColumnName("12");

                entity.Property(e => e._16)
                    .HasMaxLength(255)
                    .HasColumnName("16");

                entity.Property(e => e._2)
                    .HasMaxLength(255)
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasMaxLength(255)
                    .HasColumnName("20");

                entity.Property(e => e._25)
                    .HasMaxLength(255)
                    .HasColumnName("25");

                entity.Property(e => e._3)
                    .HasMaxLength(255)
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasMaxLength(255)
                    .HasColumnName("30");

                entity.Property(e => e._4)
                    .HasMaxLength(255)
                    .HasColumnName("4");

                entity.Property(e => e._40)
                    .HasMaxLength(255)
                    .HasColumnName("40");

                entity.Property(e => e._5)
                    .HasMaxLength(255)
                    .HasColumnName("5");

                entity.Property(e => e._50)
                    .HasMaxLength(255)
                    .HasColumnName("50");

                entity.Property(e => e._6)
                    .HasMaxLength(255)
                    .HasColumnName("6");

                entity.Property(e => e._60)
                    .HasMaxLength(255)
                    .HasColumnName("60");

                entity.Property(e => e._7)
                    .HasMaxLength(255)
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasMaxLength(255)
                    .HasColumnName("8");

                entity.Property(e => e._80)
                    .HasMaxLength(255)
                    .HasColumnName("80");
            });

            modelBuilder.Entity<ГазовыйНагреватель>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Газовый_нагреватель");

                entity.Property(e => e.Модель).HasMaxLength(255);

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<Датчики>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Датчики");

                entity.Property(e => e.Датчик).HasMaxLength(255);

                entity.Property(e => e.Ключ1).HasMaxLength(255);

                entity.Property(e => e.Ключ2).HasMaxLength(255);

                entity.Property(e => e.Ключ3).HasMaxLength(255);

                entity.Property(e => e.Ключ4).HasMaxLength(255);

                entity.Property(e => e.Ключ5).HasMaxLength(255);
            });

            modelBuilder.Entity<ДатчикиЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Датчики_Эконом");

                entity.Property(e => e.Датчик).HasMaxLength(255);

                entity.Property(e => e.Ключ1).HasMaxLength(255);

                entity.Property(e => e.Ключ2).HasMaxLength(255);

                entity.Property(e => e.Ключ3).HasMaxLength(255);

                entity.Property(e => e.Ключ4).HasMaxLength(255);

                entity.Property(e => e.Ключ5).HasMaxLength(255);
            });

            modelBuilder.Entity<Двигатели>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Двигатели");

                entity.Property(e => e.Abb)
                    .HasMaxLength(255)
                    .HasColumnName("ABB");

                entity.Property(e => e.Nxn).HasMaxLength(255);

                entity.Property(e => e.АввЭкс)
                    .HasMaxLength(255)
                    .HasColumnName("АВВ Экс");

                entity.Property(e => e.Аир)
                    .HasMaxLength(255)
                    .HasColumnName("АИР");

                entity.Property(e => e.Код1сАвв)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С АВВ");

                entity.Property(e => e.Код1сАввЭкс)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С АВВ Экс");

                entity.Property(e => e.Код1сАир)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С АИР");

                entity.Property(e => e.МаркировкаAbb)
                    .HasMaxLength(255)
                    .HasColumnName("Маркировка ABB");

                entity.Property(e => e.МаркировкаAbbЭкс)
                    .HasMaxLength(255)
                    .HasColumnName("Маркировка ABB Экс");

                entity.Property(e => e.МаркировкаАир)
                    .HasMaxLength(255)
                    .HasColumnName("Маркировка АИР");

                entity.Property(e => e.ЦенаAbb).HasColumnName("Цена ABB");

                entity.Property(e => e.ЦенаАввЭкс).HasColumnName("Цена АВВ Экс");

                entity.Property(e => e.ЦенаАир).HasColumnName("Цена АИР");
            });

            modelBuilder.Entity<Зип>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ЗИП");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._100).HasColumnName("100");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._40).HasColumnName("40");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._50).HasColumnName("50");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._60).HasColumnName("60");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._80).HasColumnName("80");

                entity.Property(e => e.Код1с1)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-1");

                entity.Property(e => e.Код1с10)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-10");

                entity.Property(e => e.Код1с100)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-100");

                entity.Property(e => e.Код1с12)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-12");

                entity.Property(e => e.Код1с16)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-16");

                entity.Property(e => e.Код1с2)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-2");

                entity.Property(e => e.Код1с20)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-20");

                entity.Property(e => e.Код1с25)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-25");

                entity.Property(e => e.Код1с3)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-3");

                entity.Property(e => e.Код1с30)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-30");

                entity.Property(e => e.Код1с4)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-4");

                entity.Property(e => e.Код1с40)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-40");

                entity.Property(e => e.Код1с5)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-5");

                entity.Property(e => e.Код1с50)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-50");

                entity.Property(e => e.Код1с6)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-6");

                entity.Property(e => e.Код1с60)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-60");

                entity.Property(e => e.Код1с7)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-7");

                entity.Property(e => e.Код1с8)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-8");

                entity.Property(e => e.Код1с80)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С-80");
            });

            modelBuilder.Entity<КомплектующиеСу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Комплектующие_СУ");

                entity.Property(e => e.A)
                    .HasMaxLength(255)
                    .HasColumnName("a");

                entity.Property(e => e.B)
                    .HasMaxLength(255)
                    .HasColumnName("b");

                entity.Property(e => e.Kvs).HasMaxLength(255);

                entity.Property(e => e.NКВт)
                    .HasMaxLength(255)
                    .HasColumnName("N, кВт");

                entity.Property(e => e.ВМаркировкуСу)
                    .HasMaxLength(255)
                    .HasColumnName("В маркировку СУ");

                entity.Property(e => e.Двухходовые).HasMaxLength(255);

                entity.Property(e => e.Комплектующие).HasMaxLength(255);

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.ПрисоедРазмерМм)
                    .HasMaxLength(255)
                    .HasColumnName("Присоед размер, мм");

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.Фазность).HasMaxLength(255);

                entity.Property(e => e.Цена).HasMaxLength(255);

                entity.Property(e => e.ЦенаДвухход)
                    .HasMaxLength(255)
                    .HasColumnName("Цена двухход");

                entity.Property(e => e.ЦенаНасоса)
                    .HasMaxLength(255)
                    .HasColumnName("Цена насоса");

                entity.Property(e => e.ЦенаТрехход)
                    .HasMaxLength(255)
                    .HasColumnName("Цена трехход");
            });

            modelBuilder.Entity<Контроллеры>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Контроллеры");

                entity.Property(e => e.Smh12210015).HasColumnName("SMH 1221-001-5");

                entity.Property(e => e.Smh43110010).HasColumnName("SMH 4311-001-0");

                entity.Property(e => e.Smh43220015).HasColumnName("SMH 4322-001-5");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<КонтроллерыDanfoss>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Контроллеры_Danfoss");

                entity.Property(e => e.Mcx06d).HasColumnName("MCX06D");

                entity.Property(e => e.Mcx06dД).HasColumnName("MCX06D-Д");

                entity.Property(e => e.Mcx08m).HasColumnName("MCX08M");

                entity.Property(e => e.Mcx15b).HasColumnName("MCX15B");

                entity.Property(e => e.Mcx20b).HasColumnName("MCX20B");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<КонтроллерыDanfossЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Контроллеры_Danfoss_Эконом");

                entity.Property(e => e.Mcx06d).HasColumnName("MCX06D");

                entity.Property(e => e.Mcx06dД).HasColumnName("MCX06D-Д");

                entity.Property(e => e.Mcx08m).HasColumnName("MCX08M");

                entity.Property(e => e.Mcx15b).HasColumnName("MCX15B");

                entity.Property(e => e.Mcx20b).HasColumnName("MCX20B");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<КонтроллерыЩитыКод1С>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Контроллеры_Щиты_Код1С");

                entity.Property(e => e.Код1сКонтроллеры)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Контроллеры");

                entity.Property(e => e.Код1сЩиты)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С Щиты");

                entity.Property(e => e.Контроллеры).HasMaxLength(255);

                entity.Property(e => e.Щиты).HasMaxLength(255);
            });

            modelBuilder.Entity<КонтроллерыЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Контроллеры_Эконом");

                entity.Property(e => e.Smh12210015).HasColumnName("SMH 1221-001-5");

                entity.Property(e => e.Smh43110010).HasColumnName("SMH 4311-001-0");

                entity.Property(e => e.Smh43220015).HasColumnName("SMH 4322-001-5");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<Коэффициент>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Коэффициент");

                entity.Property(e => e.Климат).HasMaxLength(255);

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.Эксперт).HasMaxLength(255);
            });

            modelBuilder.Entity<Массы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Массы");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._100).HasColumnName("100");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._40).HasColumnName("40");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._50).HasColumnName("50");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._60).HasColumnName("60");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._80).HasColumnName("80");
            });

            modelBuilder.Entity<Материалы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Материалы");

                entity.Property(e => e.ЕдИзм)
                    .HasMaxLength(255)
                    .HasColumnName("Ед изм");

                entity.Property(e => e.Материалы1)
                    .HasMaxLength(255)
                    .HasColumnName("Материалы");

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<МощНагрОхл>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Мощ_нагр_охл");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._100).HasColumnName("100");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._40).HasColumnName("40");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._50).HasColumnName("50");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._60).HasColumnName("60");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._80).HasColumnName("80");
            });

            modelBuilder.Entity<НагревГаз>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_газ");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<НагревГазЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_газ_Эконом");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<НагревЖидк>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_жидк");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.С1ФНасосом).HasColumnName("с 1-ф насосом");

                entity.Property(e => e.С3ФНасосомДо3КВт).HasColumnName("с 3-ф насосом до 3 кВт");

                entity.Property(e => e.С3ФНасосомДо75КВт).HasColumnName("с 3-ф насосом до 7,5 кВт");
            });

            modelBuilder.Entity<НагревЖидкЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_жидк_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.С1ФНасосом).HasColumnName("с 1-ф насосом");

                entity.Property(e => e.С3ФНасосомДо3КВт).HasColumnName("с 3-ф насосом до 3 кВт");

                entity.Property(e => e.С3ФНасосомДо75КВт).HasColumnName("с 3-ф насосом до 7,5 кВт");
            });

            modelBuilder.Entity<НагревЭл>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_эл");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1СтДо1125КВт).HasColumnName("1 ст до 11,25 кВт");

                entity.Property(e => e._1СтДо135КВт).HasColumnName("1 ст до 13,5 кВт");

                entity.Property(e => e._1СтДо1875КВт).HasColumnName("1 ст до 18,75 кВт");

                entity.Property(e => e._1СтДо225КВт).HasColumnName("1 ст до 22,5 кВт");

                entity.Property(e => e._1СтДо24КВт).HasColumnName("1 ст до 24 кВт");

                entity.Property(e => e._1СтДо30КВт).HasColumnName("1 ст до 30 кВт");

                entity.Property(e => e._1СтДо36КВт).HasColumnName("1 ст до 36 кВт");
            });

            modelBuilder.Entity<НагревЭлЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Нагрев_эл_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1СтДо1125КВт).HasColumnName("1 ст до 11,25 кВт");

                entity.Property(e => e._1СтДо135КВт).HasColumnName("1 ст до 13,5 кВт");

                entity.Property(e => e._1СтДо1875КВт).HasColumnName("1 ст до 18,75 кВт");

                entity.Property(e => e._1СтДо225КВт).HasColumnName("1 ст до 22,5 кВт");

                entity.Property(e => e._1СтДо24КВт).HasColumnName("1 ст до 24 кВт");

                entity.Property(e => e._1СтДо30КВт).HasColumnName("1 ст до 30 кВт");

                entity.Property(e => e._1СтДо36КВт).HasColumnName("1 ст до 36 кВт");
            });

            modelBuilder.Entity<НасосУвлажнителя>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Насос_увлажнителя");

                entity.Property(e => e.NНасосаКВт)
                    .HasMaxLength(255)
                    .HasColumnName("N насоса, кВт");

                entity.Property(e => e.КабельНасоса)
                    .HasMaxLength(255)
                    .HasColumnName("Кабель насоса");

                entity.Property(e => e.Климата)
                    .HasMaxLength(255)
                    .HasColumnName("№ Климата");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.КоэфТЦены)
                    .HasMaxLength(255)
                    .HasColumnName("Коэф-т цены");

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.Пп0Чп1)
                    .HasMaxLength(255)
                    .HasColumnName("ПП_0/ЧП_1");

                entity.Property(e => e.ФазыНасоса)
                    .HasMaxLength(255)
                    .HasColumnName("Фазы насоса");

                entity.Property(e => e.Цена).HasMaxLength(255);
            });

            modelBuilder.Entity<ОбвязкаОхладителя>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Обвязка_охладителя");

                entity.Property(e => e.Модель).HasMaxLength(255);

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<Опции>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Опции");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Оборудование).HasMaxLength(255);

                entity.Property(e => e.Примечание).HasMaxLength(255);

                entity.Property(e => e.ТипорядК).HasColumnName("Типоряд К");

                entity.Property(e => e.ТипорядЭ).HasColumnName("Типоряд Э");

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<Охладители>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Охладители");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1Ступень).HasColumnName("1 ступень");

                entity.Property(e => e._2Ступени).HasColumnName("2 ступени");

                entity.Property(e => e._3Ступени).HasColumnName("3 ступени");

                entity.Property(e => e._4Ступени).HasColumnName("4 ступени");
            });

            modelBuilder.Entity<ОхладителиЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Охладители_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1Ступень).HasColumnName("1 ступень");

                entity.Property(e => e._2Ступени).HasColumnName("2 ступени");

                entity.Property(e => e._3Ступени).HasColumnName("3 ступени");

                entity.Property(e => e._4Ступени).HasColumnName("4 ступени");
            });

            modelBuilder.Entity<ОхладительОбвязка>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Охладитель_обвязка");

                entity.Property(e => e.Kvs).HasMaxLength(255);

                entity.Property(e => e.Адаптер).HasMaxLength(255);

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.Электропривод).HasMaxLength(255);
            });

            modelBuilder.Entity<ОшибкиВставки>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ошибки вставки");

                entity.Property(e => e.Датчики).HasMaxLength(255);

                entity.Property(e => e.ДляКж)
                    .HasMaxLength(255)
                    .HasColumnName("Для КЖ");

                entity.Property(e => e.Оборудование).HasMaxLength(255);

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<ПитаниеШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Питание_ШУ");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.ТокДо).HasColumnName("Ток (до)");

                entity.Property(e => e.Щмп2).HasColumnName("ЩМП-2");

                entity.Property(e => e.Щмп3).HasColumnName("ЩМП-3");

                entity.Property(e => e.Щмп4).HasColumnName("ЩМП-4");

                entity.Property(e => e.Щмп5).HasColumnName("ЩМП-5");
            });

            modelBuilder.Entity<ПитаниеШуЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Питание_ШУ_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.ТокДо).HasColumnName("Ток (до)");

                entity.Property(e => e.Щмп2).HasColumnName("ЩМП-2");

                entity.Property(e => e.Щмп3).HasColumnName("ЩМП-3");

                entity.Property(e => e.Щмп4).HasColumnName("ЩМП-4");

                entity.Property(e => e.Щмп5).HasColumnName("ЩМП-5");
            });

            modelBuilder.Entity<ПластинчатыйРекуператор>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Пластинчатый_рекуператор");

                entity.Property(e => e.LГраниМм)
                    .HasMaxLength(255)
                    .HasColumnName("l грани, мм");

                entity.Property(e => e.LПакетаМм)
                    .HasMaxLength(255)
                    .HasColumnName("l пакета, мм");

                entity.Property(e => e.VМ3Ч)
                    .HasMaxLength(255)
                    .HasColumnName("V, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Высота).HasMaxLength(255);

                entity.Property(e => e.Длина).HasMaxLength(255);

                entity.Property(e => e.Исполнение).HasMaxLength(255);

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Маркировка).HasMaxLength(255);

                entity.Property(e => e.Цена).HasMaxLength(255);
            });

            modelBuilder.Entity<Привода>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Привода");

                entity.Property(e => e.МоментНМ).HasColumnName("Момент, Н*м");

                entity.Property(e => e.Оборудование).HasMaxLength(255);

                entity.Property(e => e.Привода1)
                    .HasMaxLength(255)
                    .HasColumnName("Привода");

                entity.Property(e => e.ПриводаДляКж)
                    .HasMaxLength(255)
                    .HasColumnName("Привода для КЖ");

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<ПриводаКв>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Привода_КВ");

                entity.Property(e => e.МоментНМ).HasColumnName("Момент, Н*м");

                entity.Property(e => e.Оборудование).HasMaxLength(255);

                entity.Property(e => e.Привода).HasMaxLength(255);

                entity.Property(e => e.ПриводаДляКж)
                    .HasMaxLength(255)
                    .HasColumnName("Привода для КЖ");

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена Эксперт");
            });

            modelBuilder.Entity<ПриводаШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Привода_ШУ");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._230вБезПружИли24в010вСПруж).HasColumnName("230В без пруж или 24В 0-10В с пруж");

                entity.Property(e => e._230вВозврПруж).HasColumnName("230В возвр пруж");

                entity.Property(e => e._24в010вРециркуляция).HasColumnName("24В 0-10В рециркуляция");
            });

            modelBuilder.Entity<ПриводаШуЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Привода_ШУ_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._230вБезПружИли24в010вСПруж).HasColumnName("230В без пруж или 24В 0-10В с пруж");

                entity.Property(e => e._230вВозврПруж).HasColumnName("230В возвр пруж");

                entity.Property(e => e._24в010вРециркуляция).HasColumnName("24В 0-10В рециркуляция");
            });

            modelBuilder.Entity<Примечание>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Примечание");

                entity.Property(e => e.Примечание1)
                    .HasMaxLength(255)
                    .HasColumnName("Примечание");

                entity.Property(e => e.ПримечаниеK3g)
                    .HasMaxLength(255)
                    .HasColumnName("Примечание K3G");
            });

            modelBuilder.Entity<РазмерКлапанаРекуператора>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Размер_клапана_рекуператора");

                entity.Property(e => e.ВысотаКлапана)
                    .HasMaxLength(255)
                    .HasColumnName("Высота клапана");

                entity.Property(e => e.Климата)
                    .HasMaxLength(255)
                    .HasColumnName("№ Климата");

                entity.Property(e => e.Рекуператор).HasMaxLength(255);
            });

            modelBuilder.Entity<Размеры>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Размеры");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasMaxLength(255)
                    .HasColumnName("10");

                entity.Property(e => e._100)
                    .HasMaxLength(255)
                    .HasColumnName("100");

                entity.Property(e => e._12)
                    .HasMaxLength(255)
                    .HasColumnName("12");

                entity.Property(e => e._16)
                    .HasMaxLength(255)
                    .HasColumnName("16");

                entity.Property(e => e._2)
                    .HasMaxLength(255)
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasMaxLength(255)
                    .HasColumnName("20");

                entity.Property(e => e._25)
                    .HasMaxLength(255)
                    .HasColumnName("25");

                entity.Property(e => e._3)
                    .HasMaxLength(255)
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasMaxLength(255)
                    .HasColumnName("30");

                entity.Property(e => e._4)
                    .HasMaxLength(255)
                    .HasColumnName("4");

                entity.Property(e => e._40)
                    .HasMaxLength(255)
                    .HasColumnName("40");

                entity.Property(e => e._5)
                    .HasMaxLength(255)
                    .HasColumnName("5");

                entity.Property(e => e._50)
                    .HasMaxLength(255)
                    .HasColumnName("50");

                entity.Property(e => e._6)
                    .HasMaxLength(255)
                    .HasColumnName("6");

                entity.Property(e => e._60)
                    .HasMaxLength(255)
                    .HasColumnName("60");

                entity.Property(e => e._7)
                    .HasMaxLength(255)
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasMaxLength(255)
                    .HasColumnName("8");

                entity.Property(e => e._80)
                    .HasMaxLength(255)
                    .HasColumnName("80");
            });

            modelBuilder.Entity<РазмерыAdh>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Размеры_ADH");

                entity.Property(e => e.Adh)
                    .HasMaxLength(255)
                    .HasColumnName("ADH");

                entity.Property(e => e.HИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("H исп1");

                entity.Property(e => e.HИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп1 рез дв");

                entity.Property(e => e.HИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("H исп2");

                entity.Property(e => e.HИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп2 рез дв");

                entity.Property(e => e.HИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("H исп3");

                entity.Property(e => e.HИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп3 рез дв");

                entity.Property(e => e.LИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1");

                entity.Property(e => e.LИсп1Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез");

                entity.Property(e => e.LИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез дв");

                entity.Property(e => e.LИсп1РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез рез дв");

                entity.Property(e => e.LИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2");

                entity.Property(e => e.LИсп2Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез");

                entity.Property(e => e.LИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез дв");

                entity.Property(e => e.LИсп2РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез рез дв");

                entity.Property(e => e.LИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3");

                entity.Property(e => e.LИсп3Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез");

                entity.Property(e => e.LИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез дв");

                entity.Property(e => e.LИсп3РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез рез дв");

                entity.Property(e => e.SИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("S исп1");

                entity.Property(e => e.SИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп1 рез дв");

                entity.Property(e => e.SИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("S исп2");

                entity.Property(e => e.SИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп2 рез дв");

                entity.Property(e => e.SИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("S исп3");

                entity.Property(e => e.SИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп3 рез дв");
            });

            modelBuilder.Entity<РазмерыRdh>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Размеры_RDH");

                entity.Property(e => e.HИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("H исп1");

                entity.Property(e => e.HИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп1 рез дв");

                entity.Property(e => e.HИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("H исп2");

                entity.Property(e => e.HИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп2 рез дв");

                entity.Property(e => e.HИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("H исп3");

                entity.Property(e => e.HИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("H исп3 рез дв");

                entity.Property(e => e.LИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1");

                entity.Property(e => e.LИсп1Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез");

                entity.Property(e => e.LИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез дв");

                entity.Property(e => e.LИсп1РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп1 рез рез дв");

                entity.Property(e => e.LИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2");

                entity.Property(e => e.LИсп2Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез");

                entity.Property(e => e.LИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез дв");

                entity.Property(e => e.LИсп2РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп2 рез рез дв");

                entity.Property(e => e.LИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3");

                entity.Property(e => e.LИсп3Рез)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез");

                entity.Property(e => e.LИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез дв");

                entity.Property(e => e.LИсп3РезРезДв)
                    .HasMaxLength(255)
                    .HasColumnName("L исп3 рез рез дв");

                entity.Property(e => e.Rdh)
                    .HasMaxLength(255)
                    .HasColumnName("RDH");

                entity.Property(e => e.SИсп1)
                    .HasMaxLength(255)
                    .HasColumnName("S исп1");

                entity.Property(e => e.SИсп1РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп1 рез дв");

                entity.Property(e => e.SИсп2)
                    .HasMaxLength(255)
                    .HasColumnName("S исп2");

                entity.Property(e => e.SИсп2РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп2 рез дв");

                entity.Property(e => e.SИсп3)
                    .HasMaxLength(255)
                    .HasColumnName("S исп3");

                entity.Property(e => e.SИсп3РезДв)
                    .HasMaxLength(255)
                    .HasColumnName("S исп3 рез дв");
            });

            modelBuilder.Entity<РазмерыЭксперт>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Размеры_Эксперт");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasMaxLength(255)
                    .HasColumnName("10");

                entity.Property(e => e._100)
                    .HasMaxLength(255)
                    .HasColumnName("100");

                entity.Property(e => e._12)
                    .HasMaxLength(255)
                    .HasColumnName("12");

                entity.Property(e => e._16)
                    .HasMaxLength(255)
                    .HasColumnName("16");

                entity.Property(e => e._2)
                    .HasMaxLength(255)
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasMaxLength(255)
                    .HasColumnName("20");

                entity.Property(e => e._25)
                    .HasMaxLength(255)
                    .HasColumnName("25");

                entity.Property(e => e._3)
                    .HasMaxLength(255)
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasMaxLength(255)
                    .HasColumnName("30");

                entity.Property(e => e._4)
                    .HasMaxLength(255)
                    .HasColumnName("4");

                entity.Property(e => e._40)
                    .HasMaxLength(255)
                    .HasColumnName("40");

                entity.Property(e => e._5)
                    .HasMaxLength(255)
                    .HasColumnName("5");

                entity.Property(e => e._50)
                    .HasMaxLength(255)
                    .HasColumnName("50");

                entity.Property(e => e._6)
                    .HasMaxLength(255)
                    .HasColumnName("6");

                entity.Property(e => e._60)
                    .HasMaxLength(255)
                    .HasColumnName("60");

                entity.Property(e => e._7)
                    .HasMaxLength(255)
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasMaxLength(255)
                    .HasColumnName("8");

                entity.Property(e => e._80)
                    .HasMaxLength(255)
                    .HasColumnName("80");
            });

            modelBuilder.Entity<Рекуператоры>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Рекуператоры");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.Рекуператоры1).HasColumnName("Рекуператоры");
            });

            modelBuilder.Entity<РекуператорыЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Рекуператоры_Эконом");

                entity.Property(e => e._).HasMaxLength(255);
            });

            modelBuilder.Entity<РоторныйРегенератор>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Роторный_регенератор");

                entity.Property(e => e.DРотора)
                    .HasMaxLength(255)
                    .HasColumnName("d ротора");

                entity.Property(e => e.NКВт)
                    .HasMaxLength(255)
                    .HasColumnName("N, кВт");

                entity.Property(e => e.VМ3Ч)
                    .HasMaxLength(255)
                    .HasColumnName("V, м3/ч");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Высота).HasMaxLength(255);

                entity.Property(e => e.Длина1)
                    .HasMaxLength(255)
                    .HasColumnName("Длина 1");

                entity.Property(e => e.Длина2)
                    .HasMaxLength(255)
                    .HasColumnName("Длина 2");

                entity.Property(e => e.Исполнение).HasMaxLength(255);

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.Маркировка).HasMaxLength(255);

                entity.Property(e => e.Цена).HasMaxLength(255);

                entity.Property(e => e.Ширина).HasMaxLength(255);
            });

            modelBuilder.Entity<Служебная>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Служебная");

                entity.Property(e => e._0)
                    .HasMaxLength(255)
                    .HasColumnName("0");

                entity.Property(e => e._1)
                    .HasMaxLength(255)
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasMaxLength(255)
                    .HasColumnName("10");

                entity.Property(e => e._11)
                    .HasMaxLength(255)
                    .HasColumnName("11");

                entity.Property(e => e._12)
                    .HasMaxLength(255)
                    .HasColumnName("12");

                entity.Property(e => e._13)
                    .HasMaxLength(255)
                    .HasColumnName("13");

                entity.Property(e => e._14)
                    .HasMaxLength(255)
                    .HasColumnName("14");

                entity.Property(e => e._15)
                    .HasMaxLength(255)
                    .HasColumnName("15");

                entity.Property(e => e._16)
                    .HasMaxLength(255)
                    .HasColumnName("16");

                entity.Property(e => e._17)
                    .HasMaxLength(255)
                    .HasColumnName("17");

                entity.Property(e => e._18)
                    .HasMaxLength(255)
                    .HasColumnName("18");

                entity.Property(e => e._19)
                    .HasMaxLength(255)
                    .HasColumnName("19");

                entity.Property(e => e._2)
                    .HasMaxLength(255)
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasMaxLength(255)
                    .HasColumnName("20");

                entity.Property(e => e._21)
                    .HasMaxLength(255)
                    .HasColumnName("21");

                entity.Property(e => e._22)
                    .HasMaxLength(255)
                    .HasColumnName("22");

                entity.Property(e => e._23)
                    .HasMaxLength(255)
                    .HasColumnName("23");

                entity.Property(e => e._24)
                    .HasMaxLength(255)
                    .HasColumnName("24");

                entity.Property(e => e._25)
                    .HasMaxLength(255)
                    .HasColumnName("25");

                entity.Property(e => e._26)
                    .HasMaxLength(255)
                    .HasColumnName("26");

                entity.Property(e => e._27)
                    .HasMaxLength(255)
                    .HasColumnName("27");

                entity.Property(e => e._28)
                    .HasMaxLength(255)
                    .HasColumnName("28");

                entity.Property(e => e._29)
                    .HasMaxLength(255)
                    .HasColumnName("29");

                entity.Property(e => e._3)
                    .HasMaxLength(255)
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasMaxLength(255)
                    .HasColumnName("30");

                entity.Property(e => e._31)
                    .HasMaxLength(255)
                    .HasColumnName("31");

                entity.Property(e => e._32)
                    .HasMaxLength(255)
                    .HasColumnName("32");

                entity.Property(e => e._33)
                    .HasMaxLength(255)
                    .HasColumnName("33");

                entity.Property(e => e._34)
                    .HasMaxLength(255)
                    .HasColumnName("34");

                entity.Property(e => e._35)
                    .HasMaxLength(255)
                    .HasColumnName("35");

                entity.Property(e => e._36)
                    .HasMaxLength(255)
                    .HasColumnName("36");

                entity.Property(e => e._37)
                    .HasMaxLength(255)
                    .HasColumnName("37");

                entity.Property(e => e._38)
                    .HasMaxLength(255)
                    .HasColumnName("38");

                entity.Property(e => e._39)
                    .HasMaxLength(255)
                    .HasColumnName("39");

                entity.Property(e => e._4)
                    .HasMaxLength(255)
                    .HasColumnName("4");

                entity.Property(e => e._5)
                    .HasMaxLength(255)
                    .HasColumnName("5");

                entity.Property(e => e._6)
                    .HasMaxLength(255)
                    .HasColumnName("6");

                entity.Property(e => e._7)
                    .HasMaxLength(255)
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasMaxLength(255)
                    .HasColumnName("8");

                entity.Property(e => e._9)
                    .HasMaxLength(255)
                    .HasColumnName("9");
            });

            modelBuilder.Entity<СмесительныеУзлы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Смесительные_узлы");

                entity.Property(e => e.Kvs)
                    .HasMaxLength(255)
                    .HasColumnName("KVS");

                entity.Property(e => e.NКВт)
                    .HasMaxLength(255)
                    .HasColumnName("N, кВт");

                entity.Property(e => e.Доп1).HasMaxLength(255);

                entity.Property(e => e.Доп2).HasMaxLength(255);

                entity.Property(e => e.Доп3).HasMaxLength(255);

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.Типоразмер).HasMaxLength(255);

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.Фазы).HasMaxLength(255);

                entity.Property(e => e.ЦенаВСборе)
                    .HasMaxLength(255)
                    .HasColumnName("Цена, в сборе");

                entity.Property(e => e.ЦенаКомплект)
                    .HasMaxLength(255)
                    .HasColumnName("Цена, комплект");
            });

            modelBuilder.Entity<СмесительныеУзлыТренд>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Смесительные_узлы_Тренд");

                entity.Property(e => e.Kvs)
                    .HasMaxLength(255)
                    .HasColumnName("KVS");

                entity.Property(e => e.NКВт)
                    .HasMaxLength(255)
                    .HasColumnName("N, кВт");

                entity.Property(e => e.Доп1).HasMaxLength(255);

                entity.Property(e => e.Доп2).HasMaxLength(255);

                entity.Property(e => e.Доп3).HasMaxLength(255);

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.Типоразмер).HasMaxLength(255);

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.Фазы).HasMaxLength(255);

                entity.Property(e => e.ЦенаВСборе)
                    .HasMaxLength(255)
                    .HasColumnName("Цена, в сборе");

                entity.Property(e => e.ЦенаКомплект)
                    .HasMaxLength(255)
                    .HasColumnName("Цена, комплект");
            });

            modelBuilder.Entity<Список>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Список");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Список1)
                    .HasMaxLength(255)
                    .HasColumnName("Список");
            });

            modelBuilder.Entity<Список0>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Список_0");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Список).HasMaxLength(255);
            });

            modelBuilder.Entity<СписокK3g>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Список_K3G");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Вентилятор).HasMaxLength(255);

                entity.Property(e => e.КлапанШхВ).HasColumnName("Клапан_ШхВ");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.ПараллДлина).HasColumnName("Паралл_длина");

                entity.Property(e => e.ПараллШхВ).HasColumnName("Паралл_ШхВ");

                entity.Property(e => e.РезервДлина).HasColumnName("Резерв_длина");

                entity.Property(e => e.РезервШхВ).HasColumnName("Резерв_ШхВ");

                entity.Property(e => e.СокрОбозн)
                    .HasMaxLength(255)
                    .HasColumnName("Сокр_обозн");

                entity.Property(e => e.ЦенаЭксперт).HasColumnName("Цена_Эксперт");
            });

            modelBuilder.Entity<СписокШу>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Список_ШУ");

                entity.Property(e => e._).HasColumnName("№");

                entity.Property(e => e.Список).HasMaxLength(255);
            });

            modelBuilder.Entity<СуВсбореЦена>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СУ_всборе_цена");

                entity.Property(e => e.Ав)
                    .HasMaxLength(255)
                    .HasColumnName("АВ");

                entity.Property(e => e.Б).HasMaxLength(255);

                entity.Property(e => e.Бк)
                    .HasMaxLength(255)
                    .HasColumnName("БК");

                entity.Property(e => e.Бр)
                    .HasMaxLength(255)
                    .HasColumnName("БР");

                entity.Property(e => e.Гп)
                    .HasMaxLength(255)
                    .HasColumnName("ГП");

                entity.Property(e => e.Дф)
                    .HasMaxLength(255)
                    .HasColumnName("ДФ");

                entity.Property(e => e.К1).HasMaxLength(255);

                entity.Property(e => e.К2).HasMaxLength(255);

                entity.Property(e => e.К3).HasMaxLength(255);

                entity.Property(e => e.Кс2Х)
                    .HasMaxLength(255)
                    .HasColumnName("КС 2-х");

                entity.Property(e => e.Кс3Х)
                    .HasMaxLength(255)
                    .HasColumnName("КС 3-х");

                entity.Property(e => e.КсАв)
                    .HasMaxLength(255)
                    .HasColumnName("КС_АВ");

                entity.Property(e => e.КсБ)
                    .HasMaxLength(255)
                    .HasColumnName("КС_Б");

                entity.Property(e => e.КсБк)
                    .HasMaxLength(255)
                    .HasColumnName("КС_БК");

                entity.Property(e => e.КсБр)
                    .HasMaxLength(255)
                    .HasColumnName("КС_БР");

                entity.Property(e => e.КсГп)
                    .HasMaxLength(255)
                    .HasColumnName("КС_ГП");

                entity.Property(e => e.КсДф)
                    .HasMaxLength(255)
                    .HasColumnName("КС_ДФ");

                entity.Property(e => e.КсРн)
                    .HasMaxLength(255)
                    .HasColumnName("КС_РН");

                entity.Property(e => e.КсРп)
                    .HasMaxLength(255)
                    .HasColumnName("КС_РП");

                entity.Property(e => e.КсСк)
                    .HasMaxLength(255)
                    .HasColumnName("КС_СК");

                entity.Property(e => e.КсТм)
                    .HasMaxLength(255)
                    .HasColumnName("КС_ТМ");

                entity.Property(e => e.КурсУе)
                    .HasMaxLength(255)
                    .HasColumnName("Курс УЕ");

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.РегулЧасть2Х)
                    .HasMaxLength(255)
                    .HasColumnName("Регул_часть 2-х");

                entity.Property(e => e.РегулЧасть3Х)
                    .HasMaxLength(255)
                    .HasColumnName("Регул_часть 3-х");

                entity.Property(e => e.Рн)
                    .HasMaxLength(255)
                    .HasColumnName("РН");

                entity.Property(e => e.Рп)
                    .HasMaxLength(255)
                    .HasColumnName("РП");

                entity.Property(e => e.Ск)
                    .HasMaxLength(255)
                    .HasColumnName("СК");

                entity.Property(e => e.Стандарт2Х)
                    .HasMaxLength(255)
                    .HasColumnName("Стандарт 2-х");

                entity.Property(e => e.Стандарт2Х1)
                    .HasMaxLength(255)
                    .HasColumnName("Стандарт+ 2-х");

                entity.Property(e => e.Стандарт3Х)
                    .HasMaxLength(255)
                    .HasColumnName("Стандарт 3-х");

                entity.Property(e => e.Стандарт3Х1)
                    .HasMaxLength(255)
                    .HasColumnName("Стандарт+ 3-х");

                entity.Property(e => e.Тм)
                    .HasMaxLength(255)
                    .HasColumnName("ТМ");

                entity.Property(e => e.ЦенаСк)
                    .HasMaxLength(255)
                    .HasColumnName("Цена СК");
            });

            modelBuilder.Entity<СуГабариты>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СУ_габариты");

                entity.Property(e => e.А1С)
                    .HasMaxLength(255)
                    .HasColumnName("А1_С");

                entity.Property(e => e.А1С1)
                    .HasMaxLength(255)
                    .HasColumnName("А1_С+");

                entity.Property(e => e.А2С)
                    .HasMaxLength(255)
                    .HasColumnName("А2_С+");

                entity.Property(e => e.А3С)
                    .HasMaxLength(255)
                    .HasColumnName("А3_С+");

                entity.Property(e => e.АС)
                    .HasMaxLength(255)
                    .HasColumnName("А_С");

                entity.Property(e => e.АС1)
                    .HasMaxLength(255)
                    .HasColumnName("А_С+");

                entity.Property(e => e.Б1С)
                    .HasMaxLength(255)
                    .HasColumnName("Б1_С");

                entity.Property(e => e.Б1С1)
                    .HasMaxLength(255)
                    .HasColumnName("Б1_С+");

                entity.Property(e => e.БС)
                    .HasMaxLength(255)
                    .HasColumnName("Б_С");

                entity.Property(e => e.БС1)
                    .HasMaxLength(255)
                    .HasColumnName("Б_С+");

                entity.Property(e => e.В1С)
                    .HasMaxLength(255)
                    .HasColumnName("В1_С");

                entity.Property(e => e.В1С1)
                    .HasMaxLength(255)
                    .HasColumnName("В1_С+");

                entity.Property(e => e.В2С)
                    .HasMaxLength(255)
                    .HasColumnName("В2_С");

                entity.Property(e => e.В2С1)
                    .HasMaxLength(255)
                    .HasColumnName("В2_С+");

                entity.Property(e => e.В3С)
                    .HasMaxLength(255)
                    .HasColumnName("В3_С");

                entity.Property(e => e.В3С1)
                    .HasMaxLength(255)
                    .HasColumnName("В3_С+");

                entity.Property(e => e.ВС)
                    .HasMaxLength(255)
                    .HasColumnName("В_С");

                entity.Property(e => e.ВС1)
                    .HasMaxLength(255)
                    .HasColumnName("В_С+");

                entity.Property(e => e.МассаС)
                    .HasMaxLength(255)
                    .HasColumnName("Масса_С");

                entity.Property(e => e.МассаС1)
                    .HasMaxLength(255)
                    .HasColumnName("Масса_С+");

                entity.Property(e => e.Название).HasMaxLength(255);

                entity.Property(e => e.ПрисоедРазм)
                    .HasMaxLength(255)
                    .HasColumnName("Присоед_разм");
            });

            modelBuilder.Entity<СуКомплектующие>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СУ_комплектующие");

                entity.Property(e => e.A)
                    .HasMaxLength(255)
                    .HasColumnName("a");

                entity.Property(e => e.B)
                    .HasMaxLength(255)
                    .HasColumnName("b");

                entity.Property(e => e.Kvs).HasMaxLength(255);

                entity.Property(e => e.ВМаркировкуСу)
                    .HasMaxLength(255)
                    .HasColumnName("В маркировку СУ");

                entity.Property(e => e.Комплектующие).HasMaxLength(255);

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.ЦенаКомп)
                    .HasMaxLength(255)
                    .HasColumnName("Цена комп");

                entity.Property(e => e.ЦенаНасоса)
                    .HasMaxLength(255)
                    .HasColumnName("Цена насоса");

                entity.Property(e => e.ЦенаТрехход)
                    .HasMaxLength(255)
                    .HasColumnName("Цена трехход");
            });

            modelBuilder.Entity<СуКомплектующиеТренд>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("СУ_комплектующие_Тренд");

                entity.Property(e => e.A)
                    .HasMaxLength(255)
                    .HasColumnName("a");

                entity.Property(e => e.B)
                    .HasMaxLength(255)
                    .HasColumnName("b");

                entity.Property(e => e.Kvs).HasMaxLength(255);

                entity.Property(e => e.ВМаркировкуСу)
                    .HasMaxLength(255)
                    .HasColumnName("В маркировку СУ");

                entity.Property(e => e.Комплектующие).HasMaxLength(255);

                entity.Property(e => e.Насос).HasMaxLength(255);

                entity.Property(e => e.Трехходовые).HasMaxLength(255);

                entity.Property(e => e.ЦенаКомп)
                    .HasMaxLength(255)
                    .HasColumnName("Цена комп");

                entity.Property(e => e.ЦенаНасоса)
                    .HasMaxLength(255)
                    .HasColumnName("Цена насоса");

                entity.Property(e => e.ЦенаТрехход)
                    .HasMaxLength(255)
                    .HasColumnName("Цена трехход");
            });           

            modelBuilder.Entity<ТэныЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Тэны_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e.КолВоМодулей).HasColumnName("Кол-во модулей");

                entity.Property(e => e.МощностьКВт).HasColumnName("Мощность, кВт");

                entity.Property(e => e.ШиринаКлемм).HasColumnName("Ширина клемм");
            });

            modelBuilder.Entity<Увлажнители>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Увлажнители");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1Ступень).HasColumnName("1 ступень");

                entity.Property(e => e._2Ступени).HasColumnName("2 ступени");

                entity.Property(e => e.Насос1фДо16КВт).HasColumnName("Насос 1ф до 1,6 кВт");

                entity.Property(e => e.Насос1фДо22КВт).HasColumnName("Насос 1ф до 2,2 кВт");

                entity.Property(e => e.Насос3фДо11КВт).HasColumnName("Насос 3ф до 11 кВт");

                entity.Property(e => e.Насос3фДо15КВт).HasColumnName("Насос 3ф до 15 кВт");

                entity.Property(e => e.Насос3фДо55КВт).HasColumnName("Насос 3ф до 5,5 кВт");

                entity.Property(e => e.Насос3фДо75КВт).HasColumnName("Насос 3ф до 7,5 кВт");
            });

            modelBuilder.Entity<УвлажнителиЭконом>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Увлажнители_Эконом");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1Ступень).HasColumnName("1 ступень");

                entity.Property(e => e._2Ступени).HasColumnName("2 ступени");

                entity.Property(e => e.Насос1фДо16КВт).HasColumnName("Насос 1ф до 1,6 кВт");

                entity.Property(e => e.Насос1фДо22КВт).HasColumnName("Насос 1ф до 2,2 кВт");

                entity.Property(e => e.Насос3фДо11КВт).HasColumnName("Насос 3ф до 11 кВт");

                entity.Property(e => e.Насос3фДо15КВт).HasColumnName("Насос 3ф до 15 кВт");

                entity.Property(e => e.Насос3фДо55КВт).HasColumnName("Насос 3ф до 5,5 кВт");

                entity.Property(e => e.Насос3фДо75КВт).HasColumnName("Насос 3ф до 7,5 кВт");
            });

            modelBuilder.Entity<Уе>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("УЕ");

                entity.Property(e => e.КурсУе)
                    .HasMaxLength(255)
                    .HasColumnName("Курс УЕ");
            });

            modelBuilder.Entity<УлиткаВыхлоп>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Улитка_выхлоп");

                entity.Property(e => e.Высота).HasMaxLength(255);

                entity.Property(e => e.ТипУлитки)
                    .HasMaxLength(255)
                    .HasColumnName("Тип улитки");

                entity.Property(e => e.Ширина).HasMaxLength(255);
            });

            modelBuilder.Entity<Фильтры>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Фильтры");

                entity.Property(e => e.КолВо1)
                    .HasMaxLength(255)
                    .HasColumnName("Кол-во_1");

                entity.Property(e => e.КолВо2)
                    .HasMaxLength(255)
                    .HasColumnName("Кол-во_2");

                entity.Property(e => e.КолВо3)
                    .HasMaxLength(255)
                    .HasColumnName("Кол-во_3");

                entity.Property(e => e.КолВо4)
                    .HasMaxLength(255)
                    .HasColumnName("Кол-во_4");

                entity.Property(e => e.Типоряд).HasMaxLength(255);

                entity.Property(e => e.Фильтр1)
                    .HasMaxLength(255)
                    .HasColumnName("Фильтр_1");

                entity.Property(e => e.Фильтр2)
                    .HasMaxLength(255)
                    .HasColumnName("Фильтр_2");

                entity.Property(e => e.Фильтр3)
                    .HasMaxLength(255)
                    .HasColumnName("Фильтр_3");

                entity.Property(e => e.Фильтр4)
                    .HasMaxLength(255)
                    .HasColumnName("Фильтр_4");
            });

            modelBuilder.Entity<ФреонХолод>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Фреон_холод");

                entity.Property(e => e.LВозд).HasColumnName("L возд");

                entity.Property(e => e.NКвт).HasColumnName("N Квт");

                entity.Property(e => e.АШиринаЖс).HasColumnName("А  ширина ЖС");

                entity.Property(e => e.ВВысотаЖс).HasColumnName("В высота ЖС");

                entity.Property(e => e.ВысотаГабарит).HasColumnName("Высота габарит");

                entity.Property(e => e.ДПрисоединения)
                    .HasMaxLength(255)
                    .HasColumnName("Д присоединения");

                entity.Property(e => e.Код1с)
                    .HasMaxLength(255)
                    .HasColumnName("Код 1С");

                entity.Property(e => e.КолВоКонтуров).HasColumnName("Кол-во контуров");

                entity.Property(e => e.Типоряд).HasMaxLength(255);

                entity.Property(e => e.ШиринаГабарит).HasColumnName("Ширина габарит");
            });

            modelBuilder.Entity<ЧпУпп>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ЧП_УПП");

                entity.Property(e => e._037КВт)
                    .HasMaxLength(255)
                    .HasColumnName("0,37 кВт");

                entity.Property(e => e._055КВт)
                    .HasMaxLength(255)
                    .HasColumnName("0,55 кВт");

                entity.Property(e => e._075КВт)
                    .HasMaxLength(255)
                    .HasColumnName("0,75 кВт");

                entity.Property(e => e._11КВт)
                    .HasMaxLength(255)
                    .HasColumnName("1,1 кВт");

                entity.Property(e => e._11КВт1)
                    .HasMaxLength(255)
                    .HasColumnName("11 кВт");

                entity.Property(e => e._15КВт)
                    .HasMaxLength(255)
                    .HasColumnName("1,5 кВт");

                entity.Property(e => e._15КВт1)
                    .HasMaxLength(255)
                    .HasColumnName("15 кВт");

                entity.Property(e => e._185КВт)
                    .HasMaxLength(255)
                    .HasColumnName("18,5 кВт");

                entity.Property(e => e._22КВт)
                    .HasMaxLength(255)
                    .HasColumnName("2,2 кВт");

                entity.Property(e => e._22КВт1)
                    .HasMaxLength(255)
                    .HasColumnName("22 кВт");

                entity.Property(e => e._30КВт)
                    .HasMaxLength(255)
                    .HasColumnName("30 кВт");

                entity.Property(e => e._37КВт)
                    .HasMaxLength(255)
                    .HasColumnName("37 кВт");

                entity.Property(e => e._3КВт)
                    .HasMaxLength(255)
                    .HasColumnName("3 кВт");

                entity.Property(e => e._45КВт)
                    .HasMaxLength(255)
                    .HasColumnName("45 кВт");

                entity.Property(e => e._4КВт)
                    .HasMaxLength(255)
                    .HasColumnName("4 кВт");

                entity.Property(e => e._55КВт)
                    .HasMaxLength(255)
                    .HasColumnName("5,5 кВт");

                entity.Property(e => e._55КВт1)
                    .HasMaxLength(255)
                    .HasColumnName("55 кВт");

                entity.Property(e => e._75КВт)
                    .HasMaxLength(255)
                    .HasColumnName("7,5 кВт");

                entity.Property(e => e._75КВт1)
                    .HasMaxLength(255)
                    .HasColumnName("75 кВт");

                entity.Property(e => e._90КВт)
                    .HasMaxLength(255)
                    .HasColumnName("90 кВт");

                entity.Property(e => e.Корпус).HasMaxLength(255);

                entity.Property(e => e.Фазы).HasMaxLength(255);
            });

            modelBuilder.Entity<Элементы>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Элементы");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._100).HasColumnName("100");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._40).HasColumnName("40");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._50).HasColumnName("50");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._60).HasColumnName("60");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._80).HasColumnName("80");
            });

            modelBuilder.Entity<ЭлементыЭксперт>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Элементы_Эксперт");

                entity.Property(e => e._).HasMaxLength(255);

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._10).HasColumnName("10");

                entity.Property(e => e._100).HasColumnName("100");

                entity.Property(e => e._12).HasColumnName("12");

                entity.Property(e => e._16).HasColumnName("16");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._20).HasColumnName("20");

                entity.Property(e => e._25).HasColumnName("25");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._30).HasColumnName("30");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._40).HasColumnName("40");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._50).HasColumnName("50");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._60).HasColumnName("60");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");

                entity.Property(e => e._80).HasColumnName("80");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}