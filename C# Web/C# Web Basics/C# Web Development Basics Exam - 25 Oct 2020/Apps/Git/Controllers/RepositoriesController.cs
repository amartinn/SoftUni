using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController :Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }
        //GET Repositories/All
        public HttpResponse All()
        {
            var repositories = this.repositoriesService.GetAllPublicRepos();
            return this.View(repositories);
        }
        //GET Repositories/Create
        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Please login before creating a repository!");
            }
            return this.View();
        }
        [HttpPost]
        public HttpResponse Create(RepositoryCreateViewModel model)
        {
            ;
            if (!this.IsUserSignedIn())
            {
                return this.Error("Please login before creating a repository!");
            }
            if ((model.Name.Length <3 || model.Name.Length > 10) || string.IsNullOrWhiteSpace(model.Name))
            {
                return this.Error("Repository name is required and should be between 3 and 10 characters!");
            }
            if (string.IsNullOrWhiteSpace(model.RepositoryType) || (model.RepositoryType!="Public" && model.RepositoryType!="Private"))
            {
                return this.Error("Repository type is required!");
            }
            var ownerId = this.GetUserId();
            this.repositoriesService.Create(model, ownerId);
            return this.Redirect("/Repositories/All");
        }
    }
}
