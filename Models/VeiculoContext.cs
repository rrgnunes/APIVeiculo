using Microsoft.EntityFrameworkCore;

namespace Backend.Models {
    public class VeiculoContext : DbContext {
        public VeiculoContext (DbContextOptions<VeiculoContext> options) : base (options) { }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
