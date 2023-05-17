using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.FileExtensions;
using MotorcycleWebShop.Domain.Entities;

namespace MotorcycleWebShop.Application.MotorcycleTypes.Commands.CreateMotorycleType
{
    public record CreateMotorcycleTypeCommand : IRequest<int>
    {
        public string TypeName { get; init; }
        public IFormFile? Image { get; init; }
    }

    public class CreateMotorcycleTypeCommandHandler : IRequestHandler<CreateMotorcycleTypeCommand, int>
    {
        private readonly IApplicationDbContext _db;
        private readonly IFileStorageHelper _fileHelper;

        public CreateMotorcycleTypeCommandHandler(IApplicationDbContext db,
            IFileStorageHelper fileHelper)
        {
            _db = db;
            _fileHelper = fileHelper;
        }

        public async Task<int> Handle(CreateMotorcycleTypeCommand request, CancellationToken cancellationToken)
        {
            var type = new MotorcycleType();
            if(request.Image != null)
            {
                type.ImagePath = await SaveFile(request.Image);
            }
            type.TypeName = request.TypeName;

            _db.MotorcycleTypes.Add(type);
            await _db.SaveChangesAsync(cancellationToken);

            return type.Id;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            var fileName = $"{Guid.NewGuid}{Path.GetExtension(originalFileName)}";
            fileName = fileName.Substring(0, fileName.Length - 1);
            var relativePath = await _fileHelper.SaveFileAsync(file.OpenReadStream(), fileName);

            return relativePath;
        }
    }
}
