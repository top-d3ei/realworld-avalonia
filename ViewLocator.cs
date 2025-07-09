using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using realworld_avalonia.ViewModels;

namespace realworld_avalonia;

public class ViewLocator : IDataTemplate
{

    public Control? Build(object? param)
    {
        if (param is null)
            return null;
        
        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        // var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);
        var type = Type.GetType(name);

        if (type != null)
        {
            var control = (Control)Activator.CreateInstance(type)!;
            // control.DataContext = param;
            return control;
        }
        
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
