YEAR=$1
DAY=Day$2

if [ $# -lt 2 ]; then
    echo "Usage: $0 year day"
	exit 1
fi

cd $YEAR
mkdir $DAY
cd $DAY
dotnet new classlib -o $DAY.Logic
dotnet new xunit -o $DAY.UnitTests
cd $DAY.UnitTests
dotnet add reference ../$DAY.Logic/$DAY.Logic.csproj
cd ..
dotnet new sln
dotnet sln $DAY.sln add **/*.csproj
cd ..
pwd
dotnet sln AdventOfCode$YEAR.sln add $DAY/**/*.csproj
cd $DAY
code -r .

exit 0
