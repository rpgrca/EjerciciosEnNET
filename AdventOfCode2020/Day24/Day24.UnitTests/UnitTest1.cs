using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Day24.UnitTests
{
    public class TileMust
    {
        public const string PUZZLE_DATA = @"neeneneneswneneee
eeeswneseseeseeeseeeeesesee
swswsweswwswswswnw
neseewwswwneswnewnewwswswwswwse
wswsweenweesenweeeeeenweeee
neswwwswwwnewwwwwwwwsewwswsww
neseeeswesweenweeeeeeeeee
neeeneneeneeswneeneneneene
ewwsenwwenwnwswnwswwnewwwsewne
sesesesesesewseseweeeeneweseeww
neeeswnwneswneneneweeneeneswnwnesw
neseswnwnenenewneneesenenenenenenenenenene
eneeeeseseeseesewseseseeeseee
enenewseeenewnweseewnwneseweesw
sesesesesenwseseseseseseseswseseee
nenenenenwneeesweseneeeeeenenenwe
neeenenwseswsenewseswenwewsww
neeenesweswwneeneeeeeeeeenwe
swseneswewwsewsweeeseeswwsesww
nenwwnwnwswwnwwnwnwnwnwnweswswnenww
swswseseswnwswswswseswseeswswswswnwswsesenw
nwnewwswnwesewnwwwsenwwnewewe
newwsewwsenwswwswswswswseswwnwwwsw
swswsweswseswswwswswnwseswswswswswswswsw
nenwnwnwnenwnwnwnenenwnenwneswnesenwenw
nwswnwwnwnwwnwnenwwse
neesweeeesewewneese
nwneweswwwswswwswwswswsewsw
wwwwsenwwnwneswsewsewnenewnwwseswne
eeeeeneneneneweneeeeeweswnene
enenwneneeneswnewnweewseswneswnew
swsesesesesenweswseseseswswseswswsesese
nweeeneweewsw
nwswswneswswswneswsewswswswswsesw
swenwwnenwnwnwswnwsesenenw
swswswnwneswswswseswswswswswswswseswse
sweseseseeseseweenese
wnwnwnwnwnenwnwswnwnwenwsenwenwnwnene
eeenweeeeeeeeeeesweeee
nesenwswnwseswneewnenwenwsenwenwewnw
eeeeeewesenweeseeeeswe
swwwswneswsewwswsw
nwnenwnenwnenwnenesenenwnwnwnwnwnwwnw
newnesewnwnenwneneenwnenenwnenenenenesw
eeeeeeeeeeenweeeseeeesw
swnwnwwnwwwnwwewnwwsewwwwnwnew
nwnwnwenenwswnwnwnwnwwnwnenwswewnwnw
swseenwnwswnwnenesenenwnwneeswneenwwnw
enwwseeswwenwswswesw
enwseseeeeeeenweeeseeseswseee
eseswseseswseneenwwneeswwwse
swswswwesenwswswswswswswswswswsenesesw
neswenwswswswnwnwsweswnweswswsweswsw
newsenenwswesewenesewwseeesenwesew
seswswswswswswneseseswweswseswsewseswnw
wnwwwwnwnwnwwnenwwewnwnwswnwnww
newwwwwwsenwwwewwwnwwwww
seseseeeswseseswseswswwsewseseswswse
eenenwswnenwneswnesenwnenenenwnwnenenewsw
swnwewswwewnwnwswwwnwnwewwwse
nwenewneneneewnene
wwwwwswwswenwwsewwwwwwswsww
enenewswnwneneneneseneneneeneneeneene
wnwswswnewwwswnewwwsewwseswnew
nenenwwsenweswnwswswnwswnwnenwnwne
seeenwesesesewseseeseseeesesesese
eeneeeeeeeneenwenweswsweeene
wneneneswseneneneneneneeneenenwsenwnene
seseseswsenewesesesenwneseseeseseesese
wsesenesenwsesweseswnwsesweseseesenwsese
wwwwnwwnewewwswsenwseseewnwnenwnw
wnenenenenenenenenwnenenwnenenesenenene
neeewnwwneneesweneeweseswnwneswsw
neesewwneenwnwwwwseswwnwwwwswww
esweeeeeeneneenwe
eseeseeeeenwswseeseneeseseseswee
neneenewnweneseswnenenwneneenwwseswne
senwwnesenwswnwneeewswnenwnwwnwnwsene
eeeeseeeeeneewwneeweneeenene
nwnenesenwwwseswseswnwwesesenwwnene
swseneswswswswswsewswnwneseswseneeswsesw
nwnwwnwswnwnwwnwnwenenwswwnwnwnwnwenw
seswswseeesesenwnweeseeeneeenewese
nwsenenesenwwnenenwnwneswnenenenenenene
swsewnwwwseswwwsewneneswneenene
nwenenwnwnenwsenwnenwnwswnwnenenenwnenwnw
swwneneneneneenweeeneenesweenesenesw
swnwnwswnwwwswsenewsewswsewswswseswsww
enenenenesenenenenenenenenenenwswnenewne
newewesesewseseseseeeseseeesesese
nenwwwnwsewswwwwewsewwwwwsew
enwewnwwwwnwwnwnwnwnwnwnwwwnwnwswnw
neweeswesweeswewneseewnw
swswswswsewesewswswswswneseswswswseswse
swneeewseneeeeeswneewwneseenwe
wwwwwwwwwneewwsewwwwweww
eeeesweneenweeeneneeweeenee
wnenwneseeenwseeneneewneseswwnene
wwwnwewnwnwnwnwnwewneenwnwnwswswswnw
enenenenwesesewnwneeeswneneeneenenene
nwnewseneseenwwwseswneswseneeeswnew
swsewwsweseswneseseeseswneseneswswse
swswswwswswnewsesesweswswswswseneswnesww
enwwnwwnwwnewnwswswseeswnenwwnwwnwse
sesenwnenwnwnenwnwnwswnwnenwnwnenenwnwnwsw
seeneswswwswwswswwwwswwwswnenesw
swwwwswneseswwwwswwnwswswswswwswsew
swseeenenwnwswenwneneenwnwnenwnwsewsw
wswswswwwswwwswswswneswswswseswswsw
neswnewnenenwnenewenenwneneeenenenw
eswneneneneneenenwneneeeneenenewe
enenenenenenwneneeneeeeeeenese
seeseewswwseseneesenwneseseswsewswsw
ewwewswwswwswswwewwnwswwsww
swwswswswswswswswswswne
nwnenwnenenenwnwnwswnwne
nwnenwnwswnwwewnwnwswnwsenwwnwnwnwnw
nwnwnenwnwnwnwwnwnwnwswnwswnwnwewnwnw
eseneseeswenwneeneneneneewnenwnenene
swwnwwswwswswwswwswswswsewwwwswne
swsewsenenweseesweee
nwnwnwnwsenwnwnwnenenwnewnwnwnenwnwnwnw
nwsweeeseseeeeseeeeseneeswene
neenwneneswnwnesewewswneswnwnwneneswe
esenenwnwnewseneswnwsewswwnwsenwsewswse
nwwwweneeewwwesesenwneneswswswnw
nwnwsenwnewseswnwesenewnenenwnenenenwe
wnwwnwnenwnwsenwnewwnwwsewwnwwwwe
wwwewwswwswwwswwwwswsw
swswwswswseswswswswseswswswswnesw
wwwwwwwwwwswwewwnwwwww
nwnenwnwnwnwnwsenenwnwnwnwnwnw
swnwswswswswwseeeswswswswswswsewnwnwsw
nenwnenwnenewnwnenwnwnenwnwseenenwnenwne
seewseeseeeeseseeeweneseseseese
seenesesesesesesesewseseseseesesesese
nenenenenwneneneenweneneneesenenenesene
swswneneeseswwswnwseswswwswswseswsesw
nwswsenwneenwnwnwnwsenwnwwsenwenewnwsw
nweseseseswswswswswswswswswsw
seseswseseseswsenwseseseseesesesesesese
wwwwwwsenwwnewewnwwsewswnesww
nwseswswnwseswswsewseseeseswswesesesesw
seswseseenwswseseseenwswseswseesewswse
nwwnwnwswnwwnwnwnwnwesenwnwnwwwwnww
neneswseneneneswwnenweneeneneenesenww
swswswswneseswswseswswswwswswsesweswswse
swneswseswswswswswswswswswseswswseseswsene
swswneneswswwneswwwswswswwswnweswsene
nenwnwnwwnwnwnwnwnwnwnwnwnwenwnwnwswnwnw
wwneswwwwwwwwewwwnwwwsewww
neneeswnwneneeneeee
swesweswswnesweswsesewwnenwnwnewnwnee
nwwwwewwwwwwwnwwseswwwswwe
sweenwseeseneweseseeewnwseeseenenw
eeeeeenweseeneeeeeeeenesw
nwnwnwswnwnwnwswnwnwnwnweeenwnwswnenw
eneeneeeeweeeeeneeeeneewsee
swnenwnweneneenwnwnwnwswnwnenenenwnwnwnw
nenwnenwnwnenwnenesenenwnwnwnenw
neeswnweswswseewwnwwweswwwwwne
nwseeeeeeweseeeeseeeeeeee
sweseneneseeseeseeneeeeeewsweew
wnwwnewswwwswwwwewwwwnwww
wswnwsweswwneseswnwswswwseswsweswnwwsw
nweswneeweeeeswsenwew
neeswneneenenweeneneneeneseenesenwe
nwnwnwnwnwnwnwnwnwnwnenenwnwnwnwsenwnwse
seswseseswseseswseseseseswsesenw
nwnenwewnesenwnwnwnwnewnenwnenwne
swswswswesweswswswwswswswswswswwswsw
nwnweeeeeeeeeseeeeeeeese
wswnwnwswswswwwwswswswswswwwseswswse
seneswwseswsesewsenwsenenesenwseseese
neneneswneswenenweeneenenenenwnwswnene
newwwnwwwwnwsewwwwseswwwwse
swsenwenwnwnwnwnewnwswenwwesw
newwnwnwnewsewwswwwwnwnwnwswww
eseswsenenesesenwwseswseseseeseesese
nwwenwenwsenwnewnenenwnwwnweneswnwne
neswneneseswseeseseswswsenesenwswswsww
neneeeswseneswnwnwwenenenwseswwwe
nwswseseseeeseseseseesesesesese
wswwnwswswnenwneswnweswseenwewwwse
swseseswseneswswseswswseseswswnwswseswswsw
sesesenwseswseseseseseeesesesesesesese
nenenenenenenewwneeeneneseneeneneene
wnwswwewswnwnwsenenwesesweeswsene
enenenwneneneeneeeneeseswneenenenene
seenwseseeneeswwneseeeseswwesenww
seseswnwwsewnewswnwseswneswswswesweenw
nenenenenwnwnenenwwnwenwnenw
nwwwwnwneeeeneneneseswsenewesenw
swswswneneseswwwwswswswswswnwswswswsw
nesesenwswswseswnenwsewswseseseseswnese
neeeenenweswenweneneeneeneeeeese
seeweneseeneseseseswseewsenenwe
seseseseseseseseseseseseseseswsenwsw
wswswswswsweswwwwseweswwwswswne
nwseeswneswneswwnenwseswenewseswwsw
neeweenweeeeneeeeeesweeeee
swwswwswwneweswwswswwwswsewwsw
sesweswwswenwweswswesenwnwnwnweswse
nwneenenwnewenesw
wnwseewwenwwwwesewwwnwewwnw
eeeneesenenenweswene
seenwseseseeseseewsweesesesewsese
wswsweswswseseseseseseseseswswsesesenwse
wweeeeeneeseeeeeeeeesese
swseswseseseeswsenenwseswseseseseseswsw
wwwewwwwwnwswwwnwnwnwwwewnw
wwnwnenwseneeswswswewewswswswwenw
neswswswswswseseswseseseseswseesenwswsw
neeswnewnwwswsenwnwnenwnwsenesewene
nenwseeswwswseswsesesweseswswswswseswsw
nwwwwseneneswseseneeseswswnwnwseene
seesesesesenwseweseeseseeseseswseese
ewwwswswwsewnwwwwswnewneeswsw
eeneneneneneneeneenenewnenenenesewne
enweeswnwsweseneeneenwsenewnwswswne
sesenwseewsesenweseeeseseeeseeenee
nwnwnwnenwnwnwswnwnwnwnenwnwenwnenwswnwnwnw
seswnwsenwnenwnwnenwnenwnwnenw
nenwnwnwsenwnwnwnwnwnwnwnesenwswnwnwnwnwne
swnwnenwnenenwnwnwnwnenwweenwwenwnwnwnw
senwnwnwwnwwwwnwwnwnwnwswnenwnwnwnewnw
neswnenwswsesewnwnewsewwnewnesenewnwnw
wwwsenwnewwwwewwnwwwwwsww
enwneeneneswswnesw
enweesesewsenesesw
eeswewneesenenweneneneneneeseee
nwnwseneswnwnwwewwwwsenwwwnwww
swwneswneswwwswsweeswswswwswswseswnw
ewwwwwsewswwwwwwenwwwneww
swneswseeswswswwswnwsewwswswswswwswwsw
sweswwswseneseeewswwnenwnwneewwsw
swwswswseswswswwswswswswswswswwswswne
nwwwswwwwwwswwweweswneswwew
neneneswsenenenwnenenwneswnweweenwsww
senwswnewwseseeseenewseseneeeswene
nenwsewwsenewswseenesewsenenewnwe
swswswswwwwwewswwnewwswwwwww
swsweswsenwnweenenwe
wnwsesesesewseswnesenesenwswsesesesesesese
eeewseeeseeweeeseeewwenee
eeeeeneeeeeeeweseeewwe
neneneneenenwneneneneneneneneneneneswne
seeseeseesesesenweseeeswneenwnwee
seeeseenwswneeeewswewneseeew
nwseenwnwnwnwnwswnwnewwseenwnwnwsenw
esweeeweweneeseeneseee
ewswnwswswwnewswwsweseswweswswww
sweseeneswwwwnwnenwsenwwsweseswe
eweeseseeswnwneneeeneew
swnweseeeeeneweeeeeeweene
wwnwwweswwnenwwnwnwswwwewwsw
neneeeweenewneneeeeneeeneswe
swwwesewnwsenenwnewnwneseenwwswnew
senwnwnenwnwnewnwneneswwneeneneenewse
nwwwnwwwwwnwwwwnwsewnwwwsew
wwwswwswwwswwwwseneneeswwwww
neswswseswswnwseswseseswswwseswsesesesese
nwsewnwnwwnewnwnwnenwneenwnwseneenw
seseseseseseseesenewsesesesenesewsese
newwnwnwnwwnwwwnwsenwnwnwwwsenww
swswenwnewswswswneweweswswswswnwsesese
seeseswseseseseesesesesesewseseswnwse
nenewneneneswnenwsenenenenewneenenenee
sewseneseswneseneseeewswnwswsewswwsw
eeswwswswswswswswswswswsenwswswnwwswsw
seneenwswseseeeneeeeeswswsenewe
nenenwnwnenwenenenwnewnwwsenenenwnwne
nenwenwswenwnenwnwsenwwnwenwnwswnwnw
wwwsenwwswnwwwewenewwwwwnwnw
nwnwnwnesenwnwnwsenwnwnwswnwnwnwnwnwnwnw
swswswswseswsweswswnwswwswseswneswswswwsw
eswnenwneenwewnwnwnww
seseseseeseneseseseseseseweeseseseswnw
enwwnwnwswnwnwnwnwwwnwnwnwwnw
swsewseneswneewwwwnwnwnwnwwseswsesww
nenesenwnenenenenenenenenenewneneswnee
nwweswwsweswswswneswswnwswswswswww
neeneeneneneeneenenenenenenewsenene
nwswswswsweswwswswswwswewwwswswsw
swwswwwwwswwseswswswnwweneswswsw
wswnwneeneswnwwswwnwwsenenewwnwww
nenenenenwwenwnwnenwenenww
seseneseseswwneseeseewseseesesenwse
nwenwsenwnewneswnwnenwnwnwneenwnwnwnenw
nwnwnenwnwnwnwnweswnenwsenenwnwnwnenwnwwne
nwnenwenwswnwenwwswnenwnenwnwnwnwewnee
wwnwenwnwwnwwwnenwnwwnwnwnwesww
neseeneeeneeeeewneneneneeenee
swseseswnwneeseseneswswwswswnwswse
swnwswseswswwswswswneswsw
swwweeeeswnwneneeewnweeeeee
enenwnenwsenwswnwnwnenenwnewnesenwnwsenwnw
swewswwneneseeeenwneenenwnenwseee
seseseseseenwseneseseeseswseeseswnwse
seneeeseseeeseswnwswsesesenwwwseenw
wwnewwwwwwwsenewwwwwwswwnww
nwswwwswswwnwsweswswsweswswsesweswsw
swswnwnwnwnwwenwnwnwenenwnenw
seeseseseseweseseeeseseesee
wnwnwnwsewnwnwnwnw
nwnenenwnwneswnwnwnwnwnwnwnwneenwnwwnw
sweeseneweseneswenwsesenweswsenwnee
wswnwnweseseewenenenwenenesweene
nwnesenwnwseesewneswwnesweswnwnwsenww
sewneswwwnwewnenwnwnwwwswnwwnwswe
eeesweseneeweenweeswenweneewe
neneneeneeeeneneeesweeenwenene
eeneneeeneeeenwneeswweneenenee
sesweeneeseeeweeeenweeeese
swnwswneewwwnwwsewwnwnwwnwnwwenwnw
eeeeesweseeeseswenwnwenwnwee
sewwnewwswwwwswnesewswsw
nesewseewseswsesewwswweseseneswswe
newneenwsewnenenenenenwne
sewsenwseeseesewneswwwnwsenweswnene
swswswwwwwswwwswneww
wnewwwwwwwwwwwwwwwswsw
swwwnewwwwswsenwnwwwnenwseenww
neeenenwweneeneeneneneneneeneneswse
nwsenwnwnwnwnwswwnenenwsewnwswnwenwse
nwesenwnewwnwwwnwwwwnwwswnwnww
neswwsenwswnwwwswswseswswwsw
neneeneswneneneenewnewseenenenenene
seswseswsesesenesesesesesese
wwwnwwwwweswewswnw
seneseswsesewseseneesewwseswwswsenese
enenwnwnwwnwswnwnwnwswnwenwnwswenwnw
neswwsenwswsweneswswnwswseswnesenwnesw
senwwnweswseswneswneewneseesesesesene
nwenwwnesenwnwwswenwnenwswnenwnenwse
weneeseeneeswweswnweswenwewswnw
eswnwewwnwnwswwswwswene
swwnwneseseseneneseswewswwsenewseee
seswwnwwwswseeswwswnwwsewwenene
neeneneneneneenenenenewsenenenwswnene
eesesweeeeeeeneenweeweseww
seswswswnwswswsweswswnwswswswseswswswsesw
nenwnwnwnenenwnwnwnwwnwsenesenwnenwnew
neneswneneneenesenwnenenwnenwwnewnesene
wnwnwewnwwswsenewenenwnwswwwwwwnw
weneswnenwnenwnenenenenwnenesewnwnene
eneneewswneenenwswnenweeeeneesee
neswseseswseswwseseseseswnwnwnwswnwsesw
nenenenenenwenenewnwnwwsenwnenenenene
weseswnewnenwwenwnwnwewnenenwsenw
swenwnewewwwnwneswewwsewnwsewnw
seseseseneswseseswseswseseseseswnesewsesese
nwnwnwnenwnwnwnwnenwnwenwnwnwnwnwnwnwsww
nwesweeeneeeeseeeeeneeeeee
esweseswnenwsenwnw
swneswwswswswewswwnwnewswsenenenwsw
enenwnwswnwnwnwsenenwnwnenenwnwnenwnwsenw
neswneswswswsenwseseneswseseneswseswswse
ewneneenwnenwneneswnwnw
swsenwsenesweswwnwsenesewswswwseswswsesw
swwswwswwwswwswswwswnwswswswe
nwwnewwewwwwswneswwswswseswswsw
seeseswwnesesenwsenwswweseswenwnese
nwnenwneneswswwnenesenenwnenenwnwnenenene
nenwnenwnwswnwnenwnewneneneneneneneenwne
eeeenenenenwneneeeeeeneewsese
neseswsesesesewsenewsesenwseneswnesesw
eswnwswsweeswnwnwnwwswwwswwesesesw
wnwwsenwwwenwswswswsewwenewnwwnw
seweeeeeeeneeeeseenwswnenwee
nwsenwwwwwwwwwwwwnwwwneww
swneswswswswwswsweswwwswnenwwswseswsw
swneeeeeeesweenwneneeeeeee
neewsewswseswswsenwswswneswwswenesw
wnwnwsewwswnwwwwnwnwnwnenw
neseseeseswsesesewswsenwswseseswseswswnw
nwenenwnwnwnwnwnwnwwswnwnwnwnwnwsenwe
neneeewnewnweseenenwswwnesewsee
sesewseswneswswseseswnwswswneswneswswe
seseseswseswsesesesesesesesenesesewsesenwse
enwwwswswwwnwsesewwewwwnwew
nwsenwnweseswnwnenwnwnwnwnwnwwwswnwnw
nwseseeneseesweseseseseseseseeswnwsese
seswswseswneseswswneswswswseswswswswswswnw
swswsenwseswswseswswswseseneseseseswneswsw
seseeseswswswswswseswnwswswnwsweswsesw
wneseswseseneseesenenwwnesewseswswese
neneswnenwnenenenenwneesenwnenenenwnwnene
sweneseweseeeeeseeeeeenweeee
enwnwnwnwnwnewenwsenenenwnenenwnwswne
weeeeneeeseseeeeseseesewewee
wsenwnwsewwwwwwwnwwnwnewnwww
nwnwewnwnewnwsewnwwnwnwnwnwwwwwse
swswswwwwswwswswsewnewwwswwneww
nenwswewwswneswwswswwweswswwww
neneneswenenenwneneweewnwnenenenene
swswseneseseseseswseswsese
nwnesenwnenenewneseswwwnwenenwseene
wsesewseseseseseseesesesesesenesesese
seseweswsesesesesesesese
nwnwnwnenwsenwnwnwneswnenwnenwenwnenwnw
seseswewseneseseseseseseswswsesewnese
seswseswsesenesesesesesenwswseseseswsese
sweenwseeeeeeeeenweeeeeeswe
eenwwnewswsesewewswswseneswnewww
wwwwwwwwwnwwsewww
wnwnenwswenwnwnwnwse
swneseneneswneneesewwnenene
wwswewwwwwwwwnwwnwwwswwswwse
sesesewseeseswsewseswnesesesesesesene
swwwwwwwwwswwwwnewwwsenesw
swswseswswnwswswswseseeswsw
newwswsenwnewwsewseseswenwneeswwnw
nwsweswswswswswswnwswswswseswswswswsesw
nwswneseswseswsenewenewwneseewsenw
sewseneseneseseseseesewseseneswsesesese
wnwnwenwnwnwnwnwnwnwnwsenwnwneswnwnwne
sewneewwsesenwnwnewwswwwwneswwsw
wwwnwsewwwwswwwwwnwwwwwe
ewneenwseneneewswneswneenenwenee
swwswswswswswswneswswseswswweswswswswswsw
nwswnwswnenenwswneneneneeneene
esenenenwneneneswenenewneneneenenenenene
swswsweseewweswwsesw
enwewwnwnwsenwneseswwesewnewenew
eeeseseseeneesweeeeeee
ewenwwwswwseswnwswnwwswsweswwww
wnwweeneenewnenenwnewswneeesew
nenwnenwnenenwswnenwnewnwnenwenwnwnene
neneneseneeeneneesewneneeew
neneneneneneneenenwneneneneswneenesenene
nenwnenenwnwnwenenwnwneneneenewswnenenw
swwwswwwwewswswswwwswnwseneswswww
neenenewneneseneneesenewenenenenwnwnese
wnwwweswswswwswweswswwswwswwwwnw
wswwwewwswwswwwwwwnwwwsw
senwesewenwseseswesesesenwswnwsesee
nwnwnwnwnwneneswnwsenenwnenwsenenwnwnw
seewwwwwnwnwwwwnwneswwwnwswnww
seeweseeeseeeeseneeswseeseene
enesweeweeeneesweneseeeeneee
senwseweswneeesweeneseweeesenesew
swswseswseswswsweneswswswwenwwneswsw
swswswwewnwswswswswewwswswswswswswsw
swswswseswsesewseswseenwseswseswnwnesese
ewswswswswswneswswnwwenwsesenwswwsee
swnenwweesenwswnewneneneswnwnwnwswnenw
nwnwnwnwnenwswnenwnenwenwnwwnwnenenwnwne
neneseenewnenenenewnenenenesenenenenenee
nwnwnwswnenwnwenwsenenwnwnenwnwnenenwnwnene
nenenenenewnenewsenenenenesenenenenene
swswswswseseesesesenwswswsesenwseseseese
neneneweeeenesesewneweneeeneene
wwnwewswsewwnewwnewwwww
seseeeeseeeeeesewseee
senesesesweseswenwnesesweseneeseswe
wweeswswnwswwsesesewesenwseewee
nwwnwwnwnwnwnwwwnwnwswenwwnwnw
wwswnewwwwwwwwwwsewwwww
neneeneneneneneneeneenenesenenenewne
neweseeeeseeeeeeeswseeseesee
nweneneswnwnwnwnenesenesewnwnwneenwnwnw
neneseswnenenwnwswwnwnenwnewseneseneneenw
nenenewesewseweeeswswneswneseee
swswseseeseseeeseesesesenwsesesesenwsese
seneeneenweeneneenesweeewneee
wwwewsenewwswneeneeswseswswenw
nwnwwnewsenewswnesenwwwnwenwwsenwnw
seeenwneewnweswnweewseewseese
sewnwswwwwnewwnewnwwwsewwww
swsenwnwewnwnwnwnwnwnwwnwnw
enwesweeseeneswneeseewsewwnee
wnwweneswswwsenwwwnwwwwnwnwww
wwwswwwwwwnewswwwweswwww
swswnewswswsweswswwwswseswswwwsw
wwwnwwewnwwwwnwwwwnwwwnwsew
nwnwnwnwnwsenwwnwsewnwnwnwnwnwnenwnwnw
nesenweswnenenesenenenwneneeeneenwne
sweeeseeeeesenweseeseseeese
eseswwswseswseswneseseseseseswswseswwswsw
nwenwnwsenwnwnenwnwnwnwnwnwsenwnwnwwne
wewwwwwnewwwwewwnwwswww
wnwwwswswneeswswswswswseseseesenwesw
seweeeenweeeeesweeeeee
nenenenenwsewnenenwneneswnenenenenenenene
neesewneswneeeneneneneeenwwwneene
swseswneswseswwesesweswswswnwseswnwswswe
newnwwwseswswwswwswnwswwwsewswwne
swswswwswswswswswsenwseswnenewswwswsw
neeneenenewneeweeeswneseeeeee
newsewnenwnewsenesewnwee
nwnwswswseseneswswnweseswsenwneseweswsw
seswswwwwwswwneswswwenewswne
eneeenwwnwwwwwswnwnwswnwnwwww
nwnwnwnwnwnwnwwewnwsww
seeswneseseseeseesesesewenwseenwwse
nwnwwswnwwwwewnwnwwwnwnwwewnwew
eeseseseeeseneseeeseseeneseseswwsese
swwswswweswwwnwswneswwswswswwww
wnwswwwwwnwnwwwsenenwewswwwnenw
sewswseseswnwnwsweenweswwseswswswnenwne
wwnwwwnwnwwwwwnenwwnewswnwwnwwse
seweswwneeswsenwswnwwswswswnwseswwsw
nwnenenwnwnwneswnenenenenwenwnenwnenwneswne
sewsenwnenwnwwwnenwnewwsenwwnwwnwse
seseeseseenweneseweseswswswnesesenw
swwneswwwwswwnewwswwseswswwsww
seesweswnwseseseswnwnwswswnwse
eesesweseeeseeeeeeenwsweene
swseswswswseswswswswswswswwswswenwswsesw
swwswswsweswwwnwswswswnwswwsewswsw
nwnwwwnwwnwnwwnwwneenwwwwnwsesee
weeenwseseseseeseenesesee
nwnwwseenwwwwnwwnwwnwnenwsenwnww
eeeeseseeeeswseeseseswneseeseeenw
eeeeeneesweeeesweeenenweeee
eweeseneeseesesenesweeseewsewne
neneneswswenenwwnenewsweneswenwswsenw
wwswnwsewneseswswneesenewswwwsenwsw
seswswsweswnweswesweswswwnwnwsesese
weneeeneeeeewseeeeeeeneee
nwwnewwswwswswswwwswswwewswwwe
seseesewseneeseesesweswsenwwsenwsese
wenwseeswwnwewwneswnwenwwnwnwse
wwwewswwwwwwwewnwwwwwnww
seseswsesweweeesenweeseeeeseesenw
swseneswneseswwswswswswseneseswswswswsesww
esenwseseeeseseseesesesesenwwnwseene
neeneneneeneeenenenwwswe
wnewwswswswwwswswswswsewswwswwsw
eswnwesenesweeeneesweeneseeesw
nenwneneneeswneneneswnwnenene
swswswswswswswneseswswenwwnweswswswsw
eeeeneeeneeewneneeeeeeenwesw
neneeesweseneneenwseenwnee
nwnenenenwswewnwnwnwnwnwnweswseswnenw
wneseseseseseseswseneswseseswsesesesese
wswsweseseswswneswwswneswneswswnwswsw
swnwnweneneswsewnenwnw
nwnwnwnwnewnwnenwnenwnwnwnwnwnesenenesene
nenenenenenwnenenwneenwswnenwsenenenenw
swnwswnweesenwswswswsenwswseseeswswsesw
ewswnwseswsenweenwsenesesewsee
nwnewseewsewnwnwnesewwnwsesenwwswnw
nwnwnenwnenwneneneenwwnenenenwswnwenenw
nwwwswwwwwwnwwwswwenwnwwwe
wnwsenesenwswsewswneswswnwsewswwwwsw";

        [Fact]
        public void Test1()
        {
            const string data = "esenee";

            var sut = new Tile(data);
            sut.Transverse();
            Assert.Equal((3, 0), sut.Position);
        }

        [Fact]
        public void Test2()
        {
            const string data = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";

            var sut = new Floor(data);
            Assert.Equal(10, sut.CountBlackTiles());
        }

        [Fact]
        public void Test3()
        {
            var sut = new Floor(PUZZLE_DATA);
            Assert.Equal(473, sut.CountBlackTiles());
        }

        [Theory]
        [InlineData(1, 15)]
        [InlineData(2, 12)]
        [InlineData(3, 25)]
        [InlineData(4, 14)]
        [InlineData(5, 23)]
        [InlineData(6, 28)]
        [InlineData(7, 41)]
        [InlineData(8, 37)]
        [InlineData(9, 49)]
        [InlineData(10, 37)]
        [InlineData(20, 132)]
        [InlineData(30, 259)]
        [InlineData(40, 406)]
        [InlineData(50, 566)]
        [InlineData(60, 788)]
        [InlineData(70, 1106)]
        [InlineData(80, 1373)]
        [InlineData(90, 1844)]
        [InlineData(100, 2208)]
        public void Test4(int flips, int expectedBlackTilesCount)
        {
            const string data = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";

            var sut = new Floor(data);
            sut.Flips(flips);
            Assert.Equal(expectedBlackTilesCount, sut.CountBlackTiles());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Floor(PUZZLE_DATA);
            sut.Flips(100);
            Assert.Equal(4070, sut.CountBlackTiles());
        }
    }

    [DebuggerDisplay("({Position.X}, {Position.Y}), Black? {IsBlack}}")]
    public class Tile
    {
        private readonly string _data;
        private List<string> _path;
        private (double X, double Y) _position;

        public (double X, double Y) Position => _position;
        public int IsBlack { get; private set; }

        public Tile(string data)
        {
            _data = data;
            _path = new List<string>();
            IsBlack = 1;

            ParsePath();
            Transverse();
        }

        public Tile(double x, double y)
        {
            _position.X = x;
            _position.Y = y;
            IsBlack = 0;
        }

        public void Transverse()
        {
            _position = (X: 0.0, Y: 0.0);

            foreach (var step in _path)
            {
                switch (step)
                {
                    case "w": _position.X--; break;
                    case "e": _position.X++; break;
                    case "n": _position.Y--; break;
                    case "s": _position.Y++; break;

                    case "ne":
                        _position.X += 0.5;
                        _position.Y++;
                        break;

                    case "nw":
                        _position.X -= 0.5;
                        _position.Y++;
                        break;

                    case "se":
                        _position.X += 0.5;
                        _position.Y--;
                        break;

                    case "sw":
                        _position.X -= 0.5;
                        _position.Y--;
                        break;
                }
            }
        }

        private void ParsePath()
        {
            _path = _data.Replace("nw", "1").Replace("ne", "2").Replace("se", "4").Replace("sw", "5")
                .Select(x => new string(x, 1))
                .ToArray()
                .Select(p => p
                    .Replace("1", "nw")
                    .Replace("2", "ne")
                    .Replace("4", "se")
                    .Replace("5", "sw"))
                .ToList();
        }

        public void Flip()
        {
            IsBlack ^= IsBlack;
        }

        public void SetToWhite()
        {
            IsBlack = 0;
        }

        public void SetToBlack()
        {
            IsBlack = 1;
        }
    }

    public class Floor
    {
        private readonly string _data;
        private readonly List<Tile> _tiles;
        private readonly Dictionary<(double, double), Tile> _uniqueTiles;

        public Floor(string data)
        {
            _data = data;
            _tiles = new List<Tile>();
            _uniqueTiles = new Dictionary<(double, double), Tile>();

            ParseFloor();
        }

        public void ParseFloor()
        {
            foreach (var line in _data.Split("\n"))
            {
                var tile = new Tile(line);
                if (! _uniqueTiles.ContainsKey(tile.Position))
                {
                    _uniqueTiles.Add(tile.Position, tile);
                }
                else
                {
                    _uniqueTiles[tile.Position].Flip();
                }

                _tiles.Add(new Tile(line));
            }
        }

        public int CountBlackTiles()
        {
            /*return _tiles
                .Select(p => p.Position)
                .GroupBy(p => p)
                .Count(p => p.Count() % 2 == 1);*/

            return _uniqueTiles.Values
                .Count(p => p.IsBlack == 1);
        }

        public void Flip()
        {
            var actions = new List<Action>();
            var existingTiles = new HashSet<(double, double)>();

            var offsets = new(double, double)[] {
                (-1, 0), // w
                (-0.5, 1), // nw
                (0.5, 1), // ne
                (1, 0), // e
                (0.5, -1), // se
                (-0.5, -1) // sw
            };

            foreach (var tile in _uniqueTiles.Values)
            {
                if (tile.IsBlack == 1)
                {
                    foreach (var offset in offsets)
                    {
                        var position = (tile.Position.X + offset.Item1, tile.Position.Y + offset.Item2);
                        if (!_uniqueTiles.ContainsKey(position) && !existingTiles.Contains(position))
                        {
                            existingTiles.Add(position);
                            actions.Add(() => _uniqueTiles.Add(position, new Tile(position.Item1, position.Item2)));
                        }
                    }
                }
            }
            actions.ForEach(a => a());
            actions.Clear();

            foreach (var tile in _uniqueTiles.Values)
            {
                var count = CountBlackTilesAround(tile);

                if (tile.IsBlack == 1)
                {
                    if (count == 0 || count > 2)
                    {
                        actions.Add(() => tile.SetToWhite());
                    }
                }
                else
                {
                    if (count == 2)
                    {
                        actions.Add(() => tile.SetToBlack());
                    }
                }
            }

            actions.ForEach(a => a());
        }

        private int CountBlackTilesAround(Tile tile)
        {
            return
                (_uniqueTiles.ContainsKey((tile.Position.X - 1, tile.Position.Y)) ? _uniqueTiles[(tile.Position.X - 1, tile.Position.Y)].IsBlack : 0) +
                (_uniqueTiles.ContainsKey((tile.Position.X - 0.5, tile.Position.Y + 1)) ? _uniqueTiles[(tile.Position.X - 0.5, tile.Position.Y + 1)].IsBlack : 0) +
                (_uniqueTiles.ContainsKey((tile.Position.X + 0.5, tile.Position.Y + 1)) ? _uniqueTiles[(tile.Position.X + 0.5, tile.Position.Y + 1)].IsBlack : 0) +
                (_uniqueTiles.ContainsKey((tile.Position.X + 1, tile.Position.Y)) ? _uniqueTiles[(tile.Position.X + 1, tile.Position.Y)].IsBlack : 0) +
                (_uniqueTiles.ContainsKey((tile.Position.X + 0.5, tile.Position.Y - 1)) ? _uniqueTiles[(tile.Position.X + 0.5, tile.Position.Y - 1)].IsBlack : 0) +
                (_uniqueTiles.ContainsKey((tile.Position.X - 0.5, tile.Position.Y - 1)) ? _uniqueTiles[(tile.Position.X - 0.5, tile.Position.Y - 1)].IsBlack : 0);
/*
            return _uniqueTiles.Values.Count(p =>
                p.Position != tile.Position && p.IsBlack == 1 &&
                (
                    (p.Position.X == tile.Position.X - 1 && p.Position.Y == tile.Position.Y) ||
                    (p.Position.X == tile.Position.X - 0.5 && p.Position.Y == tile.Position.Y + 1) ||
                    (p.Position.X == tile.Position.X + 0.5 && p.Position.Y == tile.Position.Y + 1) ||
                    (p.Position.X == tile.Position.X + 1 && p.Position.Y == tile.Position.Y) ||
                    (p.Position.X == tile.Position.X + 0.5 && p.Position.Y == tile.Position.Y - 1) ||
                    (p.Position.X == tile.Position.X - 0.5 && p.Position.Y == tile.Position.Y - 1)
                ));*/
        }

        public void Flips(int flips)
        {
            for (var index = 0; index < flips; index++)
            {
                Flip();
            }
        }
    }
}