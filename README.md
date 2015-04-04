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
