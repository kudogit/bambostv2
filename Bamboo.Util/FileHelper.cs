using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Bamboo.Util
{
    public static class FileHelper
    {
        public static Stream ConvertToStream(this string content)
        {
            var base64 = content.Split(',');
            var bytes = Convert.FromBase64String(base64[base64.Length - 1]);            
            return new MemoryStream(bytes);
        }

        public static IFormFile ConvertBase64ToIFormFile(string base64Content)
        {
            FormFile formFile = null;

            if (!string.IsNullOrWhiteSpace(base64Content))
            {
                var base64 = base64Content.Split(',');
                var byteArray = Convert.FromBase64String(base64[base64.Length - 1]);

                Stream stream = new MemoryStream(byteArray);

                formFile = new FormFile(stream, 0, stream.Length, Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));
            }

            return formFile;
        }

        public static Task SaveFile(string base64,ref string fileName, string path)
        {
            //  Check filePath
            path = Const.EnvironmentDerectory + path;
            if (!Directory.Exists(path))
                throw new BambooException(Core.Constants.ErrorCode.PathInvalid);

            var extension = Path.GetExtension(fileName);
            fileName = Guid.NewGuid() + extension;

            var pathSave = Path.Combine(path, fileName);

            var bytes = Convert.FromBase64String(base64);
            using (var file = new FileStream(pathSave, FileMode.Create))
            {
                file.Write(bytes, 0, bytes.Length);
                file.Flush();
            }
            return Task.CompletedTask;
        }

        public static Task<string> SaveImage(Stream stream, string filenameWithExtension, string outputPath = "", int size = 150, int quality = 75)
        {
            using (var image = new Bitmap(Image.FromStream(stream)))
            {
                int width, height;
                if (image.Width > image.Height)
                {
                    width = size;
                    height = Convert.ToInt32(image.Height * size / (double)image.Width);
                }
                else
                {
                    width = Convert.ToInt32(image.Width * size / (double)image.Height);
                    height = size;
                }
                var resized = new Bitmap(width, height);
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, width, height);

                    if (string.IsNullOrEmpty(outputPath))
                    {
                        outputPath = AppSettings.FileUrl;
                    }

                    outputPath += Guid.NewGuid() + Path.GetExtension(filenameWithExtension);
                    var writePath = AppSettings.BaseUrl + outputPath;
                    Directory.CreateDirectory(Path.GetDirectoryName(writePath));

                    using (var output = File.Open(writePath, FileMode.Create))
                    {
                        var qualityParamId = Encoder.Quality;
                        var encoderParameters = new EncoderParameters(1)
                        {
                            Param = { [0] = new EncoderParameter(qualityParamId, quality) }
                        };
                        var codec = ImageCodecInfo.GetImageDecoders()
                            .FirstOrDefault(x => x.FormatID == ImageFormat.Jpeg.Guid);
                        resized.Save(output, codec, encoderParameters);
                    }
                }
            }
            return Task.FromResult(outputPath.Replace('\\', '/').Replace("/wwwroot/", ""));
        }
    }
}
