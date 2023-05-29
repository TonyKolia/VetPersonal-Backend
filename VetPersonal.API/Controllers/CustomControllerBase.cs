using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VetPersonal.API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected static string GetFileExtension(string fileName) => fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.')).Remove(0, 1);
    }
}