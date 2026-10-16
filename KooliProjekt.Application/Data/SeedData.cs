using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Kui andmed on juba olemas, siis uuesti ei täida
                if (context.Customers.Any())
                {
                    return;
                }

                var random = new Random();

                var firstNames = new[] { "Kati", "Mati", "Jaan", "Mari", "Karl", "Anni", "Peeter", "Eva", "Kristjan", "Laura" };
                var lastNames = new[] { "Tamm", "Kask", "Saar", "Sepp", "Mägi", "Kukk", "Rebane", "Koppel", "Ilves", "Lepik" };

                // 1. KLIENDID (Customers) 
                for (int i = 1; i <= 35; i++)
                {
                    var fName = firstNames[random.Next(firstNames.Length)];
                    var lName = lastNames[random.Next(lastNames.Length)];

                    context.Customers.Add(new Customer
                    {
                        FirstName = fName,
                        LastName = lName,
                        Email = $"{fName.ToLower()}.{lName.ToLower()}{i}@example.com",
                        Phone = $"+372 5{random.Next(1000000, 9999999)}"
                    });
                }
                context.SaveChanges();

                // 2. KASUTAJAD (SystemUsers) 
                for (int i = 1; i <= 35; i++)
                {
                    var fName = firstNames[random.Next(firstNames.Length)];
                    var lName = lastNames[random.Next(lastNames.Length)];

                    context.SystemUsers.Add(new SystemUser
                    {
                        FirstName = fName,
                        LastName = lName,
                        Email = $"user{i}@kooliprojekt.ee"
                    });
                }
                context.SaveChanges();

                // 3. SÜNDMUSED (Events) 
                var eventTitles = new[] { "Koolitus", "Seminar", "Veebinar", "Töötuba", "Konverents" };
                for (int i = 1; i <= 35; i++)
                {
                    context.Events.Add(new Event
                    {
                        Name = $"{eventTitles[random.Next(eventTitles.Length)]} #{i}",
                        Description = $"Kirjeldus üritusele nr {i}",
                        StartTime = DateTime.Now.AddDays(i),
                        Capacity = random.Next(20, 200),
                        Price = random.Next(10, 150)
                    });
                }
                context.SaveChanges();

                // 4. REGISTREERIMISED (Registrations) 
                var customers = context.Customers.ToList();
                var events = context.Events.ToList();

                for (int i = 0; i < 35; i++)
                {
                    context.Registrations.Add(new Registration
                    {
                        CustomerId = customers[i % customers.Count].Id,
                        EventId = events[i % events.Count].Id,
                        RegisteredAt = DateTime.Now.AddDays(-i),
                        Status = RegistrationStatus.Confirmed
                    });
                }
                context.SaveChanges();

                // 5. ARVED (Invoices) 
                var registrations = context.Registrations.ToList();
                var systemUsers = context.SystemUsers.ToList();

                for (int i = 0; i < 35; i++)
                {
                    context.Invoices.Add(new Invoice
                    {
                        InvoiceNumber = $"INV-2026-{i + 1:D4}",
                        IssueDate = DateTime.Now.AddDays(-i),
                        DueDate = DateTime.Now.AddDays(-i + 14),
                        Amount = random.Next(10, 500),
                        Status = InvoiceStatus.Paid,
                        RegistrationId = registrations[i % registrations.Count].Id,
                        SystemUserId = systemUsers[i % systemUsers.Count].Id
                    });
                }
                context.SaveChanges();
            }
        }
    }
}