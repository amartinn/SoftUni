using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(RepositoryCreateViewModel repo,string userId)
        {
            var repository = new Repository
            {
                IsPublic = repo.RepositoryType == "Public" ? true : false,
                Name = repo.Name,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId

            };
            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAllPublicRepos()
            => this.db.Repositories.Where(x => x.IsPublic)
                .Select(x => new RepositoryViewModel
                {
                    Id = x.Id,
                    CommitsCount = x.Commits.Count(),
                    Name = x.Name,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn.ToString("g")
                }).ToList();

        public RepositoryViewModel GetById(string repoId)
            => this.GetAllPublicRepos().FirstOrDefault(x => x.Id == repoId);
        
    }
}
