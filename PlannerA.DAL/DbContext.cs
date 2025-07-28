using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Client> clients { get; set; }
    public DbSet<Equipment> equipments { get; set; }
    public DbSet<Item> items { get; set; }
    public DbSet<Operation> operations { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<Person> persons { get; set; }
    public DbSet<Process> processes { get; set; }
    public DbSet<Worker> workers { get; set; }
    public DbContext() => Database.EnsureCreatedAsync();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(AppContext.connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("clients");
            entity.HasKey(e => e.client_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.address).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.email);
            entity.Property(e => e.worker_id).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.ToTable("equipments");
            entity.HasKey(e => e.equipment_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.model);
            entity.Property(e => e.manufacturer);
            entity.Property(e => e.parameters);
            entity.Property(e => e.price).IsRequired();
            entity.Property(e => e.date_of_purchase);
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("items");
            entity.HasKey(e => e.item_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.date_of_produce);
            entity.Property(e => e.parameters);
            entity.Property(e => e.price);
            entity.Property(e => e.quantity).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Operation>(entity =>
        {
            entity.ToTable("operations");
            entity.HasKey(e => e.operation_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.duration).IsRequired();
            entity.Property(e => e.parameters);
            entity.Property(e => e.cost).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");
            entity.HasKey(e => e.order_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.client_id).IsRequired();
            entity.Property(e => e.date_start).IsRequired();
            entity.Property(e => e.date_end_plan).IsRequired();
            entity.Property(e => e.date_end);
            entity.Property(e => e.total_cost).IsRequired();
            entity.Property(e => e.description);
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("persons");
            entity.HasKey(e => e.person_id);
            entity.Property(e => e.first_name).IsRequired();
            entity.Property(e => e.last_name).IsRequired();
            entity.Property(e => e.patronymic);
            entity.Property(e => e.date_of_birth).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.address).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Process>(entity =>
        {
            entity.ToTable("processes");
            entity.HasKey(e => e.process_id);
            entity.Property(e => e.order_id).IsRequired();
            entity.Property(e => e.operation_id).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<Worker>(entity =>
        {
            entity.ToTable("workers");
            entity.HasKey(e => e.worker_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.person_id).IsRequired();
            entity.Property(e => e.date_of_hire).IsRequired();
            entity.Property(e => e.date_of_separation);
            entity.Property(e => e.education);
            entity.Property(e => e.date_of_education_end);
            entity.Property(e => e.salary).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
        modelBuilder.Entity<OperationLinks>(entity =>
        {
            entity.ToTable("operation_links");
            entity.HasKey(e => e.id);
            entity.Property(e => e.operation_id).IsRequired();
            entity.Property(e => e.out_item_id).IsRequired();
            entity.Property(e => e.in_item_id).IsRequired();
            entity.Property(e => e.supply_item_id);
            entity.Property(e => e.tail_item_id);
        });
        modelBuilder.Entity<OrderLinks>(entity =>
        {
            entity.ToTable("order_links");
            entity.HasKey(e => e.order_id);
            entity.HasKey(e => e.item_id);
            entity.Property(e => e.quantity).IsRequired();
        });
        modelBuilder.Entity<ProcessLinks>(entity =>
        {
            entity.ToTable("process_links");
            entity.HasKey(e => e.id);
            entity.Property(e => e.process_id).IsRequired();
            entity.Property(e => e.working_unit_id).IsRequired();
        });
        modelBuilder.Entity<WorkingUnit>(entity =>
        {
            entity.ToTable("working_units");
            entity.HasKey(e => e.working_unit_id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.worker_id).IsRequired();
            entity.Property(e => e.equipment_id).IsRequired();
            entity.Property(e => e.is_active).IsRequired();
        });
    }
}