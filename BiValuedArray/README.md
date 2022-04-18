## Bi-valued Array (Amazon?)

We call an array *bi-valued* if it contains at most two different numbers.

For example: [4, 5, 5, 4, 5] is bi-valued (it contains two different numbers: 4 and 5), but [1, 5, 4, 5] is not bi-valued (it contains three different numbers: 1, 4 and 5).

What is the length of the longest bi-valued slice (continuous fragment) in a given array A?

Write a function:

	class Solution { public int solution(int[] A); }

that, given an array A consisting of N integers, returns the length of the longest bi-valued slice in A.

### Examples

1. Given A = [4, 2, 2, 4, 2], the function should return 5, because the whole array is bi-valued.
1. Given A = [1, 2, 3, 2], the function should return 3. The longest bi-valued slice is [2, 3, 2].
1. Given A = [0, 5, 4, 4, 5, 12], the function should return 4. The longest bi-valued slice is [5, 4, 4, 5].
1. Given A = [4, 4], the function should return 2.
