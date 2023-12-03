﻿using FluentValidation.Results;

namespace WebApiProject.Application.Exceptions;

public class ValidationException : ApplicationException
{
	public IDictionary<string, string[]> Errors { get; set; }
	public ValidationException() : base("One or more validation failures have occurred") 
	{ 
	}

	public ValidationException(IEnumerable<ValidationFailure> failures) : this()
	{
		Errors = failures
			.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
			.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
	}
}
