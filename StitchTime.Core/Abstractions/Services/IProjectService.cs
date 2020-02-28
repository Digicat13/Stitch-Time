using StitchTime.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IProjectService
    {
        public List<ProjectDto> GetAll();

        public ProjectDto GetById(int Id);

        public Task<ProjectDto> Insert(ProjectDto projectDto);

        public ProjectDto Update(ProjectDto projectDto);

        public Task Delete(int Id);
    }
}
