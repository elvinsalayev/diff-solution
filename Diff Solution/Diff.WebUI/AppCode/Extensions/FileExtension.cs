using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace Diff.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        async public static Task<string> SaveFile(this IWebHostEnvironment env, IFormFile file, CancellationToken cancellationToken, string prefix = null)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            string name = $"{(string.IsNullOrWhiteSpace(prefix) ? "" : prefix + "-")} {Guid.NewGuid()}{fileExtension}";

            string phsicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", "products", name);

            using (var fs = new FileStream(phsicalPath, FileMode.Create, FileAccess.Write))
            {
                await file.CopyToAsync(fs, cancellationToken);
            }
            return name;
        }
    }
}
