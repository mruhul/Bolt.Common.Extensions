# Bolt.Common.Extensions

A library containing common extensions methods. Here are the list (Documentation Not  Completed Yet)

## Guid

* **ToGuid()** - Convert a string to guid
  
  ``` c-sharp
  var id = new Guid("58066027-ED5F-4488-818F-9D93E98EDB4C");

  "58066027-ED5F-4488-818F-9D93E98EDB4C".ToGuid().ShouldBe(id);
  
  "d".ToGuid().IsEmpty().ShouldBe(true);
  
  ```

* **IsEmpty()** - Return whether a nullable guid is null or empty
  
  ``` c-sharp
  Guid? id = null;
  Guid? emptyId = Guid.Empty;
  
  id.IsEmpty().ShouldBe(true);
  emptyId.IsEmpty().ShouldBe(true);
  ``` 

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

* **FormatWith(params object[])** - Format string with arguments
 
 ``` c-sharp
 var greetingsTemplate = "Hello {0}!";
 greetingsTemplate.FormatWith("World").ShouldBe("Hello World!");
 ```

* **ToSlug(int,bool)** - Generate url friendly version of a string

 ``` c-sharp
 "Hello World--345".ToSlug().ShouldBe("hello-world-345");
 ```
Based on this resource: http://www.danharman.net/2011/07/18/seo-slugification-in-dotnet-aka-unicode-to-ascii-aka-diacritic-stripping/

## Enumerable

* **NullSafe()** - Return an Enumerable.Empty&lt;T&gt; when collection is null

  ``` c-sharp
  IEnumerable<string> values = null;
  values.NullSafe().Count().ShouldBe(0);
  ```

* **IsEmpty()** - Return whether an enumerable is null or empty

  ``` c-sharp
  
  IEnumerable<string> values = null;
  var colors = new List<string>();
  
  values.IsEmpty().ShouldBe(true);
  colors.IsEmpty().ShouldBe(true);
  
  ```
  
* **HasItem()** - Reverse method of IsEmpty()

  ``` c-sharp
  
  IEnumerable<string> values = null;
  var colors = new List<string>();
  
  values.HasItem().ShouldBe(false);
  colors.HasItem().ShouldBe(false);
  
  ``` 
  
* **ForEach&lt;T&gt;(Action<T>)** - Do something with each element of an collection

  ``` c-sharp
  
  IEnumerable<string> values = null;
  var colors = new []{"Red","Green"};
  
  values.NullSafe().ForEach(x => Console.WriteLine(x)); // do nothing
  colors.ForEach(color => Console.WriteLine(color)); // print our all colors in collection
  ```   

* **Join(IEnumerable&lt;string&gt;, string)** - Join a collection of string with seperator 
 
 ``` c-sharp
 var colors = new []{ "Red", "Green", "Blue" };
 colors.Join(",").ShouldBe("Red,Green,Blue");
 ```

## Enum

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

* **ToInt()** - Convert a string to nullable int?

  ``` c-sharp
  "123".ToInt().ShouldBe(123);
  "Hello".ToInt().ShouldBe(null);
  "Hello".ToInt().NullSafe().ShouldBe(0);
  ```
  
* **ToDecimal()** - Convert a string to nullable decimal?

  ``` c-sharp
  "123.56".ToDecimal().ShouldBe(123.56);
  "Hello".ToDecimal().ShouldBe(null);
  "Hello".ToDecimal().NullSafe().ShouldBe(0);
  ```  
* **ToDouble()** - Convert a string to nullable double?

  ``` c-sharp
  "123.56".ToDouble().ShouldBe(123.56);
  "Hello".ToDouble().ShouldBe(null);
  "Hello".ToDouble().NullSafe().ShouldBe(0);
  ```  

* **ToLong()** - Convert a string to nullable long?

  ``` c-sharp
  "123".ToLong().ShouldBe(123);
  "Hello".ToLong().ShouldBe(null);
  "Hello".ToLong().NullSafe().ShouldBe(0);
  ```  

* **ToFloat()** - Convert a string to nullable float?

  ``` c-sharp
  "1.56".ToFloat().ShouldBe(1.56);
  "Hello".ToFloat().ShouldBe(null);
  "Hello".ToFloat().NullSafe().ShouldBe(0);
  ```  
