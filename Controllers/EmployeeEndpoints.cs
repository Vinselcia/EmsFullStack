using Microsoft.EntityFrameworkCore;
using EmsFullStackApplication.Data;
using EmsFullStackApplication.Models;
namespace EmsFullStackApplication.Controllers;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Employee", async (EmployeeDbContext db) =>
        {
            return await db.Employee.ToListAsync();
        })
        .WithName("GetAllEmployees")
        .Produces<List<Employee>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Employee/{id}", async (int EmpCode, EmployeeDbContext db) =>
        {
            return await db.Employee.FindAsync(EmpCode)
                is Employee model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEmployeeById")
        .Produces<Employee>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Employee/{id}", async (int EmpCode, Employee employee, EmployeeDbContext db) =>
        {
            var foundModel = await db.Employee.FindAsync(EmpCode);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(employee);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEmployee")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Employee/", async (Employee employee, EmployeeDbContext db) =>
        {
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return Results.Created($"/Employees/{employee.EmpCode}", employee);
        })
        .WithName("CreateEmployee")
        .Produces<Employee>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Employee/{id}", async (int EmpCode, EmployeeDbContext db) =>
        {
            if (await db.Employee.FindAsync(EmpCode) is Employee employee)
            {
                db.Employee.Remove(employee);
                await db.SaveChangesAsync();
                return Results.Ok(employee);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEmployee")
        .Produces<Employee>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
