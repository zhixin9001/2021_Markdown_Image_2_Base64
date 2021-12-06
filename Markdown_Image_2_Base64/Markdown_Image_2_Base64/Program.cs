namespace Markdown_Image_2_Base64
{
  using System;

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("-- Please input the physical path of markdown file:");
      var markDownPath = Console.ReadLine();
      var mdHandler = new MarkdownImageHandler(markDownPath);
      mdHandler.Run();
      Console.WriteLine("-- Convert succeed");
    }
  }
}