using ContactApp2.Core.ViewModels;

namespace ContactApp2.ContactManager.Pages;

public partial class ReportPage : ContentPage
{
	public ReportPage(ReportViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}