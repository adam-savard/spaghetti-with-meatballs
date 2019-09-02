using Avalonia;
using Avalonia.Markup.Xaml;

namespace meatballs
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
