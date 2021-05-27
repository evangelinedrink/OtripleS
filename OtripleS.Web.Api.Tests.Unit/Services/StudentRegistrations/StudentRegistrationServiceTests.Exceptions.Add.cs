﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OtripleS.Web.Api.Models.StudentRegistrations;
using OtripleS.Web.Api.Models.StudentRegistrations.Exceptions;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.StudentRegistrations
{
    public partial class StudentRegistrationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddWhenSqlExceptionOccursAndLogItAsync()
        {
            // given
            StudentRegistration someStudentRegistration = CreateRandomStudentRegistration();
            var sqlException = GetSqlException();

            var expectedStudentRegistrationDependencyException =
                new StudentRegistrationDependencyException(sqlException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentRegistrationAsync(It.IsAny<StudentRegistration>()))
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<StudentRegistration> addStudentRegistrationTask =
                this.studentRegistrationService.AddStudentRegistrationAsync(someStudentRegistration);

            // then
            await Assert.ThrowsAsync<StudentRegistrationDependencyException>(() =>
                addStudentRegistrationTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentRegistrationAsync(It.IsAny<StudentRegistration>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedStudentRegistrationDependencyException))),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
