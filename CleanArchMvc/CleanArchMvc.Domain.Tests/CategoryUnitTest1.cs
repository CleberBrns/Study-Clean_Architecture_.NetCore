namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create Category With Invalid or Zero Id")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionValidationId(int idCategory)
        {
            Action action = () => new Category(idCategory, "Category Name");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }

        [Theory(DisplayName = "Create Category With Invalid Name")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateCategory_WithInvalidNameValue_DomainExceptionValidationName(string categoryName)
        {
            Action action = () => new Category(1, categoryName);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_WithShortNameValue_DomainExceptionValidationName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
    }
}