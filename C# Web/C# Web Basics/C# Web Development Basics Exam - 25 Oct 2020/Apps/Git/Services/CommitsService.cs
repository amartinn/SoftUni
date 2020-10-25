using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(CommitCreateInputViewModel model, string creatorId,string repositoryId)
        {
            var commit = new Commit
            {
                Description = model.Description,
                CreatorId = creatorId,
                RepositoryId = repositoryId,
                CreatedOn = DateTime.UtcNow,
            };
            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public void DeleteById(string commitId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == commitId);
            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAllByUserId(string userId)
            => this.db.Commits.Where(x=>x.Creator.Id == userId)
            .Select(x => new CommitViewModel
            {
                RepositoryId = x.Repository.Id,
                RepositoryName = x.Repository.Name,
                Description = x.Description,
                CreatedOn = x.CreatedOn.ToString("g"),
                Id = x.Id,
            }).ToList();

        public bool IsUserOwnerToCommit(string userId, string commitId)
            => this.db.Users.Any(x => x.Id == userId && x.Commits.Any(x => x.Id == commitId));
    }
}
