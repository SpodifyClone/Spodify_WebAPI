﻿namespace Spodify.Domain.Exceptions.Auth;

public class VerificationCodeExpiredException : ExpiredException
{
	public VerificationCodeExpiredException()
	{
		TitleMessage = "Verification code is expired!";
	}
}
