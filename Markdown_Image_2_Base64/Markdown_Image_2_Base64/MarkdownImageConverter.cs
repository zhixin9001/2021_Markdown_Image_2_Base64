namespace Markdown_Image_2_Base64
{
  using System.Collections.Generic;
  using System.Text.RegularExpressions;

  public class MarkdownImageConverter
  {
    private readonly string _context;
    private readonly IImage2Base64Converter _image2Base64Converter;
    private Regex _regex = new Regex("\\!\\[.+?\\]\\((\\.\\/.+?\\.\\w+?)\\)");
    
    public string ReplacedContext { get; private set; }

    public MarkdownImageConverter(string context, IImage2Base64Converter image2Base64Converter)
    {
      this.ReplacedContext= _context = context;
      _image2Base64Converter = image2Base64Converter;
    }

    public IEnumerable<string> FindImageMarks()
    {
      var matches = _regex.Matches(_context);
      foreach (Match match in matches)
      {
        yield return match.Groups[1].Value;
      }
    }

    public void ReplaceImageWithBase64(string imageUri)
    {
      var base64 = _image2Base64Converter.GetBase64(imageUri);
      this.ReplacedContext = this.ReplacedContext.Replace(imageUri, base64);
    }
  }
}