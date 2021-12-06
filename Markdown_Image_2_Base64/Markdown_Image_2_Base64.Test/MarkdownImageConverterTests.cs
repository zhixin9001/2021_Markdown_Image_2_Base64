namespace Markdown_Image_2_Base64.Test
{
  using System.Linq;
  using NSubstitute;
  using NUnit.Framework;

  public class MarkdownImageConverterTests
  {
    [Test]
    public void MarkdownImageHandlerShouldFindCorrectImageMarksWhenCallFindImageMarks()
    {
      var handler = new MarkdownImageConverter("与该组织的沟通结构一样的设计副本。\r![康威定律](./康威定律.png)。...![业务5过程](./业务5过程.png)", null);
      var images = handler.FindImageMarks().ToList();

      Assert.AreEqual("./康威定律.png", images[0]);
      Assert.AreEqual("./业务5过程.png", images[1]);
    }

    [Test]
    public void MarkdownImageHandlerShouldReplaceImages()
    {
      var imageBase64Converter = Substitute.For<IImage2Base64Converter>();
      imageBase64Converter.GetBase64(Arg.Any<string>()).Returns("fakeBase64");
      var handler = new MarkdownImageConverter("![康威定律](./康威定律.png)。...![业务5过程](./业务5过程.png)", imageBase64Converter);
      var imageUris = handler.FindImageMarks();
      foreach (var imageUri in imageUris)
      {
        handler.ReplaceImageWithBase64(imageUri);
      }

      Assert.AreEqual("![康威定律](fakeBase64)。...![业务5过程](fakeBase64)", handler.ReplacedContext);
    }
  }
}