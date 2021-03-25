using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            string path = $@"{Environment.CurrentDirectory + @"\wwwroot"}";
            var result = newPath(file);

            try
            {
                var sourcepath = Path.GetTempFileName();

                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                File.Move(sourcepath,path+result);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            
            try
            {
                var newPath = AddAsync(file);

                File.Delete(sourcePath);
                return newPath;
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

           
        }

        public static IResult DeleteAsync(string path)
        {
            string path2 = $@"{Environment.CurrentDirectory + @"\wwwroot"}";
            try
            {
                File.Delete(path2+path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string  newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);

            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + fileExtension;

            //string result = $@"{Environment.CurrentDirectory + @"\wwwroot\uploads"}\{creatingUniqueFilename}";

            return  @"\uploads\"+creatingUniqueFilename;
        }
    }
}
