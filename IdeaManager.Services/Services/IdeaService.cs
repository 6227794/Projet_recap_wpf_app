using IdeaManager.Core.Entities;
using IdeaManager.Core.Interfaces;
using IdeaManager.Core.Enums;

public class IdeaService : IIdeaService
{
    //dependance encapsule tt repo
    private readonly IUnitOfWork _unitOfWork;

    public IdeaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //donner new idea
    public async Task SubmitIdeaAsync(Idea idea)
    {
        if (string.IsNullOrWhiteSpace(idea.Title))
            throw new ArgumentException("Le titre est obligatoire.");

        idea.VoteCount = 0;
        idea.Status = IdeaStatus.InProgress;

        await _unitOfWork.IdeaRepository.AddAsync(idea);
        await _unitOfWork.SaveChangesAsync();
    }

    //recupere tt idees
    public async Task<List<Idea>> GetAllAsync()
    {
        return await _unitOfWork.IdeaRepository.GetAllAsync();
    }


    //coter pour ou contre

    public async Task VoteForIdeaAsync(int ideaId)
    {
        var idea = await _unitOfWork.IdeaRepository.GetByIdAsync(ideaId);

        if (idea == null)
            throw new InvalidOperationException("Idée non trouvée.");

        idea.VoteCount++;
        await _unitOfWork.IdeaRepository.AddAsync(idea); //  mise à jour simplifiée
    }

    public async Task ApproveIdeaAsync(Idea idea)
    {
        var ideaFromDb = await _unitOfWork.IdeaRepository.GetByIdAsync(idea.Id);
        if (ideaFromDb == null)
            throw new InvalidOperationException("Idée introuvable");

        ideaFromDb.Status = IdeaStatus.Approved;
        ideaFromDb.VoteCount = 1;

        await _unitOfWork.SaveChangesAsync();
    
    }

    public async Task RejectIdeaAsync(Idea idea)
    {
        var ideaFromDb = await _unitOfWork.IdeaRepository.GetByIdAsync(idea.Id);
        if (ideaFromDb == null)
            throw new InvalidOperationException("Idée introuvable");

        ideaFromDb.Status = IdeaStatus.Rejected;
        ideaFromDb.VoteCount = 0;

        await _unitOfWork.SaveChangesAsync();

    }

    Task IIdeaService.ApprovedIdeaAsync(Idea idea)
    {
        throw new NotImplementedException();
    }
}
