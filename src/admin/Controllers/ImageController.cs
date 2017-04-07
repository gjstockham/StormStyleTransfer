using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StormStyleTransfer.Admin.Core.Configuration;
using StormStyleTransfer.Admin.Core.Data;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace StormStyleTransfer.Admin.Controllers
{
    public class ImageController : Controller
    {
        private readonly CloudStorageConfiguration _options;
        private readonly ApplicationDbContext _dbContext;
        
        public ImageController(IOptions<CloudStorageConfiguration> options, ApplicationDbContext dbContext)
        {
            _options = options.Value;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var reference = _dbContext.ReferenceStyles.Single(x => x.Id == id);

            var idString = reference.Id.ToString().ToUpper();
            
            Console.WriteLine($"{idString}/{reference.ImageName}");


            var account = CloudStorageAccount.Parse(_options.ConnectionString);

            var client = account.CreateCloudBlobClient();

            var container = client.GetContainerReference(_options.ContainerName);
            CloudBlockBlob blob = container.GetBlockBlobReference($"{idString}/{reference.ImageName}");
            
            byte[] data;

            using(var memoryStream = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(memoryStream);
                data = memoryStream.ToArray();
            }
            return File(data, reference.MimeType);

        }
    }
}