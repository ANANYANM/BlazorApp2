using Microsoft.CodeAnalysis.Scripting;
using BlazorApp2.Components;
using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Data;
namespace BlazorApp2.Services;

public class CustomerService
{
    private readonly TicketContext _context;

    public CustomerService(TicketContext context)
    {
        _context = context;
    }

    public async Task SubmitSignUpRequest(CustomerSignUpModel model,string role)
    {
        var pendingSignUp = new PendingSignUp
        {
            Name = model.Name,
            Company = model.Company,
            Username = model.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Role = role
        };
        _context.PendingSignUps.Add(pendingSignUp);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PendingSignUp>> GetPendingSignUps()
    {
        return await _context.PendingSignUps
            .Where(s => !s.IsApproved)
            .Select(s => new PendingSignUp
            {
                Id = s.Id,
                Name = s.Name,
                Company = s.Company,
                Username = s.Username
            }).ToListAsync();
    }

    public async Task ApproveSignUp(int id,string role)
    {
        try
        {
            var signUp = await _context.PendingSignUps.FindAsync(id);
            if (signUp != null)
            {
                var user = new User
                {
                    Name = signUp.Name,
                    Company = signUp.Company,
                    Username = signUp.Username,
                    Password = signUp.Password,
                    Role = role
                };
                _context.Users.Add(user);
                _context.PendingSignUps.Remove(signUp); // Remove from pending sign-ups
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            // Log the exception or throw it to the caller
            throw new Exception($"Error approving sign-up: {ex.Message}");
        }
    }

    public async Task RejectSignUp(int id)
    {
        var signUp = await _context.PendingSignUps.FindAsync(id);
        if (signUp != null)
        {
            _context.PendingSignUps.Remove(signUp);
            await _context.SaveChangesAsync();
        }
    }
}

