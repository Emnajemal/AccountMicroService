using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace AccountMicroService.Model
{
    public partial class AccountDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AccountDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Accmovement> Accmovements { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accountbalance> Accountbalances { get; set; }
        public virtual DbSet<Accountcontract> Accountcontracts { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<Financialo> Financialos { get; set; }
        public virtual DbSet<Productservice> Productservices { get; set; }
        public virtual DbSet<Receivedbill> Receivedbills { get; set; }
        public virtual DbSet<Receivedcheck> Receivedchecks { get; set; }
        public virtual DbSet<Recvplv> Recvplvs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("Default");

                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Accmovement>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_ACCMOVEMENT");

                entity.ToTable("ACCMOVEMENT");

                entity.HasIndex(e => e.Currencypk, "ACCMOVEMENT_CURRENCY");

                entity.HasIndex(e => new { e.Accountpk, e.Sign, e.Typemvt, e.Tradedate }, "ACCMOVEMENT_IDX_99340002");

                entity.HasIndex(e => e.Reversedpk, "ACCM_IDX_REVERSEDPK");

                entity.HasIndex(e => new { e.Accountpk, e.Typemvt, e.Receivedvaluedate }, "IDX_ACCMOVEMENT_TUN_001");

                entity.HasIndex(e => new { e.Typemvt, e.Operationtypecode, e.Operationtypepk, e.Operationdetailbp, e.Tradedate, e.Accountpk }, "IDX_ACCMVT_10_03_2020");

                entity.HasIndex(e => new { e.Accountpk, e.Typemvt, e.Isprinted }, "IDX_ACCMVT_20190715");

                entity.HasIndex(e => e.Operationtypecode, "IDX_ACCMVT_OPERATIONTYPE");

                entity.HasIndex(e => new { e.Tradedate, e.Receivedvaluedate }, "INDX_ACCMOVEMENT_002");

                entity.HasIndex(e => new { e.Tradedate, e.Delay, e.Sign, e.Operationtypepk }, "INDX_ACCMOVEMENT_003");

                entity.HasIndex(e => new { e.Accountpk, e.Tradedate, e.Typemvt }, "INDX_SETTLEMENT_001");

                entity.HasIndex(e => e.Valuedate, "INDX_VALUEDATE");

                entity.HasIndex(e => e.Finoperationpk, "IX_ACCMOVEMEN24813");

                entity.HasIndex(e => e.Accountcode, "IX_ACCMOVEMENT_ACCOUNTCODE");

                entity.HasIndex(e => new { e.Accountnumber, e.Tradedate }, "I_NUMCOMPTE_TRADEDATE");

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCODE_");

                entity.Property(e => e.Accountnature)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNATURE_");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER_");

                entity.Property(e => e.Accountpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTPK_");

                entity.Property(e => e.Affranchissement)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("AFFRANCHISSEMENT_");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("AMOUNT_");

                entity.Property(e => e.Amountacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("AMOUNTACCCUR_");

                entity.Property(e => e.Basisvaluedate)
                    .HasColumnType("DATE")
                    .HasColumnName("BASISVALUEDATE_");

                entity.Property(e => e.Bpnature)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("BPNATURE_");

                entity.Property(e => e.Branchenumber)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BRANCHENUMBER_");

                entity.Property(e => e.Businessdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BUSINESSDATE_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Chequenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CHEQUENUMBER_");

                entity.Property(e => e.Clientreference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTREFERENCE_");

                entity.Property(e => e.Commission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("COMMISSION_");

                entity.Property(e => e.Countrybp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYBP_");

                entity.Property(e => e.Creditmnt)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("CREDITMNT_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencynature)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYNATURE_");


                base.OnModelCreating(modelBuilder);
                entity.Property(e => e.Currencypk)
                                 .HasPrecision(19)
                                 .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Datedeclaration)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEDECLARATION_");

                entity.Property(e => e.Debitmnt)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEBITMNT_");

                entity.Property(e => e.Delay)
                    .HasPrecision(19)
                    .HasColumnName("DELAY_");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Emetteur)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMETTEUR_");

                entity.Property(e => e.Feetypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FEETYPECODE_");

                entity.Property(e => e.Feetypepk)
                    .HasPrecision(19)
                    .HasColumnName("FEETYPEPK_");

                entity.Property(e => e.Finoperationcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FINOPERATIONCODE_");

                entity.Property(e => e.Finoperationpk)
                    .HasPrecision(19)
                    .HasColumnName("FINOPERATIONPK_");

                entity.Property(e => e.Fiscalretention)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FISCALRETENTION_");

                entity.Property(e => e.Fracccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FRACCCUR_");

                entity.Property(e => e.Frmaincur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FRMAINCUR_");

                entity.Property(e => e.Fxrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXRATE_");

                entity.Property(e => e.Grossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNT_");

                entity.Property(e => e.Grossamountacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNTACCCUR_");

                entity.Property(e => e.Grossamountmaincur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNTMAINCUR_");

                entity.Property(e => e.Includedinmvtcomm)
                    .HasPrecision(1)
                    .HasColumnName("INCLUDEDINMVTCOMM_");

                entity.Property(e => e.Intermediaryauthorized)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("INTERMEDIARYAUTHORIZED_");

                entity.Property(e => e.Internalvaldatedelay)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INTERNALVALDATEDELAY_");

                entity.Property(e => e.Isagios)
                    .HasPrecision(1)
                    .HasColumnName("ISAGIOS_");

                entity.Property(e => e.Iscommission)
                    .HasPrecision(1)
                    .HasColumnName("ISCOMMISSION_");

                entity.Property(e => e.Isprinted)
                    .HasPrecision(1)
                    .HasColumnName("ISPRINTED_");

                entity.Property(e => e.Isreversed)
                    .HasPrecision(1)
                    .HasColumnName("ISREVERSED_");

                entity.Property(e => e.Isreversing)
                    .HasPrecision(1)
                    .HasColumnName("ISREVERSING_");

                entity.Property(e => e.Loanreference)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOANREFERENCE_");

                entity.Property(e => e.Locked)
                    .HasPrecision(1)
                    .HasColumnName("LOCKED_");

                entity.Property(e => e.Lockreference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOCKREFERENCE_");

                entity.Property(e => e.Montantdeclaration)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("MONTANTDECLARATION_");

                entity.Property(e => e.Nametowards)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NAMETOWARDS_");

                entity.Property(e => e.Nationaliteemetteur)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITEEMETTEUR_");

                entity.Property(e => e.Naturedocument)
                    .HasPrecision(10)
                    .HasColumnName("NATUREDOCUMENT_");

                entity.Property(e => e.Newoperationcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("NEWOPERATIONCODE_");

                entity.Property(e => e.Numdeclaration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMDECLARATION_");

                entity.Property(e => e.Numpasseport)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMPASSEPORT_");

                entity.Property(e => e.Opecodeident)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OPECODEIDENT_");

                entity.Property(e => e.Opedateident)
                    .HasColumnType("DATE")
                    .HasColumnName("OPEDATEIDENT_");

                entity.Property(e => e.Openumident)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OPENUMIDENT_");

                entity.Property(e => e.Operationdetailbp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONDETAILBP_");

                entity.Property(e => e.Operationmotif)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONMOTIF_");

                entity.Property(e => e.Operationnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONNUMBER_");

                entity.Property(e => e.Operationtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONTYPECODE_");

                entity.Property(e => e.Operationtypepk)
                    .HasPrecision(19)
                    .HasColumnName("OPERATIONTYPEPK_");

                entity.Property(e => e.Operef)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OPEREF_");

                entity.Property(e => e.Orderinsert)
                    .HasPrecision(19)
                    .HasColumnName("ORDERINSERT_");

                entity.Property(e => e.Receivedvaluedate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVEDVALUEDATE_");

                entity.Property(e => e.Reliquat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELIQUAT_");

                entity.Property(e => e.Reservedamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("RESERVEDAMOUNT_");

                entity.Property(e => e.Reversedpk)
                    .HasPrecision(19)
                    .HasColumnName("REVERSEDPK_");

                entity.Property(e => e.Ribtowards)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RIBTOWARDS_");

                entity.Property(e => e.Sbereference)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("SBEREFERENCE_");

                entity.Property(e => e.Senddealroom)
                    .HasPrecision(1)
                    .HasColumnName("SENDDEALROOM_");

                entity.Property(e => e.Sign)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_");

                entity.Property(e => e.Totalstamp)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALSTAMP_");

                entity.Property(e => e.Totaltaf)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALTAF_");

                entity.Property(e => e.Tradedate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADEDATE_");

                entity.Property(e => e.Treasurydate)
                    .HasColumnType("DATE")
                    .HasColumnName("TREASURYDATE_");

                entity.Property(e => e.Typemvt)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("TYPEMVT_");

                entity.Property(e => e.Typevaluedate)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TYPEVALUEDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Valuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALUEDATE_");

                entity.Property(e => e.Vat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("VAT_");

                entity.Property(e => e.Vatacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("VATACCCUR_");

                entity.Property(e => e.Vatmaincur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("VATMAINCUR_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.HasOne(d => d.ReversedpkNavigation)
                    .WithMany(p => p.InverseReversedpkNavigation)
                    .HasForeignKey(d => d.Reversedpk)
                    .HasConstraintName("F_MENTREVEVWT12Q");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_ACCOUNT");

                entity.ToTable("ACCOUNT");

                entity.HasIndex(e => new { e.Productcode, e.Pk }, "IDX_PRODUCTCODE");

                entity.HasIndex(e => e.Accountnumber, "IX_ACCOUNTNUMBER");

                entity.HasIndex(e => e.Unitcode, "IX_ACCOUNTUNIT9835");

                entity.HasIndex(e => e.Unitpk, "IX_ACCOUNTUNITPK2");

                entity.HasIndex(e => e.Code, "U_ACCOUNTCODE_")
                    .IsUnique();

                entity.HasIndex(e => e.Rib, "U_ACCOUNTRIB_")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER_");

                entity.Property(e => e.Activationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACTIVATIONDATE_");

                entity.Property(e => e.Active)
                    .HasPrecision(1)
                    .HasColumnName("ACTIVE_");

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKCODE_");

                entity.Property(e => e.Bankpk)
                    .HasPrecision(19)
                    .HasColumnName("BANKPK_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODE_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME_");

                entity.Property(e => e.Iban)
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasColumnName("IBAN_");

                entity.Property(e => e.Isinternalrib)
                    .HasPrecision(1)
                    .HasColumnName("ISINTERNALRIB_");

                entity.Property(e => e.Ownership)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OWNERSHIP_");

                entity.Property(e => e.Productcategorycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTCATEGORYCODE_");

                entity.Property(e => e.Productcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTCODE_");

                entity.Property(e => e.Rib)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RIB_");

                entity.Property(e => e.Signaturetype)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("SIGNATURETYPE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Unitpk)
                    .HasPrecision(19)
                    .HasColumnName("UNITPK_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.HasMany(d => d.Ownerpks)
                    .WithMany(p => p.Internalaccountspks)
                    .UsingEntity<Dictionary<string, object>>(
                        "Nternalaccount",
                        l => l.HasOne<Entity>().WithMany().HasForeignKey("Ownerpk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("F_UNTSOWNEVULHFM"),
                        r => r.HasOne<Account>().WithMany().HasForeignKey("Internalaccountspk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("F_UNTSINTE_HEN1SM"),
                        j =>
                        {
                            j.HasKey("Internalaccountspk", "Ownerpk").HasName("P_NTERNALACCOUNTS");

                            j.ToTable("NTERNALACCOUNTS");

                            j.HasIndex(new[] { "Internalaccountspk" }, "BAFIINDEX12347");

                            j.HasIndex(new[] { "Ownerpk" }, "BAFIV2_INDEX9ZZ78SSHHSSZZ99");

                            j.IndexerProperty<long>("Internalaccountspk").HasPrecision(19).HasColumnName("INTERNALACCOUNTSPK");

                            j.IndexerProperty<long>("Ownerpk").HasPrecision(19).HasColumnName("OWNERPK");
                        });
            });

            modelBuilder.Entity<Accountbalance>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_ACCOUNTBALANCE");

                entity.ToTable("ACCOUNTBALANCE");

                entity.HasIndex(e => e.Cdate, "ACCBALANCE_CDATE");

                entity.HasIndex(e => new { e.Accountcode, e.Balancetype, e.Enddate }, "ACCBAL_IDX_9C7F0001");

                entity.HasIndex(e => e.Positiondate, "ACCBAL_PDATE");

                entity.HasIndex(e => new { e.Accountcode, e.Positiondate }, "ACCOUNTBALANCE_IDX_99340001");

                entity.HasIndex(e => new { e.Currencycode, e.Balancetype, e.Enddate }, "IDX$$_CB840001");

                entity.HasIndex(e => e.Accountpk, "IDX_ACCBALANCE_ACCOUNTPK");

                entity.HasIndex(e => e.Currencypk, "IDX_ACCBALANCE_CURRENCYPK");

                entity.HasIndex(e => new { e.Accountpk, e.Positiondate }, "INDEX_BALANCE_STBNET");

                entity.HasIndex(e => e.Udate, "INDEX_BALANCE_UDATE");

                entity.HasIndex(e => new { e.Accountcode, e.Enddate, e.Positiondate, e.Balancetype }, "INDX_BALANCE_001");

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCODE_");

                entity.Property(e => e.Accountpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTPK_");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("BALANCE_");

                entity.Property(e => e.Balancetype)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BALANCETYPE_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Creditmvt)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("CREDITMVT_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Debitmvt)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEBITMVT_");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE_");

                entity.Property(e => e.Lockamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("LOCKAMOUNT_");

                entity.Property(e => e.Overdraftamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("OVERDRAFTAMOUNT_");

                entity.Property(e => e.Positiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("POSITIONDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.HasOne(d => d.AccountpkNavigation)
                    .WithMany(p => p.Accountbalances)
                    .HasForeignKey(d => d.Accountpk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("F_ANCEACCOSZH6G6");
            });

            modelBuilder.Entity<Accountcontract>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_ACCOUNTCONTRACT");

                entity.ToTable("ACCOUNTCONTRACT");

                entity.HasIndex(e => new { e.Status, e.Pk }, "ACCOUNTCONTRACT_STATUS");

                entity.HasIndex(e => new { e.Status, e.Accountcode }, "IDX_ACC_20200329");

                entity.HasIndex(e => e.Accountcode, "I_ACCOUNTCODE");

                entity.HasIndex(e => e.Categorie, "I_CATEGORIE");

                entity.HasIndex(e => e.Generatereleve, "I_GENRELEVE");

                entity.HasIndex(e => e.Generatesettlreport, "I_GENSETTREPORT");

                entity.HasIndex(e => e.Numcpt7, "I_NUMCPT7");

                entity.HasIndex(e => e.Accountnumber, "U_ACCOUNTCON26HOBS")
                    .IsUnique();

                entity.HasIndex(e => e.Inactivityperiodpk, "U_ACCOUNTCO_23L58W")
                    .IsUnique();

                entity.HasIndex(e => e.Accountpk, "U_ACCOUNTCO_3XFOQY")
                    .IsUnique();

                entity.HasIndex(e => e.Validationprocesspk, "U_ACCOUNTCO_XGAGB7")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCODE_");

                entity.Property(e => e.Accountmig)
                    .HasPrecision(1)
                    .HasColumnName("ACCOUNTMIG_");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER_");

                entity.Property(e => e.Accountpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTPK_");

                entity.Property(e => e.Addinfo1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO1_");

                entity.Property(e => e.Addinfo2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO2_");

                entity.Property(e => e.Addinfo3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO3_");

                entity.Property(e => e.Addinfo4)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO4_");

                entity.Property(e => e.Addinfo5)
                    .HasColumnType("DATE")
                    .HasColumnName("ADDINFO5_");

                entity.Property(e => e.Addinfo6)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO6_");

                entity.Property(e => e.Addinfo7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDINFO7_");

                entity.Property(e => e.Categorie)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORIE_");

                entity.Property(e => e.Clientpouvoirpk)
                    .HasPrecision(19)
                    .HasColumnName("CLIENTPOUVOIRPK_");

                entity.Property(e => e.Closingdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLOSINGDATE_");

                entity.Property(e => e.Codebp)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("CODEBP_");

                entity.Property(e => e.Comissionaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMISSIONACCOUNTCODE_");

                entity.Property(e => e.Comissionaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("COMISSIONACCOUNTPK_");

                entity.Property(e => e.Confiscated)
                    .HasPrecision(1)
                    .HasColumnName("CONFISCATED_");

                entity.Property(e => e.Countrybpcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRYBPCODE_");

                entity.Property(e => e.Countrybppk)
                    .HasPrecision(19)
                    .HasColumnName("COUNTRYBPPK_");

                entity.Property(e => e.Creationaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATIONACCOUNTCODE_");

                entity.Property(e => e.Creationaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("CREATIONACCOUNTPK_");

                entity.Property(e => e.Dateentrypackage)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEENTRYPACKAGE_");

                entity.Property(e => e.Davepackagecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DAVEPACKAGECODE_");

                entity.Property(e => e.Davepackagepk)
                    .HasPrecision(19)
                    .HasColumnName("DAVEPACKAGEPK_");

                entity.Property(e => e.Electionpresidentielle)
                    .HasPrecision(1)
                    .HasColumnName("ELECTIONPRESIDENTIELLE_");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME_");

                entity.Property(e => e.Freezecredit)
                    .HasPrecision(1)
                    .HasColumnName("FREEZECREDIT_");

                entity.Property(e => e.Freezedebit)
                    .HasPrecision(1)
                    .HasColumnName("FREEZEDEBIT_");

                entity.Property(e => e.Freezeregulatory)
                    .HasPrecision(1)
                    .HasColumnName("FREEZEREGULATORY_");

                entity.Property(e => e.Frozen)
                    .HasPrecision(1)
                    .HasColumnName("FROZEN_");

                entity.Property(e => e.Frozendate)
                    .HasColumnType("DATE")
                    .HasColumnName("FROZENDATE_");

                entity.Property(e => e.Generateafbreleve)
                    .HasPrecision(1)
                    .HasColumnName("GENERATEAFBRELEVE_");

                entity.Property(e => e.Generatereleve)
                    .HasPrecision(1)
                    .HasColumnName("GENERATERELEVE_");

                entity.Property(e => e.Generatesettlreport)
                    .HasPrecision(1)
                    .HasColumnName("GENERATESETTLREPORT_");

                entity.Property(e => e.Generateswiftreleve)
                    .HasPrecision(1)
                    .HasColumnName("GENERATESWIFTRELEVE_");

                entity.Property(e => e.Inactivecredit)
                    .HasPrecision(1)
                    .HasColumnName("INACTIVECREDIT_");

                entity.Property(e => e.Inactivedebit)
                    .HasPrecision(1)
                    .HasColumnName("INACTIVEDEBIT_");

                entity.Property(e => e.Inactivityperiodpk)
                    .HasPrecision(19)
                    .HasColumnName("INACTIVITYPERIODPK_");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME_");

                entity.Property(e => e.Linckedaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LINCKEDACCOUNTCODE_");

                entity.Property(e => e.Linckedaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("LINCKEDACCOUNTPK_");

                entity.Property(e => e.Linkedaccountpackage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LINKEDACCOUNTPACKAGE_");

                entity.Property(e => e.Locked)
                    .HasPrecision(1)
                    .HasColumnName("LOCKED_");

                entity.Property(e => e.Maxima)
                    .HasPrecision(1)
                    .HasColumnName("MAXIMA_");

                entity.Property(e => e.Numcpt7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMCPT7_");

                entity.Property(e => e.Objectrelationcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OBJECTRELATIONCODE_");

                entity.Property(e => e.Objectrelationpk)
                    .HasPrecision(19)
                    .HasColumnName("OBJECTRELATIONPK_");

                entity.Property(e => e.Origincreation)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINCREATION_");

                entity.Property(e => e.Otherobjectrelation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OTHEROBJECTRELATION_");

                entity.Property(e => e.Pendingaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PENDINGACCOUNTCODE_");

                entity.Property(e => e.Pendingaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("PENDINGACCOUNTPK_");

                entity.Property(e => e.Settlementaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SETTLEMENTACCOUNTCODE_");

                entity.Property(e => e.Settlementaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("SETTLEMENTACCOUNTPK_");

                entity.Property(e => e.Smoothingprincipalcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SMOOTHINGPRINCIPALCODE_");

                entity.Property(e => e.Status)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_");

                entity.Property(e => e.Swiftreleveaddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SWIFTRELEVEADDRESS_");

                entity.Property(e => e.Swiftrelevesequence)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SWIFTRELEVESEQUENCE_");

                entity.Property(e => e.Swiftrelevetype)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SWIFTRELEVETYPE_");

                entity.Property(e => e.Technicalaccountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TECHNICALACCOUNTCODE_");

                entity.Property(e => e.Technicalaccountpk)
                    .HasPrecision(19)
                    .HasColumnName("TECHNICALACCOUNTPK_");

                entity.Property(e => e.Transitiondate)
                    .HasPrecision(6)
                    .HasColumnName("TRANSITIONDATE_");

                entity.Property(e => e.Validationprocesspk)
                    .HasPrecision(19)
                    .HasColumnName("VALIDATIONPROCESSPK_");

                entity.HasOne(d => d.AccountpkNavigation)
                    .WithOne(p => p.Accountcontract)
                    .HasForeignKey<Accountcontract>(d => d.Accountpk)
                    .HasConstraintName("F_RACTACCO_3XFOQY");

                entity.HasOne(d => d.ComissionaccountpkNavigation)
                    .WithMany(p => p.InverseComissionaccountpkNavigation)
                    .HasForeignKey(d => d.Comissionaccountpk)
                    .HasConstraintName("F_RACTCOMII12D20");

                entity.HasOne(d => d.LinckedaccountpkNavigation)
                    .WithMany(p => p.InverseLinckedaccountpkNavigation)
                    .HasForeignKey(d => d.Linckedaccountpk)
                    .HasConstraintName("F_RACTLINCXV9LCG");

                entity.HasOne(d => d.PendingaccountpkNavigation)
                    .WithMany(p => p.InversePendingaccountpkNavigation)
                    .HasForeignKey(d => d.Pendingaccountpk)
                    .HasConstraintName("F_RACTPENDHJD0Y7");

                entity.HasOne(d => d.TechnicalaccountpkNavigation)
                    .WithMany(p => p.InverseTechnicalaccountpkNavigation)
                    .HasForeignKey(d => d.Technicalaccountpk)
                    .HasConstraintName("F_RACTTECHVVE4UT");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_ENTITY");

                entity.ToTable("ENTITY");

                entity.HasIndex(e => new { e.Nationalitycode, e.Pk }, "IDX$$_87830003");

                entity.HasIndex(e => new { e.Nationalitypk, e.Pk }, "IDX$$_87830004");

                entity.HasIndex(e => new { e.Type, e.Identifier }, "IDX_ENTITY_TYPID");

                entity.HasIndex(e => e.Soundex, "INDX_ENTITY_001");

                entity.HasIndex(e => e.Type, "INDX_TYPE");

                entity.HasIndex(e => e.Officialmailpk, "IX_OFFICIALMAILPK_");

                entity.HasIndex(e => e.Centralbankcode, "I_MEGARA_CENTRALBANKCODE_");

                entity.HasIndex(e => e.Fullname, "I_MEGARA_FULLNAME_");

                entity.HasIndex(e => e.Code, "U_ENTITYCODE_")
                    .IsUnique();

                entity.HasIndex(e => e.Identifier, "U_ENTITYIDEN8CMT5F")
                    .IsUnique();

                entity.HasIndex(e => e.Professionalactivitypk, "U_ENTITYPRO_P0W29H")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Assaini)
                    .HasPrecision(1)
                    .HasColumnName("ASSAINI_");

                entity.Property(e => e.Bl)
                    .HasPrecision(1)
                    .HasColumnName("BL_");

                entity.Property(e => e.Branch)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BRANCH_");

                entity.Property(e => e.Ccppk)
                    .HasPrecision(19)
                    .HasColumnName("CCPPK_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Centralbankcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CENTRALBANKCODE_");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODE_");

                entity.Property(e => e.Crepk)
                    .HasPrecision(19)
                    .HasColumnName("CREPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Datefield1)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFIELD1_");

                entity.Property(e => e.Datefield2)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFIELD2_");

                entity.Property(e => e.Datefield3)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFIELD3_");

                entity.Property(e => e.Decbctrisk)
                    .HasPrecision(1)
                    .HasColumnName("DECBCTRISK_");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Draft)
                    .HasPrecision(1)
                    .HasColumnName("DRAFT_");

                entity.Property(e => e.Entitycategorycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTITYCATEGORYCODE_");

                entity.Property(e => e.Entitycategorypk)
                    .HasPrecision(19)
                    .HasColumnName("ENTITYCATEGORYPK_");

                entity.Property(e => e.Fiscalresidencecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FISCALRESIDENCECODE_");

                entity.Property(e => e.Fiscalresidencepk)
                    .HasPrecision(19)
                    .HasColumnName("FISCALRESIDENCEPK_");

                entity.Property(e => e.Forbiddenaccount)
                    .HasPrecision(1)
                    .HasColumnName("FORBIDDENACCOUNT_");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME_");

                entity.Property(e => e.Gc)
                    .HasPrecision(1)
                    .HasColumnName("GC_");

                entity.Property(e => e.Identifier)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IDENTIFIER_");

                entity.Property(e => e.Identifier2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENTIFIER2_");

                entity.Property(e => e.Inscode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSCODE_");

                entity.Property(e => e.Isarchived)
                    .HasPrecision(1)
                    .HasColumnName("ISARCHIVED_");

                entity.Property(e => e.Isvalidated)
                    .HasPrecision(1)
                    .HasColumnName("ISVALIDATED_");

                entity.Property(e => e.Labft)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("LABFT_");

                entity.Property(e => e.Migstate)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MIGSTATE_");

                entity.Property(e => e.Nationalitycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATIONALITYCODE_");

                entity.Property(e => e.Nationalitypk)
                    .HasPrecision(19)
                    .HasColumnName("NATIONALITYPK_");

                entity.Property(e => e.Notresident)
                    .HasPrecision(1)
                    .HasColumnName("NOTRESIDENT_");

                entity.Property(e => e.Officialmailpk)
                    .HasPrecision(19)
                    .HasColumnName("OFFICIALMAILPK_");

                entity.Property(e => e.Otherfunctionsppe)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OTHERFUNCTIONSPPE_");

                entity.Property(e => e.Ppe)
                    .HasPrecision(1)
                    .HasColumnName("PPE_");

                entity.Property(e => e.Ppefunctionpk)
                    .HasPrecision(19)
                    .HasColumnName("PPEFUNCTIONPK_");

                entity.Property(e => e.Professionalactivitypk)
                    .HasPrecision(19)
                    .HasColumnName("PROFESSIONALACTIVITYPK_");

                entity.Property(e => e.Prospect)
                    .HasPrecision(1)
                    .HasColumnName("PROSPECT_");

                entity.Property(e => e.Residencecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESIDENCECODE_");

                entity.Property(e => e.Residencepk)
                    .HasPrecision(19)
                    .HasColumnName("RESIDENCEPK_");

                entity.Property(e => e.Resident)
                    .HasPrecision(1)
                    .HasColumnName("RESIDENT_");

                entity.Property(e => e.Riskcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RISKCODE_");

                entity.Property(e => e.Riskcodebc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RISKCODEBC_");

                entity.Property(e => e.Socialaffiliationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SOCIALAFFILIATIONDATE_");

                entity.Property(e => e.Socialaffiliationnum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOCIALAFFILIATIONNUM_");

                entity.Property(e => e.Soundex)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SOUNDEX_");

                entity.Property(e => e.Stringfield1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD1_");

                entity.Property(e => e.Stringfield2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD2_");

                entity.Property(e => e.Stringfield3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD3_");

                entity.Property(e => e.Stringfield4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD4_");

                entity.Property(e => e.Stringfield5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD5_");

                entity.Property(e => e.Stringfield6)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD6_");

                entity.Property(e => e.Stringfield7)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("STRINGFIELD7_");

                entity.Property(e => e.Translatedname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRANSLATEDNAME_");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Validatedbyjurdical)
                    .HasPrecision(1)
                    .HasColumnName("VALIDATEDBYJURDICAL_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.Property(e => e.Withanomaly)
                    .HasPrecision(1)
                    .HasColumnName("WITHANOMALY_");
            });

            modelBuilder.Entity<Financialo>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_FINANCIALO");

                entity.ToTable("FINANCIALO");

                entity.HasIndex(e => new { e.Accountcode, e.Tradedate }, "FINANCIALO_ACCCODE");

                entity.HasIndex(e => e.Accountpk, "FINANCIALO_IDX_ACCOUNTPK_");

                entity.HasIndex(e => e.Currencypk, "IDX_CURRENCYPK_");

                entity.HasIndex(e => new { e.Processed, e.Unitcode, e.Reference, e.Accountpk }, "IDX_FINO_20200904");

                entity.HasIndex(e => new { e.Processed, e.Grossamount, e.Tradedate, e.Accountpk }, "IDX_FINO_20201211");

                entity.HasIndex(e => new { e.Operationtypecode, e.Relatedoperation }, "IDX_FINO_OPETYP_RELOPE");

                entity.HasIndex(e => e.Operationtypepk, "IDX_OPERATIONTYPEPK_");

                entity.HasIndex(e => e.Unitpk, "IDX_UNITPK_");

                entity.HasIndex(e => new { e.Relatedoperation, e.Cuser }, "INDEX6");

                entity.HasIndex(e => new { e.Tradedate, e.Unitcode, e.Cuser, e.Reversed, e.Processed }, "IX_25012018_01");

                entity.HasIndex(e => new { e.Tradedate, e.Operationtypecode, e.Unitcode }, "IX_29012018_02");

                entity.HasIndex(e => e.Code, "IX_CODE_");

                entity.HasIndex(e => new { e.Accountnumber, e.Tradedate }, "IX_FINANCIALO_0001");

                entity.HasIndex(e => new { e.Lockoperationreference, e.Accountpk }, "IX_FINANCIALO_INDEX1");

                entity.HasIndex(e => new { e.Reservationreference, e.Accountpk }, "IX_FINANCIALO_INDEX2");

                entity.HasIndex(e => new { e.Lockoperationreference, e.Reversed, e.Reversedfinancialopepk }, "I_FINANCIALO");

                entity.HasIndex(e => e.Code, "U_FINANCIALOCODE_")
                    .IsUnique();

                entity.HasIndex(e => e.Reference, "U_FINANCIALOGT2CD6")
                    .IsUnique();

                entity.HasIndex(e => e.Reversedfinancialopepk, "U_FINANCIALO_Y9TGF")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Abstractopetype)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABSTRACTOPETYPE_");

                entity.Property(e => e.Accountcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCODE_");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER_");

                entity.Property(e => e.Accountpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTPK_");

                entity.Property(e => e.Cannegoce)
                    .HasPrecision(1)
                    .HasColumnName("CANNEGOCE_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Closed)
                    .HasPrecision(1)
                    .HasColumnName("CLOSED_");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODE_");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT_");

                entity.Property(e => e.Creditamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("CREDITAMOUNT_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Debitamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEBITAMOUNT_");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Differed)
                    .HasPrecision(1)
                    .HasColumnName("DIFFERED_");

                entity.Property(e => e.Differedcondition)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DIFFEREDCONDITION_");

                entity.Property(e => e.Exempttype)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXEMPTTYPE_");

                entity.Property(e => e.Extreference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXTREFERENCE_");

                entity.Property(e => e.Filtrereport)
                    .HasPrecision(1)
                    .HasColumnName("FILTREREPORT_");

                entity.Property(e => e.Force)
                    .HasPrecision(1)
                    .HasColumnName("FORCE_");

                entity.Property(e => e.Forcedate)
                    .HasColumnType("DATE")
                    .HasColumnName("FORCEDATE_");

                entity.Property(e => e.Forceuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FORCEUSER_");

                entity.Property(e => e.Fxrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXRATE_");

                entity.Property(e => e.Globalreference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GLOBALREFERENCE_");

                entity.Property(e => e.Grossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNT_");

                entity.Property(e => e.Grossamountacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNTACCCUR_");

                entity.Property(e => e.Lockoperationreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCKOPERATIONREFERENCE_");

                entity.Property(e => e.Netamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("NETAMOUNT_");

                entity.Property(e => e.Netamountacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("NETAMOUNTACCCUR_");

                entity.Property(e => e.Opeinfo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("OPEINFO_");

                entity.Property(e => e.Operationtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONTYPECODE_");

                entity.Property(e => e.Operationtypepk)
                    .HasPrecision(19)
                    .HasColumnName("OPERATIONTYPEPK_");

                entity.Property(e => e.Paymentmeanref)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTMEANREF_");

                entity.Property(e => e.Processed)
                    .HasPrecision(1)
                    .HasColumnName("PROCESSED_");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_");

                entity.Property(e => e.Relatedoperation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RELATEDOPERATION_");

                entity.Property(e => e.Reservationreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RESERVATIONREFERENCE_");

                entity.Property(e => e.Reversed)
                    .HasPrecision(1)
                    .HasColumnName("REVERSED_");

                entity.Property(e => e.Reversedfinancialopecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REVERSEDFINANCIALOPECODE_");

                entity.Property(e => e.Reversedfinancialopepk)
                    .HasPrecision(19)
                    .HasColumnName("REVERSEDFINANCIALOPEPK_");

                entity.Property(e => e.Sign)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("SIGN_");

                entity.Property(e => e.Totalcomission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALCOMISSION_");

                entity.Property(e => e.Totalcomissionacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALCOMISSIONACCCUR_");

                entity.Property(e => e.Totalfiscalretention)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALFISCALRETENTION_");

                entity.Property(e => e.Totalfracccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALFRACCCUR_");

                entity.Property(e => e.Totalstamp)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALSTAMP_");

                entity.Property(e => e.Totaltaf)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALTAF_");

                entity.Property(e => e.Totalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALVAT_");

                entity.Property(e => e.Totalvatacccur)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALVATACCCUR_");

                entity.Property(e => e.Tradedate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADEDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Unitpk)
                    .HasPrecision(19)
                    .HasColumnName("UNITPK_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.HasOne(d => d.ReversedfinancialopepkNavigation)
                    .WithOne(p => p.InverseReversedfinancialopepkNavigation)
                    .HasForeignKey<Financialo>(d => d.Reversedfinancialopepk)
                    .HasConstraintName("F_IALOREVE_Y9TGF");
            });

            modelBuilder.Entity<Productservice>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_PRODUCTSERVICE");

                entity.ToTable("PRODUCTSERVICE");

                entity.HasIndex(e => e.Productcategorycode, "IDX$$_001");

                entity.HasIndex(e => e.Type, "IDX$$_99640001");

                entity.HasIndex(e => new { e.Name, e.Type }, "IDX$$_99640003");

                entity.HasIndex(e => new { e.Code, e.Name }, "IDX$$_CB840002");

                entity.HasIndex(e => e.Productcategorypk, "IX_PRODUCTSER33221");

                entity.HasIndex(e => e.Ficheproductpk, "U_PRODUCTSE_7S4GHG")
                    .IsUnique();

                entity.HasIndex(e => e.Code, "U_PRODUCTSE_8NF190")
                    .IsUnique();

                entity.HasIndex(e => e.Vendorincentivespk, "U_PRODUCTSE_BESJO2")
                    .IsUnique();

                entity.HasIndex(e => e.Identifier, "U_PRODUCTSE_TM01JK")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Abreviation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ABREVIATION_");

                entity.Property(e => e.Activationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACTIVATIONDATE_");

                entity.Property(e => e.Applyfiscalretention)
                    .HasPrecision(1)
                    .HasColumnName("APPLYFISCALRETENTION_");

                entity.Property(e => e.Available)
                    .HasPrecision(1)
                    .HasColumnName("AVAILABLE_");

                entity.Property(e => e.Cbcategorycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CBCATEGORYCODE_");

                entity.Property(e => e.Cbcategorypk)
                    .HasPrecision(19)
                    .HasColumnName("CBCATEGORYPK_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODE_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Description)
                    .HasMaxLength(1280)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_");

                entity.Property(e => e.Draft)
                    .HasPrecision(1)
                    .HasColumnName("DRAFT_");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE_");

                entity.Property(e => e.Expired)
                    .HasPrecision(1)
                    .HasColumnName("EXPIRED_");

                entity.Property(e => e.Ficheproductpk)
                    .HasPrecision(19)
                    .HasColumnName("FICHEPRODUCTPK_");

                entity.Property(e => e.Freetext)
                    .HasMaxLength(1280)
                    .IsUnicode(false)
                    .HasColumnName("FREETEXT_");

                entity.Property(e => e.Identifier)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDENTIFIER_");

                entity.Property(e => e.Internal)
                    .HasPrecision(1)
                    .HasColumnName("INTERNAL_");

                entity.Property(e => e.Internalcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INTERNALCODE_");

                entity.Property(e => e.Isathorizedoperationempty)
                    .HasPrecision(1)
                    .HasColumnName("ISATHORIZEDOPERATIONEMPTY_");

                entity.Property(e => e.Islimiteempty)
                    .HasPrecision(1)
                    .HasColumnName("ISLIMITEEMPTY_");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME_");

                entity.Property(e => e.Offeredonce)
                    .HasPrecision(1)
                    .HasColumnName("OFFEREDONCE_");

                entity.Property(e => e.Prefixan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PREFIXAN_");

                entity.Property(e => e.Productcategorycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCTCATEGORYCODE_");

                entity.Property(e => e.Productcategorypk)
                    .HasPrecision(19)
                    .HasColumnName("PRODUCTCATEGORYPK_");

                entity.Property(e => e.Renewablerequestdelay)
                    .HasPrecision(19)
                    .HasColumnName("RENEWABLEREQUESTDELAY_");

                entity.Property(e => e.Revisionperiodicity)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("REVISIONPERIODICITY_");

                entity.Property(e => e.Risklevel)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("RISKLEVEL_");

                entity.Property(e => e.Serial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SERIAL_");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SHORTNAME_");

                entity.Property(e => e.Translatedname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRANSLATEDNAME_");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Validationprocessname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONPROCESSNAME_");

                entity.Property(e => e.Validationstepname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONSTEPNAME_");

                entity.Property(e => e.Vendorincentivespk)
                    .HasPrecision(19)
                    .HasColumnName("VENDORINCENTIVESPK_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.Property(e => e.Weightingrate)
                    .HasColumnType("FLOAT")
                    .HasColumnName("WEIGHTINGRATE_");
            });

            modelBuilder.Entity<Receivedbill>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_RECEIVEDBILL");

                entity.ToTable("RECEIVEDBILL");

                entity.HasIndex(e => new { e.Unitcode, e.Receivedbilllcstatus }, "IDX_RBIL_UC_RBS");

                entity.HasIndex(e => e.Receivedbilllcstatus, "IDX_RECBILL_LCSTATUS");

                entity.HasIndex(e => new { e.Billreference, e.Receivedbilllcstatus }, "IDX_RECEIVEDBILL_BILLREF");

                entity.HasIndex(e => new { e.Reference, e.Tradedate }, "INDX_RECEIVEDBILL_1");

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Acceptationcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCEPTATIONCODE_");

                entity.Property(e => e.Accountcontractcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCONTRACTCODE_");

                entity.Property(e => e.Accountcontractpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTCONTRACTPK_");

                entity.Property(e => e.Accphysique)
                    .HasPrecision(1)
                    .HasColumnName("ACCPHYSIQUE_");

                entity.Property(e => e.Affecteduser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AFFECTEDUSER_");

                entity.Property(e => e.Affectiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("AFFECTIONDATE_");

                entity.Property(e => e.Autoprocess)
                    .HasPrecision(1)
                    .HasColumnName("AUTOPROCESS_");

                entity.Property(e => e.Avalrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AVALRIB_");

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKCODE_");

                entity.Property(e => e.Bankpk)
                    .HasPrecision(19)
                    .HasColumnName("BANKPK_");

                entity.Property(e => e.Bap)
                    .HasPrecision(1)
                    .HasColumnName("BAP_");

                entity.Property(e => e.Beneficiaryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYNAME_");

                entity.Property(e => e.Beneficiaryref)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYREF_");

                entity.Property(e => e.Beneficiaryrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYRIB_");

                entity.Property(e => e.Billamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("BILLAMOUNT_");

                entity.Property(e => e.Billimagepk)
                    .HasPrecision(19)
                    .HasColumnName("BILLIMAGEPK_");

                entity.Property(e => e.Billimageversopk)
                    .HasPrecision(19)
                    .HasColumnName("BILLIMAGEVERSOPK_");

                entity.Property(e => e.Billreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BILLREFERENCE_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Clearingpk)
                    .HasPrecision(19)
                    .HasColumnName("CLEARINGPK_");

                entity.Property(e => e.Codelabel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODELABEL_");

                entity.Property(e => e.Codeordrepay)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODEORDREPAY_");

                entity.Property(e => e.Creationdatebill)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATIONDATEBILL_");

                entity.Property(e => e.Creationlocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATIONLOCATION_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Datecompensationinitiale)
                    .HasColumnType("DATE")
                    .HasColumnName("DATECOMPENSATIONINITIALE_");

                entity.Property(e => e.Dealingroomdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEALINGROOMDATE_");

                entity.Property(e => e.Dealingroomgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMGROSSAMOUNT_");

                entity.Property(e => e.Dealingroomnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMNETAMOUNT_");

                entity.Property(e => e.Dealingroomrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMRATE_");

                entity.Property(e => e.Dealingroomreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALINGROOMREFERENCE_");

                entity.Property(e => e.Dealingroomtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALCOMMISSION_");

                entity.Property(e => e.Dealingroomtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALVAT_");

                entity.Property(e => e.Depositname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPOSITNAME_");

                entity.Property(e => e.Draft)
                    .HasPrecision(1)
                    .HasColumnName("DRAFT_");

                entity.Property(e => e.Draweereference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DRAWEEREFERENCE_");

                entity.Property(e => e.Emettingunit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMETTINGUNIT_");

                entity.Property(e => e.Endoseravalcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENDOSERAVALCODE_");

                entity.Property(e => e.Eventtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EVENTTYPECODE_");

                entity.Property(e => e.Eventtypepk)
                    .HasPrecision(19)
                    .HasColumnName("EVENTTYPEPK_");

                entity.Property(e => e.Exempttype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EXEMPTTYPE_");

                entity.Property(e => e.Extreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXTREFERENCE_");

                entity.Property(e => e.Fallingduedate)
                    .HasColumnType("DATE")
                    .HasColumnName("FALLINGDUEDATE_");

                entity.Property(e => e.Force)
                    .HasPrecision(1)
                    .HasColumnName("FORCE_");

                entity.Property(e => e.Freetext)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FREETEXT_");

                entity.Property(e => e.Fxgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXGROSSAMOUNT_");

                entity.Property(e => e.Fxnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXNETAMOUNT_");

                entity.Property(e => e.Fxrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXRATE_");

                entity.Property(e => e.Fxtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALCOMMISSION_");

                entity.Property(e => e.Fxtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALVAT_");

                entity.Property(e => e.Grossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNT_");

                entity.Property(e => e.Hascomplementaryrecords)
                    .HasPrecision(1)
                    .HasColumnName("HASCOMPLEMENTARYRECORDS_");

                entity.Property(e => e.Initialfallingduedate)
                    .HasColumnType("DATE")
                    .HasColumnName("INITIALFALLINGDUEDATE_");

                entity.Property(e => e.Initialpayerrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INITIALPAYERRIB_");

                entity.Property(e => e.Instrumentcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("INSTRUMENTCODE_");

                entity.Property(e => e.Interestamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("INTERESTAMOUNT_");

                entity.Property(e => e.Isdeal)
                    .HasPrecision(1)
                    .HasColumnName("ISDEAL_");

                entity.Property(e => e.Issuedinlocal)
                    .HasPrecision(1)
                    .HasColumnName("ISSUEDINLOCAL_");

                entity.Property(e => e.Mandatorycodes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MANDATORYCODES_");

                entity.Property(e => e.Manualclearing)
                    .HasPrecision(1)
                    .HasColumnName("MANUALCLEARING_");

                entity.Property(e => e.Naturebenef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATUREBENEF_");

                entity.Property(e => e.Negociateexchange)
                    .HasPrecision(1)
                    .HasColumnName("NEGOCIATEEXCHANGE_");

                entity.Property(e => e.Netamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("NETAMOUNT_");

                entity.Property(e => e.Nrem)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NREM_");

                entity.Property(e => e.Ntrans)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NTRANS_");

                entity.Property(e => e.Operationtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONTYPECODE_");

                entity.Property(e => e.Operationtypepk)
                    .HasPrecision(19)
                    .HasColumnName("OPERATIONTYPEPK_");

                entity.Property(e => e.Papercode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAPERCODE_");

                entity.Property(e => e.Payername)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYERNAME_");

                entity.Property(e => e.Payerref)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYERREF_");

                entity.Property(e => e.Payerrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYERRIB_");

                entity.Property(e => e.Protestfees)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("PROTESTFEES_");

                entity.Property(e => e.Provisionrejectioncancelled)
                    .HasPrecision(1)
                    .HasColumnName("PROVISIONREJECTIONCANCELLED_");

                entity.Property(e => e.Rcppk)
                    .HasPrecision(19)
                    .HasColumnName("RCPPK_");

                entity.Property(e => e.Receivedbilllcstatus)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("RECEIVEDBILLLCSTATUS_");

                entity.Property(e => e.Receivedvaluedate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVEDVALUEDATE_");

                entity.Property(e => e.Refcommercialpayer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFCOMMERCIALPAYER_");

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_");

                entity.Property(e => e.Referencerio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCERIO_");

                entity.Property(e => e.Referencettn)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCETTN_");

                entity.Property(e => e.Rejectcodereasons)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REJECTCODEREASONS_");

                entity.Property(e => e.Rejectdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REJECTDATE_");

                entity.Property(e => e.Restournecommission)
                    .HasPrecision(1)
                    .HasColumnName("RESTOURNECOMMISSION_");

                entity.Property(e => e.Reversalreason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REVERSALREASON_");

                entity.Property(e => e.Riskcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RISKCODE_");

                entity.Property(e => e.Signatureimagepk)
                    .HasPrecision(19)
                    .HasColumnName("SIGNATUREIMAGEPK_");

                entity.Property(e => e.Situationbenef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SITUATIONBENEF_");

                entity.Property(e => e.Spotdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SPOTDATE_");

                entity.Property(e => e.Totalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALCOMMISSION_");

                entity.Property(e => e.Totalstamp)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALSTAMP_");

                entity.Property(e => e.Totaltaf)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALTAF_");

                entity.Property(e => e.Totalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALVAT_");

                entity.Property(e => e.Tradedate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADEDATE_");

                entity.Property(e => e.Transitiondate)
                    .HasPrecision(6)
                    .HasColumnName("TRANSITIONDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Validationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALIDATIONDATE_");

                entity.Property(e => e.Validationprocessname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONPROCESSNAME_");

                entity.Property(e => e.Validationstepname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONSTEPNAME_");

                entity.Property(e => e.Validationuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.Property(e => e.Vfcheck)
                    .HasPrecision(1)
                    .HasColumnName("VFCHECK_");

                entity.Property(e => e.Withaval)
                    .HasPrecision(1)
                    .HasColumnName("WITHAVAL_");

                entity.Property(e => e.Withoutimage)
                    .HasPrecision(1)
                    .HasColumnName("WITHOUTIMAGE_");

                entity.HasOne(d => d.AccountcontractpkNavigation)
                    .WithMany(p => p.Receivedbills)
                    .HasForeignKey(d => d.Accountcontractpk)
                    .HasConstraintName("F_BILLACCOXJQF8T");
            });

            modelBuilder.Entity<Receivedcheck>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_RECEIVEDCHECK");

                entity.ToTable("RECEIVEDCHECK");

                entity.HasIndex(e => new { e.Draweerib, e.Number }, "DRAWEERIB_NUMBER_20190515");

                entity.HasIndex(e => new { e.Receivedchecklcstatus, e.Draft, e.Draweerib }, "IDX$$_2DE510001");

                entity.HasIndex(e => e.Reference, "IDX$$_585A90002");

                entity.HasIndex(e => new { e.Pk, e.Unitcode, e.Draft }, "IDX$$_DD2A0001");

                entity.HasIndex(e => new { e.Unitcode, e.Draft }, "IDX_RCHK_26022020");

                entity.HasIndex(e => new { e.Chequepk, e.Pk }, "IDX_RECCHQ_CHPK_PK");

                entity.HasIndex(e => e.Accountcontractcode, "IDX_RECEIVEDCHECK_ACCOUNTCODE");

                entity.HasIndex(e => new { e.Unitcode, e.Natremettant, e.Chequepk }, "IDX_RECVCHQ");

                entity.HasIndex(e => e.Chequecode, "INDX_RECVCHQ_31072018");

                entity.HasIndex(e => new { e.Accountcontractpk, e.Currencypk, e.Operationtypepk }, "IX_RECEIVEDCHECK_ACC");

                entity.HasIndex(e => new { e.Receivedchecklcstatus, e.Eventtypecode, e.Tradedate, e.Hasexploit, e.Rejectdate }, "RECEIVEDCHECK_IDX_13112017");

                entity.HasIndex(e => new { e.Number, e.Accountcontractpk }, "RECEIVEDCHECK_IDX_94A60001");

                entity.HasIndex(e => new { e.Draft, e.Tradedate, e.Accountcontractpk }, "RECEIVEDCHECK_IDX_95590002");

                entity.HasIndex(e => new { e.Unitcode, e.Receivedchecklcstatus, e.Tradedate }, "RECEIVEDCHECK_IDX_95DD0002");

                entity.HasIndex(e => new { e.Reference, e.Tradedate }, "U_RECEIVEDCHECK");

                entity.HasIndex(e => e.Chequepk, "U_RECEIVEDCHECK_28112019");

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountcontractcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ACCOUNTCONTRACTCODE_");

                entity.Property(e => e.Accountcontractpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTCONTRACTPK_");

                entity.Property(e => e.Accountnature)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNATURE_");

                entity.Property(e => e.Affecteduser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AFFECTEDUSER_");

                entity.Property(e => e.Affectiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("AFFECTIONDATE_");

                entity.Property(e => e.Anrdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ANRDATE_");

                entity.Property(e => e.Autoprocess)
                    .HasPrecision(1)
                    .HasColumnName("AUTOPROCESS_");

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKCODE_");

                entity.Property(e => e.Bankpk)
                    .HasPrecision(19)
                    .HasColumnName("BANKPK_");

                entity.Property(e => e.Beneficiaryaccnature)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYACCNATURE_");

                entity.Property(e => e.Beneficiaryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYNAME_");

                entity.Property(e => e.Beneficiaryrib)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYRIB_");

                entity.Property(e => e.Benefsituation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFSITUATION_");

                entity.Property(e => e.Branchdestcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BRANCHDESTCODE_");

                entity.Property(e => e.Branchremcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BRANCHREMCODE_");

                entity.Property(e => e.Cannegoce)
                    .HasPrecision(1)
                    .HasColumnName("CANNEGOCE_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Certificationamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("CERTIFICATIONAMOUNT_");

                entity.Property(e => e.Checkimagepk)
                    .HasPrecision(19)
                    .HasColumnName("CHECKIMAGEPK_");

                entity.Property(e => e.Checkimageversopk)
                    .HasPrecision(19)
                    .HasColumnName("CHECKIMAGEVERSOPK_");

                entity.Property(e => e.Chequecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHEQUECODE_");

                entity.Property(e => e.Chequepk)
                    .HasPrecision(19)
                    .HasColumnName("CHEQUEPK_");

                entity.Property(e => e.Clearingnatremettant)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLEARINGNATREMETTANT_");

                entity.Property(e => e.Clearingpk)
                    .HasPrecision(19)
                    .HasColumnName("CLEARINGPK_");

                entity.Property(e => e.Cnpdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CNPDATE_");

                entity.Property(e => e.Cnpeffacer)
                    .HasPrecision(1)
                    .HasColumnName("CNPEFFACER");

                entity.Property(e => e.Codelabel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODELABEL_");

                entity.Property(e => e.Creationlocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CREATIONLOCATION_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Date90eme)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE90EME_");

                entity.Property(e => e.Dealingroomdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEALINGROOMDATE_");

                entity.Property(e => e.Dealingroomgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMGROSSAMOUNT_");

                entity.Property(e => e.Dealingroomnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMNETAMOUNT_");

                entity.Property(e => e.Dealingroomrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMRATE_");

                entity.Property(e => e.Dealingroomreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALINGROOMREFERENCE_");

                entity.Property(e => e.Dealingroomtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALCOMMISSION_");

                entity.Property(e => e.Dealingroomtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALVAT_");

                entity.Property(e => e.Depositname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPOSITNAME_");

                entity.Property(e => e.Devposacc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEVPOSACC_");

                entity.Property(e => e.Draft)
                    .HasPrecision(1)
                    .HasColumnName("DRAFT_");

                entity.Property(e => e.Draweerib)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("DRAWEERIB_");

                entity.Property(e => e.Eventtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EVENTTYPECODE_");

                entity.Property(e => e.Eventtypepk)
                    .HasPrecision(19)
                    .HasColumnName("EVENTTYPEPK_");

                entity.Property(e => e.Exempttype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EXEMPTTYPE_");

                entity.Property(e => e.Extreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXTREFERENCE_");

                entity.Property(e => e.Force)
                    .HasPrecision(1)
                    .HasColumnName("FORCE_");

                entity.Property(e => e.Freezone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FREEZONE_");

                entity.Property(e => e.Fxgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXGROSSAMOUNT_");

                entity.Property(e => e.Fxnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXNETAMOUNT_");

                entity.Property(e => e.Fxrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXRATE_");

                entity.Property(e => e.Fxtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALCOMMISSION_");

                entity.Property(e => e.Fxtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALVAT_");

                entity.Property(e => e.Generatecnp)
                    .HasPrecision(1)
                    .HasColumnName("GENERATECNP_");

                entity.Property(e => e.Generatepapillion)
                    .HasPrecision(1)
                    .HasColumnName("GENERATEPAPILLION_");

                entity.Property(e => e.Generatepreavis)
                    .HasPrecision(1)
                    .HasColumnName("GENERATEPREAVIS_");

                entity.Property(e => e.Grossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNT_");

                entity.Property(e => e.Hasexploit)
                    .HasPrecision(1)
                    .HasColumnName("HASEXPLOIT_");

                entity.Property(e => e.Huissiercode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HUISSIERCODE_");

                entity.Property(e => e.Huissierpk)
                    .HasPrecision(19)
                    .HasColumnName("HUISSIERPK_");

                entity.Property(e => e.Iddocument)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IDDOCUMENT_");

                entity.Property(e => e.Immediatereject)
                    .HasPrecision(1)
                    .HasColumnName("IMMEDIATEREJECT_");

                entity.Property(e => e.Internalexternal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("INTERNALEXTERNAL_");

                entity.Property(e => e.Iscertified)
                    .HasPrecision(1)
                    .HasColumnName("ISCERTIFIED_");

                entity.Property(e => e.Isdeal)
                    .HasPrecision(1)
                    .HasColumnName("ISDEAL_");

                entity.Property(e => e.Isforeignbank)
                    .HasPrecision(1)
                    .HasColumnName("ISFOREIGNBANK_");

                entity.Property(e => e.Isproccureurdoc)
                    .HasPrecision(1)
                    .HasColumnName("ISPROCCUREURDOC_");

                entity.Property(e => e.Isreglemente)
                    .HasPrecision(1)
                    .HasColumnName("ISREGLEMENTE_");

                entity.Property(e => e.Issuedate)
                    .HasColumnType("DATE")
                    .HasColumnName("ISSUEDATE_");

                entity.Property(e => e.Issuedinlocal)
                    .HasPrecision(1)
                    .HasColumnName("ISSUEDINLOCAL_");

                entity.Property(e => e.Mandatorycodes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MANDATORYCODES_");

                entity.Property(e => e.Manualclearing)
                    .HasPrecision(1)
                    .HasColumnName("MANUALCLEARING_");

                entity.Property(e => e.Migreservedamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("MIGRESERVEDAMOUNT_");

                entity.Property(e => e.Natremettant)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATREMETTANT_");

                entity.Property(e => e.Natremettantvrai)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NATREMETTANTVRAI_");

                entity.Property(e => e.Naturecomptebenef)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("NATURECOMPTEBENEF_");

                entity.Property(e => e.Negociateexchange)
                    .HasPrecision(1)
                    .HasColumnName("NEGOCIATEEXCHANGE_");

                entity.Property(e => e.Netamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("NETAMOUNT_");

                entity.Property(e => e.Nrem)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NREM_");

                entity.Property(e => e.Ntrans)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NTRANS_");

                entity.Property(e => e.Number)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NUMBER_");

                entity.Property(e => e.Numcnp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMCNP_");

                entity.Property(e => e.Numtranche)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMTRANCHE_");

                entity.Property(e => e.Oldanrdate)
                    .HasColumnType("DATE")
                    .HasColumnName("OLDANRDATE_");

                entity.Property(e => e.Oldcleringpk)
                    .HasPrecision(19)
                    .HasColumnName("OLDCLERINGPK_");

                entity.Property(e => e.Olddate90eme)
                    .HasColumnType("DATE")
                    .HasColumnName("OLDDATE90EME_");

                entity.Property(e => e.Olddatecnp)
                    .HasColumnType("DATE")
                    .HasColumnName("OLDDATECNP_");

                entity.Property(e => e.Olddatepreavis)
                    .HasColumnType("DATE")
                    .HasColumnName("OLDDATEPREAVIS_");

                entity.Property(e => e.Oldfinpremierdelai)
                    .HasColumnType("DATE")
                    .HasColumnName("OLDFINPREMIERDELAI_");

                entity.Property(e => e.Oldnumcnp)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OLDNUMCNP");

                entity.Property(e => e.Oldnumppreavis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OLDNUMPPREAVIS");

                entity.Property(e => e.Operationtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONTYPECODE_");

                entity.Property(e => e.Operationtypepk)
                    .HasPrecision(19)
                    .HasColumnName("OPERATIONTYPEPK_");

                entity.Property(e => e.Orgnisationunithuissiercode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ORGNISATIONUNITHUISSIERCODE_");

                entity.Property(e => e.Orgnisationunithuissierpk)
                    .HasPrecision(19)
                    .HasColumnName("ORGNISATIONUNITHUISSIERPK_");

                entity.Property(e => e.Particiantremcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PARTICIANTREMCODE_");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENTDATE_");

                entity.Property(e => e.Paymentdocnum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTDOCNUM_");

                entity.Property(e => e.Paymentpartiel)
                    .HasPrecision(1)
                    .HasColumnName("PAYMENTPARTIEL_");

                entity.Property(e => e.Preavisdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PREAVISDATE_");

                entity.Property(e => e.Preaviseffacer)
                    .HasPrecision(1)
                    .HasColumnName("PREAVISEFFACER");

                entity.Property(e => e.Presdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PRESDATE_");

                entity.Property(e => e.Proccureurdocgenerated)
                    .HasPrecision(1)
                    .HasColumnName("PROCCUREURDOCGENERATED_");

                entity.Property(e => e.Provisionamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("PROVISIONAMOUNT_");

                entity.Property(e => e.Provisiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("PROVISIONDATE_");

                entity.Property(e => e.Provisionrejectioncancelled)
                    .HasPrecision(1)
                    .HasColumnName("PROVISIONREJECTIONCANCELLED_");

                entity.Property(e => e.Receivedchecklcstatus)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RECEIVEDCHECKLCSTATUS_");

                entity.Property(e => e.Receivedvaluedate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVEDVALUEDATE_");

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_");

                entity.Property(e => e.Referencerio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCERIO_");

                entity.Property(e => e.Refpubkey)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFPUBKEY_");

                entity.Property(e => e.Regulamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("REGULAMOUNT_");

                entity.Property(e => e.Regulinterestamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("REGULINTERESTAMOUNT_");

                entity.Property(e => e.Rejectcodereasons)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REJECTCODEREASONS_");

                entity.Property(e => e.Rejectdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REJECTDATE_");

                entity.Property(e => e.Relatedservicecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELATEDSERVICECODE_");

                entity.Property(e => e.Relatedservicepk)
                    .HasPrecision(19)
                    .HasColumnName("RELATEDSERVICEPK_");

                entity.Property(e => e.Requestedamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("REQUESTEDAMOUNT_");

                entity.Property(e => e.Restournecommission)
                    .HasPrecision(1)
                    .HasColumnName("RESTOURNECOMMISSION_");

                entity.Property(e => e.Reversalreason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REVERSALREASON_");

                entity.Property(e => e.Signature)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SIGNATURE_");

                entity.Property(e => e.Signatureimagepk)
                    .HasPrecision(19)
                    .HasColumnName("SIGNATUREIMAGEPK_");

                entity.Property(e => e.Spotdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SPOTDATE_");

                entity.Property(e => e.Totalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALCOMMISSION_");

                entity.Property(e => e.Totalregulamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALREGULAMOUNT_");

                entity.Property(e => e.Totalstamp)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALSTAMP_");

                entity.Property(e => e.Totaltaf)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALTAF_");

                entity.Property(e => e.Totalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALVAT_");

                entity.Property(e => e.Tradedate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADEDATE_");

                entity.Property(e => e.Transitiondate)
                    .HasPrecision(6)
                    .HasColumnName("TRANSITIONDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Validationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALIDATIONDATE_");

                entity.Property(e => e.Validationprocessname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONPROCESSNAME_");

                entity.Property(e => e.Validationstepname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONSTEPNAME_");

                entity.Property(e => e.Validationuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.Property(e => e.Vfcheck)
                    .HasPrecision(1)
                    .HasColumnName("VFCHECK_");

                entity.Property(e => e.Withoutimage)
                    .HasPrecision(1)
                    .HasColumnName("WITHOUTIMAGE_");
            });

            modelBuilder.Entity<Recvplv>(entity =>
            {
                entity.HasKey(e => e.Pk)
                    .HasName("P_RECVPLV");

                entity.ToTable("RECVPLV");

                entity.HasIndex(e => e.Accountcontractpk, "IDX$$_2DE500001");

                entity.HasIndex(e => new { e.Unitcode, e.Status, e.Fromcentralservice }, "IDX$$_B0340001");

                entity.HasIndex(e => new { e.Status, e.Tradedate, e.Accountcontractpk }, "IDX_20210131");

                entity.HasIndex(e => new { e.Status, e.Fromcentralservice, e.Locked, e.Beneficiaryrib, e.Draft, e.Tradedate }, "IDX_RECVPLV_20201210");

                entity.HasIndex(e => e.Clearingpk, "IDX_RECVPLV_CLEARPK");

                entity.HasIndex(e => e.Opetypeintrasource, "IDX_RECVPLV_OPETYP");

                entity.HasIndex(e => e.Plvauthpk, "IDX_RECVPLV_PLVAUTHPK_");

                entity.HasIndex(e => e.Rcppk, "IDX_RECVPLV_RCPPK");

                entity.HasIndex(e => e.Reference, "IDX_RECVPLV_REF_20190422");

                entity.HasIndex(e => e.Relatedprelevementpk, "INDEX_RELATEDPRELEVEMENTPK");

                entity.HasIndex(e => new { e.Reference, e.Tradedate }, "U_RECVPLVREFCJ3TYT")
                    .IsUnique();

                entity.HasIndex(e => e.Validationspk, "U_RECVPLVVAL88THVI")
                    .IsUnique();

                entity.Property(e => e.Pk)
                    .HasPrecision(19)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_");

                entity.Property(e => e.Accountcontractcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTCONTRACTCODE_");

                entity.Property(e => e.Accountcontractpk)
                    .HasPrecision(19)
                    .HasColumnName("ACCOUNTCONTRACTPK_");

                entity.Property(e => e.Accountnumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTNUMBER_");

                entity.Property(e => e.Accountrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ACCOUNTRIB_");

                entity.Property(e => e.Affecteduser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AFFECTEDUSER_");

                entity.Property(e => e.Affectiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("AFFECTIONDATE_");

                entity.Property(e => e.Autoprocess)
                    .HasPrecision(1)
                    .HasColumnName("AUTOPROCESS_");

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BANKCODE_");

                entity.Property(e => e.Bankpk)
                    .HasPrecision(19)
                    .HasColumnName("BANKPK_");

                entity.Property(e => e.Beneficiaryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYNAME_");

                entity.Property(e => e.Beneficiaryrib)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BENEFICIARYRIB_");

                entity.Property(e => e.Cdate)
                    .HasPrecision(6)
                    .HasColumnName("CDATE_");

                entity.Property(e => e.Clearingdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CLEARINGDATE_");

                entity.Property(e => e.Clearinglock)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLEARINGLOCK_");

                entity.Property(e => e.Clearingpk)
                    .HasPrecision(19)
                    .HasColumnName("CLEARINGPK_");

                entity.Property(e => e.Clientidentifier)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTIDENTIFIER_");

                entity.Property(e => e.Codeemetteur)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODEEMETTEUR_");

                entity.Property(e => e.Codelabel)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CODELABEL_");

                entity.Property(e => e.Compensecentralpk)
                    .HasPrecision(19)
                    .HasColumnName("COMPENSECENTRALPK_");

                entity.Property(e => e.Currencycode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CURRENCYCODE_");

                entity.Property(e => e.Currencypk)
                    .HasPrecision(19)
                    .HasColumnName("CURRENCYPK_");

                entity.Property(e => e.Cuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CUSER_");

                entity.Property(e => e.Dealingroomdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEALINGROOMDATE_");

                entity.Property(e => e.Dealingroomgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMGROSSAMOUNT_");

                entity.Property(e => e.Dealingroomnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMNETAMOUNT_");

                entity.Property(e => e.Dealingroomrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMRATE_");

                entity.Property(e => e.Dealingroomreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEALINGROOMREFERENCE_");

                entity.Property(e => e.Dealingroomtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALCOMMISSION_");

                entity.Property(e => e.Dealingroomtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("DEALINGROOMTOTALVAT_");

                entity.Property(e => e.Depositname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DEPOSITNAME_");

                entity.Property(e => e.Draft)
                    .HasPrecision(1)
                    .HasColumnName("DRAFT_");

                entity.Property(e => e.Eventtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EVENTTYPECODE_");

                entity.Property(e => e.Eventtypepk)
                    .HasPrecision(19)
                    .HasColumnName("EVENTTYPEPK_");

                entity.Property(e => e.Exempttype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EXEMPTTYPE_");

                entity.Property(e => e.Extreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXTREFERENCE_");

                entity.Property(e => e.Force)
                    .HasPrecision(1)
                    .HasColumnName("FORCE_");

                entity.Property(e => e.Freetext)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FREETEXT_");

                entity.Property(e => e.Fromcentralservice)
                    .HasPrecision(1)
                    .HasColumnName("FROMCENTRALSERVICE_");

                entity.Property(e => e.Fromclearing)
                    .HasPrecision(1)
                    .HasColumnName("FROMCLEARING_");

                entity.Property(e => e.Fromcompense)
                    .HasPrecision(1)
                    .HasColumnName("FROMCOMPENSE_");

                entity.Property(e => e.Fromsbe)
                    .HasPrecision(1)
                    .HasColumnName("FROMSBE_");

                entity.Property(e => e.Fxgrossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXGROSSAMOUNT_");

                entity.Property(e => e.Fxnetamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXNETAMOUNT_");

                entity.Property(e => e.Fxrate)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXRATE_");

                entity.Property(e => e.Fxtotalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALCOMMISSION_");

                entity.Property(e => e.Fxtotalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("FXTOTALVAT_");

                entity.Property(e => e.Grossamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("GROSSAMOUNT_");

                entity.Property(e => e.Isdeal)
                    .HasPrecision(1)
                    .HasColumnName("ISDEAL_");

                entity.Property(e => e.Locked)
                    .HasPrecision(1)
                    .HasColumnName("LOCKED_");

                entity.Property(e => e.Mandatorycodes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MANDATORYCODES_");

                entity.Property(e => e.Maturitydate)
                    .HasColumnType("DATE")
                    .HasColumnName("MATURITYDATE_");

                entity.Property(e => e.Negociateexchange)
                    .HasPrecision(1)
                    .HasColumnName("NEGOCIATEEXCHANGE_");

                entity.Property(e => e.Netamount)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("NETAMOUNT_");

                entity.Property(e => e.Nrem)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NREM_");

                entity.Property(e => e.Ntrans)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NTRANS_");

                entity.Property(e => e.Numtranche)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NUMTRANCHE_");

                entity.Property(e => e.Objet)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OBJET_");

                entity.Property(e => e.Operationtypecode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPERATIONTYPECODE_");

                entity.Property(e => e.Operationtypepk)
                    .HasPrecision(19)
                    .HasColumnName("OPERATIONTYPEPK_");

                entity.Property(e => e.Opetypeintracible)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPETYPEINTRACIBLE_");

                entity.Property(e => e.Opetypeintrasource)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("OPETYPEINTRASOURCE_");

                entity.Property(e => e.Paymentdocnum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTDOCNUM_");

                entity.Property(e => e.Paymentdocreference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENTDOCREFERENCE_");

                entity.Property(e => e.Plvauthcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PLVAUTHCODE_");

                entity.Property(e => e.Plvauthpk)
                    .HasPrecision(19)
                    .HasColumnName("PLVAUTHPK_");

                entity.Property(e => e.Rcppk)
                    .HasPrecision(19)
                    .HasColumnName("RCPPK_");

                entity.Property(e => e.Receivedvaluedate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEIVEDVALUEDATE_");

                entity.Property(e => e.Receptiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("RECEPTIONDATE_");

                entity.Property(e => e.Reference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCE_");

                entity.Property(e => e.Referencerio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCERIO_");

                entity.Property(e => e.Rejectcodereasons)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REJECTCODEREASONS_");

                entity.Property(e => e.Rejectdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REJECTDATE_");

                entity.Property(e => e.Relatedprelevementpk)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("RELATEDPRELEVEMENTPK_");

                entity.Property(e => e.Restournecommission)
                    .HasPrecision(1)
                    .HasColumnName("RESTOURNECOMMISSION_");

                entity.Property(e => e.Reversalreason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REVERSALREASON_");

                entity.Property(e => e.Spotdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SPOTDATE_");

                entity.Property(e => e.Status)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_");

                entity.Property(e => e.Totalcommission)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALCOMMISSION_");

                entity.Property(e => e.Totalstamp)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALSTAMP_");

                entity.Property(e => e.Totaltaf)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALTAF_");

                entity.Property(e => e.Totalvat)
                    .HasColumnType("NUMBER(19,4)")
                    .HasColumnName("TOTALVAT_");

                entity.Property(e => e.Tradedate)
                    .HasColumnType("DATE")
                    .HasColumnName("TRADEDATE_");

                entity.Property(e => e.Transitiondate)
                    .HasPrecision(6)
                    .HasColumnName("TRANSITIONDATE_");

                entity.Property(e => e.Udate)
                    .HasPrecision(6)
                    .HasColumnName("UDATE_");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UNITCODE_");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("UUSER_");

                entity.Property(e => e.Validatecomptereg)
                    .HasPrecision(1)
                    .HasColumnName("VALIDATECOMPTEREG_");

                entity.Property(e => e.Validationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("VALIDATIONDATE_");

                entity.Property(e => e.Validationprocessname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONPROCESSNAME_");

                entity.Property(e => e.Validationspk)
                    .HasPrecision(19)
                    .HasColumnName("VALIDATIONSPK_");

                entity.Property(e => e.Validationstepname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONSTEPNAME_");

                entity.Property(e => e.Validationuser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("VALIDATIONUSER_");

                entity.Property(e => e.Versionnum)
                    .HasPrecision(10)
                    .HasColumnName("VERSIONNUM_");

                entity.HasOne(d => d.AccountcontractpkNavigation)
                    .WithMany(p => p.Recvplvs)
                    .HasForeignKey(d => d.Accountcontractpk)
                    .HasConstraintName("F_VPLVACCO_OQ83UV");
            });

          



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

