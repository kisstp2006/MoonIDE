using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading; // Add this namespace for Dispatcher
using AvaloniaEdit.Highlighting; // Add this namespace for syntax highlighting definitions
using MoonIDE.Console;
using MoonIDE.Lua;
using System;
using System.Collections.Generic;

namespace MoonIDE.Views;

public partial class MainView : UserControl
{
    LuaInterpreter luaInterpreter;
    private int _lastLogCount = 0;

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
        CodeEditor.Options.HideCursorWhileTyping = true;
        CodeEditor.Options.CutCopyWholeLine = true;



        var luaHighlighting = HighlightingManager.Instance.GetDefinition("Lua");
        CodeEditor.SyntaxHighlighting = luaHighlighting;
        luaInterpreter  = new LuaInterpreter();
        luaInterpreter.init();

        // Subscribe to log updates
        MoonIDE.Lua.Debug.LogUpdated += OnLogUpdated;

       
        GetIDEHistory();
    }

    private void OnLogUpdated()
    {
        // Only update if there are new log messages
        var logCount = MoonIDE.Lua.Debug.GetLogedMessages().Count;
        if (logCount > _lastLogCount)
        {
            _lastLogCount = logCount;
            Dispatcher.UIThread.Post(GetIDEHistory);
        }
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
    public void GetIDEHistory()
    {
        var consoleHistory = new IDEConsoleHistory().getHistory();
        ConsoleOutput.Text = string.Join('\n', consoleHistory);
        _lastLogCount = consoleHistory.Count; // Update the count after refresh
    }

    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
