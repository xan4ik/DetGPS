using System.Collections.Generic;


namespace DepthMapBounders
{
    public class OutsideFigureLinePointsRecognizer
    {
        private Stack<MatrixPoint> buffer = new Stack<MatrixPoint>();

        public IEnumerable<MatrixPoint> GetInnerObjectPoints(int[,] boundMatrix)
        {
            buffer.Clear();
            for (int i = 0; i < boundMatrix.GetLength(0); i++)
            {
                FillBufferWithObjectLinePoints(boundMatrix, i);
            }
            return buffer;
        }

        public void FillBufferWithObjectLinePoints(int[,] boundMatrix, int line)
        {
            int addedPointCount = 0;
            bool isInsideObject = false;

            for (int i = 0; i < boundMatrix.GetLength(1); i++)
            {
                if (CanBeInsideObject(boundMatrix, line, i))
                {
                    buffer.Push(new MatrixPoint(line, i));
                    addedPointCount++;
                }
                else
                {
                    if (isInsideObject && addedPointCount == 0)
                    {
                        continue;
                    }
                    else if (isInsideObject)
                    {
                        isInsideObject = false;
                        addedPointCount = 0;
                    }
                    else if (!isInsideObject)
                    {
                        isInsideObject = true;
                        RemoveLastNumbers(addedPointCount);
                        addedPointCount = 0;
                    }
                }
            }
        }

        private bool CanBeInsideObject(int[,] boundMatrix, int i, int j)
        {
            return boundMatrix[i, j] == 1;
        }

        private void RemoveLastNumbers(int count)
        {
            for (int j = 0; j < count; j++)
            {
                buffer.Pop();
            }
        }
    }
}
   
 