using System.Reflection;

namespace Odin.Configuration
{
    public class SlashEqualsConvention : Conventions
    {
        public override string GetCommandName(Command command)
        {
            var name = command.GetType().Name;
            return name.Replace("Command", "");
        }

        public override string GetLongOptionName(ParameterInfo row)
        {
            return $"/{row.Name}";
        }

        public override string GetActionName(MethodInfo methodInfo)
        {
            return methodInfo.Name;
        }

        public override string GetShortOptionName(string rawAlias)
        {
            return $"/{rawAlias}";
        }

        public override bool IsIdentifiedBy(ParameterValue parameterMap, string arg)
        {
            return arg.StartsWith(parameterMap.LongOptionName);
        }

        public override IValueParser GetParser(ParameterValue parameter)
        {
            return new SlashEqualsValueParser(parameter);
        }
    }
}