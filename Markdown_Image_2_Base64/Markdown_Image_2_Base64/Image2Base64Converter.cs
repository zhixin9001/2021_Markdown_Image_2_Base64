namespace Markdown_Image_2_Base64
{
  using System;
  using System.IO;

  public interface IImage2Base64Converter
  {
    string GetBase64(string imageUri);
  }

  public class Image2Base64Converter: IImage2Base64Converter
  {
    private readonly string _pwd;

    public Image2Base64Converter(string pwd)
    {
      _pwd = pwd;
    }
    
    public string GetBase64(string imageUri)
    {
      return Image2Base64(Path.Combine(_pwd, imageUri));
    }
    
    private string Image2Base64(string fileFullName)
    {
     using var fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read);
     var byteArray = new byte[fs.Length];
     fs.Read(byteArray, 0, byteArray.Length);
     return "data:image/png;base64," + Convert.ToBase64String(byteArray);
    }
  }
}