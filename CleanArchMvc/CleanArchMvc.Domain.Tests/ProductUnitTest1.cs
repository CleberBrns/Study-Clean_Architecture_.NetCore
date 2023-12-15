namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "product.image");

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create Product With Invalid or Zero Id")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionValidationId(int productId)
        {
            Action action = () => new Product(
                productId,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }

        [Theory(DisplayName = "Create Product With Invalid Name")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithInvalidNameValue_DomainExceptionValidationName(string productName)
        {
            Action action = () => new Product(
                1,
                productName,
                "Product Description",
                9.99m,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortNameValue_DomainExceptionValidationName()
        {
            Action action = () => new Product(
                1,
                "Pr",
                "Product Description",
                9.99m,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        //Description
        [Theory(DisplayName = "Create Product With Invalid Description")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithInvalidDescriptionValue_DomainExceptionValidationDescription(string productDescription)
        {
            Action action = () => new Product(
                1,
                "Product Name",
                productDescription,
                9.99m,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescriptionValue_DomainExceptionValidationDescription()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Prod",
                9.99m,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionValidationPrice()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                -1,
                99,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionValidationStock()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                -1,
                "product.image");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Theory(DisplayName = "Create Product With Empty or Null Image, returns Valid State")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithEmptyOrNullImage_ResultObjectValidState(string image)
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                image);

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create Product With Empty or Null Image, DO NOT return NullReferenceException")]
        [InlineData(null)]
        public void CreateProduct_WithEmptyOrNullImage_DoNotReturnNullReferenceException(string image)
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                image);

            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Image Too Long")]
        public void CreateProduct_WithImageValueTooLong_DomainExceptionValidationDescription()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                @"imageproducttoolongimageproducttoolongimageproducttoolongimageproducttoolongimageproducttoolongimage
                        producttoolongimageproducttoolongimageproducttoolongimageproducttoolongimageproducttoolongimageprod
                        ucttoolongimageproducttoolongimageproducttoolongimageproducttoolong");

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Theory(DisplayName = "Update Product With Invalid CategoryId")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateProduct_WithInvalidCategoryIdValue_DomainExceptionValidationCategoryId(int categoryId)
        {
            var product = new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "product.image");

            var action = () => product.Update(
                product.Name, 
                product.Description, 
                product.Price, 
                product.Stock,
                product.Image,
                categoryId);

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid CategoryId value.");
        }
    }
}
