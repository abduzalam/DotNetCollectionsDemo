# DotNetCollectionsDemo

# What is IEnumerable in C#?

IEnumerable acts as an abstraction over a collection and allows us to iterate over it 
without knowing the actual type of the collection.

The `IEnumerable` interface is the base for all the non-generic collections that can be enumerated.

It exposes a single method `GetEnumerator()`. This method returns a reference to yet another interface `System.Collections.IEnumerator`.

The `IEnumerator` interface in turn provides the ability to iterate through a collection by using the methods `MoveNext()` and `Reset()`, and the property `Current`.
Hence, in order for us to be able to use `ForEach` over a collection, it must implement `IEnumerable`.

# Extension Methods in IEnumerable

The IEnumerable interface includes some extension methods along with the GetEnumerator() method. 

We use deferred execution to implement these methods, so the actual value of the return object is realized only when the object is enumerated either using a ForEach loop or by calling its GetEnumerator() method.

# Cast<TResult>
This method takes a sequence of type IEnumerable and converts all the objects of the given sequence to the type TResult, thus resulting in a return type IEnumerable<TResult>.

The Cast<TResult>() method is a generic method where TResult acts as a placeholder for the actual type we want to work with at compile time. It allows the use of standard LINQ query operators like filtering, sorting, etc. on a non-generic type such as Arraylist:

This is a NUnit test project in the example code below

![image](https://user-images.githubusercontent.com/32676744/224372603-e1fd41c1-a018-41bf-a4ca-9160227123c0.png)

We are able to convert a non-generic collection of type Arraylist into IEnumerable<int>and thus have all its functionalities available.

# OfType<TResult>
This method takes a sequence of type IEnumerable and filters it based on the specified type. It returns only those elements from the input source that can be cast to the type TResult:

![image](https://user-images.githubusercontent.com/32676744/224374357-0c760b99-e148-4889-bafd-cda4a44c1bf4.png)


