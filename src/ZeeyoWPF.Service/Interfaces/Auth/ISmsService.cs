﻿using ZeeyoWPF.Service.Models.Response;
using ZeeyoWPF.Service.Models.SmsModels;

namespace ZeeyoWPF.Service.Interfaces.Auth;

public interface ISmsService
{
    public Task<Response> SendCodeByPhoneNumberAsync(string phoneNumber);
    public Task<Response> VerifySmsCodeAsync(VerifyPhoneNumberModel phoneNumberModel);
}
