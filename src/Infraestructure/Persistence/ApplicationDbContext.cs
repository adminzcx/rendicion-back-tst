using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Domain._Common;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.CashFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Infraestructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public readonly IDateTime _dateTime;

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;

            Database.Migrate();

        }

        #region Entities
        public DbSet<User> Users { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Management> Managements { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<SubZone> SubZones { get; set; }

        public DbSet<Zone> Zones { get; set; }

        public DbSet<Reason> Reasons { get; set; }

        public DbSet<Concept> Concepts { get; set; }

        public DbSet<Segment> Segments { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseUser> ExpenseUsers { get; set; }

        public DbSet<Source> Sources { get; set; }

        public DbSet<TechnicalVisit> TechnicalVisits { get; set; }

        public DbSet<ExpenseStatus> ExpenseStatus { get; set; }

        public DbSet<ExpenseFormStatus> ExpenseFormStatus { get; set; }

        public DbSet<ExpenseForm> ExpenseForms { get; set; }

        public DbSet<ExpenseStops> ExpenseStops { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<RejectReason> RejectReasons { get; set; }

        public DbSet<ExpenseFormAudit> ExpenseFormAudits { get; set; }

        public DbSet<UserSubstitution> UserSubstitutions { get; set; }

        public DbSet<PositionConfiguration> PositionConfigurations { get; set; }

        public DbSet<ExpenseFormComment> ExpenseFormComments { get; set; }

        public DbSet<ExpenseAdvice> ExpenseAdvices { get; set; }

        public DbSet<Organism> Organisms { get; set; }

        public DbSet<CashFormStatus> CashFormStatus { get; set; }

        public DbSet<MoneyType> MoneyTypes { get; set; }

        public DbSet<CashFormExpense> CashFormExpenses { get; set; }

        public DbSet<CashFormMoney> CashFormMoney { get; set; }

        public DbSet<CashForm> CashForms { get; set; }

        public DbSet<LunchStops> LunchStops { get; set; }

        public DbSet<CashConcept> CashConcepts { get; set; }

        public DbSet<CostCenter> CostCenters { get; set; }

        public DbSet<UserAbsenteeism> UserAbsenteeisms { get; set; }

        public DbSet<CashFormAmount> CashFormAmounts { get; set; }

        public DbSet<CashFormCapAmount> CashFormCapAmounts { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole();
            });


            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging();

        }
    }
}
