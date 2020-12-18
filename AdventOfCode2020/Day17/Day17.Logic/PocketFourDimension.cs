namespace AdventOfCode2020.Day17.Logic
{
    public class PocketFourDimension : PocketThreeDimension
    {
        public PocketFourDimension(string initialState)
            : base(initialState) =>
            NeighboursPerCube = 80;

        protected override Cube BuildCubeFromCoordenates(int x, int y, char state) =>
            new Cube4D($"x={x},y={y},z=0,w=0", state == '#');

        protected override int[] UpdateCoordinates(Cube cube, int[] offset)
        {
            var updatedCoordinates = base.UpdateCoordinates(cube, offset);
            return new int[]
            {
                updatedCoordinates[0],
                updatedCoordinates[1],
                updatedCoordinates[2],
                cube.AddOffsetToW(offset[3])
            };
        }

        protected override void CreateSurroundingCube(Cube cube, int[] offsets)
        {
            for (var wOffset = -1; wOffset <= 1; wOffset++)
            {
                int[] values = { offsets[0], offsets[1], offsets[2], wOffset };
                base.CreateSurroundingCube(cube, values);
           }
        }

        protected override string CalculateCurrentCoordinates() =>
            $"{base.CalculateCurrentCoordinates()},w={_currentCoordinates[3]}";

        protected override Cube BuildCube(string coordinates, bool active) =>
            new Cube4D(coordinates, false);
    }
}