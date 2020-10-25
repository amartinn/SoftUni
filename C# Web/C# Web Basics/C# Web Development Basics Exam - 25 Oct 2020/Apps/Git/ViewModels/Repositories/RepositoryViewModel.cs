using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class RepositoryViewModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string CreatedOn { get; set; }
        public int CommitsCount { get; set; }
        public string Id { get; set; }
    }
}
