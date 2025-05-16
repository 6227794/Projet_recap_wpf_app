using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.Tests.Services
{
    public class IdeaServiceTests
    {

        private readonly Mock<IRepository<Idea>> _ideaRepoMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly IdeaService _service;

        public IdeaServiceTests()
        {
            _unitOfWorkMock.Setup(u => u.IdeaRepository).Returns(_ideaRepoMock.Object);
            _service = new IdeaService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task SubmitIdeaAsync_ShouldThrow_WhenTitleIsEmpty()
        {
            var idea = new Idea { Title = "" };
            await Assert.ThrowsAsync<ArgumentException>(() => _service.SubmitIdeaAsync(idea));
        }

        [Fact]
        public async Task SubmitIdeaAsync_ShouldAddIdea_WhenValid()
        {
            var idea = new Idea { Title = "New idea" };
            await _service.SubmitIdeaAsync(idea);
            _ideaRepoMock.Verify(r => r.AddAsync(It.IsAny<Idea>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

    }
}
