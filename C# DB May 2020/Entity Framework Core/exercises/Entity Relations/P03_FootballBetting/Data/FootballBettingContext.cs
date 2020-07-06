namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FootballBettingContext: DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions<FootballBettingContext> options)
            :base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"server=DESKTOP-KQ9J3DG\SQLEXPRESS;Database=FootballBetting;Integrated Security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>(entity =>
            {
                entity
                .HasKey(pk => pk.TeamId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(p => p.LogoUrl)
                .IsRequired()
                .IsUnicode();

                entity
                .Property(p => p.Initials)
                .HasMaxLength(3)
                .IsRequired()
                .IsUnicode(false);

                entity
                .HasOne(pkc => pkc.PrimaryKitColor)
                .WithMany(pkc => pkc.PrimaryKitTeams)
                .HasForeignKey(fk => fk.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(e => e.SecondaryKitColor)
                .WithMany(skc => skc.SecondaryKitTeams)
                .HasForeignKey(fk => fk.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Color>(entity =>
            {
                entity
                .HasKey(pk => pk.ColorId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });
            builder.Entity<Country>(entity =>
            {
                entity
                .HasKey(pk => pk.CountryId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

                entity.HasMany(t => t.Towns)
                .WithOne(c => c.Country)
                .HasForeignKey(fk => fk.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Town>(entity =>
            {
                entity
                .HasKey(pk => pk.TownId);

                entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

                entity.HasMany(t => t.Teams)
                .WithOne(t => t.Town)
                .HasForeignKey(fk => fk.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            });
            builder.Entity<Player>(entity =>
            {
                entity
                .HasKey(pk => pk.PlayerId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

                entity
                .Property(p => p.SquadNumber)
                .IsRequired();

                entity
                .HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.PositionId);

                entity
                .HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.TeamId);
            });
            builder.Entity<Position>(entity =>
            {
                entity
                .HasKey(pk => pk.PositionId);

                entity
                .Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(30);
            });
            builder.Entity<Game>(entity =>
            {
                entity
                .HasKey(pk => pk.GameId);

                entity
                .Property(p => p.AwayTeamBetRate)
                .IsRequired();

                entity
                .Property(p => p.AwayTeamGoals)
                .IsRequired();

                entity
                .Property(p => p.DrawBetRate)
                .IsRequired();

                entity
                .Property(p => p.HomeTeamBetRate)
                .IsRequired();

                entity
                .Property(p => p.HomeTeamGoals)
                .IsRequired();

                entity
                .Property(p => p.Result)
                .HasMaxLength(20)
                .IsRequired();

                entity
                .Property(p => p.DateTime)
                .IsRequired();

                entity
                .HasOne(t => t.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(fk => fk.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
               .HasOne(t => t.AwayTeam)
               .WithMany(g => g.AwayGames)
               .HasForeignKey(fk => fk.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<PlayerStatistic>(entity =>
            {
                entity
                .HasKey(pk => new { pk.GameId, pk.PlayerId });

                entity
                .HasOne(p => p.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(fk => fk.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(p => p.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(fk => fk.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<User>(entity =>
            {
                entity
                .HasKey(pk => pk.UserId);

                entity
                .Property(p => p.Balance)
                .IsRequired();

                entity
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode();

                entity
                .Property(p => p.Name)
                .HasMaxLength(40)
                .IsUnicode(false);

                entity
                .Property(p => p.Password)
                .IsRequired()
                .IsUnicode(false);

                entity
                .Property(p => p.Username)
                .IsRequired()
                .IsUnicode(false);

                entity.HasMany(b => b.Bets)
                .WithOne(u => u.User)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Bet>(entity =>
            {
                entity
                .HasKey(pk => pk.BetId);

                entity
                .Property(p => p.Amount)
                .IsRequired();

                entity
                .Property(p => p.Prediction)
                .IsRequired();

                entity
                .Property(p => p.DateTime)
                .IsRequired();

                entity.HasOne(g => g.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.GameId)
                .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
