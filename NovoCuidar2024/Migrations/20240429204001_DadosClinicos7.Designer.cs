﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NovoCuidar2024.Data;

#nullable disable

namespace NovoCuidar2024.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240429204001_DadosClinicos7")]
    partial class DadosClinicos7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CC")
                        .HasColumnType("int");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Concelho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("NomeApelido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomePrincipal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SNS")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.ContactoPrioritario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Andar")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Fracao")
                        .HasColumnType("int");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumPorta")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Parentesco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataInicio")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumeroContrato")
                        .HasColumnType("int");

                    b.Property<string>("TipoContrato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contrato");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.DadosClinicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alergias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CentroSaude")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GrupoSanguinio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InformacoessComplementares")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MedicoAssistente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumUtenteSaúde")
                        .HasColumnType("int");

                    b.Property<string>("Patologias")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RestricoesAlimentare")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ResumoClinico")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DadosClinicos");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.FamiliaUtentes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FamiliaUtentes");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.LinhaOrcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LinhaOrcamento");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.MoradaUtente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Andar")
                        .HasColumnType("int");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Concelho")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fracao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumPorta")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MoradaUtente");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Orcamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataOrcamento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orcamento");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("OrigemContacto")
                        .HasColumnType("longtext");

                    b.Property<string>("Preco")
                        .HasColumnType("longtext");

                    b.Property<string>("ServicoContratado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.SubSistema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SubSistema");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Tecnico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tecnico");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactoEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactoTelemovel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DataInscricao")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("DocIdentificacaoNum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocIdentificacaoTipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateOnly>("DocIdentificacaoValidade")
                        .HasColumnType("date");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Habilitacoes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HabitacaoPartilhada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HabitacaoTipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdInterno")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Nif")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrigemContrato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ResponsavelTecnicoId")
                        .HasColumnType("int");

                    b.Property<string>("SegurancaSocialNum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vivencia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Utente");
                });

            modelBuilder.Entity("NovoCuidar2024.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observações")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Visita");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
