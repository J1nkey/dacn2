using MediatR;
using Microsoft.AspNetCore.Http;
using MotorcycleWebShop.Application.Common.Interfaces;
using MotorcycleWebShop.Application.FileExtensions;
using MotorcycleWebShop.Domain.Entities;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace MotorcycleWebShop.Application.Slides.Commands.CreateSlide
{
    public record CreateSlideCommand : IRequest<int>
    {
        public IFormFile ImageFile { init; get; }
        public int? SortOrder { init; get; }
    }

    public class CreateSlideCommandHandler : IRequestHandler<CreateSlideCommand, int>
    {
        private readonly IApplicationDbContext _db;
        private readonly IFileStorageHelper _fileStorageHelper;

        public CreateSlideCommandHandler(IApplicationDbContext db,
            IFileStorageHelper fileStorageHelper)
        {
            _db = db;
            _fileStorageHelper = fileStorageHelper;
        }

        public async Task<int> Handle(CreateSlideCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filePath = await SaveFile(request.ImageFile);
                Slide slide = new Slide
                {
                    ImagePath = filePath,
                    SortOrder = request.SortOrder?? 0
                };
                _db.Slides.Add(slide);
                await _db.SaveChangesAsync(cancellationToken);

                return slide.Id;
            }
            catch (Exception ex)
            {
                Debugger.Log(1, nameof(CreateSlideCommandHandler), ex.Message);
            }

            return 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            fileName = fileName.Substring(0, fileName.Length - 1);
            var relativePath = await _fileStorageHelper.SaveFileAsync(file.OpenReadStream(), fileName);

            //return fileName;
            return relativePath;
        }
    }
}
