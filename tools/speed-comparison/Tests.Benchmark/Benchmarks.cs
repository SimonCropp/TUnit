﻿using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using CliWrap;

namespace Tests.Benchmark;

[MarkdownExporterAttribute.GitHub]
public class Benchmarks
{
    private readonly Stream _outputStream = Console.OpenStandardOutput();

    private static readonly string TUnitPath = GetProjectPath("TUnitTimer");
    private static readonly string NUnitPath = GetProjectPath("NUnitTimer");
    private static readonly string xUnitPath = GetProjectPath("xUnitTimer");
    private static readonly string MSTestPath = GetProjectPath("MSTestTimer");
    
    private static readonly string? ClassName = Environment.GetEnvironmentVariable("CLASS_NAME");
    
    [GlobalCleanup]
    public async Task FlushStream()
    {
        await _outputStream.FlushAsync();
    }
    
    [Benchmark]
    [BenchmarkCategory("Runtime")]
    public async Task TUnit_AOT()
    {
        await Cli.Wrap(Path.Combine(TUnitPath, "aot-publish", GetExecutableFileName()))
            .WithArguments(["--treenode-filter",  $"/*/*/{ClassName}/*"])
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }

    [Benchmark]
    [BenchmarkCategory("Runtime")]
    public async Task TUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["run", "--no-build", "-c", "Release", "--treenode-filter",  $"/*/*/{ClassName}/*"])
            .WithWorkingDirectory(TUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }

    [Benchmark]
    [BenchmarkCategory("Runtime")]
    public async Task NUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["test", "--no-build", "-c", "Release", "--filter", $"FullyQualifiedName~{ClassName}"])
            .WithWorkingDirectory(NUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }

    [Benchmark]
    [BenchmarkCategory("Runtime")]
    public async Task xUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["test", "--no-build", "-c", "Release", "--filter", $"FullyQualifiedName~{ClassName}"])
            .WithWorkingDirectory(xUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }

    [Benchmark]
    [BenchmarkCategory("Runtime")]
    public async Task MSTest()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["test", "--no-build", "-c", "Release", "--filter", $"FullyQualifiedName~{ClassName}"])
            .WithWorkingDirectory(MSTestPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }
    
    [Benchmark]
    [BenchmarkCategory("Build")]
    public async Task Build_TUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["build", "--no-incremental", "-c", "Release"])
            .WithWorkingDirectory(TUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }
    
    [Benchmark]
    [BenchmarkCategory("Build")]
    public async Task Build_NUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["build", "--no-incremental", "-c", "Release"])
            .WithWorkingDirectory(NUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }
    
    [Benchmark]
    [BenchmarkCategory("Build")]
    public async Task Build_xUnit()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["build", "--no-incremental", "-c", "Release"])
            .WithWorkingDirectory(xUnitPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }
    
    [Benchmark]
    [BenchmarkCategory("Build")]
    public async Task Build_MSTest()
    {
        await Cli.Wrap("dotnet")
            .WithArguments(["build", "--no-incremental", "-c", "Release"])
            .WithWorkingDirectory(MSTestPath)
            .WithStandardOutputPipe(PipeTarget.ToStream(_outputStream))
            .ExecuteAsync();
    }

    private static string GetProjectPath(string name)
    {
        var folder = new DirectoryInfo(Environment.CurrentDirectory);

        while (folder.Name != "speed-comparison")
        {
            folder = folder.Parent!;
        }
        
        return Path.Combine(folder.FullName, name, name);
    }

    private string GetPlatformFolder()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "win-x64";
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return "linux-x64";
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return "osx-x64";
        }
        
        throw new NotImplementedException();
    }

    private string GetExecutableFileName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "TUnitTimer.exe";
        }

        return "TUnitTimer";
    }
}
