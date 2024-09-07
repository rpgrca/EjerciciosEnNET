## Sum of Groups

Given an array of large numbers, your task is to:
   1. Group the numbers that have the same digits with the same frequencies.
   1. Select the smallest number from each group.
   1. Add the selected numbers together to compute the total sum.
   1. Return the sum of the digits of the total sum.

**Note**: A number should only be included in the sum if its group contains at least one other number in the same group

### Example:
```
Input: [ 1234, 3142, 66654, 65466, 2143 ]
Group 1: [1234, 3142, 2143]
Smallest number in the group: 1234
Group 2: [66654, 65466]
Smallest number in the group: 65466
sumaTotal = 1234 + 65466 = 66700

Sum of the digits of 66700: 6 + 6 + 7 + 0 + 0 = 19
Output: 19
```

### Note:

   - The numbers in the array can have up to 100 digits.

### Input:

An array of large number. The array will contain between 1 and 1000 elements.

### Output:

An integer representing the sum of the digits of the total sum.

### Additional Examples:

```
Input: [ 12345, 54321, 98765, 56789, 12354, 54312 ]
- Group 1: [12345, 54321, 12354, 54312]
  - Smallest number in the group: 12345
- Group 2: [98765, 56789]
  - Smallest number in the group: 56789
sumaTotal = 12345 + 56789 = 69134
- Sum of the digits of 69134: 6 + 9 + 1 + 3 + 4 = 23
Output: 23
```

```
Input: [ 111, 11, 1, 222, 22, 2 ]
- No groups with more than one element, so the total sum is 0.
- Sum of the digits of 0: 0
Output: 0
```

Good luck!

[Try it yourself](https://www.codewars.com/kata/66b6bc0427ed9bb6ef6131c0)