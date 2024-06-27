using ApiNasaAlbornoz.ViewModels;
namespace ApiNasaAlbornoz.Views;

public partial class ApodPageEA : ContentPage
{
    public ApodPageEA()
    {
        InitializeComponent();
        BindingContext = new ApodViewModelEA();
    }
}