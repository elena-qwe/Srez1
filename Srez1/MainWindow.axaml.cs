
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Srez1.Models;

namespace Srez1;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        ShowUsers();
        ShowRole();
    }

    private void ShowUsers()
    {
        using ( PostgresContext db = new PostgresContext())
        {
            var users = db.Users.Join(db.InfoUsers,
                c => c.IdInfoUser, p => p.Id,
                (c, p) => new
            {
                address_home = p.AddressHome,
                phone_number = p.PhoneNumber,
                birthday_date = p.BirthdayDate.ToString(),
                first_name = c.FirstName,
                middle_name = c.MiddleName,
                last_name = c.LastName
            }).ToList();
            UserGrid.Items = users;
        }
    }

    private void ShowRole()
    {
        using (PostgresContext db = new PostgresContext())
        {
            var roles = db.Roles.Join(db.Users,
                x => x.Id, p => p.IdRole,
                (x, p) => new 
                {
                    id = x.Id,
                    name = x.Name,
                    first_name = p.FirstName,
                    last_name = p.LastName,
                    middle_name = p.MiddleName 
                }).ToList();
            RoleDataGrid.Items = roles;
        }
      
        
    }

    private void BtnDelete_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }
}

