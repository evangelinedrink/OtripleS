﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using OtripleS.Web.Api.Brokers.DateTimes;
using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.SemesterCourses;

namespace OtripleS.Web.Api.Services.SemesterCourses
{
	public partial class SemesterCourseService : ISemesterCourseService
	{
		private readonly IStorageBroker storageBroker;
		private readonly ILoggingBroker loggingBroker;
		private readonly IDateTimeBroker dateTimeBroker;

		public SemesterCourseService(IStorageBroker storageBroker,
			ILoggingBroker loggingBroker,
			IDateTimeBroker dateTimeBroker)
		{
			this.storageBroker = storageBroker;
			this.loggingBroker = loggingBroker;
			this.dateTimeBroker = dateTimeBroker;
		}

		public ValueTask<SemesterCourse> RetrieveSemesterCourseByIdAsync(Guid courseId)
		{
			throw new NotImplementedException();
		}
	}
}
