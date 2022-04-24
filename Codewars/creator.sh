#!/bin/bash

LEVEL=$1
NAME=$2
KYUDIR=${LEVEL}kyu
BASEDIR=${KYUDIR}/$NAME
TESTDIR=$NAME.UnitTests
LOGICDIR=$NAME.Logic

if [ -z $LEVEL ]; then
    echo "Missing level!"
	exit 1
fi

if [ ! -d $KYUDIR ]; then
    echo "Creating directory $KYUDIR"
	mkdir $KYUDIR
fi

if [ -d $BASEDIR ]; then
	echo "Kata with the same name in same level already exists! Aborting..."
	exit 1
fi

mkdir $BASEDIR
cd $BASEDIR
dotnet new nunit -o $TESTDIR
dotnet new classlib -o $LOGICDIR

cd $TESTDIR
dotnet add reference ../$LOGICDIR/$LOGICDIR.csproj

cd ..
dotnet new sln
dotnet sln $NAME.sln add **/*.csproj
dotnet build

cd ../..
dotnet sln Codewars.sln add $BASEDIR/**/*.csproj

cd $BASEDIR
code -r .
