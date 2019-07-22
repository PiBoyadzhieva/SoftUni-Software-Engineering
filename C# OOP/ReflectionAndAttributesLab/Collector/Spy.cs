using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {classType}");

        foreach (var field in fields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] nonPublicField = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] nonPublicGetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.Name.StartsWith("get"))
            .ToArray();

        MethodInfo[] publicSetter = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.Name.StartsWith("set"))
            .ToArray();

        StringBuilder result = new StringBuilder();

        foreach (var field in nonPublicField)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (var getter in nonPublicGetters)
        {
            result.AppendLine($"{getter.Name} have to be public!");
        }

        foreach (var setter in publicSetter)
        {
            result.AppendLine($"{setter.Name} have to be private!");
        }

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder result = new StringBuilder();

        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethod)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder result = new StringBuilder();

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            Type parameterType = method.GetParameters().First().ParameterType;
            result.AppendLine($"{method.Name} will set field of {parameterType}");
        }

        return result.ToString().Trim();
    }
}