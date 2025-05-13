# C# my cook book

## What can you expect? 
In this book are the essectial of C# Net8.0. In each Project is a additinal ReadMe.md with detailed 
description of the topic. 

## Shortcuts
|Shortcut|Method|
|---|---|
|```Shift + Alt + E```|Select entire line|
|```Ctrl + D```|Duplicate current line and insert one below|
|```Shift + F2```| Create a new file (extention important e.g.: .cs)

## nameof()
Instead of hardcoding make sure that the variable name stays correct even if we change
the name:
```
string firstName = "Alice";
if (firstName == null)
    throw new ArgumentNullException(nameof(firstName));
```

Avoid magic strings when accessing member names: 

` var prop = typeof(MyClass).GetProperty(nameof(MyClass.MyProperty)); `

## Nullable
By exploring various approaches, from traditional checks to newer language features and design patterns, 
developers gain the flexibility to tailor their strategies based on specific scenarios. Choosing the right
null-checking method contributes to code readability, maintainability, and overall resilience against 
null reference exceptions.

See code in Basic Concept Project.

## Parallelism, Tasks and Thread
### Comparison of Thread vs Task in C#

| Feature               | Thread                         | Task                            |
|-----------------------|--------------------------------|---------------------------------|
| **Abstraction Level**  | Low-level, manual control      | High-level, abstracted control  |
| **Creation**           | `new Thread()`                 | `Task.Run()` or `Task.Factory`  |
| **Execution**          | Managed by the OS              | Managed by the ThreadPool       |
| **Performance**        | Heavy, expensive for many threads | Lightweight, efficient with many tasks |
| **Concurrency**        | Manually managed               | Automatically scaled by the runtime |
| **Blocking/Async**     | Blocking                       | Non-blocking with `async/await` |
| **Error Handling**     | Manual                         | Built-in exception handling     |
| **Use Case**           | Fine-grained control, real-time | Asynchronous, parallel processing |

### Using asyncronous code correctly
The key advantage fo async/await programming is realized when we have multiple I/O-bound operations happening at
the same time. For example: 

- Handling multiple web requests
- Reading multiple files concurrently
- Making multiple HTTP requests 
- Making multiple database queries 

In the program you only can feel it when we use ```await Task.WhenAll(task1, task2, task3, ...)```, if they are time consuming.

__Some key-points:__ 

- Almost never use blocking statements like: ``Thread.Sleep()``, ``.Wait()``
- ``async void`` doesn't return anything, it is fire-and-forget
- ``async Task`` for the most cases, because we have to await for the result, usually
- ``async Task<T>`` returns the result from the method
- If we want parallelism we can to different tasks and wait for dem parallel with ``await Task.WhenAll()``



__What happends when we ``await`` a task?__
- Current method pauses execution at ``await`` point.
- Thread is freed (befreit) to do other work.
- Once the awaited task completed, the method resumes execution.

### await and not await (fire-and-forget)
When Would You Not Want to Await?
Sometimes, fire-and-forget tasks are intentional. For example:

- Logging asynchronously in the background.
- Running a low-priority operation that doesn't affect the main flow.
- Running independent operations where monitoring completion is unnecessary.
- Send a message to a broker. 

## Performance topics

### Iterate over a ```List<T>()```

If I have a ```List<T>()``` then I have several options to iterate over this collection. If I need the index
each element, then I have 3 main options. I have to consider if the list has a known order and that I need a 
particular element of the list. 

Option 1 - Classic: 
```
for (var i = 0; i < myList.Count; i++) {
	newList1.Add(myList[i] + 1);
}
```

Option 2 - With ``Enumarable.Select`` or ``Enumarable.Zip``: 
```
foreach (var el in myList.Select((value, index) => new { index, value }))
{
	newList2.Add(el.value + 1);
}
```

Option 3 - With index tracking manual: 
```
var index = 0;
foreach (var el in myList.Select((value, index) => new { index, value }))
{
	newList3.Add(myList[index] + 1);
	index++;
}
```

Fastest one according the option number. While classic for loop is 4x - 10x faster then the others. Manual tracking 
is even slower, 2x slower then LINQ version. 

### Take away
Use ``for``: When performance is critical, especially for large lists or in performance-sensitive parts of your application.

Use ``LINQ``: When readability and simplicity matter more than raw performance, especially for small to medium-sized collections.

### 8-ung
_**Modification the In-Place is only possible with for loop! Otherwise I have to create a new List()**__

# System Collections

# LINQ

## .Select => 
Purpose of ``.Select()``  is: 
- Transform data
- Create new Objects: Extract data and reshape data into a new object or type
- Project specific properties: Extract specific fields or properties from complex objects

The original collection doesn't change, it returns a new collection. 


## .editorconfig

The file define a consistent coding style. It can be added for solution or projects.
It is not the same as the global text editor settings in Visual Studio (Tools > Options > TextEditor). 

EditConfig file settings adhere to a file format specification maintained by [EditorConfig.org](https://www.editorconfig.org). 

**Benefit**: Exchangeable for other projects and I can still use my own editor settings. 

