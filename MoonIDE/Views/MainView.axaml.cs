using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaEdit.Highlighting; // Add this namespace for syntax highlighting definitions
using MoonIDE.Lua;

namespace MoonIDE.Views;

public partial class MainView : UserControl
{
    LuaInterpreter luaInterpreter;
    public MainView()
    {
        InitializeComponent();

        // Try to get the Lua highlighting definition
        var luaHighlighting = HighlightingManager.Instance.GetDefinition("Lua");
        CodeEditor.SyntaxHighlighting = luaHighlighting;

        luaInterpreter  = new LuaInterpreter();
        luaInterpreter.init();
    }
    private void ClearConsoleOutput_Click(object? sender, RoutedEventArgs e)
    {
        ConsoleOutput.Text = string.Empty;
    }
    private void Start_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        luaInterpreter.RegisterDefaultWrappers();
        luaInterpreter.ExecuteScript(CodeEditor.Text);
    }

    private void CopyConsoleOutput_Click(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Exit_Click(object? sender, RoutedEventArgs e)
    {
         
    }

}
