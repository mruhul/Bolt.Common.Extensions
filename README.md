# Bolt.Common.Extensions

A library containing common extensions methods. Here are the list

## String
* **NullSafe()** - Return a empty string when the string is null

  ``` c-sharp
   var name = null;
   name.NullSafe().ShouldBe(string.Empty);
  ```
* **IsEmpty()** - Return true when string is null or empty or whitespace

  ``` c-sharp
   var name = null;
   name.IsEmpty().ShouldBe(true);
   var name = " ";
   name.IsEmpty().ShouldBe(true);
   var name = "";
   name.IsEmpty().ShouldBe(true);   
  ```
* **HasValue()** - Return true when string not null and not empty and not white space

  ``` c-sharp
   var name = null;
   name.HasValue().ShouldBe(false);
   var name = " ";
   name.HasValue().ShouldBe(false);
   var name = "";
   name.HasValue().ShouldBe(false);   
  ```
* **IsSame(string)** - Compare with another string in case insensitive way
 ``` c-sharp
 var greetingsLowerCase = "hello world";
 var greetings = "Hello World";
 var name = "Ruhul Amin";
 
 greetings.IsSame(greetingsLowerCase).ShouldBe(true);
 grretings.IsSame(name).ShouldBe(false);
 ```
* **Join(IEnumerable<string>, string)** - Join a collection of string with seperator 
 ``` c-sharp
 var colors = new []{ "Red", "Green", "Blue" };
 colors.Join(",").ShouldBe("Red,Green,Blue");
 ```



