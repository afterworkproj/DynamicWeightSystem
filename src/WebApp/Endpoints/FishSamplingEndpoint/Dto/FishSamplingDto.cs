﻿namespace WebApp.Endpoints.FishSamplingEndpoint.Dto;

public class FishSamplingDto
{
    public required long Timestamp { get; set; }
    public required string FishCode { get; set; }
    public required int Weight { get; set; }
}