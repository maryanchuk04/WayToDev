using WayToDev.Application.Services;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;

namespace WayToDev.Tests.Services;

[TestFixture]
public class TagServiceTest : TestInitializer
{
    private TagService service;
    private Tag tag;
    private TagDto tagDto;
    
    [SetUp]
    protected override void Initialize()
    {
        base.Initialize();
        service = new TagService(Context, MockMapper.Object);
        tag = new Tag
        {
            TagName = ".NET",
            Image = new Image(".netImage"),
        };
        
        tagDto = new TagDto
        {
            Id = tag.Id,
            TagName = "React",
            ImageUrl = "ReactImage",
        };
        
        Context.Tags.Add(tag);
        Context.SaveChanges();

        MockMapper.Setup(m => m.Map<Tag, TagDto>(tag)).Returns(new TagDto
        {
            Id = tag.Id,
            ImageUrl = tag.Image.ImageUrl,
            TagName = tag.TagName
        });

        MockMapper
            .Setup(m => m.Map<List<Tag>, List<TagDto>>(new List<Tag>{tag}))
            .Returns(new List<TagDto>{ tagDto });
    }

    [Test]
    [TestCase(".NET",".net/image.png")]
    [TestCase("ReactJS","react/image.png")]
    public void Should_Return_InsertedTagModel(string tagName, string imageUrl)
    {
        Assert.DoesNotThrowAsync(async () => await service.InsertNewTag(tagName, imageUrl));
    }


    [Test]
    public async Task Should_Return_AllTagsFromDb()
    {
        var res = await service.GetAllTags();
        Assert.That(res, Is.Not.Zero);
    }


    [Test]
    public async Task Should_Remove_TagFromDb()
    {
        //existing in db tagId
        var id = tag.Id;

        await service.DeleteTag(id);

        Assert.That(Context.Tags.FirstOrDefault(x => x.Id == id), Is.Null);
    }
    
    [Test]
    public void Should_ThrowsTagException_IdNotExist_RemoveTag()
    {
        var res = Assert.ThrowsAsync<TagExceptions>(async () => await service.DeleteTag(Guid.Empty));
        Assert.That(res.Message, Is.Not.Empty);
    }
    
    [Test]
    public void Should_ThrowsTagException_IdNotExist_UpdateTag()
    {
        Assert.ThrowsAsync<TagExceptions>(async () => await service.UpdateTag(Guid.Empty, string.Empty, string.Empty));
    }
    
    [Test]
    public async Task Should_Update_TagInDb()
    {
        MockMapper.Setup(x => x.Map<Tag, TagDto>(tag)).Returns(tagDto);
        //existing in db tagId
        var id = tag.Id;

        var res = await service.UpdateTag(id, "React", "ReactImage");

        Assert.That(res.TagName, Is.EqualTo(tagDto.TagName));
    }

    [Test]
    public void Should_Return_ListOfTagsModel()
    {
        var res = service.FilteredTags(x => x.Image.ImageUrl.Contains("net"));
        
        Assert.That(res, Is.Not.Empty);
    }

}