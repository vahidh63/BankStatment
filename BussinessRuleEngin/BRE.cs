using System;
using System.Collections.Generic;

public interface ICondition
{
    bool Evaluate(Dictionary<string, object> data);
}

public interface IAction
{
    void Execute(Dictionary<string, object> data);
}

public class Rule
{
    public ICondition Condition { get; }
    public IAction Action { get; }

    public Rule(ICondition condition, IAction action)
    {
        Condition = condition;
        Action = action;
    }

    public void Apply(Dictionary<string, object> data)
    {
        if (Condition.Evaluate(data))
        {
            Action.Execute(data);
        }
    }
}

public class RulesEngine
{
    private readonly List<Rule> _rules = new List<Rule>();

    public void AddRule(Rule rule)
    {
        _rules.Add(rule);
    }

    public void Execute(Dictionary<string, object> data)
    {
        foreach (var rule in _rules)
        {
            rule.Apply(data);
        }
    }
}

// Example conditions and actions
public class AgeCondition : ICondition
{
    private readonly int _minAge;

    public AgeCondition(int minAge)
    {
        _minAge = minAge;
    }

    public bool Evaluate(Dictionary<string, object> data)
    {
        return data.ContainsKey("Age") && (int)data["Age"] >= _minAge;
    }
}

public class PrintAction : IAction
{
    private readonly string _message;

    public PrintAction(string message)
    {
        _message = message;
    }

    public void Execute(Dictionary<string, object> data)
    {
        Console.WriteLine(_message);
    }
}

// Usage
var engine = new RulesEngine();
engine.AddRule(new Rule(new AgeCondition(18), new PrintAction("User is an adult")));

var userData = new Dictionary<string, object>
{
    { "Age", 20 }
};

engine.Execute(userData);