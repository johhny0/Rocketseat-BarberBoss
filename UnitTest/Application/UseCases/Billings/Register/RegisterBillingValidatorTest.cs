﻿using Application.UseCases.Billings;
using Application.UseCases.Billings.Register;
using Communication.Request;
using Domain;
using FluentAssertions;
using UnitTest.Builder;

namespace UnitTest.Application.UseCases.Billings.Register;
public class RegisterBillingValidatorTest
{
    private readonly RegisterBillingValidator _validator = new();
   
    [Fact]
    public void ShouldReturnErrorWhenTitleIsEmpty()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
            .WithTitle("")
            .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.TITLE_REQUIRED));
    }

    [Fact]
    public void ShouldReturnErrorWhenDueDateIsEmpty()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
            .WithDueDate("")
            .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.DUE_DATE_REQUIRED));
    }

    [Fact]
    public void ShouldReturnErrorWhenDueDateIsInvalid()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
            .WithDueDate("InvalidDate")
            .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.DUE_DATE_INVALID));
    }

    [Fact]
    public void ShouldReturnErrorWhenPaymentMethodIsEmpty()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
            .WithPaymentMethod(null)
            .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.PAYMENT_METHOD_REQUIRED));
    }

    [Fact]
    public void ShouldReturnErrorWhenPaymentMethodIsInvalid()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
           .WithPaymentMethod(10)
           .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.PAYMENT_METHOD_NOT_VALID));
    }

    [Fact]
    public void ShouldReturnErrorWhenValueIsNull()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
           .WithValue(null)
           .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.VALUE_REQUIRED));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShouldReturnErrorWhenValueIsZeroOrNegative(decimal value)
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
           .WithValue(value)
           .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(e => e.ErrorMessage.Equals(BillingsResource.VALUE_GREATER_THAN_ZERO));
    }

    [Fact]
    public void ShouldReturnTrueWhenBillingIsValid()
    {
        // Arrange
        var request = new RequestRegisterBillingBuilder()
           .Build();

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Errors.Should().BeEmpty();
        result.IsValid.Should().BeTrue();
    }
}
