# Bolt.Common.Extensions

A library containing common extensions methods. Here are the list (Documentation Not  Completed Yet)

## String
* **NullSafe()** - Return a empty string when the string is null

  ``` c-sharp
   var name = null;
   name.NullSafe().ShouldBe(string.Empty);
   "hello".NullSafe().ShouldBe("hello");
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

* **FormatWith(params object[])** - Format string with arguments
 
 ``` c-sharp
 var greetingsTemplate = "Hello {0}!";
 greetingsTemplate.FormatWith("World").ShouldBe("Hello World");
 ```

* **ToSlug(int,bool)** - Generate url friendly version of a string

 ``` c-sharp
 "Hello World--345".ToSlug().ShouldBe("hello-world");
 ```
 
 Based on this resource: http://www.danharman.net/2011/07/18/seo-slugification-in-dotnet-aka-unicode-to-ascii-aka-diacritic-stripping/

* **Description()** - Return the description attribute value of an enum

 ``` c-sharp
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

* **ToInt()** - Convert a string to int?

  ``` c-sharp
  "123".ToInt().ShouldBe(123);
  "Hello".ToInt().ShouldBe(null);
  "Hello".ToInt().NullSafe().ShouldBe(0);
  ```
