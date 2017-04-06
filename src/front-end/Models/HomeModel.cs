using Microsoft.AspNetCore.Http;

namespace StormStyleTransfer.FrontEnd.Models
{
    public class HomeModel
    {
        public string CheckpointModel {get; set;}

        public IFormFile PostedFile {get; set;}
    }
}