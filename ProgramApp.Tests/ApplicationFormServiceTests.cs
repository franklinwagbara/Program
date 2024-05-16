using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using ProgramApp.Application.DTOs;
using ProgramApp.Application.Mappings;
using ProgramApp.Application.Services;
using ProgramApp.Domain.Entities;
using ProgramApp.Domain.Interfaces;
using ProgramApp.Persistence.Repositories.CachedRepositories;

namespace ProgramApp.Tests;

public class ApplicationFormServiceTests
{
    private readonly IMapper _mapper;
    public ApplicationFormServiceTests()
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AppFormMappings());
        });
        _mapper = mappingConfig.CreateMapper();
    }

    [Fact]
    public async void CreateAppForm_ShouldReturnResult_True()
    {
        //Arrange
        var repoMock = new Mock<IApplicationFormRepository>();
        repoMock.Setup(x => x.Create(It.IsAny<ApplicationForm>()))
            .Returns(Task.FromResult(AppFormMockData.Get()));

        repoMock.Setup(x => x.SaveChangesAsync()).Returns(Task.FromResult<bool>(true));

        var memoryCacheMock = new Mock<IMemoryCache>();
        var cacheEntryMock = new Mock<ICacheEntry>();
        object cacheValue = null;

        memoryCacheMock.Setup(m => m.TryGetValue(It.IsAny<object>(), out cacheValue))
            .Returns(false);

        memoryCacheMock.Setup(m => m.CreateEntry(It.IsAny<object>()))
            .Returns(cacheEntryMock.Object);

        var cachedRepo = new CachedApplicationFormRespository(repoMock.Object, memoryCacheMock.Object);

        var apFormService = new ApplicationFormService(repoMock.Object, _mapper);

        //Act
        var result = await apFormService.CreateAppForm(new CreateAppFormDTO());

        //Assert
        Assert.NotNull(result);
        Assert.True(result.IsSuccess);
        Assert.True(result.Result);
    }
}
