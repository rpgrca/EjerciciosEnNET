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
cd ..
dotnet new sln
dotnet sln $DAY.sln add **/*.csproj
cd ..
dotnet sln AdventOfCode$YEAR.sln add $DAY/**/*.csproj
cd $DAY

# Create Constants.cs
cat <<EOT > $DAY.UnitTests/Constants.cs
namespace Day$DAY.UnitTests;

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
