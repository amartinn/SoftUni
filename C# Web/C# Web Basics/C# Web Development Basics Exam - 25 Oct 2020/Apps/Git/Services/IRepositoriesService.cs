using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepositoryViewModel> GetAllPublicRepos();
        void Create(RepositoryCreateViewModel repo,string userId);
        RepositoryViewModel GetById(string repoId);
    }
}
