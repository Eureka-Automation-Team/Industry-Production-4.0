﻿using IPD.Application.TodoLists.Commands.UpdateTodoList;
using IPD.Application.UnitTests.Common;
using IPD.Domain.Entities;
using Shouldly;
using Xunit;

namespace IPD.Application.UnitTests.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandValidatorTests : CommandTestBase
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new UpdateTodoListCommand
            {
                Id = 1,
                Title = "Shopping"
            };

            var validator = new UpdateTodoListCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            Context.TodoLists.Add(new TodoList { Title = "Shopping" });
            Context.SaveChanges();

            var command = new UpdateTodoListCommand
            {
                Id = 2,
                Title = "Shopping"
            };

            var validator = new UpdateTodoListCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}