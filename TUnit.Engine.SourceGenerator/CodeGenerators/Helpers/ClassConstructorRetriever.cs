﻿using Microsoft.CodeAnalysis;
using TUnit.Engine.SourceGenerator.Models.Arguments;

namespace TUnit.Engine.SourceGenerator.CodeGenerators.Helpers;

internal class ClassConstructorRetriever
{
    public static ArgumentsContainer Parse(INamedTypeSymbol namedTypeSymbol, AttributeData dataAttribute, int index)
    {
        var type = dataAttribute.AttributeClass!.TypeArguments.First();

        return new ArgumentsContainer
        {
            Arguments = [],
            DataAttribute = dataAttribute,
            DataAttributeIndex = index,
            ClassConstructorType = type.ToDisplayString(DisplayFormats.FullyQualifiedGenericWithGlobalPrefix),
            IsEnumerableData = false
        };
    }
}