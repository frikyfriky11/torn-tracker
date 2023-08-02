﻿global using InfluxDB.Client.Api.Domain;
global using InfluxDB.Client.Writes;
global using InfluxDB.Client;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using NodaTime;
global using System.Text.Json;
global using TornTracker.Application.Common.Interfaces;
global using TornTracker.Application.Common.TornApi;
global using TornTracker.Domain.Entities;
global using TornTracker.Infrastructure.Persistence;
global using TornTracker.Infrastructure.Services;
global using TornTracker.Infrastructure.Settings;