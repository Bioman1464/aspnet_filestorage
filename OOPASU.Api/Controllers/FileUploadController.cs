using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOPASU.Api.Data;

namespace OOPASU.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUpload : ControllerBase
    {
        DataContext _context;
        IWebHostEnvironment _appEnvironment;
 
        public FileUpload(DataContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                return UnprocessableEntity("No file loaded!");
            }

            string path = Path.Combine("Files", uploadedFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            await uploadedFile.CopyToAsync(stream);
            
            stream.Close();
            
            
            /*using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
            _context.Files.Add(file);
            _context.SaveChanges();*/
            
            return Ok(uploadedFile.FileName);
        }
        
    }
}