# Bolt.Common.Extensions

A library containing common extensions methods. A nuget package also available https://www.nuget.org/packages/Bolt.Common.Extensions/

## Guid

- **ToGuid()** - Convert a string to nullable guid?

  ```c-sharp
  var id = new Guid("58066027-ED5F-4488-818F-9D93E98EDB4C");

  "58066027-ED5F-4488-818F-9D93E98EDB4C".ToGuid().ShouldBe(id);

  "d".ToGuid().IsEmpty().ShouldBe(true);

  ```

- **IsEmpty()** - Return whether a nullable guid is null or empty

  ```c-sharp
  Guid? id = null;
  Guid? emptyId = Guid.Empty;

  id.IsEmpty().ShouldBe(true);
  emptyId.IsEmpty().ShouldBe(true);
  ```

## String

- **NullSafe()** - Return a empty string when the string is null

  ```c-sharp
   var name = null;
   name.NullSafe().ShouldBe(string.Empty);
   "hello".NullSafe().ShouldBe("hello");
  ```

- **IsEmpty()** - Return true when string is null or empty or whitespace

  ```c-sharp
   var name = null;
   name.IsEmpty().ShouldBe(true);
   var name = " ";
   name.IsEmpty().ShouldBe(true);
   var name = "";
   name.IsEmpty().ShouldBe(true);
  ```

- **HasValue()** - Return true when string not null and not empty and not white space

  ```c-sharp
   var name = null;
   name.HasValue().ShouldBe(false);
   var name = " ";
   name.HasValue().ShouldBe(false);
   var name = "";
   name.HasValue().ShouldBe(false);
  ```

- **IsSame(string)** - Compare with another string in case insensitive way

```c-sharp
var greetingsLowerCase = "hello world";
var greetings = "Hello World";
var name = "Ruhul Amin";

greetings.IsSame(greetingsLowerCase).ShouldBe(true);
grretings.IsSame(name).ShouldBe(false);
```

- **IsSameAny(params string[] values)** - return true when any of the supplied value match with source string. comparison done in case insensitive way

```c-sharp
  // match case insesnsitive way
  var sut = "hello";
  var got = sut.IsSameAny("Hello", "test");
  got.ShouldBe(true);

  // no match
  var got = sut.IsSameAny("test", "test2");
  got.ShouldBe(false);

  // null safe
  var sut = null;
  got = sut.IsSameAny("test");
  got.ShouldBe(false);
```

- **IsStartWith(string value)** - check whether a string starts wtih supplied value in case insensitive way

```c-sharp
  // return true as source starts with supplied value
  var sut = "hello world!"
  var got = sut.IsStartWith("HELLO");
  got.ShouldBe(true);

  // return false when source is null
  string sut = null;
  sut.IsStartWith("s").ShouldBe(false);
```

- **IsEndWith(string value)** - Check whether a string ends with supplied value in case insensitive way

  ```c-sharp
  var sut = "hello world";
  sut.IsEndWith("WORLD").ShouldBeTrue();
  ```

- **IsContain(string value)** - check whether a string contains in source string in case insensitive way

  ```c-sharp
  var sut = "Hello World!";
  sut.IsContain("WORLD").ShouldBeTrue();
  ```

- **FormatWith(params object[])** - Format string with arguments

```c-sharp
var greetingsTemplate = "Hello {0}!";
greetingsTemplate.FormatWith("World").ShouldBe("Hello World!");
```

- **ToSlug(int,bool)** - Generate url friendly version of a string

```c-sharp
"Hello World--345".ToSlug().ShouldBe("hello-world-345");
```

Based on this resource: http://www.danharman.net/2011/07/18/seo-slugification-in-dotnet-aka-unicode-to-ascii-aka-diacritic-stripping/

## DateTime

- **ToDateTime()** - Convert a string to nullable datetime

  ```c-sharp
  "2012-04-05".ToDateTime().ShouldBe(new DateTime(2015,04,05));
  "dsfsd".ToDateTime().ShouldBe(null);
  ```
- **ToUtcDateTime()** - Convert a string to UTC datetime. The method assumes the string is formatted as `RoundTripKind (o)`. If the converted datetime not UTC kind then transform to universaltime before return.

  ```c-sharp
  var utcDateFromUtcDateString = "2021-07-10T12:40:21.3389002Z".ToUtcDateTime();
  var utcDateFromLocalDateString = "2021-07-10T22:40:21.3389002+10:00".ToUtcDateTime();
  
  utcDateFromUtcDateString.ShouldBe(utcDateFromLocalString);

  ```
- **FormatAsUtc()** - Format a datetime to utc format `RoundTripKind (o)`. If the supplied datetime kind is not UTC then this function convert the datetime to universal time and then format to stirng

  ```
  var utcDateString = DateTime.UtcNow.FormatAsUtc(); // should print date as format similar to `2021-07-10T12:40:21.3389002Z`
  var localDateString = DateTime.Now.FormatAsUtc(); // should convert the time to Unversal time and then format similar to `2021-07-10T12:40:21.3389002Z`
  ```

## Enumerable

- **NullSafe()** - Return an Enumerable.Empty&lt;T&gt; when collection is null

  ```c-sharp
  IEnumerable<string> values = null;
  values.NullSafe().Count().ShouldBe(0);
  ```

- **IsEmpty()** - Return whether an enumerable is null or empty

  ```c-sharp

  IEnumerable<string> values = null;
  var colors = new List<string>();

  values.IsEmpty().ShouldBe(true);
  colors.IsEmpty().ShouldBe(true);

  ```

- **HasItem()** - Reverse method of IsEmpty()

  ```c-sharp

  IEnumerable<string> values = null;
  var colors = new List<string>();

  values.HasItem().ShouldBe(false);
  colors.HasItem().ShouldBe(false);

  ```

- **ForEach&lt;T&gt;(Action<T>)** - Do something with each element of an collection

  ```c-sharp

  IEnumerable<string> values = null;
  var colors = new []{"Red","Green"};

  values.NullSafe().ForEach(x => Console.WriteLine(x)); // do nothing
  colors.ForEach(color => Console.WriteLine(color)); // print our all colors in collection
  ```

- **Join(IEnumerable&lt;string&gt;, string)** - Join a collection of string with seperator

```c-sharp
  var colors = new []{ "Red", "Green", "Blue" };
  colors.Join(",").ShouldBe("Red,Green,Blue");
```

- **Append&lt;T&gt;(params T[] items)** - add items at end of enumerable

```c-sharp
  var colors = new []{"Red", "Green"};
  colors.Append("Blue"); // colors collection will now have ["Red","Green","Blue"]

```

- **Prepend&lt;T&gt;(params T[] items)** - add items at beginning of enumerable

```c-sharp
  var colors = new []{"Green", "Blue"};
  colors.Append("Red"); // colors collection will now have ["Red","Green","Blue"]

```

## Dictionary

- **NullSafe()** - Return a new instance of dictionary if supplied source is null

  ```c-sharp
  Dictionary<string,string> source = null;
  source.NullSafe().Count.ShouldBe(0);
  ```

- **GetValueOrDefault(TKey key, [TValue defaultValue])** - Return value of the key if exists otherwise return the default(TValue) or supplied default value.

  ```c-sharp
  var source = new Dictionary<string, string> {{"name", "ruhul"}};

  source.TryGetValueOrDefault("name").ShouldBe("ruhul");
  source.TryGetValueOrDefault("postcode").ShouldBe(null);
  source.TryGetValueOrDefault("postcode", "3000").ShouldBe("3000");
  ```

- **Merge(IDictionary<TKey,TValue>)** - Merge a dictionary with another dictionary and return a new dictionary instance

  ```c-sharp
  var source = new Dictionary<string,string>{
    ["one"] = "1"
  }

  var other = new Dictionary<string,string>{
    ["two"] = "2"
  }

  var got = source.Merge(other);
  got.Count.ShouldBe(2);
  got["one"].ShouldBe("1");
  got["two"].ShouldBe("2");
  ```

- **Append(IDictionary<TKey,TValue>)** - Same as merge, difference is Append alter the supplied source dictionary and add new items in source dictionary. Merge method doesn't do any change in source dictionary

  ```c-sharp
  var source = new Dictionary<string,string>{
    ["one"] = "1"
  }

  var other = new Dictionary<string,string>{
    ["two"] = "2"
  }

  _ = source.Append(other);
  source.Count.ShouldBe(2);
  source["one"].ShouldBe("1");
  source["two"].ShouldBe("2");
  ```


## Enum

- **ToEnum&lt;TEnum&gt;** - Convert a string to nulllable enum

  ```c-sharp
  enum Color
  {
    None,
    Red
  }

  "Red".ToEnum<Color>().ShouldBe(Color.Red);
  "Unknown".ToEnum<Color>().ShouldBe(null);
  "Unknown".ToEnum<Color>().NullSafe().ShouldBe(Color.None);
  ```

- **Description()** - Return the description attribute value of an enum

```c-sharp
private enum Color
{
   [System.ComponentModel.Description("Red Color")]
   Red,
   Green,
   Blue
}

var redColor = Color.Red;
var greenColor = Color.Green;

redColor.Description().ShouldBe("Red Color");
greenColor.Description().ShouldBe("Green");
```

## Numeric

- **ToInt()** - Convert a string to nullable int?

  ```c-sharp
  "123".ToInt().ShouldBe(123);
  "Hello".ToInt().ShouldBe(null);
  "Hello".ToInt().NullSafe().ShouldBe(0);
  ```

- **ToDecimal()** - Convert a string to nullable decimal?

  ```c-sharp
  "123.56".ToDecimal().ShouldBe(123.56);
  "Hello".ToDecimal().ShouldBe(null);
  "Hello".ToDecimal().NullSafe().ShouldBe(0);
  ```

- **ToDouble()** - Convert a string to nullable double?

  ```c-sharp
  "123.56".ToDouble().ShouldBe(123.56);
  "Hello".ToDouble().ShouldBe(null);
  "Hello".ToDouble().NullSafe().ShouldBe(0);
  ```

- **ToLong()** - Convert a string to nullable long?

  ```c-sharp
  "123".ToLong().ShouldBe(123);
  "Hello".ToLong().ShouldBe(null);
  "Hello".ToLong().NullSafe().ShouldBe(0);
  ```

- **ToFloat()** - Convert a string to nullable float?

  ```c-sharp
  "1.56".ToFloat().ShouldBe(1.56);
  "Hello".ToFloat().ShouldBe(null);
  "Hello".ToFloat().NullSafe().ShouldBe(0);
  ```

# Null Related

- **NullSafe()** - Return a defult(T) of any struct is null

  ```c-sharp
  Color? value = null;
  value.NullSafe().ShouldBe(Color.None);

  int? value = null;
  value.NullSafe().ShouldBe(0);
  ```

- **NullSafe()** - Return Enumerable.Empty<T> when a enumerable is null. Handy for chaining methods

  ```c-sharp
  string[] values = null;
  values.NullSafe().Count().ShouldBe(0);
  ```

- **NullSafeGet&lt;T&gt;** - Execute an func of a object and return the value. When the object is null return default(T)

  ```c-sharp
  Person p = null;
  p.NullSafeGet(x => x.Name).ShouldBe(null);

  Person p = new Person { Name = "Test Name" };
  p.NullSafeGet(x => x.Name).ShouldBe("Test Name");
  ```

- **NullSafeDo&lt;T&gt;** - Execute an action related to an object. When the object is null do nothing

  ```c-sharp
  Person p = null;
  p.NullSafeDo(x => x.Name = "Mr. {0}".FormatWith(x.Name));
  p.ShouldBeNull();

  Person p = new Person { Name = "Test Name" };
  p.NullSafeDo(x => x.Name = "Mr. {0}".FormatWith(x.Name));
  p.Name.ShouldBe("Mr. Test Name");
  ```

# Task related

- **WrapInTask** - Fluently convert any object to a Complated Task

  ```c-sharp
  public class InMemoryStockProvider : IStockProvider
  {
    public Task<Stock> GetAsync(string id)
    {
      var stock = GetAssetFromMemory(id);

      // instead of writing as
      // Task.FromResult(stock);
      return stock.WrapInTask();
    }
  }
  ```
