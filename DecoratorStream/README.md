## Decorator Stream

Implement methods and properties in the _DecoratorStream_ class:

- _Write_ method should write the prefix into the underlying stream member **only** on the first _Write_ invocation. It should always write the bytes it receives to the underlying stream.
- The _prefix_ should be written in UTF-8 encoding.

For example, if the _DecoratorStream_ is instantiated with "First line: " as the prefix parameter and _Write_ method is called with UTF-8 byte representation of "Hello, world!", it should write "First line: Hello, world!" into the underlying stream.

[Try it yourself!](https://www.testdome.com/questions/c-sharp/decorator-stream/96022)