using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route("api/files")]
    public class FileController : ApiController
    {
        private readonly IFileServive _fileServive;

        public FileController(IFileServive fileServive)
        {
            _fileServive = fileServive;
        }

        [Route("remove/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(int id)
        {
            await _fileServive.DeleteAsync(id).ConfigureAwait(true);
            return NoContent();
        }
    }
}