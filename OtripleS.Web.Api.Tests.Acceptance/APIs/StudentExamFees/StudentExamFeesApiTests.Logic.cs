﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using OtripleS.Web.Api.Tests.Acceptance.Models.StudentExamFees;
using RESTFulSense.Exceptions;
using Xunit;

namespace OtripleS.Web.Api.Tests.Acceptance.APIs.StudentExamFees
{
    public partial class StudentExamFeesApiTests
    {
        [Fact]
        public async Task ShouldPostStudentExamFeeAsync()
        {
            // given
            StudentExamFee randomStudentExamFee = await CreateRandomStudentExamFeeAsync();
            StudentExamFee inputStudentExamFee = randomStudentExamFee;
            StudentExamFee expectedStudentExamFee = inputStudentExamFee;

            // when 
            await this.otripleSApiBroker.PostStudentExamFeeAsync(inputStudentExamFee);

            StudentExamFee actualStudentExamFee =
               await this.otripleSApiBroker.GetStudentExamFeeByIdsAsync(
                   inputStudentExamFee.StudentId,
                   inputStudentExamFee.ExamFeeId);

            // then
            actualStudentExamFee.Should().BeEquivalentTo(expectedStudentExamFee);
            await DeleteStudentExamFeeAsync(actualStudentExamFee);
        }

        
    }
}
