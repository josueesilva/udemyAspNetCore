

namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        public string Name { get; private set; }
    
        public Category(string name)
        {   
            ValidateNameAndSetName(name);
        }

        private void ValidateNameAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(name.Length <= 2, "Name is invalid");

            Name = name;
        }

        public void Update(string name)
        {
            ValidateNameAndSetName(name);
        }
    }
}