# LeanGoldfish
A Simple Garbage Collector Friendly Combinator Parser Library

Need to do some text parsing in an environment where every object creation is something you've got to be worried about?
(Lest it accidentally cause an ugly garbage collection right in the middle of something important?)

LeanGoldish is a simple parser library where the only object creation is the stuff you write.
You are in control of when and where object instances are created. 
No hidden stuff done behind the scenes that could come back to bite you later.
Especially useful in Unity 3D and MonoGame where unexpected garbage collection can be very expensive.

## Creating a parser

There are a selection of combinators one can use to build up a parser:

* IsCharacter
* IsText
* And
* Or
* Some
* MaybeOne
* MaybeSome

For example, here's one possible way to construct a simple parser for the text "ABC":

```c#
var myParser = new IsCharacter('A')
                   .And(new IsCharacter('B'))
                   .And(new IsCharacter('C'));
```

Here's another. This time the parser will be configured to check if a single character is one of the three valid ones:

```c#
var myParser = new IsCharacter('A')
                   .Or(new IsCharacter('B'))
                   .Or(new IsCharacter('C'));
```

And the following parser will check whether the text is one of two valid options:

```c#
var abc = new IsCharacter('A')
                .And(new IsCharacter('B'))
                .And(new IsCharacter('C'))
                ;

var def = new IsCharacter('D')
                .And(new IsCharacter('E'))
                .And(new IsCharacter('F'))
                ;

var abcOrDef = abc.Or(def);
```

## Using a parser

To parse some text with a parser, simply call its `TryParse` method.

```c#
var result = mayParser.TryParse("ABC", ... , ... );
```

The method takes three arguments:
1. The text to be parsed
2. A factory function to supply a fresh instance of a parser result
3. A function to notify when the parser no longer needs a particular parser result instance

In the supplied unit tests, there are examples where low fuss lambdas are in use:

```c#
var result = myParser.TryParse("ABC", 
                               () => { return new ParsingResult(); }, 
                               (r) => { });
```

This code will work (and may be perfect for what you need) but please note that the use of lambdas in some environments can lead to garbage quietly being created behind the scenes.

## Capturing text

The `Upon` combinators can be used to extract text as it is successfully parsed.

```c#
var test = new IsText("AA")
                .AndUpon(new IsText("BB"), 
                (r) = {
                   /// called when 'BB' is successfully parsed
                })
                .And(new IsText("CC"));
```
