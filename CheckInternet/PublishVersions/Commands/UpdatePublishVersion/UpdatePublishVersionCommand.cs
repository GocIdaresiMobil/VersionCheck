using CheckInternet.Entities;
using CheckInternet.Exceptions;
using CheckInternet.Interfaces;
using MediatR;

namespace CheckInternet.PublishVersions.Commands.UpdatePublishVersion
{
    public record class UpdatePublishVersionCommand : IRequest
    {
        public int Id { get; init; }
        public string ApplicationName { get; set; }
        public string LastVersion { get; set; }
        public string CurrentVersion { get; set; }
        public bool EmailFlag { get; set; }
    }

    public class UpdatePublishVersionCommandHandler : IRequestHandler<UpdatePublishVersionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePublishVersionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePublishVersionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PublishVersions
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PublishVersion), request.Id);
            }

            entity.ApplicationName = request.ApplicationName;
            entity.LastVersion = request.LastVersion;
            entity.CurrentVersion = request.CurrentVersion;
            entity.EmailFlag = request.EmailFlag;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
