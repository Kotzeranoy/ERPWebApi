using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ERPWebApi.Models;

public partial class ErpdbconnectContext : DbContext
{
    public ErpdbconnectContext()
    {
    }

    public ErpdbconnectContext(DbContextOptions<ErpdbconnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TCb> TCbs { get; set; }

    public virtual DbSet<Tbank> Tbanks { get; set; }

    public virtual DbSet<TbankEmp> TbankEmps { get; set; }

    public virtual DbSet<TbankPartner> TbankPartners { get; set; }

    public virtual DbSet<Tcategory> Tcategories { get; set; }

    public virtual DbSet<TdeliveryNote> TdeliveryNotes { get; set; }

    public virtual DbSet<TdnDetail> TdnDetails { get; set; }

    public virtual DbSet<TempPosition> TempPositions { get; set; }

    public virtual DbSet<TempStatus> TempStatuses { get; set; }

    public virtual DbSet<Temployee> Temployees { get; set; }

    public virtual DbSet<TgoodReceipt> TgoodReceipts { get; set; }

    public virtual DbSet<TgrDetail> TgrDetails { get; set; }

    public virtual DbSet<Tgrpayperiod> Tgrpayperiods { get; set; }

    public virtual DbSet<Tmaterial> Tmaterials { get; set; }

    public virtual DbSet<Tpartner> Tpartners { get; set; }

    public virtual DbSet<TpoDetail> TpoDetails { get; set; }

    public virtual DbSet<Tpopayperiod> Tpopayperiods { get; set; }

    public virtual DbSet<TprDetail> TprDetails { get; set; }

    public virtual DbSet<TpreiodDetail> TpreiodDetails { get; set; }

    public virtual DbSet<Tproject> Tprojects { get; set; }

    public virtual DbSet<TprojectPeriod> TprojectPeriods { get; set; }

    public virtual DbSet<Tprpayperiod> Tprpayperiods { get; set; }

    public virtual DbSet<TpurchaseOrder> TpurchaseOrders { get; set; }

    public virtual DbSet<TpurchaseRequest> TpurchaseRequests { get; set; }

    public virtual DbSet<Trn> Trns { get; set; }

    public virtual DbSet<TrnDetail> TrnDetails { get; set; }

    public virtual DbSet<Tunit> Tunits { get; set; }

    public virtual DbSet<Tunitconvert> Tunitconverts { get; set; }

    public virtual DbSet<TwdDetail> TwdDetails { get; set; }

    public virtual DbSet<Twithdraw> Twithdraws { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ERPDBConnect;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TCb>(entity =>
        {
            entity.HasKey(e => e.Cbscode);

            entity.ToTable("T_CBS");

            entity.Property(e => e.Cbscode)
                .HasMaxLength(50)
                .HasColumnName("CBSCode");
            entity.Property(e => e.Cbsdescription).HasColumnName("CBSDescription");
            entity.Property(e => e.Cbslevel).HasColumnName("CBSLevel");
            entity.Property(e => e.Cbsname)
                .HasMaxLength(150)
                .HasColumnName("CBSName");
            entity.Property(e => e.Cbsparent)
                .HasMaxLength(50)
                .HasColumnName("CBSParent");
        });

        modelBuilder.Entity<Tbank>(entity =>
        {
            entity.HasKey(e => e.BankId);

            entity.ToTable("TBank");

            entity.Property(e => e.BankId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BankID");
            entity.Property(e => e.BankAbbreviation)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.BankName).HasMaxLength(150);
        });

        modelBuilder.Entity<TbankEmp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBankEmp");

            entity.Property(e => e.AccounName).HasMaxLength(150);
            entity.Property(e => e.AccountBranch).HasMaxLength(150);
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.BankId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BankID");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");

            entity.HasOne(d => d.Bank).WithMany()
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_TBankEmp_TBank");

            entity.HasOne(d => d.Emp).WithMany()
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TBankEmp_TEmployee");
        });

        modelBuilder.Entity<TbankPartner>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TBankPartner");

            entity.Property(e => e.AccounName).HasMaxLength(150);
            entity.Property(e => e.AccountBranch).HasMaxLength(150);
            entity.Property(e => e.AccountNo1).HasMaxLength(50);
            entity.Property(e => e.BankId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BankID");
            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");

            entity.HasOne(d => d.Bank).WithMany()
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_TBankPartner_TBank");

            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_TBankPartner_TPartner");
        });


        modelBuilder.Entity<Tcategory>(entity =>
        {
            entity.HasMany(c => c.SubCategories)
                .WithOne()
                .HasForeignKey(c => c.CatParent)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasKey(e => e.CatCode);

            entity.ToTable("TCategory");

            entity.Property(e => e.CatCode).HasMaxLength(50);
            entity.Property(e => e.CatName).HasMaxLength(100);
            entity.Property(e => e.CatParent).HasMaxLength(50);
            entity.Property(e => e.Cbscode)
                .HasMaxLength(50)
                .HasColumnName("CBSCode");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");

            entity.HasOne(d => d.CbscodeNavigation).WithMany(p => p.Tcategories)
                .HasForeignKey(d => d.Cbscode)
                .HasConstraintName("FK_TCategory_T_CBS");

            entity.HasOne(d => d.Emp).WithMany(p => p.Tcategories)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TCategory_TEmployee");

        });

        modelBuilder.Entity<TdeliveryNote>(entity =>
        {
            entity.HasKey(e => e.Dnno);

            entity.ToTable("TDeliveryNote");

            entity.Property(e => e.Dnno)
                .HasMaxLength(20)
                .HasColumnName("DNNo");
            entity.Property(e => e.CarRegNo).HasMaxLength(50);
            entity.Property(e => e.Deliverer).HasMaxLength(200);
            entity.Property(e => e.DncarId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DNCarID");
            entity.Property(e => e.Dndatetime)
                .HasColumnType("datetime")
                .HasColumnName("DNDatetime");
            entity.Property(e => e.Dnremark).HasColumnName("DNRemark");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.ProjectDestination).HasMaxLength(50);
            entity.Property(e => e.ProjectOrigin).HasMaxLength(50);
        });

        modelBuilder.Entity<TdnDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TDN_Detail");

            entity.Property(e => e.Dnno)
                .HasMaxLength(20)
                .HasColumnName("DNno");
            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");
        });

        modelBuilder.Entity<TempPosition>(entity =>
        {
            entity.HasKey(e => e.EmpPositionId);

            entity.ToTable("TEmpPosition");

            entity.Property(e => e.EmpPositionId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpPositionID");
            entity.Property(e => e.EmpPositionName).HasMaxLength(50);
        });

        modelBuilder.Entity<TempStatus>(entity =>
        {
            entity.HasKey(e => e.EmpStatusId);

            entity.ToTable("TEmpStatus");

            entity.Property(e => e.EmpStatusId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpStatusID");
            entity.Property(e => e.EmpStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Temployee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("TEmployee");

            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.EmpFirstname).HasMaxLength(100);
            entity.Property(e => e.EmpImage).HasColumnType("image");
            entity.Property(e => e.EmpLastname).HasMaxLength(100);
            entity.Property(e => e.EmpOthername).HasMaxLength(100);
            entity.Property(e => e.EmpPassword).HasMaxLength(50);
            entity.Property(e => e.EmpPositionId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpPositionID");
            entity.Property(e => e.EmpStatusId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpStatusID");
            entity.Property(e => e.EmpTelephone).HasMaxLength(50);
            entity.Property(e => e.EmpUsername).HasMaxLength(50);

            entity.HasOne(d => d.EmpPosition).WithMany(p => p.Temployees)
                .HasForeignKey(d => d.EmpPositionId)
                .HasConstraintName("FK_TEmployee_TEmpPosition");

            entity.HasOne(d => d.EmpStatus).WithMany(p => p.Temployees)
                .HasForeignKey(d => d.EmpStatusId)
                .HasConstraintName("FK_TEmployee_TEmpStatus");
        });

        modelBuilder.Entity<TgoodReceipt>(entity =>
        {
            entity.HasKey(e => e.Grno).HasName("PK_TGR");

            entity.ToTable("TGood_Receipt");

            entity.Property(e => e.Grno)
                .HasMaxLength(50)
                .HasColumnName("GRNo");
            entity.Property(e => e.Dodate).HasColumnName("DODate");
            entity.Property(e => e.Dono)
                .HasMaxLength(50)
                .HasColumnName("DONo");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.Grdate)
                .HasColumnType("datetime")
                .HasColumnName("GRDate");
            entity.Property(e => e.GrpayCreditDate).HasColumnName("GRPayCreditDate");
            entity.Property(e => e.GrpayMethod).HasColumnName("GRPayMethod");
            entity.Property(e => e.GrpayTerm).HasColumnName("GRPayTerm");
            entity.Property(e => e.Grremark).HasColumnName("GRRemark");
            entity.Property(e => e.GrspecialDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GRSpecialDiscount");
            entity.Property(e => e.Grsubtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GRSubtotal");
            entity.Property(e => e.Grtotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("GRTotal");
            entity.Property(e => e.Grvat).HasColumnName("GRVat");
            entity.Property(e => e.GrvatValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GRVatValue");
            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(50)
                .HasColumnName("ProjectID");

            entity.HasOne(d => d.Emp).WithMany(p => p.TgoodReceipts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TGood_Receipt_TEmployee");

            entity.HasOne(d => d.Partner).WithMany(p => p.TgoodReceipts)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_TGood_Receipt_TPartner");

            entity.HasOne(d => d.PonoNavigation).WithMany(p => p.TgoodReceipts)
                .HasForeignKey(d => d.Pono)
                .HasConstraintName("FK_TGood_Receipt_TPurchase_Order");

            entity.HasOne(d => d.Project).WithMany(p => p.TgoodReceipts)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TGood_Receipt_TProject");
        });

        modelBuilder.Entity<TgrDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TGR_Detail");

            entity.Property(e => e.CatCode).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gritem).HasColumnName("GRItem");
            entity.Property(e => e.Grno)
                .HasMaxLength(50)
                .HasColumnName("GRNo");
            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");

            entity.HasOne(d => d.CatCodeNavigation).WithMany()
                .HasForeignKey(d => d.CatCode)
                .HasConstraintName("FK_TGR_Detail_TCategory");

            entity.HasOne(d => d.GrnoNavigation).WithMany()
                .HasForeignKey(d => d.Grno)
                .HasConstraintName("FK_TGR_Detail_TGood_Receipt");

            entity.HasOne(d => d.MatCodeNavigation).WithMany()
                .HasForeignKey(d => d.MatCode)
                .HasConstraintName("FK_TGR_Detail_TMaterial");

            entity.HasOne(d => d.Unit).WithMany()
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_TGR_Detail_TUnit");
        });

        modelBuilder.Entity<Tgrpayperiod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TGRPayperiod");

            entity.Property(e => e.Grno)
                .HasMaxLength(50)
                .HasColumnName("GRNo");
            entity.Property(e => e.GrpayValue)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("GRPayValue");
            entity.Property(e => e.Grpaymethod).HasColumnName("GRPaymethod");
            entity.Property(e => e.Grpayperiod).HasColumnName("GRPayperiod");

            entity.HasOne(d => d.GrnoNavigation).WithMany()
                .HasForeignKey(d => d.Grno)
                .HasConstraintName("FK_TGRPayperiod_TGood_Receipt");
        });

        modelBuilder.Entity<Tmaterial>(entity =>
        {
            entity.HasKey(e => e.MatCode);

            entity.ToTable("TMaterial");

            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.CatCode).HasMaxLength(50);
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.MatName).HasMaxLength(100);
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");

            entity.HasOne(d => d.CatCodeNavigation).WithMany(p => p.Tmaterials)
                .HasForeignKey(d => d.CatCode)
                .HasConstraintName("FK_TMaterial_TCategory");

            entity.HasOne(d => d.Emp).WithMany(p => p.Tmaterials)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TMaterial_TEmployee");

            entity.HasOne(d => d.Unit).WithMany(p => p.Tmaterials)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_TMaterial_TUnit");
        });

        modelBuilder.Entity<Tpartner>(entity =>
        {
            entity.HasKey(e => e.PartnerId);

            entity.ToTable("TPartner");

            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");
            entity.Property(e => e.PartnerEmail).HasMaxLength(150);
            entity.Property(e => e.PartnerFax).HasMaxLength(50);
            entity.Property(e => e.PartnerName).HasMaxLength(150);
            entity.Property(e => e.PartnerOthername).HasMaxLength(150);
            entity.Property(e => e.PartnerTaxId)
                .HasMaxLength(50)
                .HasColumnName("PartnerTaxID");
            entity.Property(e => e.PartnerTelephone).HasMaxLength(50);
            entity.Property(e => e.PartnerZipcode)
                .HasMaxLength(5)
                .IsFixedLength();
        });

        modelBuilder.Entity<TpoDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TPO_Detail");

            entity.Property(e => e.CatCode).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Poitem).HasColumnName("POItem");
            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Prno)
                .HasMaxLength(50)
                .HasColumnName("PRNo");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");

            entity.HasOne(d => d.CatCodeNavigation).WithMany()
                .HasForeignKey(d => d.CatCode)
                .HasConstraintName("FK_TPO_Detail_TCategory");

            entity.HasOne(d => d.MatCodeNavigation).WithMany()
                .HasForeignKey(d => d.MatCode)
                .HasConstraintName("FK_TPO_Detail_TMaterial");

            entity.HasOne(d => d.PonoNavigation).WithMany()
                .HasForeignKey(d => d.Pono)
                .HasConstraintName("FK_TPO_Detail_TPurchase_Order");

            entity.HasOne(d => d.Unit).WithMany()
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_TPO_Detail_TUnit");
        });

        modelBuilder.Entity<Tpopayperiod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TPOPayperiod");

            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.PopayValue)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("POPayValue");
            entity.Property(e => e.Popaymethod).HasColumnName("POPaymethod");
            entity.Property(e => e.Popayperiod).HasColumnName("POPayperiod");

            entity.HasOne(d => d.PonoNavigation).WithMany()
                .HasForeignKey(d => d.Pono)
                .HasConstraintName("FK_TPOPayperiod_TPurchase_Order");
        });

        modelBuilder.Entity<TprDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TPR_Detail");

            entity.Property(e => e.CatCode).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Pritem).HasColumnName("PRItem");
            entity.Property(e => e.Prno)
                .HasMaxLength(50)
                .HasColumnName("PRNo");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");

            entity.HasOne(d => d.CatCodeNavigation).WithMany()
                .HasForeignKey(d => d.CatCode)
                .HasConstraintName("FK_TPR_Detail_TCategory");

            entity.HasOne(d => d.MatCodeNavigation).WithMany()
                .HasForeignKey(d => d.MatCode)
                .HasConstraintName("FK_TPR_Detail_TMaterial");

            entity.HasOne(d => d.PrnoNavigation).WithMany()
                .HasForeignKey(d => d.Prno)
                .HasConstraintName("FK_TPR_Detail_TPurchase_Request");

            entity.HasOne(d => d.Unit).WithMany()
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FK_TPR_Detail_TUnit");
        });

        modelBuilder.Entity<TpreiodDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TPreiodDetail");

            entity.Property(e => e.PeriodAdvance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PeriodItem).HasMaxLength(50);
            entity.Property(e => e.PeriodName).HasMaxLength(250);
            entity.Property(e => e.PeriodValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PreiodRetention).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PreiodSubtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectPeriodId)
                .HasMaxLength(50)
                .HasColumnName("ProjectPeriodID");

            entity.HasOne(d => d.ProjectPeriod).WithMany()
                .HasForeignKey(d => d.ProjectPeriodId)
                .HasConstraintName("FK_TPreiodDetail_TProjectPeriod");
        });

        modelBuilder.Entity<Tproject>(entity =>
        {
            entity.HasKey(e => e.ProjectId);

            entity.ToTable("TProject");

            entity.Property(e => e.ProjectId)
                .HasMaxLength(50)
                .HasColumnName("ProjectID");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");
            entity.Property(e => e.ProjectBiddingValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectBudgetValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectCommitValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectContactNo).HasMaxLength(50);
            entity.Property(e => e.ProjectContactValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectEmail).HasMaxLength(100);
            entity.Property(e => e.ProjectParent).HasMaxLength(50);
            entity.Property(e => e.ProjectTelephone).HasMaxLength(50);

            entity.HasOne(d => d.Emp).WithMany(p => p.Tprojects)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TProject_TEmployee");

            entity.HasOne(d => d.Partner).WithMany(p => p.Tprojects)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_TProject_TPartner");
        });

        modelBuilder.Entity<TprojectPeriod>(entity =>
        {
            entity.HasKey(e => e.ProjectPeriodId);

            entity.ToTable("TProjectPeriod");

            entity.Property(e => e.ProjectPeriodId)
                .HasMaxLength(50)
                .HasColumnName("ProjectPeriodID");
            entity.Property(e => e.Advance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.ContactValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectId).HasMaxLength(50);
            entity.Property(e => e.Retention).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Project).WithMany(p => p.TprojectPeriods)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TProjectPeriod_TProject");
        });

        modelBuilder.Entity<Tprpayperiod>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TPRPayperiod");

            entity.Property(e => e.Prno)
                .HasMaxLength(50)
                .HasColumnName("PRNo");
            entity.Property(e => e.PrpayValue)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("PRPayValue");
            entity.Property(e => e.Prpaymethod).HasColumnName("PRPaymethod");
            entity.Property(e => e.Prpayperiod).HasColumnName("PRPayperiod");

            entity.HasOne(d => d.PrnoNavigation).WithMany()
                .HasForeignKey(d => d.Prno)
                .HasConstraintName("FK_TPRPayperiod_TPurchase_Request");
        });

        modelBuilder.Entity<TpurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Pono).HasName("PK_TPO");

            entity.ToTable("TPurchase_Order");

            entity.Property(e => e.Pono)
                .HasMaxLength(50)
                .HasColumnName("PONo");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");
            entity.Property(e => e.Podate)
                .HasColumnType("datetime")
                .HasColumnName("PODate");
            entity.Property(e => e.PopayCreditDate).HasColumnName("POPayCreditDate");
            entity.Property(e => e.PopayMethod).HasColumnName("POPayMethod");
            entity.Property(e => e.PopayTerm).HasColumnName("POPayTerm");
            entity.Property(e => e.Poremark).HasColumnName("PORemark");
            entity.Property(e => e.PospecialDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("POSpecialDiscount");
            entity.Property(e => e.Posubtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("POSubtotal");
            entity.Property(e => e.Pototal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("POTotal");
            entity.Property(e => e.Povat).HasColumnName("POVat");
            entity.Property(e => e.PovatValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("POVatValue");
            entity.Property(e => e.Prno)
                .HasMaxLength(50)
                .HasColumnName("PRNo");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(50)
                .HasColumnName("ProjectID");

            entity.HasOne(d => d.Emp).WithMany(p => p.TpurchaseOrders)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TPurchase_Order_TEmployee");

            entity.HasOne(d => d.Partner).WithMany(p => p.TpurchaseOrders)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_TPurchase_Order_TPartner");

            entity.HasOne(d => d.Project).WithMany(p => p.TpurchaseOrders)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TPurchase_Order_TProject");
        });

        modelBuilder.Entity<TpurchaseRequest>(entity =>
        {
            entity.HasKey(e => e.Prno).HasName("PK_TPR");

            entity.ToTable("TPurchase_Request");

            entity.Property(e => e.Prno)
                .HasMaxLength(50)
                .HasColumnName("PRNo");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.PartnerId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("PartnerID");
            entity.Property(e => e.Prdate)
                .HasColumnType("datetime")
                .HasColumnName("PRDate");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(50)
                .HasColumnName("ProjectID");
            entity.Property(e => e.PrpayCreditDate).HasColumnName("PRPayCreditDate");
            entity.Property(e => e.PrpayMethod).HasColumnName("PRPayMethod");
            entity.Property(e => e.PrpayTerm).HasColumnName("PRPayTerm");
            entity.Property(e => e.Prremark).HasColumnName("PRRemark");
            entity.Property(e => e.PrspecialDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRSpecialDiscount");
            entity.Property(e => e.Prsubtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRSubtotal");
            entity.Property(e => e.Prtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRTotal");
            entity.Property(e => e.Prvat).HasColumnName("PRVat");
            entity.Property(e => e.PrvatValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRVatValue");

            entity.HasOne(d => d.Emp).WithMany(p => p.TpurchaseRequests)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TPurchase_Request_TEmployee");

            entity.HasOne(d => d.Partner).WithMany(p => p.TpurchaseRequests)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("FK_TPurchase_Request_TPartner");

            entity.HasOne(d => d.Project).WithMany(p => p.TpurchaseRequests)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TPurchase_Request_TProject");
        });

        modelBuilder.Entity<Trn>(entity =>
        {
            entity.HasKey(e => e.Rnno);

            entity.ToTable("TRN");

            entity.Property(e => e.Rnno)
                .HasMaxLength(20)
                .HasColumnName("RNNo");
            entity.Property(e => e.Dnno)
                .HasMaxLength(20)
                .HasColumnName("DNNo");
            entity.Property(e => e.Dnremark).HasColumnName("DNRemark");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.ProjectDestination).HasMaxLength(50);
            entity.Property(e => e.ProjectOrigin).HasMaxLength(50);
            entity.Property(e => e.Recipient).HasMaxLength(200);
            entity.Property(e => e.Rndatetime)
                .HasColumnType("datetime")
                .HasColumnName("RNDatetime");
        });

        modelBuilder.Entity<TrnDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TRN_Detail");

            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rnno)
                .HasMaxLength(20)
                .HasColumnName("RNNo");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");
        });

        modelBuilder.Entity<Tunit>(entity =>
        {
            entity.HasKey(e => e.UnitId);

            entity.ToTable("TUnit");

            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");
            entity.Property(e => e.UnitName).HasMaxLength(50);
            entity.Property(e => e.UnitType)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Tunitconvert>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TUnitconvert");

            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.UnitBase)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitBaseAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitConvert)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UnitConvertAmount).HasColumnType("numeric(18, 2)");

            entity.HasOne(d => d.MatCodeNavigation).WithMany()
                .HasForeignKey(d => d.MatCode)
                .HasConstraintName("FK_TUnitconvert_TMaterial");

            entity.HasOne(d => d.UnitBaseNavigation).WithMany()
                .HasForeignKey(d => d.UnitBase)
                .HasConstraintName("FK_TUnitconvert_TUnit");

            entity.HasOne(d => d.UnitConvertNavigation).WithMany()
                .HasForeignKey(d => d.UnitConvert)
                .HasConstraintName("FK_TUnitconvert_TUnit1");
        });

        modelBuilder.Entity<TwdDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TWD_Detail");

            entity.Property(e => e.MatCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UnitID");
            entity.Property(e => e.Wdno)
                .HasMaxLength(20)
                .HasColumnName("WDNo");
        });

        modelBuilder.Entity<Twithdraw>(entity =>
        {
            entity.HasKey(e => e.Wdno);

            entity.ToTable("TWithdraw");

            entity.Property(e => e.Wdno)
                .HasMaxLength(20)
                .HasColumnName("WDNo");
            entity.Property(e => e.Dnremark).HasColumnName("DNRemark");
            entity.Property(e => e.Drawer).HasMaxLength(150);
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("EmpID");
            entity.Property(e => e.ProjectId).HasMaxLength(50);
            entity.Property(e => e.Wddatetime)
                .HasColumnType("datetime")
                .HasColumnName("WDDatetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
