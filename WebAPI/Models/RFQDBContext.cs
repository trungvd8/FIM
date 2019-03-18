using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public partial class RFQDBContext : DbContext
    {
        public RFQDBContext(DbContextOptions<RFQDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ADGroup> ADGroups { get; set; }
        public virtual DbSet<BudgetGeography> BudgetGeography { get; set; }
        public virtual DbSet<CategoryOrganization> CategoryOrganizations { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<MasterContract> MasterContracts { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public virtual DbSet<ParentCategory> ParentCategories { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationByVendor> QuotationByVendors { get; set; }
        public virtual DbSet<RFQDetail> RFQDetails { get; set; }
        public virtual DbSet<RFQMailCC> RFQMailCCs { get; set; }
        public virtual DbSet<RFQWorkflow> RFQWorkflows { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public virtual DbSet<PRDetail> PRDetails { get; set; }
        public virtual DbSet<RequestForQuotation> RequestForQuotations { get; set; }
    }
}
