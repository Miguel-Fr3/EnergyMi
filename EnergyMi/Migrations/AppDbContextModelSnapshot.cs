﻿// <auto-generated />
using System;
using EnergyMi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EnergyMi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnergyMi.Models.Alerta", b =>
                {
                    b.Property<int>("CdAlerta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdAlerta"));

                    b.Property<int?>("AparelhoCdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("CdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DsObservacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<DateTime>("DtAlerta")
                        .HasColumnType("DATE");

                    b.Property<string>("StNivelPrioridade")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("NVARCHAR2(5)");

                    b.HasKey("CdAlerta");

                    b.HasIndex("AparelhoCdAparelho");

                    b.ToTable("tb_alerta");
                });

            modelBuilder.Entity("EnergyMi.Models.Aparelho", b =>
                {
                    b.Property<int>("CdAparelho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdAparelho"));

                    b.Property<int?>("CdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DsNomeAparelho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("DsTipoAparelho")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<short>("NrWatts")
                        .HasColumnType("NUMBER(5)");

                    b.Property<int?>("UsuarioCdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CdAparelho");

                    b.HasIndex("UsuarioCdUsuario");

                    b.ToTable("tb_aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.Consumo", b =>
                {
                    b.Property<int>("CdConsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdConsumo"));

                    b.Property<int?>("AparelhoCdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("CdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DsObservacoes")
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<DateTime>("DtConsumo")
                        .HasColumnType("DATE");

                    b.Property<short>("NrConsumoEnergia")
                        .HasColumnType("NUMBER(5)");

                    b.Property<short>("NrCusto")
                        .HasColumnType("NUMBER(5)");

                    b.HasKey("CdConsumo");

                    b.HasIndex("AparelhoCdAparelho");

                    b.ToTable("tb_consumo");
                });

            modelBuilder.Entity("EnergyMi.Models.LogConsumo", b =>
                {
                    b.Property<int>("CdLogConsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdLogConsumo"));

                    b.Property<int?>("AparelhoCdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("CdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("DATE");

                    b.Property<short>("NrConsumoPrevisto")
                        .HasColumnType("NUMBER(5)");

                    b.HasKey("CdLogConsumo");

                    b.HasIndex("AparelhoCdAparelho");

                    b.ToTable("tb_log_consumo");
                });

            modelBuilder.Entity("EnergyMi.Models.PrevisaoConsumo", b =>
                {
                    b.Property<int>("CdPrevisao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdPrevisao"));

                    b.Property<int?>("AparelhoCdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("CdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DsMetodoPrevisao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<DateTime>("DtPrevisao")
                        .HasColumnType("DATE");

                    b.Property<short>("NrConsumoPrevisto")
                        .HasColumnType("NUMBER(5)");

                    b.HasKey("CdPrevisao");

                    b.HasIndex("AparelhoCdAparelho");

                    b.ToTable("tb_previsao_consumo");
                });

            modelBuilder.Entity("EnergyMi.Models.Recomendacao", b =>
                {
                    b.Property<int>("CdRecomendacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdRecomendacao"));

                    b.Property<int?>("AparelhoCdAparelho")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("CdAparelho")
                        .IsRequired()
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("DsObservacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<DateTime>("DtRecomendacao")
                        .HasColumnType("DATE");

                    b.Property<string>("StRecomendacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("CdRecomendacao");

                    b.HasIndex("AparelhoCdAparelho");

                    b.ToTable("tb_recomendacao");
                });

            modelBuilder.Entity("EnergyMi.Models.Usuario", b =>
                {
                    b.Property<int>("CdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdUsuario"));

                    b.Property<string>("DsAmbiente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("DsEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("DsEndereco")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR2(250)");

                    b.Property<string>("DsNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("DsSenha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("CdUsuario");

                    b.ToTable("tb_usuario");

                    b.HasData(
                        new
                        {
                            CdUsuario = 1,
                            DsAmbiente = "Ambiente padrão",
                            DsEmail = "userdefault@gmail.com",
                            DsEndereco = "Endereco padrão",
                            DsNome = "Usuario padrão",
                            DsSenha = "senha123"
                        });
                });

            modelBuilder.Entity("EnergyMi.Models.Alerta", b =>
                {
                    b.HasOne("EnergyMi.Models.Aparelho", "Aparelho")
                        .WithMany()
                        .HasForeignKey("AparelhoCdAparelho");

                    b.Navigation("Aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.Aparelho", b =>
                {
                    b.HasOne("EnergyMi.Models.Usuario", "Usuario")
                        .WithMany("Aparelho")
                        .HasForeignKey("UsuarioCdUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EnergyMi.Models.Consumo", b =>
                {
                    b.HasOne("EnergyMi.Models.Aparelho", "Aparelho")
                        .WithMany()
                        .HasForeignKey("AparelhoCdAparelho");

                    b.Navigation("Aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.LogConsumo", b =>
                {
                    b.HasOne("EnergyMi.Models.Aparelho", "Aparelho")
                        .WithMany()
                        .HasForeignKey("AparelhoCdAparelho");

                    b.Navigation("Aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.PrevisaoConsumo", b =>
                {
                    b.HasOne("EnergyMi.Models.Aparelho", "Aparelho")
                        .WithMany()
                        .HasForeignKey("AparelhoCdAparelho");

                    b.Navigation("Aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.Recomendacao", b =>
                {
                    b.HasOne("EnergyMi.Models.Aparelho", "Aparelho")
                        .WithMany()
                        .HasForeignKey("AparelhoCdAparelho");

                    b.Navigation("Aparelho");
                });

            modelBuilder.Entity("EnergyMi.Models.Usuario", b =>
                {
                    b.Navigation("Aparelho");
                });
#pragma warning restore 612, 618
        }
    }
}
