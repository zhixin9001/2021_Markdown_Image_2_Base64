namespace Markdown_Image_2_Base64.Test
{
  using NUnit.Framework;

  public class MDHandlerIntegrationTests
  {
    [Test]
    public void ShouldReplaceImagesWithBase64()
    {
      var mdHandler = new MarkdownImageHandler("/Users/zhixin/Personal/2021_Business_Oriented_Design/notes/1/面向业务设计和履约建模(1).md");
      mdHandler.Run();
    }
  }
}