# Operation Engine

This framework offers a simple approach of instantiating and executing Sub Use Case logic which are, usually, needed to be executed from multiple Use Cases.

## How it came to be?

### The Need

When implementing Use Cases (Commands and Queries), there will be, eventually, a need to extract and reuse parts of one use case in other use cases.

### The "Simple" Solution

The simplest approach is to extract the shared logic into a new class and use it across all relevant Use Cases:

- Instantiate the class;
- Set its properties;
- Call the `Execute()` method (or a similarly named method)

I call this class an Operation.

### The Problem

One recurring issue I've encountered is that these Operation classes often require dependencies from the Dependency Container. This means the parent class (which instantiates the Operation) must also have those same dependencies injected into its constructor to pass them to the Operation. This creates unnecessary transitive dependencies in the parent class that it doesn't actually use—an undesirable approach.

### The "Complete" Solution

I have decided to create a Manager class that exposes methods for executing Operations. The Manager uses a Factory class to create these Operations. The Factory provides the necessary dependencies to each Operation when it's instantiated, typically using a dependency injection framework such as Autofac, Ninject, or Microsoft Dependency Injection behind the scenes.
