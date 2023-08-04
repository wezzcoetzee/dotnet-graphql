using Microsoft.Extensions.Options;

namespace BooksApi.Options;

public class MongoOptions
{
    public string ConnectionString { get; set; } = "";
    public string DatabaseName { get; set; } = "";
    public TimeSpan ServerSelectionTimeout { get; set; } = TimeSpan.FromSeconds(30);
}

public sealed class MongoOptionsValidator : IValidateOptions<MongoOptions>
{
    public ValidateOptionsResult Validate(string name, MongoOptions options)
    {
        var failures = new List<string>();

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
            failures.Add($"{nameof(MongoOptions.ConnectionString)} must be specified.");

        if (string.IsNullOrWhiteSpace(options.DatabaseName))
            failures.Add($"{nameof(MongoOptions.DatabaseName)} must be specified.");
        
        return failures.Count > 0 ? ValidateOptionsResult.Fail(failures) : ValidateOptionsResult.Success;

    }
}