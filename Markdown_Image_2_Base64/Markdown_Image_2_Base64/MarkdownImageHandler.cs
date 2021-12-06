namespace Markdown_Image_2_Base64
{
  using System.IO;

  public class MarkdownImageHandler
  {
    private readonly string _markDownPath;
    private string _fileName;
    private string _pwd;

    public MarkdownImageHandler(string markDownPath)
    {
      _markDownPath = markDownPath;
      _fileName = Path.GetFileName(_markDownPath);
      _pwd = Path.GetDirectoryName(_markDownPath);
    }

    public void Run()
    {
      var imageBase64Converter = new Image2Base64Converter(_pwd);
      var markdownImageHandler = new MarkdownImageConverter(ReadContext(), imageBase64Converter);
      var imageUris = markdownImageHandler.FindImageMarks();
      foreach (var imageUri in imageUris)
      {
        markdownImageHandler.ReplaceImageWithBase64(imageUri);
      }
      WriteReplacedContext(markdownImageHandler.ReplacedContext);
    }

    private string ReadContext()
    {
      using var sr = new StreamReader(_markDownPath);
      return sr.ReadToEnd();
    }

    private void WriteReplacedContext(string context)
    {
      using var sw = new StreamWriter(Path.Combine(_pwd, "base64_"+_fileName));
      sw.Write(context);
    }
  }
}