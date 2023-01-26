using AutoMapper;
using Moq;
using WayToDev.Application.Services;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Enums;
using WayToDev.Core.Exceptions;

namespace WayToDev.Tests.Services;

[TestFixture]
public class NewsServiceTest : TestInitializer
{
    private NewsService service;
    private NewsDto newsDto;
    private News news;
    private NewsFilterViewModel model;
    
    [SetUp]
    protected override void Initialize()
    {
        base.Initialize();
        service = new NewsService(Context, MockMapper.Object);
        MockMapper.Setup(x => x.Map<NewsDto, News>(newsDto)).Returns(news);
        MockMapper.Setup(x => x.Map<News, NewsDto>(news)).Returns(newsDto);
        news = new News()
        {
            ShortDescription = "short-description",
            Date = DateTime.Now,
            Text = "Text",
            Image = new Image("picture"),
            Title = "Title"
        };
        
        newsDto = new NewsDto
        {
            Id = Guid.NewGuid(),
            ShortDescription = "short-description",
            Date = DateTime.Now,
            Text = "Text",
            Image = "picture",
            Title = "Title"
        };

        model = new NewsFilterViewModel
        {
            Page = 1,
            PageSize = 3,
            SortBy = SortBy.DescDate
        };

        Context.NewsSet.Add(news);
        Context.SaveChanges();
    }

    [Test]
    public void Should_Throws_Exception_WhenCreateNews()
    {
        news = null;
        MockMapper.Setup(x => x.Map<NewsDto, News>(newsDto)).Returns(news);
        Assert.ThrowsAsync<DataAccessException>(async () =>
        {
            await service.Create(newsDto);
        });
    }
    
    [Test]
    public async Task Should_Return_NewsModel_WhenCreateNews()
    {
        news.Id = Guid.NewGuid();
        MockMapper.Setup(x => x.Map<NewsDto, News>(newsDto)).Returns(news);
        MockMapper.Setup(x => x.Map<News, NewsDto>(news)).Returns(newsDto);
        
        var res = await service.Create(newsDto);
        
        Assert.That(res, Is.Not.Null);
    }

    [Test]
    public async Task Should_Success_UpdateNews()
    {
        newsDto.Title = "newTitle";
        newsDto.Text = "newText";
        newsDto.ShortDescription = "new short Description";
        newsDto.Image = "Image";
        MockMapper.Setup(x => x.Map<NewsDto, News>(newsDto)).Returns(news);
        await service.Update(newsDto);
        
        Assert.Multiple(() =>
        {
            var newNews = Context.NewsSet.First(x=>x.Id == news.Id);
            Assert.That(news.Title, Is.EqualTo(newNews.Title));
            Assert.That(news.Text, Is.EqualTo(newNews.Text));
        });
    }
    
    [Test]
    public void Should_ThrowsException_When_UpdateNews()
    {
        Assert.ThrowsAsync<ArgumentException>(
            async () =>
            {
                await service.Update(null);
            });
    }

    [Test]
    public void Should_Return_ListOfNews()
    {
        var expectedList = new List<NewsDto> { newsDto };
        var sutList = new List<News> { news };
        MockMapper.Setup(x => x.Map<List<News>, List<NewsDto>>(sutList)).Returns(expectedList);

        var res = service.GetNews();
        Assert.That(res, Has.Count.EqualTo(expectedList.Count));
    }

    [Test]
    public void Should_DeleteNews_FromDb()
    {
        Assert.DoesNotThrowAsync(async () =>
        {
            await service.Delete(news.Id);
            Assert.That(Context.NewsSet.FirstOrDefault(x => x.Id == news.Id), Is.Null);
        }); 
    }

    [Test]
    public void Should_ThrowsException_NewsById()
    {
        Assert.Throws<NewsNotFoundException>(() =>
        {
            service.GetNewsById(Guid.Empty);
        });
    }
    
    [Test]
    public void Should_Return_NewsById()
    {
        newsDto.Id = news.Id;
        MockMapper.Setup(x => x.Map<News, NewsDto>(news)).Returns(newsDto);
        var res = service.GetNewsById(news.Id);
        
        Assert.DoesNotThrow(() =>
        {
            Assert.Multiple(() =>
            {
                Assert.That(res.Id, Is.EqualTo(news.Id));
                Assert.That(res, Is.Not.Null);
            });
        });
    }

}