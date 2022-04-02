using System;

namespace AdventOfCode2020.Day5.Logic
{
    public class Seat
    {
        private readonly string _seatCode;
        private string _seatRowCode;
        private string _seatRowBinary;
        private string _seatColumnCode;
        private string _seatColumnBinary;

        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Id { get; private set; }

        public Seat(string aSeatCode)
        {
            _seatCode = aSeatCode;

            CalculateRow();
            CalculateColumn();
            CalculateId();
        }

        private void CalculateRow()
        {
            ExtractSeatRowCode();
            TransformRowCodeToBinary();
            ConvertBinaryRowToDecimal();
        }

        private void ExtractSeatRowCode() => _seatRowCode = _seatCode[0..7];

        private void TransformRowCodeToBinary() =>
            _seatRowBinary = _seatRowCode.Replace('B', '1').Replace('F', '0');

        private void ConvertBinaryRowToDecimal() =>
            Row = ConvertFrom(_seatRowBinary);

        private static int ConvertFrom(string aBinaryValue) => Convert.ToInt32(aBinaryValue, 2);

        private void CalculateColumn()
        {
            ExtractSeatColumnCode();
            TransformColumnCodeToBinary();
            ConvertBinaryColumnToDecimal();
        }

        private void CalculateId() => Id = (Row * 8) + Column;

        private void ExtractSeatColumnCode() =>
            _seatColumnCode = _seatCode.Substring(7, 3);

        private void TransformColumnCodeToBinary() =>
            _seatColumnBinary = _seatColumnCode.Replace('L', '0').Replace('R', '1');

        private void ConvertBinaryColumnToDecimal() =>
            Column = ConvertFrom(_seatColumnBinary);
    }
}