/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Interfaces;

public interface IConsole
{
    /// <summary>Clear the console window from any text.</summary>
    void Clear();

    /// <summary>
    /// Load,compile and run a script by calling its main function with the provided arguments Errors are outputed to the console window. The function will return when the
    /// script has finished execution.
    /// </summary>
    /// <param name="script">   Path to the script that will be run</param>
    /// <param name="arguments">Arguments to pass to the script</param>
    void RunScript(string script, string arguments);

    // Load,compile and run a script by calling its main function with the provided arguments
    /// <summary>Run a script without extra arguments. Errors are outputted to the console window.</summary>
    /// <param name="script">Path to the script to be run.</param>
    void RunScript(string script);

    /// <summary>Write text to the console window</summary>
    /// <param name="line">Text to be written</param>
    void Write(string line);

    /// <summary>Write a line of text to the console window</summary>
    /// <param name="line">Text to be output</param>
    void WriteLine(string line);
}