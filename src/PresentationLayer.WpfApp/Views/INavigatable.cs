namespace PresentationLayer.WpfApp.Views
{
    public interface INavigatable
    {
        void BuildNavigation(MainWindow window);
        void Refresh();
    }
}