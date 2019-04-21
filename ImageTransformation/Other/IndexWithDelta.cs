using System;

namespace ImageTransformation
{
    public class IndexWithDelta : IEquatable<IndexWithDelta>
    {
        public int BaseIndex { get; private set; }

        public int RowIndex { get; private set; }

        public int ColumnIndex { get; private set; }

        public IndexWithDelta(int baseIndex, int rowIndex, int columnIndex)
        {
            BaseIndex = baseIndex;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public override int GetHashCode()
        {
            return BaseIndex;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IndexWithDelta);
        }

        #region IEquatable implementation

        public bool Equals(IndexWithDelta other)
        {
            return BaseIndex == other.BaseIndex && RowIndex == other.BaseIndex && ColumnIndex == other.ColumnIndex;
        }

        #endregion
    }
}
