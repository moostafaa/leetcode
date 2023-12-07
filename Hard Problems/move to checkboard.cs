public class Solution {
    public int MovesToChessboard(int[][] board) {
        int N = board.Length, colMoveNeeded = 0, rowMoveNeeded = 0, noOfOnesInFirstRow = 0, noOfOnesInFirstCol = 0;
	for (int i = 0; i < N; i++)
		for (int j = 0; j < N; j++)
			if (((board[0][0] ^ board[i][0]) ^ (board[i][j] ^ board[0][j])) == 1) return -1;

	for (int i = 0; i < N; i++)
	{
		noOfOnesInFirstRow += board[0][i];
		noOfOnesInFirstCol += board[i][0];

		if (board[i][0] == i % 2) rowMoveNeeded++;
		if (board[0][i] == i % 2) colMoveNeeded++;
	}
	if (noOfOnesInFirstRow < N / 2 || noOfOnesInFirstRow > (N + 1) / 2) return -1;
	if (noOfOnesInFirstCol < N / 2 || noOfOnesInFirstCol > (N + 1) / 2) return -1;
	if (N % 2 == 1)
	{
		if(colMoveNeeded % 2 == 1)colMoveNeeded = N - colMoveNeeded;
		if(rowMoveNeeded % 2== 1)rowMoveNeeded = N - rowMoveNeeded;
	}
	else
	{
		colMoveNeeded = Math.Min(colMoveNeeded, N - colMoveNeeded);
		rowMoveNeeded = Math.Min(rowMoveNeeded, N - rowMoveNeeded);
	}
	return (rowMoveNeeded + colMoveNeeded)/2;
    }
}