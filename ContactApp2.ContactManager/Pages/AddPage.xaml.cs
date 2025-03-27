using ContactApp2.Core.ViewModels;

namespace ContactApp2.ContactManager.Pages;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
        InitializeComponent();
		this.BindingContext = viewModel;
	}
}