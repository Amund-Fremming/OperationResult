# Operation Result Pattern

## Purpose
This pattern serves as an alternative to throwing exceptions for handling expected or non-critical errors, 
reducing unnecessary CPU overhead. Instead of relying on exceptions for flow control,
OperationResult<T> allows you to communicate operation results (data, messages, and exceptions)
in a more structured and efficient way.

## Key Benefits
1. Improved Performance: Throwing exceptions incurs a CPU cost, particularly in high-throughput applications where exceptions can degrade performance. OperationResult<T> avoids this by providing a lightweight way to signal success or failure.
2. Enhanced Readability and Maintainability: Using OperationResult<T> makes code flow more intuitive, as it’s clear when an operation succeeded or failed. Methods return a result directly, making it easier for developers to handle the outcome in a structured manner and avoiding null checks.
3. Better User and Developer Experience: This pattern provides meaningful error messages and structured results, giving both end-users and upstream services clear feedback on what went wrong. 

## Usage
We use this wrapper when we catch an exception, we want to return a successful result or we are handling results from a layer that this as a return type.

**On success**
```C#
return OperationResult<T>.Success(data);
```

**On failure**
```C#
try 
{ ... }
catch(Exception)
{
	return OperationResult<T>.Failure("Error message for end user", exception);
}
```

**When calling a function returning `OperationResult`**
```C#
OperationResult<T> result = _service.DoSomething();
if(!result.IsSuccess)
	return OperationResult<T>.Failure(result.Message, result.Exception);

var data = result.Data;
```
