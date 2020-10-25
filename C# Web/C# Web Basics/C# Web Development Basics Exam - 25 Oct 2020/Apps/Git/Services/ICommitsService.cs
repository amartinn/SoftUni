using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(CommitCreateInputViewModel model, string creatorId,string repositoryId);
        void DeleteById(string commitId );
        IEnumerable<CommitViewModel> GetAllByUserId(string userId);
        bool IsUserOwnerToCommit(string userId, string commitId);
    }
}
