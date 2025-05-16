using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Enums;
using IdeaManager.Core.Interfaces;

namespace IdeaManager.UI.ViewModels
{
    public class ProjectListViewModel
    {
        private readonly IIdeaService _ideaService;

        public ObservableCollection<Idea> ApprovedIdeas { get; set; }

        public ProjectListViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            ApprovedIdeas = new ObservableCollection<Idea>();
        }

        public async Task LoadApprovedIdeasAsync()
        {
            var allIdeas = await _ideaService.GetAllAsync();
            var approved = allIdeas.Where(i => i.Status == IdeaStatus.Approved).ToList();

            ApprovedIdeas.Clear();
            foreach (var idea in approved)
                ApprovedIdeas.Add(idea);
        }
    }
}