## Train Composition

A _TrainComposition_ is built by attaching and detaching wagons from the left and the right sides, **efficiently** with respect to time used.

For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, again from the left, we get a composition of two wagons (13 and 7 from left to right). Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

Implement a _TrainComposition_ that models this problem.

[Try it yourself!](https://www.testdome.com/questions/c-sharp/train-composition/96017)
