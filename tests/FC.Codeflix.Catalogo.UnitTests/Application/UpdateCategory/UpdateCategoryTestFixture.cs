using FC.Codeflix.Catalog.Application.Interfaces;
using FC.Codeflix.Catalog.Application.UseCases.Category.UpdateCategory;
using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Repository;
using FC.Codeflix.Catalog.UnitTests.Common;
using Moq;
using Xunit;

namespace FC.Codeflix.Catalog.UnitTests.Application.UpdateCategory;

public class UpdateCategoryTestFixture : BaseFixture
{
    public Mock<ICategoryRepository> GetRepositoryMock() => new();
    
    public Mock<IUnitOfWork> GetUnitOfWorkMock() => new();
    
    public string GetValidCategoryName()
    {
        var categoryName = "";

        while (categoryName.Length < 3)
            categoryName = Faker.Commerce.Categories(1)[0];
        
        if (categoryName.Length > 255)
            categoryName = categoryName[..255];

        return categoryName;
    }

    public string GetValidCategoryDescription()
    {
        var categoryDescription = Faker.Commerce.ProductDescription();

        if (categoryDescription.Length > 10_000)
            categoryDescription = categoryDescription[..10_000];

        return categoryDescription;
    }

    public bool GetRandomBoolean() => new Random().NextDouble() < 0.5;

    public Category GetExampleCategory()
        => new Category(
            GetValidCategoryName(),
            GetValidCategoryName(),
            GetRandomBoolean());

    public UpdateCategoryInput GetValidInput(Guid? id = null)
        => new UpdateCategoryInput(
            id ?? Guid.NewGuid(),
            GetValidCategoryName(),
            GetValidCategoryDescription(),
            GetRandomBoolean()
        );
}

[CollectionDefinition(nameof(UpdateCategoryTestFixture))]
public class GetCategoryTestFixtureCollection : ICollectionFixture<UpdateCategoryTestFixture>
{
}