using CrowDo.Core.Data;
using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CrowDo.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CrowDoDbContext context_;
        private readonly IUserService user_;
        private readonly IFundingPackageService fundingPackage_;
        public ProjectService(
            CrowDoDbContext context,
            IUserService users,
            IFundingPackageService fundingPackages)
        {
            context_ = context;
            user_ = users;
            fundingPackage_ = fundingPackages;
        }

        public Project CreateProject(CreateProjectOptions options)
        {
            if (options == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(options.Title) ||
               options.Budget <= 0 ||
               string.IsNullOrWhiteSpace(options.Description))
            {
                return null;
            }

            var user = user_.GetUserById(options.UserId);

            if (user == null)
            {
                return null;
            }

            var project = new Project()
            {
                Title = options.Title,
                Budget = options.Budget,
                Description = options.Description,
                Category = options.Category

            };

            foreach (var id in options.FundingPackageIds)
            {
                var fundingPackageResult = fundingPackage_
                    .GetFundingPackageById(id);
                if (fundingPackageResult == null)
                {
                    return null;
                }
                project.ProjectFundingPackages.Add(
                    new ProjectFundingPackage()
                    {
                        FundingPackage = fundingPackageResult
                    });
            }

            context_.Add(project);
            user.Projects.Add(project);
            context_.SaveChanges();
            return project;
        }

        public List<Project> SearchProject(
         SearchProjectOptions options)
        {
            if (options == null)
            {
                return null;
            }

            if (options.ProjectId == null
                && options.UserId == null)
            {
                return null;
            }

            var query = context_
                 .Set<Project>()
                 .AsQueryable();

            if (options.UserId != 0)
            {
                query = query.Where(
                    c => c.User.Id == options.UserId);
            }

            if (options.ProjectId != 0)
            {
                query = query.Where(
                    c => c.Id == options.ProjectId);
            }

            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                query = query
                      .Where(c => c.Description.Contains(options.Description));
            }

            if (!string.IsNullOrWhiteSpace(options.Title))
            {
                query = query
                      .Where(c => c.Title.Contains(options.Title));
            }
            //to be checked
            if (options.StatusProject == StatusProject.Available)
            {
                query = query
                      .Where(c => c.StatusProject.Equals(options.StatusProject));
            }

            if (!options.Category.Equals(ProjectCategory.Invalid))
            {
                query = query
                     .Where(c => c.StatusProject.Equals(options.StatusProject));
            }

            return query.ToList();
        }

        public Project UpdateProject(
            int projectId, UpdateProjectOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var project = GetProjectById(projectId);

            if (project == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                project.Description = options.Description;
            }

            if (!string.IsNullOrWhiteSpace(options.Title))
            {
                project.Title = options.Title;
            }

            //if (options.StatusProject.HasValue)
            //{
            //    project.StatusProject.Equals(options.StatusProject);
            //} must be a function in case a project budget is accomplished
                        
            context_.SaveChanges();
            return project;
        }

        public Project GetProjectById(int id)
        {
            var project = context_
                .Set<Project>()
                .SingleOrDefault(p => p.Id == id);
            if (project == null)
            {
                return null;
            }
            return project;
        }

        public List<Project> GetProjects()
        {
            return context_.Set<Project>()
                    .ToList();
        }
    }
}