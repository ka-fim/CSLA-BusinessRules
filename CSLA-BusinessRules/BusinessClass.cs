using Csla;
using Csla.Rules;
using Csla.Rules.CommonRules;

[Serializable]
public class BusinessClass : BusinessBase<BusinessClass>
{
    public static readonly PropertyInfo<string> PrimaryProperty = RegisterProperty<string>(c => c.Primary);

    public static readonly PropertyInfo<string> AdditionalInputProperty = RegisterProperty<string>(c => c.AdditionalInput);

    public string Primary
    {
        get => GetProperty(PrimaryProperty);
        set => SetProperty(PrimaryProperty, value);
    }

    public string AdditionalInput
    {
        get => GetProperty(AdditionalInputProperty);
        set => SetProperty(AdditionalInputProperty, value);
    }

    protected override void AddBusinessRules()
    {
        BusinessRules.AddRule(new Lambda(CustomRule)
        {
            PrimaryProperty = PrimaryProperty,
            InputProperties = { AdditionalInputProperty }
        });
    }

    private void CustomRule(IRuleContext context)
    {
        Console.WriteLine("Rule is executed");
    }

    [Create]
    private void Create()
    {
    }
}