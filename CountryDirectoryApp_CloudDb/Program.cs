using CountryDirectoryApp_CloudDb;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

//1.GET / api - ������ �������, ������� ��������� �server is running�
app.MapGet("/api", () => new { Message = "server is running" });

//2.GET / api / ping - ������� ��������� �pong�
app.MapGet("/api/ping", () => new { Message = "pong" });

// 3. GET /api/country - ������� ������ ���� ����� �� ������� ��
app.MapGet("/api/country", async (ApplicationDbContext db) =>
{
    return await db.Countries.ToListAsync();
});

// 4. GET /api/country/{id} - ������� ������ �� id ��� null ���� ��� ����� � ��
app.MapGet("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    return await db.Countries.FirstOrDefaultAsync(d => d.Id == id);
});

//5.GET / api / country /{ code} -������� ������ �� ���� ��� null ���� �� ����� � ��
app.MapGet("/api/country/code/{code}", async (string code, ApplicationDbContext db) =>
{
    var country = await db.Countries.FirstOrDefaultAsync(c => c.Alpha2Code == code);
    return country == null ? Results.NotFound() : Results.Ok(country);
});

// 6. POST /api/country
app.MapPost("/api/country", async (Country country, ApplicationDbContext db) =>
{
    await db.Countries.AddAsync(country);
    await db.SaveChangesAsync();
    return country;
});

// 7. DELETE /api/country/{id}
app.MapDelete("/api/country/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Country? deleted = await db.Countries.FirstOrDefaultAsync(d => d.Id == id);
    if (deleted != null)
    {
        db.Countries.Remove(deleted);
        await db.SaveChangesAsync();
    }
});

app.Run();
