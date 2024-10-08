using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Operators;
using TUnit.Assertions.AssertionBuilders;

namespace TUnit.Assertions.AssertConditions;

public abstract class BaseAssertCondition
{
    protected internal string? OverriddenMessage { get; set; }
    protected internal abstract string GetFailureMessage();
}

public abstract class BaseAssertCondition<TActual> : BaseAssertCondition
{
    internal InvokableAssertionBuilder<TActual, TAnd, TOr> ChainedTo<TAnd, TOr>(AssertionBuilder<TActual, TAnd, TOr> assertionBuilder, string[] argumentExpressions, [CallerMemberName] string caller = "")
        where TAnd : IAnd<TActual, TAnd, TOr>
        where TOr : IOr<TActual, TAnd, TOr>
    {
        return assertionBuilder.AppendExpression($"{caller}({string.Join(", ", argumentExpressions)})").WithAssertion(this);
    }
    
    internal bool Assert(AssertionData<TActual> assertionData)
    {
        return Assert(assertionData.Result, assertionData.Exception, assertionData.ActualExpression);
    }

    protected TActual? ActualValue { get; private set; }
    protected Exception? Exception { get; private set; }
    protected internal string? ActualExpression { get; private set; }
    
    internal bool Assert(TActual? actualValue, Exception? exception, string? actualExpression)
    {
        ActualValue = actualValue;
        Exception = exception;
        ActualExpression = actualExpression;
        
        return Passes(actualValue, exception);
    }

    private protected abstract bool Passes(TActual? actualValue, Exception? exception);
}