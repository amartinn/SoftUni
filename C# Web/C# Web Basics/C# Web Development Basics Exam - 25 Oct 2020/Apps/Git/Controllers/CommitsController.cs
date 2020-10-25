using Git.Data.Models;
using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController :Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService,IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }
        //GET Commits/Alls
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You should be logged in before seeing your commits!");
            }
            var userId = this.GetUserId();
            var commits = this.commitsService.GetAllByUserId(userId);
            return this.View(commits);
        }
        //GET Commits/Create
        public HttpResponse Create(string repositoryId)
        {
            var repository = this.repositoriesService.GetById(repositoryId);
            if (repository == null)
            {
                return this.Error("Please commit to an existing repository!");
            }
            if (!this.IsUserSignedIn())
            {
                return this.Error("Please login before creating a commit!");
            }
            var model = new CommitCreateViewModel
            {
                RepositoryId = repository.Id,
                RepositoryName = repository.Name,
            };
            return this.View(model);
        }
        [HttpPost]
        public HttpResponse Create(string repositoryId,CommitCreateInputViewModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Please login before creating a commit!");
            }

            if (model.Description.Length < 5 || string.IsNullOrWhiteSpace(model.Description))
            {
                return this.Error("Description is Required and should be longer thgan 5 characters!");
            }
            if (this.repositoriesService.GetById(repositoryId)==null)
            {
                return this.Redirect("/");
            }
            var creatorId = this.GetUserId();
            this.commitsService.Create(model, creatorId, repositoryId);
            return this.Redirect("/Repositories/All");
        }
        public HttpResponse Delete(string commitId)
        {

            var userId = this.GetUserId();
            if (userId==null)
            {
                return this.Error("Please login before deleting a commit!");
            }
            if (!this.commitsService.IsUserOwnerToCommit(userId,commitId))
            {
                return this.Error("You can delete only your own commits!");
            }
            this.commitsService.DeleteById(commitId);
            return this.Redirect("/Commits/All");
        }
       
    }
}
