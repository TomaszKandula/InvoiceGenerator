namespace InvoiceGenerator.UnitTests.Services
{
    using Moq;
    using Xunit;
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Backend.Domain.Enums;
    using Backend.InvoiceService;
    using Backend.Domain.Entities;
    using Backend.Core.Exceptions;
    using Backend.Shared.Resources;
    using Backend.InvoiceService.Models;
    using Backend.Core.Services.LoggerService;
    using Backend.Core.Services.DateTimeService;

    public class InvoiceServiceTest : TestBase
    {
        [Fact]
        public async Task GivenValidInvoiceNUmber_WhenGetIssuedInvoice_ShouldSucceed()
        {
            // Arrange
            var user = new Users
            {
                Id = Guid.NewGuid(),
                FirstName = DataUtilityService.GetRandomString(),
                LastName = DataUtilityService.GetRandomString(),
                UserAlias = DataUtilityService.GetRandomString(5),
                EmailAddress = DataUtilityService.GetRandomEmail(),
                Registered = DateTimeService.Now.AddDays(-120),
                IsActivated = true,
                PrivateKey = DataUtilityService.GetRandomString()
            };

            var invoices = new List<IssuedInvoices>
            {
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    InvoiceData = new byte[4096],
                    ContentType = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-12)
                },
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    InvoiceData = new byte[2048],
                    ContentType = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-6)
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddAsync(user);
            await databaseContext.AddRangeAsync(invoices);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            var result = await service.GetIssuedInvoice(invoices[0].InvoiceNumber);

            // Assert
            result.Number.Should().Be(invoices[0].InvoiceNumber);
        }

        [Fact]
        public async Task GivenInvalidInvoiceNUmber_WhenGetIssuedInvoice_ShouldThrowError()
        {
            // Arrange
            var user = new Users
            {
                Id = Guid.NewGuid(),
                FirstName = DataUtilityService.GetRandomString(),
                LastName = DataUtilityService.GetRandomString(),
                UserAlias = DataUtilityService.GetRandomString(5),
                EmailAddress = DataUtilityService.GetRandomEmail(),
                Registered = DateTimeService.Now.AddDays(-120),
                IsActivated = true,
                PrivateKey = DataUtilityService.GetRandomString()
            };

            var invoices = new List<IssuedInvoices>
            {
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    InvoiceData = new byte[4096],
                    ContentType = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-12)
                },
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    InvoiceData = new byte[2048],
                    ContentType = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-6)
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddAsync(user);
            await databaseContext.AddRangeAsync(invoices);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.GetIssuedInvoice(DataUtilityService.GetRandomString()));

            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_INVOICE_NUMBER));
        }

        [Fact]
        public async Task GivenOrderList_WhenOrderInvoiceBatchProcessing_ShouldSucceed()
        {
            // Arrange
            var user = new Users
            {
                Id = Guid.NewGuid(),
                FirstName = DataUtilityService.GetRandomString(),
                LastName = DataUtilityService.GetRandomString(),
                UserAlias = DataUtilityService.GetRandomString(5),
                EmailAddress = DataUtilityService.GetRandomEmail(),
                Registered = DateTimeService.Now.AddDays(-120),
                IsActivated = true,
                PrivateKey = DataUtilityService.GetRandomString()
            };
            
            var orders = new List<OrderDetail>
            {
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new()
                        {
                            ItemText = DataUtilityService.GetRandomString(),
                            ItemQuantity = DataUtilityService.GetRandomInteger(),
                            ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                            ItemAmount = DataUtilityService.GetRandomDecimal(),
                            ItemDiscountRate = null,
                            ValueAmount = DataUtilityService.GetRandomDecimal(),
                            VatRate = null,
                            GrossAmount = DataUtilityService.GetRandomDecimal(),
                            CurrencyCode = CurrencyCodes.Gbp
                        },
                        new()
                        {
                            ItemText = DataUtilityService.GetRandomString(),
                            ItemQuantity = DataUtilityService.GetRandomInteger(),
                            ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                            ItemAmount = DataUtilityService.GetRandomDecimal(),
                            ItemDiscountRate = null,
                            ValueAmount = DataUtilityService.GetRandomDecimal(),
                            VatRate = null,
                            GrossAmount = DataUtilityService.GetRandomDecimal(),
                            CurrencyCode = CurrencyCodes.Gbp
                        }
                    }
                },                
                new()
                {
                    UserId = user.Id,
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    InvoiceItems = new List<InvoiceItem>
                    {
                        new()
                        {
                            ItemText = DataUtilityService.GetRandomString(),
                            ItemQuantity = DataUtilityService.GetRandomInteger(),
                            ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                            ItemAmount = DataUtilityService.GetRandomDecimal(),
                            ItemDiscountRate = null,
                            ValueAmount = DataUtilityService.GetRandomDecimal(),
                            VatRate = null,
                            GrossAmount = DataUtilityService.GetRandomDecimal(),
                            CurrencyCode = CurrencyCodes.Gbp
                        },
                        new()
                        {
                            ItemText = DataUtilityService.GetRandomString(),
                            ItemQuantity = DataUtilityService.GetRandomInteger(),
                            ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                            ItemAmount = DataUtilityService.GetRandomDecimal(),
                            ItemDiscountRate = null,
                            ValueAmount = DataUtilityService.GetRandomDecimal(),
                            VatRate = null,
                            GrossAmount = DataUtilityService.GetRandomDecimal(),
                            CurrencyCode = CurrencyCodes.Gbp
                        }
                    }
                }                
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddAsync(user);
            await databaseContext.SaveChangesAsync();
            
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();
            
            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            var result = await service.OrderInvoiceBatchProcessing(orders);

            // Assert
            result.Should().NotBeEmpty();

            databaseContext.BatchInvoices.ToList().Count.Should().Be(2);
            databaseContext.BatchInvoiceItems.ToList().Count.Should().Be(4);
            databaseContext.BatchInvoicesProcessing.ToList().Count.Should().Be(1);
        }

        [Fact]
        public async Task GivenValidBatchProcessingKey_WhenGetBatchInvoiceProcessingStatus_ShouldSucceed()
        {
            // Arrange
            var user = new Users
            {
                Id = Guid.NewGuid(),
                FirstName = DataUtilityService.GetRandomString(),
                LastName = DataUtilityService.GetRandomString(),
                UserAlias = DataUtilityService.GetRandomString(5),
                EmailAddress = DataUtilityService.GetRandomEmail(),
                Registered = DateTimeService.Now.AddDays(-120),
                IsActivated = true,
                PrivateKey = DataUtilityService.GetRandomString()
            };

            var processing = new BatchInvoicesProcessing
            {
                Id = Guid.NewGuid(),
                BatchProcessingTime = null,
                Status = ProcessingStatuses.New,
                CreatedAt = DateTimeService.Now
            };

            var invoices = new List<BatchInvoices>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    CreatedAt = DateTimeService.Now,
                    CreatedBy = user.Id,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    CreatedAt = DateTimeService.Now,
                    CreatedBy = user.Id,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id
                }
            };

            var invoiceItems = new List<BatchInvoiceItems>
            {
                new()
                {
                    BatchInvoiceId = invoices[0].Id,
                    ItemText = DataUtilityService.GetRandomString(),
                    ItemQuantity = DataUtilityService.GetRandomInteger(),
                    ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                    ItemAmount = DataUtilityService.GetRandomDecimal(),
                    ItemDiscountRate = null,
                    ValueAmount = DataUtilityService.GetRandomDecimal(),
                    VatRate = null,
                    GrossAmount = DataUtilityService.GetRandomDecimal(),
                    CurrencyCode = CurrencyCodes.Gbp
                },
                new()
                {
                    BatchInvoiceId = invoices[1].Id,
                    ItemText = DataUtilityService.GetRandomString(),
                    ItemQuantity = DataUtilityService.GetRandomInteger(),
                    ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                    ItemAmount = DataUtilityService.GetRandomDecimal(),
                    ItemDiscountRate = null,
                    ValueAmount = DataUtilityService.GetRandomDecimal(),
                    VatRate = null,
                    GrossAmount = DataUtilityService.GetRandomDecimal(),
                    CurrencyCode = CurrencyCodes.Gbp
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddAsync(user);
            await databaseContext.AddAsync(processing);
            await databaseContext.AddRangeAsync(invoices);
            await databaseContext.AddRangeAsync(invoiceItems);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();
            
            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            var result = await service.GetBatchInvoiceProcessingStatus(processing.Id);

            // Assert
            result.Status.Should().Be(ProcessingStatuses.New);
            result.BatchProcessingTime.Should().BeNull();
        }

        [Fact]
        public async Task GivenInvalidBatchProcessingKey_WhenGetBatchInvoiceProcessingStatus_ShouldThrowError()
        {
            // Arrange
            var user = new Users
            {
                Id = Guid.NewGuid(),
                FirstName = DataUtilityService.GetRandomString(),
                LastName = DataUtilityService.GetRandomString(),
                UserAlias = DataUtilityService.GetRandomString(5),
                EmailAddress = DataUtilityService.GetRandomEmail(),
                Registered = DateTimeService.Now.AddDays(-120),
                IsActivated = true,
                PrivateKey = DataUtilityService.GetRandomString()
            };

            var processing = new BatchInvoicesProcessing
            {
                Id = Guid.NewGuid(),
                BatchProcessingTime = null,
                Status = ProcessingStatuses.New,
                CreatedAt = DateTimeService.Now
            };

            var invoices = new List<BatchInvoices>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    CreatedAt = DateTimeService.Now,
                    CreatedBy = user.Id,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = DataUtilityService.GetRandomString(),
                    VoucherDate = DataUtilityService.GetRandomDateTime(),
                    ValueDate = DataUtilityService.GetRandomDateTime(),
                    DueDate = DataUtilityService.GetRandomDateTime(),
                    PaymentTerms = DataUtilityService.GetRandomInteger(),
                    PaymentType = PaymentTypes.CreditCard,
                    CompanyName = DataUtilityService.GetRandomString(),
                    CompanyVatNumber = DataUtilityService.GetRandomString(),
                    CountryCode = CountryCodes.Pl,
                    City = DataUtilityService.GetRandomString(),
                    AddressLine1 = DataUtilityService.GetRandomString(),
                    AddressLine2 = DataUtilityService.GetRandomString(),
                    AddressLine3 = DataUtilityService.GetRandomString(),
                    PostalCode = DataUtilityService.GetRandomString(),
                    PostalArea = DataUtilityService.GetRandomString(),
                    InvoiceTemplateName = DataUtilityService.GetRandomString(),
                    CreatedAt = DateTimeService.Now,
                    CreatedBy = user.Id,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id
                }
            };

            var invoiceItems = new List<BatchInvoiceItems>
            {
                new()
                {
                    BatchInvoiceId = invoices[0].Id,
                    ItemText = DataUtilityService.GetRandomString(),
                    ItemQuantity = DataUtilityService.GetRandomInteger(),
                    ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                    ItemAmount = DataUtilityService.GetRandomDecimal(),
                    ItemDiscountRate = null,
                    ValueAmount = DataUtilityService.GetRandomDecimal(),
                    VatRate = null,
                    GrossAmount = DataUtilityService.GetRandomDecimal(),
                    CurrencyCode = CurrencyCodes.Gbp
                },
                new()
                {
                    BatchInvoiceId = invoices[1].Id,
                    ItemText = DataUtilityService.GetRandomString(),
                    ItemQuantity = DataUtilityService.GetRandomInteger(),
                    ItemQuantityUnit = DataUtilityService.GetRandomString(3),
                    ItemAmount = DataUtilityService.GetRandomDecimal(),
                    ItemDiscountRate = null,
                    ValueAmount = DataUtilityService.GetRandomDecimal(),
                    VatRate = null,
                    GrossAmount = DataUtilityService.GetRandomDecimal(),
                    CurrencyCode = CurrencyCodes.Gbp
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddAsync(user);
            await databaseContext.AddAsync(processing);
            await databaseContext.AddRangeAsync(invoices);
            await databaseContext.AddRangeAsync(invoiceItems);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.GetBatchInvoiceProcessingStatus(Guid.NewGuid()));
            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_PROCESSING_BATCH_KEY));
        }

        [Fact]
        public async Task GivenValidTemplateId_WhenGetInvoiceTemplate_ShouldSucceed()
        {
            // Arrange
            const int templateDataLength = 2048;
            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = false
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            var result = await service.GetInvoiceTemplate(templates[0].Id);

            // Assert
            result.ContentData.Should().HaveCount(templateDataLength);
        }

        [Fact]
        public async Task GivenInvalidTemplateId_WhenGetInvoiceTemplate_ShouldThrowError()
        {
            // Arrange
            const int templateDataLength = 1024;
            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = false
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.GetInvoiceTemplate(Guid.NewGuid()));
            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_TEMPLATE_ID));
        }

        [Fact]
        public async Task GivenDeletedTemplateId_WhenGetInvoiceTemplate_ShouldThrowError()
        {
            // Arrange
            const int templateDataLength = 1024;
            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = true
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.GetInvoiceTemplate(templates[1].Id));
            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_TEMPLATE_ID));
        }

        [Fact]
        public async Task GivenExistingTemplateId_WhenRemoveInvoiceTemplate_ShouldSucceed()
        {
            // Arrange
            const int templateDataLength = 2048;
            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = false
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            await service.RemoveInvoiceTemplate(templates[0].Id);

            // Assert
            var result = databaseContext.InvoiceTemplates
                .Where(invoiceTemplates => invoiceTemplates.Id == templates[0].Id)
                .Select(invoiceTemplates => invoiceTemplates.IsDeleted)
                .FirstOrDefault();

            result.Should().BeTrue();
        }

        [Fact]
        public async Task GivenNonExistingTemplateId_WhenRemoveInvoiceTemplate_ShouldThrowError()
        {
            // Arrange
            const int templateDataLength = 2048;
            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = true
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = true
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.RemoveInvoiceTemplate(Guid.NewGuid()));
            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_TEMPLATE_ID));
        }

        [Fact]
        public async Task GivenInvoiceTemplateData_WhenAddInvoiceTemplate_ShouldSucceed()
        {
            // Arrange
            var template = new InvoiceTemplate
            {
                TemplateName = DataUtilityService.GetRandomString(),
                InvoiceTemplateData = new InvoiceTemplateData
                {
                    ContentData = new byte[2048],
                    ContentType = DataUtilityService.GetRandomString()
                },
                InvoiceTemplateDescription = DataUtilityService.GetRandomString()
            };

            var databaseContext = GetTestDatabaseContext();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            var result = await service.AddInvoiceTemplate(template);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GivenExistingInvoiceTemplateId_WhenReplaceInvoiceTemplate_ShouldSucceed()
        {
            // Arrange
            const int templateDataLength = 1024;
            var newTemplateData = new InvoiceTemplateData
            {
                ContentData = new byte[514],
                ContentType = DataUtilityService.GetRandomString()
            };

            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = false
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            await service.ReplaceInvoiceTemplate(templates[0].Id, newTemplateData);

            // Assert
            var result = databaseContext.InvoiceTemplates
                .FirstOrDefault(invoiceTemplates => invoiceTemplates.Id == templates[0].Id);

            result.Should().NotBeNull();
            result?.Data.Should().HaveCount(newTemplateData.ContentData.Length);
        }

        [Fact]
        public async Task GivenNonExistingInvoiceTemplateId_WhenReplaceInvoiceTemplate_ShouldThrowError()
        {
            // Arrange
            const int templateDataLength = 1024;
            var newTemplateData = new InvoiceTemplateData
            {
                ContentData = new byte[514],
                ContentType = DataUtilityService.GetRandomString()
            };

            var templates = new List<InvoiceTemplates>
            {
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-150),
                    IsDeleted = false
                },
                new()
                {
                    Name = DataUtilityService.GetRandomString(),
                    Data = new byte[templateDataLength],
                    ContentType = DataUtilityService.GetRandomString(),
                    ShortDescription = DataUtilityService.GetRandomString(),
                    GeneratedAt = DateTimeService.Now.AddDays(-100),
                    IsDeleted = false
                }
            };

            var databaseContext = GetTestDatabaseContext();
            await databaseContext.AddRangeAsync(templates);
            await databaseContext.SaveChangesAsync();

            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedLoggerService = new Mock<ILoggerService>();

            var service = new InvoiceService(
                databaseContext, 
                mockedDateTimeService.Object, 
                mockedLoggerService.Object);

            // Act
            // Assert
            var result = await Assert.ThrowsAsync<BusinessException>(() 
                => service.ReplaceInvoiceTemplate(Guid.NewGuid(), newTemplateData));
            result.ErrorCode.Should().Be(nameof(ErrorCodes.INVALID_TEMPLATE_ID));
        }
    }
}