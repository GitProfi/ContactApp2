using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactApp2.Data.Services;
using ContactApp2.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp2.Core.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace ContactApp2.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    IRepository _repository;
    private bool IsLoaded = false;

    public MainViewModel(IRepository repository)
    {
        _repository = repository;

        WeakReferenceMessenger.Default.Register<AddContactMessage>(this, (r, m) =>
        {
            System.Diagnostics.Debug.WriteLine(r);
            System.Diagnostics.Debug.WriteLine(m.Value);

            Contacts.Add(m.Value);

            /*
            Contacts.Clear();

            var contacts = _repository.Get();
            foreach (var contact in contacts)
            {
                System.Diagnostics.Debug.WriteLine(contact);
                Contacts.Add(contact);
            }
            */
            //  this.IsLoaded = !this.IsLoaded;


        });
    }

    [ObservableProperty]
    ObservableCollection<Contact>_contacts = new ObservableCollection<Contact>();

    [RelayCommand]
    void Load()
    {
        if (!this.IsLoaded)
        {
            var contacts = _repository.Get();

            foreach (var contact in contacts)
            {
                System.Diagnostics.Debug.WriteLine(contact);
                Contacts.Add(contact);
            }

            this.IsLoaded = !this.IsLoaded;
        }
    }
}
