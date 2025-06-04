using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaEdit.Highlighting; // Add this namespace for syntax highlighting definitions
using MoonIDE.Console;
using MoonIDE.Lua;
using System.Collections.Generic;

namespace MoonIDE.Views;

public partial class MainView : UserControl
{
    LuaInterpreter luaInterpreter;
    public MainView()
    {
        InitializeComponent();
        //Setting the code editor's settings (later move them to the settings)
        CodeEditor.Options.HighlightCurrentLine = true;
        CodeEditor.Options.ShowTabs = true;
        CodeEditor.Options.ShowSpaces = true;
        CodeEditor.Options.AllowToggleOverstrikeMode = true;
        CodeEditor.Options.EnableTextDragDrop = true;
        CodeEditor.Options.ShowEndOfLine=true;
        CodeEditor.Options.ShowBoxForControlCharacters = true;



        var luaHighlighting = HighlightingManager.Instance.GetDefinition("Lua");
        CodeEditor.SyntaxHighlighting = luaHighlighting;
        luaInterpreter  = new LuaInterpreter();
        luaInterpreter.init();

       

        // Try to get the Lua highlighting definition
        GetIDEHistory();
    }
    private void ClearConsoleOutput_Click(object? sender, RoutedEventArgs e)
    {
        ConsoleOutput.Text = string.Empty;
    }
    private void Start_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        luaInterpreter.RegisterDefaultWrappers();
        luaInterpreter.ExecuteScript(CodeEditor.Text);
        GetIDEHistory();
    }

    private void CopyConsoleOutput_Click(object? sender, RoutedEventArgs e)
    {
        
    }

    private void Exit_Click(object? sender, RoutedEventArgs e)
    {
         
    }
    public void GetIDEHistory()
    {
        ConsoleOutput.Text = "";
        IDEConsoleHistory history = new IDEConsoleHistory();
        // Load the console history into the console output TextBox
        var consoleHistory = history.getHistory();
        foreach (var message in consoleHistory)
        {
            ConsoleOutput.Text += message + "\n";
        }
    }
}
