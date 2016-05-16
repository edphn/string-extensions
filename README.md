StringExtensions
=================

StringExtensions is a small pack of methods that provides better and more readable
way of manipulating strings in C#. This class is highly inspired by great library
for PHP - [Stringy](https://github.com/danielstjules/Stringy) by Daniel St. Jules.

## Methods

##### Between(string startDelimiter, string endDelimiter, [int offset = 0])

Returns substring found between start and end delimiters.

```csharp
"A description of {foo} goes here".Between("{", "}") // "foo"
```

##### Camelize()

Returns a copy of this string in camelCase version. Trims surrounding
spaces, capitalizes letters following digits, spaces, dashes and
underscores, and removes spaces, dashes, as well as underscores.

```csharp
"CamelCase".Camelize(); // "camelCase"
```

##### CollapseWhitespace()

Returns new trimmed string with replaced consecutive whitespace
characters with a single space (including tabs and newline characters).

```csharp
"  foo   bar  ".CollapseWhitespace(); // "foo bar"
```

##### CountSubstring(string substring, [caseSensitive = true])

Counts occurencies of given substring.

```csharp
"foo bar".CountSubstring("foo"); // 1
```

##### Dasherize()

Returns a copy of this string in dash-case version. Trims surrounding
spaces, dashes and underscores. Dashes are inserted before capital
letters and in place of spaces and underscores.

```csharp
"testCase".Dasherize(); // "test-case"
```

##### Delimit(string delimiter)

Returns a copy of this string delimited by given delimiter. Trims
surrounding spaces, dashes and underscores. Delimiters are inserted
before capital letters and in place of spaces, dashes and underscores.

```csharp
"test case".Delimit("#"); // "test#case"
```

##### EnsureLeft(string substring)

Ensures that the string begins with given substring. If it does not,
then returns a new string in which a specified string is inserted at
the very first position.

```csharp
"http://foobar".EnsureLeft("http://"); // "http://foobar"
"foobar".EnsureLeft("http://"); // "http://foobar"
```

##### EnsureRight(string substring)

Ensures that the string ends with given substring. If it does not,
then returns a new string in which a specified string is inserted at
the very last position.

```csharp
"foobar.com".EnsureRight(".com"); // "foobar.com"
"foobar".EnsureRight(".com"); // "foobar.com"
```

##### FirstCharacters(int numberOfCharacters)

Returns the first n characters of this string.

```csharp
"foo bar".FirstCharacters(3); // "foo"
```

##### HasLower()

Determines whether the string contains any lowercase character.

```csharp
"foobar".HasLower(); // true
"FOOBAR".HasLower(); // false
```

##### HasUpper()

Determines whether the string contains any uppercase characters.

```csharp
"Foo bar".HasUpper(); // true
"foo bar".HasUpper(); // false
```

##### IsAlpha()

Determines whether the string contains only alphabetic characters.

```csharp
"foobar".IsAlpha(); // true
"foobar2".IsAlpha(); // false
```

##### IsAlphanumeric()

Determines whether the string contains only alphanumeric characters.

```csharp
"foobar1".IsAlphanumeric(); // true
```

##### IsLower()

Determines whether the string contains only lowercase characters.

```csharp
"foobar".IsLower(); // true
```

##### IsUpper()

Determines whether the string contains only uppercase characters.

```csharp
"FOOBAR".IsUpper(); // true
```

##### LastCharacters(int numberOfCharacters)

Returns the last n characters of this string.

```csharp
"foo bar".LastCharacters(3); // "bar"
```

##### Pascalize()

Returns a copy of this string in PascalCase version. Trims surrounding
spaces, capitalizes letters following digits, spaces, dashes and
underscores, and removes spaces, dashes, as well as underscores.

```csharp
"camelCase".Pascalize(); // "CamelCase"
```

##### RemoveLeft(string substring)

Returns a copy of this string with removed substring from the left side
(if it exists).

```csharp
"foo bar".RemoveLeft("f"); // "oo bar"
```

##### RemoveRight(string substring)

Returns a copy of this string with removed substring from the right side
(if it exists).

```csharp
"foo bar".RemoveRight("r"); // "foo ba"
```

##### Repeat(int numberOfRepetitions)

Returns a repeated string.

```csharp
"foo".Repeat(2)); // "foofoo"
```

##### Shuffle()

Returns a copy of this string with shuffled characters.

```csharp
"foobar".Shuffle(); // "robaof"
```

##### Surround(string substring)

Returns a copy of this string surrounded by given substring.

```csharp
"foobar".Surround("__"); // "__foobar__"
```

##### SwapCase()

Returns a copy of this string with swapped case.

```csharp
"testCase".SwapCase(); // "TESTcASE"
```

##### Titleize(string[] ignoredWords = null)

Returns a copy of this string in Title Case version. Capitalizes
first letter of each word unless word is specified in ignored array,
inserts spaces in place of dashes and underscores, trims surrounding
spaces, dashes, as well as underscores.

```csharp
"TITLE CASE".Titleize(); // "Title Case"
"testing the method".Titleize(new[] { "the" }); // "Testing the Method"
```

##### ToBoolean()

Returns a boolean representation of the given logical string value. True
value is evaluated for "yes", "on", "true" (including uppercase versions)
and all numbers greater than 0. Rest options is evaluated into false.

```csharp
"true".ToBoolean(); // true
"1".ToBoolean(); // true
"on".ToBoolean(); // true
"yes".ToBoolean(); // true
"999".ToBoolean(); // true
"false".ToBoolean(); // false
"0".ToBoolean(); // false
"off".ToBoolean(); // false
```

##### ToLowerFirst()

Returns a copy of this string with first character converted to lowercase.

```csharp
"Test".ToLowerFirst(); // "test"
```

##### ToUpperFirst()

Returns a copy of this string with first character converted to uppercase.

```csharp
"test".ToUpperFirst(); // "Test"
```

##### Truncate(int length, string substring = "")

Returns new string, truncated to a given length. If substring is provided, and
truncating occurs, the string is further truncated so that the substring
may be appended without exceeding the desired length.

```csharp
"Test foo bar".Truncate(4); // "Test"
"Test foo bar".Truncate(12, "..."); // "Test foo bar"
"Test foo bar".Truncate(11, "..."); // "Test foo..."
```

##### Underscorize()

Returns a copy of this string in underscore_case version. Trims
surrounding spaces, dashes and underscores. Underscores are inserted
before capital letters and in place of spaces and underscores.

```csharp
"testCase".Underscorize(); // "test_case"
```

## License

Released under the MIT License - see `LICENSE` for details.
