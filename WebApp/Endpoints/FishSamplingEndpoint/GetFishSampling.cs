﻿using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApp.Endpoints.FishSamplingEndpoint.Dto;

namespace WebApp.Endpoints.FishSamplingEndpoint;

public class GetFishSampling : Ep
    .NoReq
    .Res<Results<
        Ok<List<FishSamplingDto>>,
        BadRequest<string>
    >>
{
    private readonly AppDbContext _db;

    public GetFishSampling(AppDbContext db)
    {
        _db = db;
    }

    public override void Configure()
    {
        Get("/fish-sampling");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<List<FishSamplingDto>>, BadRequest<string>>> ExecuteAsync(
        CancellationToken ct)
    {
        var result = await _db.FishSamplings
            .Select(x => new FishSamplingDto
            {
                Timestamp = x.Timestamp,
                FishCode = x.FishCode,
                Weight = x.Weight
            })
            .ToListAsync(cancellationToken: ct);

        return TypedResults.Ok(result);
    }
}