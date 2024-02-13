using Microsoft.EntityFrameworkCore;
using EmsFullStackApplication.Data;
using EmsFullStackApplication.Models;
namespace EmsFullStackApplication.Controllers;

public static class DeptMasterEndpoints
{
    public static void MapDeptMasterEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/DeptMaster", async (DeptMasterContext db) =>
        {
            return await db.DeptMaster.ToListAsync();
        })
        .WithName("GetAllDeptMasters")
        .Produces<List<DeptMaster>>(StatusCodes.Status200OK);

        routes.MapGet("/api/DeptMaster/{id}", async (int DeptCode, DeptMasterContext db) =>
        {
            return await db.DeptMaster.FindAsync(DeptCode)
                is DeptMaster model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetDeptMasterById")
        .Produces<DeptMaster>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/DeptMaster/{id}", async (int DeptCode, DeptMaster deptMaster, DeptMasterContext db) =>
        {
            var foundModel = await db.DeptMaster.FindAsync(DeptCode);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(deptMaster);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateDeptMaster")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/DeptMaster/", async (DeptMaster deptMaster, DeptMasterContext db) =>
        {
            db.DeptMaster.Add(deptMaster);
            await db.SaveChangesAsync();
            return Results.Created($"/DeptMasters/{deptMaster.DeptCode}", deptMaster);
        })
        .WithName("CreateDeptMaster")
        .Produces<DeptMaster>(StatusCodes.Status201Created);

        routes.MapDelete("/api/DeptMaster/{id}", async (int DeptCode, DeptMasterContext db) =>
        {
            if (await db.DeptMaster.FindAsync(DeptCode) is DeptMaster deptMaster)
            {
                db.DeptMaster.Remove(deptMaster);
                await db.SaveChangesAsync();
                return Results.Ok(deptMaster);
            }

            return Results.NotFound();
        })
        .WithName("DeleteDeptMaster")
        .Produces<DeptMaster>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
	public static void MapDeptMasterEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/DeptMaster", async (fullprofileDbContext db) =>
        {
            return await db.DeptMaster.ToListAsync();
        })
        .WithName("GetAllDeptMasters")
        .Produces<List<DeptMaster>>(StatusCodes.Status200OK);

        routes.MapGet("/api/DeptMaster/{id}", async (int EmpCode, fullprofileDbContext db) =>
        {
            return await db.DeptMaster.FindAsync(EmpCode)
                is DeptMaster model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetDeptMasterById")
        .Produces<DeptMaster>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/DeptMaster/{id}", async (int EmpCode, DeptMaster deptMaster, fullprofileDbContext db) =>
        {
            var foundModel = await db.DeptMaster.FindAsync(EmpCode);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(deptMaster);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateDeptMaster")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/DeptMaster/", async (DeptMaster deptMaster, fullprofileDbContext db) =>
        {
            db.DeptMaster.Add(deptMaster);
            await db.SaveChangesAsync();
            return Results.Created($"/DeptMasters/{deptMaster.EmpCode}", deptMaster);
        })
        .WithName("CreateDeptMaster")
        .Produces<DeptMaster>(StatusCodes.Status201Created);


        routes.MapDelete("/api/DeptMaster/{id}", async (int EmpCode, fullprofileDbContext db) =>
        {
            if (await db.DeptMaster.FindAsync(EmpCode) is DeptMaster deptMaster)
            {
                db.DeptMaster.Remove(deptMaster);
                await db.SaveChangesAsync();
                return Results.Ok(deptMaster);
            }

            return Results.NotFound();
        })
        .WithName("DeleteDeptMaster")
        .Produces<DeptMaster>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
