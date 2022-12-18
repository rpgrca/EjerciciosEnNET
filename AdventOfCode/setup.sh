YEAR=$1
DAY=Day$2

if [ $# -lt 2 ]; then
    echo "Usage: $0 year day"
	exit 1
fi

# Build directory structure
mkdir -p $YEAR
cd $YEAR
mkdir -p $DAY
cd $DAY

# Create solution and projects
dotnet new classlib -o $DAY.Logic
dotnet new xunit -o $DAY.UnitTests
cd $DAY.UnitTests
dotnet add reference ../$DAY.Logic/$DAY.Logic.csproj

# Add using to test file
sed -i "1s/^/using $DAY.Logic;\nusing static $DAY.UnitTests.Constants;\n\n/" UnitTest1.cs

cd ..
dotnet new sln
dotnet sln $DAY.sln add **/*.csproj

# Create editorconfig
cat <<EOT > .editorconfig
[*]
end_of_line = lf
trim_trailing_whitespace = true
indent_size = 4

[*.{cs,vb}]
dotnet_naming_rule.private_members_with_underscore.symbols  = private_fields
dotnet_naming_rule.private_members_with_underscore.style    = prefix_underscore
dotnet_naming_rule.private_members_with_underscore.severity = suggestion

dotnet_naming_symbols.private_fields.applicable_kinds           = field
dotnet_naming_symbols.private_fields.applicable_accessibilities = private

dotnet_naming_style.prefix_underscore.capitalization = camel_case
dotnet_naming_style.prefix_underscore.required_prefix = _
EOT

cd ..
dotnet sln AdventOfCode$YEAR.sln add $DAY/**/*.csproj
cd $DAY

# Create Constants.cs
cat <<EOT > $DAY.UnitTests/Constants.cs
namespace $DAY.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"";

    public const string PUZZLE_INPUT = @"";
}
EOT

# Convert all files to LF
dos2unix $DAY.UnitTests/$DAY.UnitTests.csproj
dos2unix $DAY.UnitTests/UnitTest1.cs
dos2unix $DAY.Logic/$DAY.Logic.csproj
dos2unix $DAY.Logic/Class1.cs

# Open Visual Studio Code
code -r .

exit 0
