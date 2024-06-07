﻿using TUnit.Core;
using TUnit.TestProject.Enums;

namespace TUnit.TestProject;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class PriorityAttribute : PropertyAttribute
{
    public PriorityLevel PriorityLevel { get; }

    public PriorityAttribute(PriorityLevel priorityLevel) : base("Priority", priorityLevel.ToString())
    {
        PriorityLevel = priorityLevel;
    }
}

public class PriorityFilteringTests
{
    [Test, Priority(PriorityLevel.High)]
    public async Task High_1()
    {
        await Task.CompletedTask;
    }
    
    [Test, Priority(PriorityLevel.High)]
    public async Task High_2()
    {
        await Task.CompletedTask;
    }
    
    [Test, Priority(PriorityLevel.High)]
    public async Task High_3()
    {
        await Task.CompletedTask;
    }
    
    [Test, Priority(PriorityLevel.Medium)]
    public async Task Medium_1()
    {
        await Task.CompletedTask;
    }
    
    [Test, Priority(PriorityLevel.Medium)]
    public async Task Medium_2()
    {
        await Task.CompletedTask;
    }
    
    [Test, Priority(PriorityLevel.Low)]
    public async Task Low_1()
    {
        await Task.CompletedTask;
    }
}