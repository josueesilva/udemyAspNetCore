using StoreBuild.Domain.Dtos;

namespace StoreBuild.Domain.Products
{
    public class CategoryStorer
    {
        private readonly IRepoitory<Category> _categoryRepository;

        public CategoryStorer(IRepoitory<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Store(CategoryDto dto)
        {
            var category = _categoryRepository.GetById(dto.CategoryId);
            DomainException.When(categiry == null, "category is required");

            if (category == null)
            {
                category = new Product(dto.Name);
                _categoryRepository.Save(category);
            }
            else
                category.Update(dto.Name);
        }
    }
}